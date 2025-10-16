using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DemoNganHangNCB
{
    partial class FNhapOTP
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FNhapOTP));
            panel1 = new Panel();
            btnBack = new Button();
            reSendOTP = new LinkLabel();
            btnLogin = new Button();
            label4 = new Label();
            txtOTP = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnBack);
            panel1.Controls.Add(reSendOTP);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtOTP);
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Location = new Point(454, 67);
            panel1.Name = "panel1";
            panel1.Size = new Size(407, 507);
            panel1.TabIndex = 0;
            // 
            // btnBack
            // 
            btnBack.BackColor = SystemColors.AppWorkspace;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new System.Drawing.Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = SystemColors.ControlLightLight;
            btnBack.Location = new Point(56, 369);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(313, 49);
            btnBack.TabIndex = 12;
            btnBack.Text = "Quay lại";
            btnBack.UseVisualStyleBackColor = false;
            // 
            // reSendOTP
            // 
            reSendOTP.AutoSize = true;
            reSendOTP.Location = new Point(173, 293);
            reSendOTP.Name = "reSendOTP";
            reSendOTP.Size = new Size(64, 15);
            reSendOTP.TabIndex = 11;
            reSendOTP.TabStop = true;
            reSendOTP.Text = "Gửi lại OTP";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.ActiveCaption;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new System.Drawing.Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = SystemColors.ControlLightLight;
            btnLogin.Location = new Point(56, 424);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(313, 49);
            btnLogin.TabIndex = 10;
            btnLogin.Text = "Hoàn tất giao dịch";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // label4
            // 
            label4.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(56, 164);
            label4.Name = "label4";
            label4.Size = new Size(313, 50);
            label4.TabIndex = 4;
            label4.Text = "Lần đầu đăng nhập ở đây. Vui lòng \r\nnhập mã OTP đã gửi về điện thoại";
            // 
            // txtOTP
            // 
            txtOTP.Font = new System.Drawing.Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtOTP.Location = new Point(56, 220);
            txtOTP.Name = "txtOTP";
            txtOTP.Size = new Size(313, 35);
            txtOTP.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Controls.Add(label3);
            flowLayoutPanel1.Location = new Point(56, 31);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(5);
            flowLayoutPanel1.Size = new Size(209, 61);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(8, 5);
            label1.Name = "label1";
            label1.Size = new Size(51, 25);
            label1.TabIndex = 0;
            label1.Text = "NCB";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.HotTrack;
            label2.Location = new Point(65, 5);
            label2.Name = "label2";
            label2.Size = new Size(76, 25);
            label2.TabIndex = 1;
            label2.Text = "iziBank";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlDark;
            label3.Location = new Point(8, 30);
            label3.Name = "label3";
            label3.Size = new Size(169, 21);
            label3.TabIndex = 2;
            label3.Text = "Kính chào quý khách";
            // 
            // FNhapOTP
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(958, 666);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FNhapOTP";
            Text = "Đăng nhập";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label3;
        private Label label4;
        private TextBox txtOTP;
        private Button btnLogin;
        private Button btnBack;
        private LinkLabel reSendOTP;
    }
}
