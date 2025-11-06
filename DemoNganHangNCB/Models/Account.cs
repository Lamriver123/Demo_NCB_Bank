using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNganHangNCB.Models
{
    public class Account
    {
        public string accountNo { get; set; }
        public string accountName { get; set; }
        public string accountType { get; set; }
        public string currency { get; set; }
        public string balance { get; set; }
        public string status { get; set; }
        public DateTime openDate { get; set; }
    }
}
