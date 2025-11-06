using DemoNganHangNCB.Items;
using DemoNganHangNCB.Models;
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
        private List<Account> accounts; 
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
                accounts = await traCuuService.LayThongTinTaiKhoanAsync();

                if (accounts == null)
                {
                    MessageBox.Show("Phiên đăng nhập đã hết hạn. Vui lòng đăng nhập lại.", "Thông báo");
                    LogoutRequested?.Invoke();

                    return;
                }
                cbAccount.DataSource = accounts;
                cbAccount.DisplayMember = "accountNo";
                cbAccount.ValueMember = "accountNo";
                cbAccount.DropDownStyle = ComboBoxStyle.DropDownList;
                cbAccount.ItemHeight = tlpSTK.Height;

                // Gán thông tin cho tài khoản đầu tiên
                HienThiThongTinTaiKhoan(accounts[0]);
                pContent.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tra cứu: {ex.Message}");
            }

        }

        private void HienThiThongTinTaiKhoan(Account account)
        {
            lblAccountName.Text = "Chủ tài khoản: " + account.accountName;
            lblAccountType.Text = account.accountType;
            lblSoDu.Text = FormatNumberStringWithCommas(account.balance) + "  " + account.currency;
            lblStatus.Text = account.status;
        }

        public string FormatNumberStringWithCommas(string numberString)
        {
            if (long.TryParse(numberString, out long number))
            {
                return number.ToString("N0", new CultureInfo("en-US"));
            }
            return numberString;
        }

        private void cbAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbAccount.SelectedIndex;
            if (index >= 0 && index < accounts.Count)
            {
                HienThiThongTinTaiKhoan(accounts[index]);
            }
        }
    }
}
