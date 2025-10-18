using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNganHangNCB.Models
{
    public class FormCKN
    {
        public string transactionCode { get; set; }
        public string transferTime { get; set; }
        public string debitAcctNo { get; set; }
        public string debitAcctName { get; set; }
        public string bankCode { get; set; }
        public string bankName { get; set; }
        public string creditAcctNo { get; set; }
        public string creditAcctName { get; set; }
        public string amount { get; set; }
        public string note { get; set; }
        public string fee { get; set; }
        public string duty { get; set; }
        public string currency { get; set; }
        public string otpMethod { get; set; }
        public string otpLevel { get; set; }
        public string challenge { get; set; }
        public string challengeQRCode { get; set; }
        public string time { get; set; }
    }
}
