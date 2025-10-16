using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNganHangNCB.Models
{
    public class AuthResult
    {
        public bool IsSuccess { get; set; }
        public string ErrorCode { get; set; }   
        public string Message { get; set; }     
    }

}
