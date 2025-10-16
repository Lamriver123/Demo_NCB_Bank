using DemoNganHangNCB.Models;
using Microsoft.Playwright;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DemoNganHangNCB.Services
{
    public class AuthService : IAsyncDisposable
    {
        private const string BaseUrl = "https://www.ncb-bank.vn";

        // reusable Playwright objects
        private IPlaywright _playwright;
        private IBrowser _browser;
        private IBrowserContext _context;
        private IPage _page;

        // simple sync to prevent concurrent page.Evaluate calls
        private readonly SemaphoreSlim _pageLock = new SemaphoreSlim(1, 1);

        // flag init
        private bool _initialized = false;

        // cấu hình tái sử dụng
        private readonly bool _headless;

        public AuthService(bool headless = true)
        {
            _headless = headless;
        }

        // Khởi tạo Playwright + Browser + Context + Page (gọi 1 lần)
        public async Task InitializeAsync()
        {
            if (_initialized) return;

            _playwright = await Playwright.CreateAsync();

            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = _headless,
                Args = new[]
                {
                    "--disable-blink-features=AutomationControlled",
                    "--no-sandbox",
                    "--disable-gpu",
                    "--start-minimized",               // cố gắng minimize khi mở
                    "--window-position=-32000,-32000"  // đẩy cửa sổ ra ngoài màn hình (Windows)
                }
            });

            _context = await _browser.NewContextAsync(new BrowserNewContextOptions
            {
                UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/118.0.0.0 Safari/537.36",
                Locale = "vi-VN",
                ViewportSize = new ViewportSize { Width = 1280, Height = 720 }
            });

            _page = await _context.NewPageAsync();

            // load trang để Cloudflare set cookie / clearance
            await _page.GotoAsync($"{BaseUrl}/IziBankBiz/Corp/dang-nhap?redirectURL=%2Fhome");
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);

            _initialized = true;
        }

        // Kiểm tra nếu chưa init thì init
        private async Task EnsureInitializedAsync()
        {
            if (!_initialized)
                await InitializeAsync();
        }

        // login và trả token (không đóng browser)
        public async Task<AuthResult> LoginAndGetTokenAsync(string username, string password)
        {
            await EnsureInitializedAsync();

            // lock để tránh nhiều call cùng lúc
            await _pageLock.WaitAsync();
            try
            {
                // build JS để gửi form multipart từ trong trình duyệt
                var js = $@"
                    async () => {{
                        const form = new FormData();
                        form.append('username', '{EscapeForJs(username)}');
                        form.append('password', '{EscapeForJs(password)}');
                        form.append('grant_type', 'password');
                        form.append('grant_service', 'IB');
                        form.append('grant_client', '{EscapeForJs(AppState.grant_client ?? "")}');
                        form.append('grant_device', '{EscapeForJs(AppState.grant_device ?? "")}');

                        const res = await fetch('{BaseUrl}/IziBankBiz/Corp/corporate-gateway-server/oauth/token', {{
                            method: 'POST',
                            headers: {{
                                'Accept': 'application/json, text/plain, */*',
                                'Authorization': 'Basic amF2YWRldmVsb3BlcnpvbmU6c2VjcmV0',
                                'x-device-id': '{EscapeForJs(AppState.grant_device ?? "")}',
                                'x-device-name': 'Windows 10',
                                'Referer': '{BaseUrl}/IziBankBiz/Corp/dang-nhap?redirectURL=%2Fhome'
                            }},
                            body: form,
                            credentials: 'include'
                        }});
                        const text = await res.text();
                        return text;
                    }}";

                // Gửi fetch từ trong page (sử dụng context + TLS của Chromium)
                var responseBody = await _page.EvaluateAsync<string>(js);

                // nếu server trả HTML (Cloudflare), responseBody sẽ bắt đầu bằng '<!DOCTYPE html>' hoặc 'Access denied'
                if (string.IsNullOrWhiteSpace(responseBody) || responseBody.TrimStart().StartsWith("<"))
                {
                    return new AuthResult
                    {
                        IsSuccess = false,
                        Message = "Phản hồi không phải JSON — có thể Cloudflare chặn hoặc server trả trang HTML."
                    };
                }

                JObject json;
                try
                {
                    json = JObject.Parse(responseBody);
                }
                catch (Exception)
                {
                    return new AuthResult
                    {
                        IsSuccess = false,
                        Message = "Không parse được JSON trả về từ server."
                    };
                }

                string accessToken = json["access_token"]?.ToString();
                string refreshToken = json["refresh_token"]?.ToString();

                if (string.IsNullOrEmpty(accessToken))
                {
                    return new AuthResult
                    {
                        IsSuccess = false,
                        Message = "Không tìm thấy access_token trong phản hồi."
                    };
                }

                AppState.AccessToken = accessToken;
                AppState.RefreshToken = refreshToken;

                return new AuthResult
                {
                    IsSuccess = true,
                    Message = "Đăng nhập thành công!"
                };
            }
            finally
            {
                _pageLock.Release();
            }
        }

        // Lấy cookie hiện tại (string) — để debug hoặc gửi ra client khác
        public async Task<string> GetCookieHeaderAsync()
        {
            await EnsureInitializedAsync();
            var cookies = await _context.CookiesAsync();
            return string.Join("; ", cookies.Select(c => $"{c.Name}={c.Value}"));
        }

        // Helper: kiểm tra cf_clearance tồn tại hay không
        public async Task<bool> HasCfClearanceAsync()
        {
            await EnsureInitializedAsync();
            var cookies = await _context.CookiesAsync();
            return cookies.Any(c => c.Name.Equals("cf_clearance", StringComparison.OrdinalIgnoreCase));
        }

        // Đóng browser khi bạn muốn (ví dụ khi app shutdown)
        public async ValueTask DisposeAsync()
        {
            try
            {
                if (_page != null) await _page.CloseAsync();
                if (_context != null) await _context.CloseAsync();
                if (_browser != null) await _browser.CloseAsync();
                _playwright?.Dispose();
            }
            catch { /* ignore */ }
        }

        // Escape chuỗi để an toàn chèn vào JS string
        private static string EscapeForJs(string s)
        {
            if (s == null) return "";
            return s.Replace("\\", "\\\\").Replace("'", "\\'").Replace("\r", "\\r").Replace("\n", "\\n");
        }
    }
}
