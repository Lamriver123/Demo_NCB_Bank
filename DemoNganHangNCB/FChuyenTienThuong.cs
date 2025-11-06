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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoNganHangNCB
{
    public partial class FChuyenTienThuong : Form
    {
        private List<Bank> banks = new List<Bank>();
        private FormCKN formCKN;
        private Dictionary<string, Image> logoCache = new Dictionary<string, Image>();
        private bool benChuyenTra = false;
        private Account accountChoose;
        public event Action? LogoutRequested;
        private List<Account> accounts = new List<Account>();
        public FChuyenTienThuong()
        {
            InitializeComponent();
            pContent.Hide();
        }

        private async void FChuyenTienThuong_Load(object sender, EventArgs e)
        {
            rbBenChuyenTra.Checked = true;
            rbBenNhanTra.Checked = false;
            cbNganHang.IntegralHeight = false;
            pChuyenTien.Hide();
            await LoadBankList();
            LoadLocalBankLogos();
            InitializeComboBox();
            await LoadSoDu();

            pContent.Show();
        }


        private async Task LoadSoDu()
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

                // Gán thông tin cho tài khoản đầu tiên
                HienThiThongTinTaiKhoan(accounts[0]);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tra cứu: {ex.Message}");
            }
        }
        private void HienThiThongTinTaiKhoan(Account account)
        {
            accountChoose = account;
            lblAccountType.Text = account.accountType;
            lblSoDu.Text = FormatNumberStringWithCommas(account.balance) + "  " + account.currency;
        }

        private void cbNganHang_MouseMove(object sender, MouseEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

            // Ngăn auto-scroll khi hover cuối danh sách
            if (cb.DroppedDown)
            {
                // Nếu chuột ở vùng dưới cùng (5px cuối)
                if (e.Y > cb.Height - 5)
                {
                    // Reset để ngăn Windows cuộn
                    cb.SelectedIndex = -1;
                }
            }
        }


        private async Task LoadBankList()
        {
            try
            {
                var bankingService = new BankingService(AppState.virtualWeb);
                banks = await bankingService.GetListBank();
                foreach(var bank in banks)
                {
                    if(bank.bankCode == "-1")
                    {
                        banks.Remove(bank);
                        break;
                    }
                }
                if (banks == null)
                {
                    MessageBox.Show("Phiên đăng nhập đã hết hạn. Vui lòng đăng nhập lại.", "Thông báo");
                    LogoutRequested?.Invoke();

                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tra cứu: {ex.Message}");
            }
        }

        private void LoadLocalBankLogos()
        {
            string logoFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logos");

            foreach (var bank in banks)
            {
                string safeFileName = bank.bankName.Replace("/", "-").Replace("\\", "-"); // tránh lỗi tên file
                string logoPath = Path.Combine(logoFolder, $"{safeFileName}.png");

                if (File.Exists(logoPath))
                {
                    try
                    {
                        using (var img = Image.FromFile(logoPath))
                        {
                            // Resize cho mượt mà, nhẹ
                            Image resized = ResizeImage(img, 40, 40);
                            logoCache[bank.bankName] = resized;
                        }
                    }
                    catch
                    {
                        // fallback nếu lỗi đọc file
                        logoCache[bank.bankName] = null;
                    }
                }
                else
                {
                    logoCache[bank.bankName] = null; // Không có logo thì để trống
                }
            }
        }

        private void InitializeComboBox()
        {

            cbNganHang.DataSource = banks;
            cbNganHang.DrawMode = DrawMode.OwnerDrawFixed;
            cbNganHang.ItemHeight = 40; // thử 40-44
            cbNganHang.IntegralHeight = false;
            cbNganHang.MaxDropDownItems = 8; // hoặc set sao cho dropdown có khoảng trống
            cbNganHang.DisplayMember = "bankName";
            cbNganHang.ValueMember = "bankCode";
            cbNganHang.DrawItem += CbNganHang_DrawItem;

        }

        private void CbNganHang_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            var bank = (Bank)((ComboBox)sender).Items[e.Index];
            e.DrawBackground();

            if (logoCache.TryGetValue(bank.bankName, out Image logo) && logo != null)
            {
                e.Graphics.DrawImage(logo, new Rectangle(e.Bounds.X + 5, e.Bounds.Y + 5, 32, 32));
            }

            int textX = e.Bounds.X + 55;
            using (Font font = new Font("Segoe UI", 10, FontStyle.Bold))
                e.Graphics.DrawString($"{bank.shortName} ({bank.bankCode})", font, Brushes.Black, textX, e.Bounds.Y + 5);

            using (Font subFont = new Font("Segoe UI", 8))
                e.Graphics.DrawString($"BIN: {bank.bin}", subFont, Brushes.Gray, textX, e.Bounds.Y + 25);

            e.DrawFocusRectangle();
        }

        private string FormatNumberStringWithCommas(string numberString)
        {
            if (long.TryParse(numberString, out long number))
            {
                return number.ToString("N0", new CultureInfo("en-US"));
            }
            return numberString;
        }

        private Image ResizeImage(Image img, int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(img, 0, 0, width, height);
            }
            return bmp;
        }

        private async void txtSTK_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSTK.Text))
            {
                try
                {
                    string selectedCode = cbNganHang.SelectedValue?.ToString();
                    if (selectedCode != "")
                    {

                        var bankingService = new BankingService(AppState.virtualWeb);
                        var creditName = "";
                        if (selectedCode != "-1")
                        {

                            creditName = await bankingService.LayTenNguoiThuHuongKhacTKAsync(txtSTK.Text, selectedCode);
                        }
                        else
                        {
                            creditName = await bankingService.LayTenNguoiThuHuongCungTKAsync(txtSTK.Text);
                        }
                        if (creditName == null)
                        {
                            MessageBox.Show("Phiên đăng nhập đã hết hạn. Vui lòng đăng nhập lại.", "Thông báo");
                            LogoutRequested?.Invoke();

                            return;
                        }

                        txtBenThuHuong.Text = creditName;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    txtBenThuHuong.Clear();
                    txtSTK.Clear();
                }
            }
        }

        private void cbNganHang_TextChanged(object sender, EventArgs e)
        {
            txtSTK.Clear();
            txtBenThuHuong.Clear();
        }

        private async void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSTK.Text.Trim() != "" && cbNganHang.Text.Trim() != "" && txtBenThuHuong.Text.Trim() != "" && txtNoiDungChuyen.Text.Trim() != "" && txtSoTienChuyen.Text.Trim() != "")
                {
                    string selectedCode = cbNganHang.SelectedValue?.ToString();
                    string soTienText = txtSoTienChuyen.Text.Replace(",", "");
                    string duty = "NO";

                    if (rbBenNhanTra.Checked == true)
                    {
                        duty = "YES";
                    }
                    var bankingService = new BankingService(AppState.virtualWeb);
                    
                    formCKN = await bankingService.ChuyenTienThuongAsync(accountChoose.accountNo, accountChoose.accountName, txtSTK.Text, txtBenThuHuong.Text, selectedCode, soTienText, txtNoiDungChuyen.Text, duty);

                    if (formCKN == null)
                    {
                        MessageBox.Show("Phiên đăng nhập đã hết hạn. Vui lòng đăng nhập lại.", "Thông báo");
                        LogoutRequested?.Invoke();

                        return;
                    }
                    
                    pChuyenTien.Show();
                    btnXacNhan.Hide();
                    cbAccount.Enabled = true;
                    txtNoiDungChuyen.ReadOnly = true;
                    txtSoTienChuyen.ReadOnly = true;
                    txtSTK.ReadOnly = true;
                    cbNganHang.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtSTK.Clear();
                txtBenThuHuong.Clear();
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            btnXacNhan.Show();
            pChuyenTien.Hide();
            txtNoiDungChuyen.ReadOnly = false;
            txtSoTienChuyen.ReadOnly = false;
            txtSTK.ReadOnly = false;
            cbNganHang.Enabled = true;
            cbAccount.Enabled = true;
        }

        private async void btnChuyen_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtOTP.Text != "")
                {
                    string selectedCode = cbNganHang.SelectedValue?.ToString();
                    var bankingService = new BankingService(AppState.virtualWeb);
                    
                    var authResult = await bankingService.XacNhanChuyenTienThuongAsync(formCKN, txtOTP.Text);

                    if (authResult.ErrorCode == "401")
                    {
                        MessageBox.Show("Phiên đăng nhập đã hết hạn. Vui lòng đăng nhập lại.", "Thông báo");
                        LogoutRequested?.Invoke();

                        return;
                    }
                    else if (authResult.ErrorCode == "200")
                    {
                        MessageBox.Show("Tạo lệnh thành công");
                        btnQuayLai_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show(authResult.Message);
                    }
                   

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtBenThuHuong.Clear();
                txtSTK.Clear();
            }
        }

        private void txtSoTienChuyen_TextChanged(object sender, EventArgs e)
        {
            // Lưu vị trí con trỏ hiện tại
            int selectionStart = txtSoTienChuyen.SelectionStart;

            // Lấy chuỗi chỉ gồm các ký tự số
            string digits = new string(txtSoTienChuyen.Text.Where(char.IsDigit).ToArray());

            // Giới hạn tối đa 10 chữ số
            if (digits.Length > 10)
                digits = digits.Substring(0, 10);

            if (string.IsNullOrEmpty(digits))
            {
                txtSoTienChuyen.Text = "";
                return;
            }

            // Định dạng có dấu chấm
            if (decimal.TryParse(digits, out decimal value))
            {
                txtSoTienChuyen.Text = string.Format("{0:N0}", value);
            }

            // Đưa con trỏ về cuối
            txtSoTienChuyen.SelectionStart = txtSoTienChuyen.Text.Length;
        }

        private void txtSoTienChuyen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNoiDungChuyen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            // Kiểm tra ký tự hợp lệ: chỉ A-Z, a-z, 0-9, khoảng trắng
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"^[a-zA-Z0-9\s]$"))
            {
                e.Handled = true; // chặn ký tự
            }
        }

        private void txtSTK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            // Kiểm tra ký tự hợp lệ: 0-9
            if (!Regex.IsMatch(e.KeyChar.ToString(), @"^[0-9]$"))
            {
                e.Handled = true; // chặn ký tự
            }
        }

        private void cbAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
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
