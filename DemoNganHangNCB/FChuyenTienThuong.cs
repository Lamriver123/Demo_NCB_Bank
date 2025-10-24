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
    public partial class FChuyenTienThuong : Form
    {
        public event Action? LogoutRequested;
        public FChuyenTienThuong()
        {
            InitializeComponent();
        }

        private async void FChuyenTienThuong_Load(object sender, EventArgs e)
        {
            try
            {
                AppState.AccessToken = "a";
                var traCuuService = new TraCuuService(AppState.virtualWeb);
                var account = await traCuuService.LayThongTinTaiKhoanAsync();

                if (account == null)
                {
                    MessageBox.Show("Phiên đăng nhập đã hết hạn. Vui lòng đăng nhập lại.", "Thông báo");
                    LogoutRequested?.Invoke();

                    return;
                }
                lblAccountNo.Text = account.accountNo;
                lblAccountType.Text = account.accountType;
                lblSoDu.Text = FormatNumberStringWithCommas(account.balance) + "  " + account.currency;

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
