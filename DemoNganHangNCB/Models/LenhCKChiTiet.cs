using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNganHangNCB.Models
{
    public class LenhCKChiTiet
    {
        public string transactionCode { get; set; }
        public string debitAcctNo { get; set; }
        public string debitAcctName { get; set; }
        public string creditAcctNo { get; set; }
        public string creditAcctName { get; set; }
        public string amount { get; set; }
        public string currency { get; set; }
        public string fee { get; set; }
        public string duty { get; set; }
        public string note { get; set; }
        public string approvalLevel { get; set; }
        public long createDate { get; set; }
        public string channelId { get; set; }
        public string channelName { get; set; }
        public string status { get; set; }
        public string statusDetail { get; set; }
        public string creator { get; set; }
        public string lastApprover { get; set; }
        public string bankName { get; set; }
        public string rejectedReason { get; set; }
        public string bankNameI18n { get; set; }
        public long lastApproveTime { get; set; }

        //Chuyen doi
        
        public DateTime createAtTran()
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(this.createDate);

            DateTime localTime = dateTimeOffset.ToOffset(TimeSpan.FromHours(7)).DateTime;
            return localTime;
        }

        public string statusTran()
        {
            string tmp = this.status;
            if (tmp == "LEVEL_1")
            {
                tmp = "Đã tạo";
            }
            else if (tmp == "TC")
            {
                tmp = "Bị từ chối";
            }
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
