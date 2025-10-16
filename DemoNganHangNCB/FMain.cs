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
    public partial class FMain : Form
    {
        Color primaryBackColor = Color.MediumTurquoise;
        Color primaryForeColor = SystemColors.ControlLightLight;
        Color tertiaryBackColor = Color.LightBlue;
        Color tertiaryForeColor = SystemColors.ControlDarkDark;
        Color secondaryBackColor = Color.DeepSkyBlue;
        Color secondaryForeColor = Color.DarkBlue;
        public FMain()
        {
            InitializeComponent();
            pMoreLenhChuyenTien.Hide();

            // Đặt kiểu kích thước của dòng thành tuyệt đối và chiều cao là 0
            RowStyle rowStyle = tableLayoutPanel1.RowStyles[2];
            rowStyle.SizeType = SizeType.Percent;
            rowStyle.Height = 0;
        }

        private void btnLenhChuyenTien_Click(object sender, EventArgs e)
        {
            RowStyle rowStyle = tableLayoutPanel1.RowStyles[2];

            if (pMoreLenhChuyenTien.Visible)
            {
                pMoreLenhChuyenTien.Hide();

                rowStyle.SizeType = SizeType.Percent;
                rowStyle.Height = 0;
            }
            else
            {
                pMoreLenhChuyenTien.Show();

                rowStyle.SizeType = SizeType.AutoSize;
            }
        }

        private void btnTraCuuSoDu_Click(object sender, EventArgs e)
        {
            //set UI
            pMoreLenhChuyenTien.BackColor = tertiaryBackColor;

            btnTraCuuSoDu.BackColor = primaryBackColor;
            btnTraCuuSoDu.ForeColor = primaryForeColor;
            btnTraCuuSoDu.IconColor = primaryForeColor;

            btnTrangChu.BackColor = tertiaryBackColor;
            btnTrangChu.ForeColor = tertiaryForeColor;
            btnTrangChu.IconColor = tertiaryForeColor;

            btnLenhChuyenTien.BackColor = tertiaryBackColor;
            btnLenhChuyenTien.ForeColor = tertiaryForeColor;
            btnLenhChuyenTien.IconColor = tertiaryForeColor;

            btnChuyenNhanh.BackColor = tertiaryBackColor;
            btnChuyenNhanh.ForeColor = tertiaryForeColor;
            btnChuyenNhanh.IconColor = tertiaryForeColor;

            btnChuyenThuong.BackColor = tertiaryBackColor;
            btnChuyenThuong.ForeColor = tertiaryForeColor;
            btnChuyenThuong.IconColor = tertiaryForeColor;

            FTraCuuSoDu fTraCuuSoDu = new FTraCuuSoDu();
            openChildForm(fTraCuuSoDu);

        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            pMoreLenhChuyenTien.BackColor = tertiaryBackColor;

            btnTrangChu.BackColor = primaryBackColor;
            btnTrangChu.ForeColor = primaryForeColor;
            btnTrangChu.IconColor = primaryForeColor;

            btnTraCuuSoDu.BackColor = tertiaryBackColor;
            btnTraCuuSoDu.ForeColor = tertiaryForeColor;
            btnTraCuuSoDu.IconColor = tertiaryForeColor;

            btnLenhChuyenTien.BackColor = tertiaryBackColor;
            btnLenhChuyenTien.ForeColor = tertiaryForeColor;
            btnLenhChuyenTien.IconColor = tertiaryForeColor;

            btnChuyenNhanh.BackColor = tertiaryBackColor;
            btnChuyenNhanh.ForeColor = tertiaryForeColor;
            btnChuyenNhanh.IconColor = tertiaryForeColor;

            btnChuyenThuong.BackColor = tertiaryBackColor;
            btnChuyenThuong.ForeColor = tertiaryForeColor;
            btnChuyenThuong.IconColor = tertiaryForeColor;

            //Logic
            FTrangChu fTrangChu = new FTrangChu();
            openChildForm(fTrangChu);
        }


        private void btnDangXuat_Click(object sender, EventArgs e)
        {

        }

        public void openChildForm(Form f)
        {
            pChild.Controls.Clear();
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            pChild.Controls.Add(f);
            f.Show();
        }

        private void btnChuyenNhanh_Click(object sender, EventArgs e)
        {
            //UI
            pMoreLenhChuyenTien.BackColor = primaryBackColor;

            btnChuyenNhanh.BackColor = secondaryBackColor;
            btnChuyenNhanh.ForeColor = secondaryForeColor;
            btnChuyenNhanh.IconColor = secondaryForeColor;

            btnTrangChu.BackColor = tertiaryBackColor;
            btnTrangChu.ForeColor = tertiaryForeColor;
            btnTrangChu.IconColor = tertiaryForeColor;

            btnTraCuuSoDu.BackColor = tertiaryBackColor;
            btnTraCuuSoDu.ForeColor = tertiaryForeColor;
            btnTraCuuSoDu.IconColor = tertiaryForeColor;

            btnLenhChuyenTien.BackColor = primaryBackColor;
            btnLenhChuyenTien.ForeColor = primaryForeColor;
            btnLenhChuyenTien.IconColor = primaryForeColor;

            btnChuyenThuong.BackColor = primaryBackColor;
            btnChuyenThuong.ForeColor = tertiaryForeColor;
            btnChuyenThuong.IconColor = tertiaryForeColor;


            //Logic
            FChuyenTienNhanh fChuyenTienNhanh = new FChuyenTienNhanh();
            openChildForm(fChuyenTienNhanh);
        }

        private void btnChuyenThuong_Click(object sender, EventArgs e)
        {
            pMoreLenhChuyenTien.BackColor = primaryBackColor;

            btnChuyenThuong.BackColor = secondaryBackColor;
            btnChuyenThuong.ForeColor = secondaryForeColor;
            btnChuyenThuong.IconColor = secondaryForeColor;

            btnTrangChu.BackColor = tertiaryBackColor;
            btnTrangChu.ForeColor = tertiaryForeColor;
            btnTrangChu.IconColor = tertiaryForeColor;

            btnTraCuuSoDu.BackColor = tertiaryBackColor;
            btnTraCuuSoDu.ForeColor = tertiaryForeColor;
            btnTraCuuSoDu.IconColor = tertiaryForeColor;

            btnLenhChuyenTien.BackColor = primaryBackColor;
            btnLenhChuyenTien.ForeColor = primaryForeColor;
            btnLenhChuyenTien.IconColor = primaryForeColor;

            btnChuyenNhanh.BackColor = primaryBackColor;
            btnChuyenNhanh.ForeColor = tertiaryForeColor;
            btnChuyenNhanh.IconColor = tertiaryForeColor;

            //Logic
            FChuyenTienThuong fChuyenTienThuong = new FChuyenTienThuong();
            openChildForm(fChuyenTienThuong);
        }

        private void FMain_Load(object sender, EventArgs e)
        {
            btnTrangChu_Click(sender, e);
        }
    }
}
