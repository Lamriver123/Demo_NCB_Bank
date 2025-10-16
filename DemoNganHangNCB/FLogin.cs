using DemoNganHangNCB.Services;
using static System.Windows.Forms.DataFormats;

namespace DemoNganHangNCB
{
    public partial class FLogin : Form
    {
        public FLogin()
        {
            InitializeComponent();
        }
        private string username;
        private string password;

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUserName.Text.Trim() =="" ||  txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Nhập đầy đủ thông tin");
                return;
            }
            btnLogin.Enabled = false;
            username = txtUserName.Text;
            password = txtPassword.Text;

            
            AppState.virtualWeb = new AuthService(headless: false);
            await AppState.virtualWeb.InitializeAsync();

            var result = await AppState.virtualWeb.LoginAndGetTokenAsync(username, password);
            if (result.IsSuccess)
            {
                MessageBox.Show("Đăng nhập thành công!");
                this.Hide();
                FHome fHome = new FHome();
                fHome.ShowDialog();
                this.Close();
            }
            else
            {
                if (result.ErrorCode?.Contains("NCBLOGIN-14") == true)
                {
                    MessageBox.Show("Thiết bị mới, vui lòng nhập mã OTP.");
                    //var otpForm = new FormOtp(txtUsername.Text, txtPassword.Text);
                    //otpForm.ShowDialog();
                }
                else if (result.ErrorCode?.Contains("NCBLOGIN-9") == true)
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.");
                }
                else
                {
                    MessageBox.Show(result.Message);
                }
            }
            btnLogin.Enabled = true;
        }
    }
}
