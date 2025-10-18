using DemoNganHangNCB.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNganHangNCB.Services
{
    public class BankingService
    {
        private readonly VirtualWebService _virtualWebService;
        private const string BaseUrl = "https://www.ncb-bank.vn";

        public BankingService(VirtualWebService virtualWebService)
        {
            _virtualWebService = virtualWebService;
        }

        public async Task<List<Bank>?> GetListBank()
        {
            var url = $"{BaseUrl}/IziBankBiz/Corp/corporate-gateway-server/corporate-fund-transfer-service/transfer/list-bank";

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

            JObject json = JObject.Parse(responseText);
            int code = json["code"]?.Value<int>() ?? 0;

            // 🟡 Hết hạn đăng nhập (token hết hiệu lực)
            if (code == 401)
                return null;

            if (code != 200)
                throw new Exception(json["message"]?.ToString() ?? "Yêu cầu thất bại.");

            var dataArray = json["data"] as JArray;
            if (dataArray == null || dataArray.Count == 0)
                throw new Exception("Không có dữ liệu tài khoản.");

            List<Bank> banks = new List<Bank>();
            foreach ( var data in dataArray)
            {
                var bank = new Bank
                {
                    bankCode = data["bankCode"]?.ToString(),
                    bankName = data["bankName"]?.ToString(),
                    logo = data["logo"]?.ToString(),
                    bin = data["bin"]?.ToString(),
                    shortName = data["shortName"]?.ToString(),
                    
                };
                banks.Add(bank);
            }
            


            return banks;
        }


        public async Task<string> LayTenNguoiThuHuongAsync(
            string creditAcctNo,
            string bankCode,
            string type = "ACCOUNT")
        {
            var url =
                $"{BaseUrl}/IziBankBiz/Corp/corporate-gateway-server/corporate-fund-transfer-service/transfer/quick-external-account" +
                $"?debitAcctNo={Uri.EscapeDataString(AppState.account.accountNo)}" +
                $"&debitAcctName={Uri.EscapeDataString(AppState.account.accountName)}" +
                $"&creditAcctNo={Uri.EscapeDataString(creditAcctNo)}" +
                $"&bankCode={Uri.EscapeDataString(bankCode)}" +
                $"&type={Uri.EscapeDataString(type)}";

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

            int code = json["code"]?.Value<int>() ?? 0;

            if (code == 401)
                throw new UnauthorizedAccessException("Phiên đăng nhập đã hết hạn.");

            if (code != 200)
                throw new Exception(json["message"]?.ToString() ?? "Yêu cầu thất bại.");

            var data = json["data"];
            if (data == null)
                throw new Exception("Không có dữ liệu trả về.");

            string creditAcctName = data["creditAcctName"]?.ToString() ?? "";

            if (string.IsNullOrEmpty(creditAcctName))
                throw new Exception("Không tìm thấy tên người thụ hưởng.");

            return creditAcctName;
        }

        public async Task<FormCKN> ChuyenTienNhanhAsync(
            string creditAcctNo,
            string creditAcctName,
            string bankCode,
            string amount,
            string note,
            string duty = "NO",
            string type = "ACCOUNT")
        {
            var url = $"{BaseUrl}/IziBankBiz/Corp/corporate-gateway-server/corporate-fund-transfer-service/transfer/quick-external-confirm";

            var headers = new Dictionary<string, string>
            {
                ["Authorization"] = $"Bearer {AppState.AccessToken}",
                ["Content-Type"] = "application/json"
            };

            // 🔹 Tạo payload đúng format như bạn thấy trong hình
            var bodyJS = new
            {
                debitAcctNo = AppState.account.accountNo,
                creditAcctNo = creditAcctNo,
                amount = Convert.ToInt32(amount),
                note = note,
                debitAcctName = AppState.account.accountName,
                creditAcctName = creditAcctName,
                bankCode = bankCode,
                duty = "NO",
                type = "ACCOUNT"
            };

            // 🔹 Chuyển sang JSON để gửi đi
            string body = Newtonsoft.Json.JsonConvert.SerializeObject(bodyJS);

            // 🔹 Gửi request POST
            string responseText = await _virtualWebService.GuiRequestSerializeAsync(
                url,
                method: "POST",
                headers: headers,
                bodyJs: body
            );

            // Parse phản hồi
            JObject json = JObject.Parse(responseText);
            int code = json["code"]?.Value<int>() ?? 0;

            if (code == 401)
                throw new UnauthorizedAccessException("Phiên đăng nhập đã hết hạn.");

            if (code != 200)
                throw new Exception(json["message"]?.ToString() ?? "Yêu cầu thất bại.");

            var data = json["data"];
            if (data == null)
                throw new Exception("Không có dữ liệu trả về.");

            // 🔹 Map dữ liệu về model FormCKN
            var result = new FormCKN
            {
                transactionCode = data["transactionCode"]?.ToString(),
                transferTime = data["transferTime"]?.ToString(),
                debitAcctNo = data["debitAcctNo"]?.ToString(),
                debitAcctName = data["debitAcctName"]?.ToString(),
                bankCode = data["bankCode"]?.ToString(),
                bankName = data["bankName"]?.ToString(),
                creditAcctNo = data["creditAcctNo"]?.ToString(),
                creditAcctName = data["creditAcctName"]?.ToString(),
                amount = data["amount"]?.ToString(),
                note = data["note"]?.ToString(),
                fee = data["fee"]?.ToString(),
                duty = data["duty"]?.ToString(),
                currency = data["currency"]?.ToString(),
                otpMethod = data["otpMethod"]?.ToString(),
                otpLevel = data["otpLevel"]?.ToString(),
                time = data["time"]?.ToString()
            };

            return result;
        }

        public async Task<AuthResult> XacNhanChuyenTienNhanhAsync(
            FormCKN formCKN,
            string otp)
        {
            var url = $"{BaseUrl}/IziBankBiz/Corp/corporate-gateway-server/corporate-fund-transfer-service/transfer/quick-external";

            var headers = new Dictionary<string, string>
            {
                ["Authorization"] = $"Bearer {AppState.AccessToken}",
                ["Content-Type"] = "application/json"
            };

            // 🔹 Tạo payload đúng format như bạn thấy trong hình
            var bodyJS = new
            {
                debitAcctNo = formCKN.debitAcctNo,
                creditAcctNo = formCKN.creditAcctNo,
                amount = Convert.ToDecimal(formCKN.amount),
                note = formCKN.note,
                otpMethod = formCKN.otpMethod,
                otpLevel = formCKN.otpLevel,
                otp = otp, // giá trị OTP bạn nhập
                transactionCode = formCKN.transactionCode,
                debitAcctName = formCKN.debitAcctName,
                creditAcctName = formCKN.creditAcctName,
                bankCode = formCKN.bankCode,
                type = "ACCOUNT", // fallback nếu chưa có
                time = formCKN.time
            };

            // 🔹 Chuyển sang JSON để gửi đi
            string body = Newtonsoft.Json.JsonConvert.SerializeObject(bodyJS);

            // 🔹 Gửi request POST
            string responseText = await _virtualWebService.GuiRequestSerializeAsync(
                url,
                method: "POST",
                headers: headers,
                bodyJs: body
            );

            // Parse phản hồi
            JObject json = JObject.Parse(responseText);
            AuthResult a = new AuthResult
            {
                ErrorCode = json["code"]?.ToString(),

            };
            

            
            return a;
        }



    }
}
