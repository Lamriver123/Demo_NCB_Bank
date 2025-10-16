using DemoNganHangNCB.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoNganHangNCB
{
    public partial class FTraCuuSoDu : Form
    {
        public FTraCuuSoDu()
        {
            InitializeComponent();
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
                    var fLogin = new FLogin();
                    this.Hide();
                    fLogin.ShowDialog();
                    this.Close();
                    return;
                }
                lblAccountName.Text = account.accountName;
                lblAccountNo.Text = account.accountNo;
                lblAccountType.Text = account.accountType;
                lblSoDu.Text = account.balance + "  " + account.currency;
                lblStatus.Text = account.status;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tra cứu: {ex.Message}");
            }
        }
    }
}
