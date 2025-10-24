using DemoNganHangNCB.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoNganHangNCB.Services
{
    public class TraCuuService
    {
        private readonly VirtualWebService _virtualWebService;
        private const string BaseUrl = "https://www.ncb-bank.vn";

        public TraCuuService(VirtualWebService virtualWebService)
        {
            _virtualWebService = virtualWebService;
        }

        public async Task<Account?> LayThongTinTaiKhoanAsync()
        {
            var url = $"{BaseUrl}/IziBankBiz/Corp/corporate-gateway-server/corporate-account-service/account/debits";

            var headers = new Dictionary<string, string>
            {
                ["Authorization"] = $"Bearer {AppState.AccessToken}"
            };

            string responseText = await _virtualWebService.GuiRequestAsync(
                url,
                method: "GET",
                headers: headers
            );

            if (string.IsNullOrWhiteSpace(responseText) || responseText.StartsWith("<"))
                throw new Exception("Phản hồi không hợp lệ hoặc bị Cloudflare chặn.");

            JObject json;
            try
            {
                json = JObject.Parse(responseText);
            }
            catch
            {
                throw new Exception("Không thể phân tích phản hồi JSON từ server.");
            }

            // Trường hợp token hết hạn hoặc không hợp lệ
            if (json["error"]?.ToString() == "invalid_token")
            {
                return null; // báo cho caller biết cần đăng nhập lại
            }

            int code = json["code"]?.Value<int>() ?? 0;
            if (code != 200)
            {
                throw new Exception(json["message"]?.ToString() ?? "Yêu cầu thất bại.");
            }

            // Lấy dữ liệu tài khoản
            var dataArray = json["data"] as JArray;
            if (dataArray == null || dataArray.Count == 0)
                throw new Exception("Không có dữ liệu tài khoản.");

            var firstItem = dataArray.First;
            var account = new Account
            {
                accountNo = firstItem["accountNo"]?.ToString(),
                accountName = firstItem["accountName"]?.ToString(),
                accountType = firstItem["accountType"]?.ToString(),
                currency = firstItem["currency"]?.ToString(),
                balance = firstItem["balance"]?.ToString(),
                status = firstItem["status"]?.ToString(),
                openDate = firstItem["openDate"]?.Type == JTokenType.Null
                    ? DateTime.MinValue
                    : firstItem["openDate"]!.Value<DateTime>()
            };

            AppState.account = account;
            return account;
        }
    }
}
