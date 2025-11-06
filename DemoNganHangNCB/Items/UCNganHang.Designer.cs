namespace DemoNganHangNCB.Items
{
    partial class UCNganHang
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCNganHang));
            tableLayoutPanel1 = new TableLayoutPanel();
            lblNganHang = new Label();
            pictureBox1 = new PictureBox();
            lblCode = new Label();
            lblBin = new Label();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.408971F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 44.4591026F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(lblBin, 3, 0);
            tableLayoutPanel1.Controls.Add(lblNganHang, 1, 0);
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(lblCode, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(758, 30);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblNganHang
            // 
            lblNganHang.AutoSize = true;
            lblNganHang.Dock = DockStyle.Fill;
            lblNganHang.Location = new Point(44, 0);
            lblNganHang.Name = "lblNganHang";
            lblNganHang.Size = new Size(331, 30);
            lblNganHang.TabIndex = 1;
            lblNganHang.Text = "Ngân hàng (NH)";
            lblNganHang.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(35, 24);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Dock = DockStyle.Fill;
            lblCode.Location = new Point(381, 0);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(183, 30);
            lblCode.TabIndex = 3;
            lblCode.Text = "label2";
            lblCode.Visible = false;
            // 
            // lblBin
            // 
            lblBin.AutoSize = true;
            lblBin.Dock = DockStyle.Fill;
            lblBin.Location = new Point(570, 0);
            lblBin.Name = "lblBin";
            lblBin.Size = new Size(185, 30);
            lblBin.TabIndex = 4;
            lblBin.Text = "label1";
            lblBin.Visible = false;
            // 
            // UCNganHang
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "UCNganHang";
            Size = new Size(758, 30);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label lblNganHang;
        private PictureBox pictureBox1;
        private Label lblCode;
        private Label lblBin;
    }
}
