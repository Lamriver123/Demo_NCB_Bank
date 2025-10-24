using DemoNganHangNCB.Models;
using DemoNganHangNCB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DemoNganHangNCB
{
    public static class AppState
    {
        public static string grant_type = "password";
        public static string grant_service = "IB";
        public static string grant_client = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/141.0.0.0 Safari/537.36 Edg/141.0.0.0";
        public static string reCaptcha = "fdfd";
        public static string grant_device = "9f49a0a0c39e776f19d9d21e8a720764";
        public static string AccessToken { get; set; }
        public static string RefreshToken { get; set; }
        public static VirtualWebService virtualWeb { get; set; }

        public static Account account { get; set; }
        public static void Reset()
        {
            AccessToken = null;
            RefreshToken = null;
            account = null;
        }
        public static void DangXuat()
        {
            if (virtualWeb != null)
            {
                virtualWeb.DisposeAsync().AsTask().GetAwaiter().GetResult();
                virtualWeb = null;
            }
            Reset();
        }

    }
}
