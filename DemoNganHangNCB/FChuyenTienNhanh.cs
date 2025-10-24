using DemoNganHangNCB.Models;
using DemoNganHangNCB.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Net;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoNganHangNCB
{
    public partial class FChuyenTienNhanh : Form
    {
        private List<Bank> banks = new List<Bank>();
        private FormCKN formCKN;
        private Dictionary<string, Image> logoCache = new Dictionary<string, Image>();
        private bool benChuyenTra = false;
        public event Action? LogoutRequested;
        public FChuyenTienNhanh()
        {
            InitializeComponent();
            pContent.Hide();
        }

        private async void FChuyenTienNhanh_Load(object sender, EventArgs e)
        {
            rbBenChuyenTra.Checked = true;
            rbBenNhanTra.Checked = false;
            pChuyenTien.Hide();
            await LoadBankList();
            LoadLocalBankLogos();
            InitializeComboBox();
            LoadSoDu();

            pContent.Show();
        }


        private async void LoadSoDu()
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

                lblAccountNo.Text = account.accountNo;
                lblAccountType.Text = account.accountType;
                lblSoDu.Text = FormatNumberStringWithCommas(account.balance) + "  " + account.currency;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tra cứu: {ex.Message}");
            }
        }

        private async Task LoadBankList()
        {
            try
            {
                var bankingService = new BankingService(AppState.virtualWeb);
                banks = await bankingService.GetListBank();

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
            cbNganHang.DrawMode = DrawMode.OwnerDrawFixed;
            cbNganHang.ItemHeight = 50;
            cbNganHang.DataSource = banks;
            cbNganHang.DisplayMember = "bankName";
            cbNganHang.ValueMember = "bankCode";
            cbNganHang.DrawItem += CbNganHang_DrawItem;
        }

        private void CbNganHang_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            var bank = (Bank)((ComboBox)sender).Items[e.Index];
            e.DrawBackground();

            // 🖼️ Lấy ảnh logo từ cache
            if (logoCache.TryGetValue(bank.bankName, out Image logo) && logo != null)
            {
                e.Graphics.DrawImage(logo, new Rectangle(e.Bounds.X + 5, e.Bounds.Y + 5, 40, 40));
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

        private async void btnChuyen_Click(object sender, EventArgs e)
        {

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
                    string soTienText = txtSoTienChuyen.Text.Replace(".", "");
                    string duty = "NO";
                    string selectedCode = cbNganHang.SelectedValue?.ToString();
                    if (rbBenNhanTra.Checked == true)
                    {
                        duty = "YES";
                    }
                    var bankingService = new BankingService(AppState.virtualWeb);
                    formCKN = await bankingService.ChuyenTienNhanhAsync(txtSTK.Text, txtBenThuHuong.Text, selectedCode, soTienText, txtNoiDungChuyen.Text, duty);

                    if (formCKN == null)
                    {
                        MessageBox.Show("Phiên đăng nhập đã hết hạn. Vui lòng đăng nhập lại.", "Thông báo");
                        LogoutRequested?.Invoke();

                        return;
                    }

                    pChuyenTien.Show();
                    btnXacNhan.Hide();
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
        }

        private async void btnChuyen_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtOTP.Text != "")
                {
                    string selectedCode = cbNganHang.SelectedValue?.ToString();
                    var bankingService = new BankingService(AppState.virtualWeb);
                    var authResult = await bankingService.XacNhanChuyenTienNhanhAsync(formCKN, txtOTP.Text);

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
                        LogoutRequested?.Invoke();
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

        private void rbBenChuyenTra_CheckedChanged(object sender, EventArgs e)
        {

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

        private void lblAccountNo_Click(object sender, EventArgs e)
        {

        }
    }
}
