using DemoNganHangNCB.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoNganHangNCB
{
    public partial class FTraCuuSoDu : Form
    {
        public event Action? LogoutRequested;
        public FTraCuuSoDu()
        {
            InitializeComponent();
            pContent.Hide();

        }


        private async void FTraCuuSoDu_Load(object sender, EventArgs e)
        {
            try
            {
                var traCuuService = new TraCuuService(AppState.virtualWeb);
                var account = await traCuuService.LayThongTinTaiKhoanAsync();

                if (account == null)
                {
                    MessageBox.Show("Phiên đăng nhập đã hết hạn. Vui lòng đăng nhập lại.", "Thông báo");
                    LogoutRequested?.Invoke();
                    
                    return;
                }
                lblAccountName.Text ="Chủ tài khoản: " + account.accountName;
                lblAccountNo.Text ="Số tài khoản: "+ account.accountNo;
                lblAccountType.Text = account.accountType;
                lblSoDu.Text = FormatNumberStringWithCommas(account.balance) + "  " + account.currency;
                lblStatus.Text = account.status;

                pContent.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tra cứu: {ex.Message}");
            }
            
        }

        public string FormatNumberStringWithCommas(string numberString)
        {
            if (long.TryParse(numberString, out long number))
            {
                return number.ToString("N0", new CultureInfo("en-US"));
            }
            return numberString;
        }
    }
}
