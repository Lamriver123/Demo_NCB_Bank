using DemoNganHangNCB.Services;
using static System.Net.WebRequestMethods;
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


            var authService = new AuthService(AppState.virtualWeb);
            var result = await authService.LoginAndGetTokenAsync(username, password);
            if (result.IsSuccess)
            {
                MessageBox.Show("Đăng nhập thành công!");
                this.Hide();
                FMain fHome = new FMain();
                fHome.ShowDialog();
                this.Close();
            }
            else
            {
                switch (result.ErrorCode)
                {
                    case "NCBLOGIN-9":
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu. Tài khoản có thể đã bị khóa sau nhiều lần thử sai.",
                                        "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;

                    case "NCBLOGIN-14":
                        MessageBox.Show("Thiết bị mới — cần xác thực OTP để tiếp tục.",
                                        "Xác thực OTP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide() ;
                        using (var fNhapOTP = new FNhapOTP(username,password))
                        {
                            fNhapOTP.ShowDialog();
                        }
                        this.Close();
                        break;
                    default:
                        MessageBox.Show(result.Message ?? "Đăng nhập thất bại. Vui lòng thử lại.",
                                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            btnLogin.Enabled = true;
        }
    }
}
