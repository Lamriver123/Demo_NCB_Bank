using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DemoNganHangNCB
{
    partial class FMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMain));
            pHeader = new Panel();
            pSidebar = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            btnTrangChu = new FontAwesome.Sharp.IconButton();
            btnLenhChuyenTien = new FontAwesome.Sharp.IconButton();
            pMoreLenhChuyenTien = new Panel();
            tableLayoutPanel3 = new TableLayoutPanel();
            btnChuyenThuong = new FontAwesome.Sharp.IconButton();
            btnChuyenNhanh = new FontAwesome.Sharp.IconButton();
            btnDangXuat = new FontAwesome.Sharp.IconButton();
            btnTraCuuSoDu = new FontAwesome.Sharp.IconButton();
            pFooter = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            pChild = new Panel();
            pSidebar.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            pMoreLenhChuyenTien.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // pHeader
            // 
            pHeader.BackColor = SystemColors.GradientInactiveCaption;
            pHeader.Dock = DockStyle.Top;
            pHeader.Location = new Point(0, 0);
            pHeader.Name = "pHeader";
            pHeader.Size = new Size(1291, 49);
            pHeader.TabIndex = 0;
            // 
            // pSidebar
            // 
            pSidebar.BackColor = Color.LightBlue;
            pSidebar.Controls.Add(tableLayoutPanel2);
            pSidebar.Dock = DockStyle.Fill;
            pSidebar.Location = new Point(3, 3);
            pSidebar.Name = "pSidebar";
            pSidebar.Padding = new Padding(5);
            pSidebar.Size = new Size(190, 693);
            pSidebar.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(btnTrangChu, 0, 0);
            tableLayoutPanel2.Controls.Add(btnLenhChuyenTien, 0, 1);
            tableLayoutPanel2.Controls.Add(pMoreLenhChuyenTien, 0, 2);
            tableLayoutPanel2.Controls.Add(btnDangXuat, 0, 5);
            tableLayoutPanel2.Controls.Add(btnTraCuuSoDu, 0, 3);
            tableLayoutPanel2.Dock = DockStyle.Top;
            tableLayoutPanel2.Location = new Point(5, 5);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 6;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.Size = new Size(180, 331);
            tableLayoutPanel2.TabIndex = 7;
            // 
            // btnTrangChu
            // 
            btnTrangChu.BackColor = Color.LightBlue;
            btnTrangChu.Dock = DockStyle.Fill;
            btnTrangChu.FlatAppearance.BorderColor = Color.Azure;
            btnTrangChu.FlatStyle = FlatStyle.Flat;
            btnTrangChu.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTrangChu.ForeColor = SystemColors.ControlDarkDark;
            btnTrangChu.IconChar = FontAwesome.Sharp.IconChar.House;
            btnTrangChu.IconColor = SystemColors.ControlDarkDark;
            btnTrangChu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnTrangChu.Location = new Point(0, 0);
            btnTrangChu.Margin = new Padding(0);
            btnTrangChu.Name = "btnTrangChu";
            btnTrangChu.Padding = new Padding(10, 0, 0, 0);
            btnTrangChu.Size = new Size(180, 62);
            btnTrangChu.TabIndex = 3;
            btnTrangChu.Text = "Trang chủ";
            btnTrangChu.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnTrangChu.UseVisualStyleBackColor = false;
            btnTrangChu.Click += btnTrangChu_Click;
            // 
            // btnLenhChuyenTien
            // 
            btnLenhChuyenTien.BackColor = Color.MediumTurquoise;
            btnLenhChuyenTien.Dock = DockStyle.Fill;
            btnLenhChuyenTien.FlatAppearance.BorderColor = Color.Azure;
            btnLenhChuyenTien.FlatStyle = FlatStyle.Flat;
            btnLenhChuyenTien.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLenhChuyenTien.ForeColor = SystemColors.ControlLight;
            btnLenhChuyenTien.IconChar = FontAwesome.Sharp.IconChar.MoneyBill1;
            btnLenhChuyenTien.IconColor = SystemColors.ControlLight;
            btnLenhChuyenTien.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnLenhChuyenTien.Location = new Point(0, 62);
            btnLenhChuyenTien.Margin = new Padding(0);
            btnLenhChuyenTien.Name = "btnLenhChuyenTien";
            btnLenhChuyenTien.Padding = new Padding(10, 0, 0, 0);
            btnLenhChuyenTien.Size = new Size(180, 62);
            btnLenhChuyenTien.TabIndex = 5;
            btnLenhChuyenTien.Text = "Lệnh chuyển tiền";
            btnLenhChuyenTien.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLenhChuyenTien.UseVisualStyleBackColor = false;
            btnLenhChuyenTien.Click += btnLenhChuyenTien_Click;
            // 
            // pMoreLenhChuyenTien
            // 
            pMoreLenhChuyenTien.BackColor = Color.MediumTurquoise;
            pMoreLenhChuyenTien.Controls.Add(tableLayoutPanel3);
            pMoreLenhChuyenTien.Dock = DockStyle.Fill;
            pMoreLenhChuyenTien.Location = new Point(0, 124);
            pMoreLenhChuyenTien.Margin = new Padding(0);
            pMoreLenhChuyenTien.Name = "pMoreLenhChuyenTien";
            pMoreLenhChuyenTien.Size = new Size(180, 100);
            pMoreLenhChuyenTien.TabIndex = 6;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(btnChuyenThuong, 0, 1);
            tableLayoutPanel3.Controls.Add(btnChuyenNhanh, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.Size = new Size(180, 100);
            tableLayoutPanel3.TabIndex = 8;
            // 
            // btnChuyenThuong
            // 
            btnChuyenThuong.Dock = DockStyle.Fill;
            btnChuyenThuong.FlatAppearance.BorderColor = Color.LightBlue;
            btnChuyenThuong.FlatStyle = FlatStyle.Flat;
            btnChuyenThuong.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            btnChuyenThuong.IconChar = FontAwesome.Sharp.IconChar.Usd;
            btnChuyenThuong.IconColor = Color.Black;
            btnChuyenThuong.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnChuyenThuong.IconSize = 24;
            btnChuyenThuong.Location = new Point(0, 50);
            btnChuyenThuong.Margin = new Padding(0);
            btnChuyenThuong.Name = "btnChuyenThuong";
            btnChuyenThuong.Padding = new Padding(20, 0, 0, 0);
            btnChuyenThuong.Size = new Size(180, 50);
            btnChuyenThuong.TabIndex = 8;
            btnChuyenThuong.Text = "Chuyển thường";
            btnChuyenThuong.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnChuyenThuong.UseVisualStyleBackColor = true;
            btnChuyenThuong.Click += btnChuyenThuong_Click;
            // 
            // btnChuyenNhanh
            // 
            btnChuyenNhanh.BackColor = Color.DeepSkyBlue;
            btnChuyenNhanh.Dock = DockStyle.Fill;
            btnChuyenNhanh.FlatAppearance.BorderColor = Color.LightBlue;
            btnChuyenNhanh.FlatStyle = FlatStyle.Flat;
            btnChuyenNhanh.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            btnChuyenNhanh.IconChar = FontAwesome.Sharp.IconChar.BoltLightning;
            btnChuyenNhanh.IconColor = Color.Black;
            btnChuyenNhanh.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnChuyenNhanh.IconSize = 24;
            btnChuyenNhanh.Location = new Point(0, 0);
            btnChuyenNhanh.Margin = new Padding(0);
            btnChuyenNhanh.Name = "btnChuyenNhanh";
            btnChuyenNhanh.Padding = new Padding(20, 0, 0, 0);
            btnChuyenNhanh.Size = new Size(180, 50);
            btnChuyenNhanh.TabIndex = 8;
            btnChuyenNhanh.Text = "Chuyển nhanh";
            btnChuyenNhanh.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnChuyenNhanh.UseVisualStyleBackColor = false;
            btnChuyenNhanh.Click += btnChuyenNhanh_Click;
            // 
            // btnDangXuat
            // 
            btnDangXuat.Dock = DockStyle.Fill;
            btnDangXuat.FlatAppearance.BorderColor = Color.Azure;
            btnDangXuat.FlatStyle = FlatStyle.Flat;
            btnDangXuat.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDangXuat.ForeColor = SystemColors.ControlDarkDark;
            btnDangXuat.IconChar = FontAwesome.Sharp.IconChar.DoorOpen;
            btnDangXuat.IconColor = SystemColors.ControlDarkDark;
            btnDangXuat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDangXuat.Location = new Point(0, 277);
            btnDangXuat.Margin = new Padding(0);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Padding = new Padding(10, 0, 0, 0);
            btnDangXuat.Size = new Size(180, 54);
            btnDangXuat.TabIndex = 7;
            btnDangXuat.Text = "Đăng xuất";
            btnDangXuat.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDangXuat.UseVisualStyleBackColor = true;
            btnDangXuat.Click += btnDangXuat_Click;
            // 
            // btnTraCuuSoDu
            // 
            btnTraCuuSoDu.Dock = DockStyle.Fill;
            btnTraCuuSoDu.FlatAppearance.BorderColor = Color.Azure;
            btnTraCuuSoDu.FlatStyle = FlatStyle.Flat;
            btnTraCuuSoDu.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTraCuuSoDu.ForeColor = SystemColors.ControlDarkDark;
            btnTraCuuSoDu.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnTraCuuSoDu.IconColor = SystemColors.ControlDarkDark;
            btnTraCuuSoDu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnTraCuuSoDu.Location = new Point(0, 224);
            btnTraCuuSoDu.Margin = new Padding(0);
            btnTraCuuSoDu.Name = "btnTraCuuSoDu";
            btnTraCuuSoDu.Padding = new Padding(10, 0, 0, 0);
            btnTraCuuSoDu.Size = new Size(180, 53);
            btnTraCuuSoDu.TabIndex = 8;
            btnTraCuuSoDu.Text = "Tra cứu số dư";
            btnTraCuuSoDu.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnTraCuuSoDu.UseVisualStyleBackColor = true;
            btnTraCuuSoDu.Click += btnTraCuuSoDu_Click;
            // 
            // pFooter
            // 
            pFooter.BackColor = SystemColors.GradientInactiveCaption;
            pFooter.Dock = DockStyle.Bottom;
            pFooter.Location = new Point(0, 748);
            pFooter.Name = "pFooter";
            pFooter.Size = new Size(1291, 27);
            pFooter.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.2542381F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 84.74576F));
            tableLayoutPanel1.Controls.Add(pSidebar, 0, 0);
            tableLayoutPanel1.Controls.Add(pChild, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 49);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1291, 699);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // pChild
            // 
            pChild.Dock = DockStyle.Fill;
            pChild.Location = new Point(199, 3);
            pChild.Name = "pChild";
            pChild.Size = new Size(1089, 693);
            pChild.TabIndex = 2;
            // 
            // FMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1291, 775);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(pHeader);
            Controls.Add(pFooter);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NCB Banking";
            Load += FMain_Load;
            pSidebar.ResumeLayout(false);
            pSidebar.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            pMoreLenhChuyenTien.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pHeader;
        private Panel pSidebar;
        private Panel pFooter;
        private Panel panel1;
        private FontAwesome.Sharp.IconButton btnTrangChu;
        private FontAwesome.Sharp.IconButton btnLenhChuyenTien;
        private Panel panel2;
        private Panel pMoreLenhChuyenTien;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private FontAwesome.Sharp.IconButton btnDangXuat;
        private FontAwesome.Sharp.IconButton btnTraCuuSoDu;
        private TableLayoutPanel tableLayoutPanel3;
        private FontAwesome.Sharp.IconButton btnChuyenThuong;
        private FontAwesome.Sharp.IconButton btnChuyenNhanh;
        private Panel pChild;
    }
}