using DemoNganHangNCB.Models;
using Newtonsoft.Json;
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

        public async Task<List<Account>?> LayThongTinTaiKhoanAsync()
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

            var Items = dataArray;
            List<Account> accounts = new List<Account>();
            foreach (var item in Items) 
            {
                var account = new Account
                {
                    accountNo = item["accountNo"]?.ToString(),
                    accountName = item["accountName"]?.ToString(),
                    accountType = item["accountType"]?.ToString(),
                    currency = item["currency"]?.ToString(),
                    balance = item["balance"]?.ToString(),
                    status = item["status"]?.ToString(),
                    openDate = item["openDate"]?.Type == JTokenType.Null
                 ? DateTime.MinValue
                 : item["openDate"]!.Value<DateTime>()
                };
                accounts.Add(account);
            }
            AppState.account = accounts[0];
            return accounts;
        }

        public async Task<ModelLenhCK<LenhCKThuong>?>TraCuuDanhSachLenhThuong(string type)
        {
            //Trong ngày APPROVED
            //Chờ xử lý WAITING

            var url =
                $"{BaseUrl}/IziBankBiz/Corp/corporate-gateway-server/corporate-account-service/approval" +
                $"?type={type}" +
                $"&size=65535" ;

            var headers = new Dictionary<string, string>
            {
                ["Authorization"] = $"Bearer {AppState.AccessToken}"
            };

            // Gửi request qua Playwright context
            string responseText = await _virtualWebService.GuiRequestAsync(
                url,
                method: "GET",
                headers: headers
            );

            if (string.IsNullOrWhiteSpace(responseText) || responseText.StartsWith("<"))
                throw new Exception("Phản hồi không hợp lệ hoặc bị Cloudflare chặn.");

            JObject json = JObject.Parse(responseText);

            // Trường hợp token hết hạn hoặc không hợp lệ
            if (json["error"]?.ToString() == "invalid_token")
            {
                return null; // báo cho caller biết cần đăng nhập lại
            }
            var model = JsonConvert.DeserializeObject<ModelLenhCK<LenhCKThuong>>(responseText);

            if (model?.data?.content == null)
                return new ModelLenhCK<LenhCKThuong>();

            return model;

        }

        public async Task<ModelLenhCK<LenhCKChiTiet>?> TraCuuDanhSachLenhChiTiet(string type, string? page)
        {
            
            var url =
                $"{BaseUrl}/IziBankBiz/Corp/corporate-gateway-server/corporate-fund-transfer-service/transaction/search" +
                $"?type={type}";
            if(page != null)
            {
                url += $"&page={page}";
            }
            var headers = new Dictionary<string, string>
            {
                ["Authorization"] = $"Bearer {AppState.AccessToken}"
            };

            // Gửi request qua Playwright context
            string responseText = await _virtualWebService.GuiRequestAsync(
                url,
                method: "GET",
                headers: headers
            );

            if (string.IsNullOrWhiteSpace(responseText) || responseText.StartsWith("<"))
                throw new Exception("Phản hồi không hợp lệ hoặc bị Cloudflare chặn.");

            JObject json = JObject.Parse(responseText);

            // Trường hợp token hết hạn hoặc không hợp lệ
            if (json["error"]?.ToString() == "invalid_token")
            {
                return null; // báo cho caller biết cần đăng nhập lại
            }
            var model = JsonConvert.DeserializeObject<ModelLenhCK<LenhCKChiTiet>>(responseText);

            if (model?.data?.content == null)
                return new ModelLenhCK<LenhCKChiTiet>();

            return model;
        }
    }
}
