using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DemoNganHangNCB.Services
{
    public class VirtualWebService : IAsyncDisposable
    {
        private IPlaywright _playwright;
        private IBrowser _browser;
        private IBrowserContext _context;
        private IPage _page;
        private readonly SemaphoreSlim _pageLock = new SemaphoreSlim(1, 1);
        private bool _initialized = false;

        // cấu hình khởi tạo (headless hay off-screen)
        private readonly bool _headless;
        private readonly bool _useOffscreen; // nếu true sẽ cố gắng minimize/đẩy cửa sổ ra ngoài

        public VirtualWebService(bool headless = true, bool useOffscreen = false)
        {
            _headless = headless;
            _useOffscreen = useOffscreen;
        }

        public IPage Page => _page;

        public async Task InitializeAsync()
        {
            if (_initialized) return;

            Environment.SetEnvironmentVariable("PLAYWRIGHT_BROWSERS_PATH", ".playwright");
            _playwright = await Playwright.CreateAsync();

            var launchArgs = new List<string> { "--disable-blink-features=AutomationControlled" };
            if (_useOffscreen)
            {
                // đẩy cửa sổ ra ngoài màn hình / minimize (Windows)
                launchArgs.Add("--start-minimized");
                launchArgs.Add("--window-position=-32000,-32000");
            }

            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = _headless,
                Args = launchArgs.ToArray()
            });

            _context = await _browser.NewContextAsync(new BrowserNewContextOptions
            {
                UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) " +
                            "AppleWebKit/537.36 (KHTML, like Gecko) " +
                            "Chrome/118.0.0.0 Safari/537.36",
                Locale = "vi-VN",
                ViewportSize = new ViewportSize { Width = 1280, Height = 720 }
            });

            // Spoof cơ bản để giảm detect (tùy chọn)
            await _context.AddInitScriptAsync(@"() => {
                try {
                    Object.defineProperty(navigator, 'webdriver', { get: () => false });
                    Object.defineProperty(navigator, 'languages', { get: () => ['vi-VN', 'vi', 'en-US'] });
                    window.chrome = window.chrome || { runtime: {} };
                } catch (e) {}
            }");

            _page = await _context.NewPageAsync();

            // load trang để Cloudflare cấp cookie clearance nếu cần
            await _page.GotoAsync("https://www.ncb-bank.vn/IziBankBiz/Corp/dang-nhap?redirectURL=%2Fhome");
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await Task.Delay(1000);

            _initialized = true;
        }

        private async Task EnsureInitializedAsync()
        {
            if (!_initialized) await InitializeAsync();
        }

        /// <summary>
        /// Gửi HTTP request từ trong context trình duyệt bằng fetch.
        /// Trả về raw response text.
        /// </summary>
        /// <param name="url">Full url</param>
        /// <param name="method">GET/POST/PUT/DELETE</param>
        /// <param name="headers">header dictionary</param>
        /// <param name="bodyJs">nếu đã có body là JSON string (đã escape), truyền null nếu không</param>
        public async Task<string> GuiRequestAsync(string url, string method = "GET",
            Dictionary<string, string> headers = null, string bodyJs = null)
        {
            await EnsureInitializedAsync();

            // build JS header literal
            string headersJs = "{}";
            if (headers != null && headers.Count > 0)
            {
                var pairs = headers.Select(kv => $"'{EscapeJs(kv.Key)}':'{EscapeJs(kv.Value)}'");
                headersJs = "{" + string.Join(",", pairs) + "}";
            }

            string bodyDeclaration = bodyJs != null ? $"const body = {bodyJs};" : "const body = null;";

            string js = $@"
                async () => {{
                    {bodyDeclaration}
                    const opts = {{
                        method: '{method.ToUpper()}',
                        headers: {headersJs},
                        credentials: 'include'
                    }};
                    if (body) opts.body = body;
                    const res = await fetch('{EscapeJs(url)}', opts);
                    return await res.text();
                }}";

            await _pageLock.WaitAsync();
            try
            {
                var text = await _page.EvaluateAsync<string>(js);
                return text;
            }
            finally
            {
                _pageLock.Release();
            }
        }

        public async Task<string> GuiRequestSerializeAsync(string url, string method = "GET",
            Dictionary<string, string> headers = null, string bodyJs = null)
        {
            await EnsureInitializedAsync();

            // build JS header literal
            string headersJs = "{}";
            if (headers != null && headers.Count > 0)
            {
                var pairs = headers.Select(kv => $"'{EscapeJs(kv.Key)}':'{EscapeJs(kv.Value)}'");
                headersJs = "{" + string.Join(",", pairs) + "}";
            }

            string bodyDeclaration = bodyJs != null? $"const body = JSON.stringify({bodyJs});": "const body = null;";


            string js = $@"
                async () => {{
                    {bodyDeclaration}
                    const opts = {{
                        method: '{method.ToUpper()}',
                        headers: {headersJs},
                        credentials: 'include'
                    }};
                    if (body) opts.body = body;
                    const res = await fetch('{EscapeJs(url)}', opts);
                    return await res.text();
                }}";

            await _pageLock.WaitAsync();
            try
            {
                var text = await _page.EvaluateAsync<string>(js);
                return text;
            }
            finally
            {
                _pageLock.Release();
            }
        }

        /// <summary>
        /// Lấy cookie header hiện tại (dạng "k=v; k2=v2")
        /// </summary>
        public async Task<string> GetCookieHeaderAsync()
        {
            await EnsureInitializedAsync();
            var cookies = await _context.CookiesAsync();
            return string.Join("; ", cookies.Select(c => $"{c.Name}={c.Value}"));
        }

        private static string EscapeJs(string s)
        {
            if (s == null) return "";
            return s.Replace("\\", "\\\\").Replace("'", "\\'").Replace("\r", "\\r").Replace("\n", "\\n");
        }

        public async ValueTask DisposeAsync()
        {
            try
            {
                try { if (_page != null) await _page.CloseAsync(); } catch { }
                try { if (_context != null) await _context.CloseAsync(); } catch { }
                try { if (_browser != null) await _browser.CloseAsync(); } catch { }
                _playwright?.Dispose();
            }
            catch { /* ignore */ }
            finally
            {
                _initialized = false;
            }
        }
    }
}
