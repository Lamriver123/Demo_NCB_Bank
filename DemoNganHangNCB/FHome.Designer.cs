using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DemoNganHangNCB
{
    partial class FHome
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
            pHeader = new Panel();
            pSidebar = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            btnTrangChu = new FontAwesome.Sharp.IconButton();
            btnLenhChuyenTien = new FontAwesome.Sharp.IconButton();
            pMoreLenhChuyenTien = new Panel();
            label1 = new Label();
            btnChuyenNhanh = new Label();
            btnDangXuat = new FontAwesome.Sharp.IconButton();
            pFooter = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnTraCuuSoDu = new FontAwesome.Sharp.IconButton();
            pSidebar.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            pMoreLenhChuyenTien.SuspendLayout();
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
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(btnTraCuuSoDu, 0, 3);
            tableLayoutPanel2.Controls.Add(btnTrangChu, 0, 0);
            tableLayoutPanel2.Controls.Add(btnLenhChuyenTien, 0, 1);
            tableLayoutPanel2.Controls.Add(pMoreLenhChuyenTien, 0, 2);
            tableLayoutPanel2.Controls.Add(btnDangXuat, 0, 5);
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
            tableLayoutPanel2.Size = new Size(180, 363);
            tableLayoutPanel2.TabIndex = 7;
            // 
            // btnTrangChu
            // 
            btnTrangChu.BackColor = Color.MediumTurquoise;
            btnTrangChu.Dock = DockStyle.Fill;
            btnTrangChu.FlatStyle = FlatStyle.Flat;
            btnTrangChu.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTrangChu.ForeColor = SystemColors.ControlLightLight;
            btnTrangChu.IconChar = FontAwesome.Sharp.IconChar.House;
            btnTrangChu.IconColor = Color.WhiteSmoke;
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
            // 
            // btnLenhChuyenTien
            // 
            btnLenhChuyenTien.BackColor = Color.LightBlue;
            btnLenhChuyenTien.Dock = DockStyle.Fill;
            btnLenhChuyenTien.FlatStyle = FlatStyle.Flat;
            btnLenhChuyenTien.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLenhChuyenTien.ForeColor = SystemColors.ControlDarkDark;
            btnLenhChuyenTien.IconChar = FontAwesome.Sharp.IconChar.MoneyBill1;
            btnLenhChuyenTien.IconColor = SystemColors.ControlDarkDark;
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
            pMoreLenhChuyenTien.AutoSize = true;
            pMoreLenhChuyenTien.Controls.Add(label1);
            pMoreLenhChuyenTien.Controls.Add(btnChuyenNhanh);
            pMoreLenhChuyenTien.Dock = DockStyle.Fill;
            pMoreLenhChuyenTien.Location = new Point(0, 124);
            pMoreLenhChuyenTien.Margin = new Padding(0);
            pMoreLenhChuyenTien.Name = "pMoreLenhChuyenTien";
            pMoreLenhChuyenTien.Padding = new Padding(5, 0, 5, 5);
            pMoreLenhChuyenTien.Size = new Size(180, 71);
            pMoreLenhChuyenTien.TabIndex = 6;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Dock = DockStyle.Top;
            label1.FlatStyle = FlatStyle.Popup;
            label1.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(5, 33);
            label1.Name = "label1";
            label1.Padding = new Padding(25, 5, 5, 5);
            label1.Size = new Size(170, 33);
            label1.TabIndex = 1;
            label1.Text = "> Chuyển thường";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnChuyenNhanh
            // 
            btnChuyenNhanh.BackColor = Color.Transparent;
            btnChuyenNhanh.Dock = DockStyle.Top;
            btnChuyenNhanh.FlatStyle = FlatStyle.Popup;
            btnChuyenNhanh.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnChuyenNhanh.ForeColor = SystemColors.ActiveCaptionText;
            btnChuyenNhanh.Location = new Point(5, 0);
            btnChuyenNhanh.Name = "btnChuyenNhanh";
            btnChuyenNhanh.Padding = new Padding(25, 5, 5, 5);
            btnChuyenNhanh.Size = new Size(170, 33);
            btnChuyenNhanh.TabIndex = 0;
            btnChuyenNhanh.Text = "> Chuyển nhanh";
            btnChuyenNhanh.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnDangXuat
            // 
            btnDangXuat.FlatStyle = FlatStyle.Flat;
            btnDangXuat.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDangXuat.ForeColor = SystemColors.ControlDarkDark;
            btnDangXuat.IconChar = FontAwesome.Sharp.IconChar.DoorOpen;
            btnDangXuat.IconColor = SystemColors.ControlDarkDark;
            btnDangXuat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnDangXuat.Location = new Point(0, 248);
            btnDangXuat.Margin = new Padding(0);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Padding = new Padding(10, 0, 0, 0);
            btnDangXuat.Size = new Size(180, 53);
            btnDangXuat.TabIndex = 7;
            btnDangXuat.Text = "Đăng xuất";
            btnDangXuat.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDangXuat.UseVisualStyleBackColor = true;
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
            // btnTraCuuSoDu
            // 
            btnTraCuuSoDu.FlatStyle = FlatStyle.Flat;
            btnTraCuuSoDu.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTraCuuSoDu.ForeColor = SystemColors.ControlDarkDark;
            btnTraCuuSoDu.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnTraCuuSoDu.IconColor = SystemColors.ControlDarkDark;
            btnTraCuuSoDu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnTraCuuSoDu.Location = new Point(0, 195);
            btnTraCuuSoDu.Margin = new Padding(0);
            btnTraCuuSoDu.Name = "btnTraCuuSoDu";
            btnTraCuuSoDu.Padding = new Padding(10, 0, 0, 0);
            btnTraCuuSoDu.Size = new Size(180, 53);
            btnTraCuuSoDu.TabIndex = 8;
            btnTraCuuSoDu.Text = "Tra cứu số dư";
            btnTraCuuSoDu.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnTraCuuSoDu.UseVisualStyleBackColor = true;
            // 
            // FHome
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1291, 775);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(pHeader);
            Controls.Add(pFooter);
            Name = "FHome";
            Text = "FHome";
            pSidebar.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            pMoreLenhChuyenTien.ResumeLayout(false);
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
        private Label label1;
        private Label btnChuyenNhanh;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private FontAwesome.Sharp.IconButton btnDangXuat;
        private FontAwesome.Sharp.IconButton btnTraCuuSoDu;
    }
}