using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNganHangNCB.Models
{
    public class LenhCKThuong
    {
        public string transactionId { get; set; }
        public string category { get; set; }
        public string type { get; set; }
        public string debitAccountNo { get; set; }
        public string beneficiaryName { get; set; }
        public string createdBy { get; set; }
        public long createdAt { get; set; }
        public string amount { get; set; }
        public string currency { get; set; }
        public string lastApprover { get; set; }
        public string status { get; set; }
        public string rejectedReason { get; set; }
        public long approvalTime { get; set; }
        public bool isExpiredSoon { get; set; }
        public string note { get; set; }
        public string creditAccountNo { get; set; }

        //Chuyen doi
        public string typeTran()
        {
            string tmp = this.type switch
            {
                "URT" => "CK nội bộ",
                "ISL" => "CK 24/7",
                "IBT" => "Chuyển thường",
                _ => this.type
            };
            return tmp;
        }

        public DateTime createAtTran()
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(this.createdAt);

            DateTime localTime = dateTimeOffset.ToOffset(TimeSpan.FromHours(7)).DateTime;
            return localTime;
        }

        public string statusTran()
        {
            string tmp = this.status switch
            {
                "LEVEL_1" => "Đã tạo",
                "TC" => "Bị từ chối",
                _ => this.type
            };
            return tmp;
        }
        public string amountTran()
        {
            string tmp = this.amount;
            if (decimal.TryParse(tmp, out decimal value))
            {
                tmp = string.Format("{0:N0}", value);
            }
            return tmp + " VND";
        }
    }
}
