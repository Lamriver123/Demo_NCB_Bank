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
    public class AuthService
    {
        private readonly VirtualWebService _guiYeuCau;

        public AuthService(VirtualWebService guiYeuCau)
        {
            _guiYeuCau = guiYeuCau ?? throw new ArgumentNullException(nameof(guiYeuCau));
        }

        public async Task<MessageResult> LoginAndGetTokenAsync(string username, string password)
        {
            // Đảm bảo trình duyệt/context đã khởi tạo
            await _guiYeuCau.InitializeAsync();

            // chuẩn bị body và headers để gửi từ browser
            var formDataJs = $@"
                (() => {{
                    const form = new FormData();
                    form.append('username', '{EscapeForJs(username)}');
                    form.append('password', '{EscapeForJs(password)}');
                    form.append('grant_type', 'password');
                    form.append('grant_service', 'IB');
                    form.append('grant_client', '{EscapeForJs(AppState.grant_client ?? "")}');
                    form.append('grant_device', '{EscapeForJs(AppState.grant_device ?? "")}');
                    return form;
                }})()
            ";

            var headers = new Dictionary<string, string>
            {
                ["Accept"] = "application/json, text/plain, */*",
                ["Authorization"] = "Basic amF2YWRldmVsb3BlcnpvbmU6c2VjcmV0",
                ["x-device-id"] = AppState.grant_device ?? "",
                ["x-device-name"] = "Windows 10",
                ["Referer"] = "https://www.ncb-bank.vn/IziBankBiz/Corp/dang-nhap?redirectURL=%2Fhome"
            };

            // gửi request qua GuiYeuCauService
            string text = await _guiYeuCau.GuiRequestAsync(
                "https://www.ncb-bank.vn/IziBankBiz/Corp/corporate-gateway-server/oauth/token",
                method: "POST",
                headers: headers,
                bodyJs: formDataJs
            );

            if (string.IsNullOrWhiteSpace(text) || text.TrimStart().StartsWith("<"))
            {
                return new MessageResult
                {
                    IsSuccess = false,
                    ErrorCode = "HTML_RESPONSE",
                    Message = "Phản hồi không phải JSON — có thể Cloudflare chặn hoặc server trả HTML."
                };
            }

            JObject json;
            try
            {
                json = JObject.Parse(text);
            }
            catch
            {
                return new MessageResult
                {
                    IsSuccess = false,
                    ErrorCode = "INVALID_JSON",
                    Message = "Không parse được JSON trả về từ server."
                };
            }

            // 🔹 Phân loại phản hồi lỗi
            if (json["error"] != null)
            {
                string errorDesc = json["error_description"]?.ToString();

                switch (errorDesc)
                {
                    case "NCBLOGIN-9":
                        return new MessageResult
                        {
                            IsSuccess = false,
                            ErrorCode = "NCBLOGIN-9",
                            Message = "Sai tên đăng nhập hoặc mật khẩu\nNếu sai quá 5 lần tài khoản sẽ bị khóa"
                        };

                    case "NCBLOGIN-14":
                        return new MessageResult
                        {
                            IsSuccess = false,
                            ErrorCode = "NCBLOGIN-14",
                            Message = "Thiết bị mới — cần xác thực OTP."
                        };

                    default:
                        return new MessageResult
                        {
                            IsSuccess = false,
                            ErrorCode = errorDesc,
                            Message = "Đăng nhập thất bại: " + errorDesc
                        };
                }
            }

            // 🔹 Đăng nhập thành công
            string accessToken = json["access_token"]?.ToString();
            string refreshToken = json["refresh_token"]?.ToString();

            if (string.IsNullOrEmpty(accessToken))
            {
                return new MessageResult
                {
                    IsSuccess = false,
                    ErrorCode = "NO_TOKEN",
                    Message = "Không nhận được access_token từ server."
                };
            }

            AppState.AccessToken = accessToken;
            AppState.RefreshToken = refreshToken;

            return new MessageResult
            {
                IsSuccess = true,
                ErrorCode = null,
                Message = "Đăng nhập thành công!"
            };
        }

        private static string EscapeForJs(string s)
        {
            if (s == null) return "";
            return s.Replace("\\", "\\\\").Replace("'", "\\'").Replace("\r", "\\r").Replace("\n", "\\n");
        }
    }
}
