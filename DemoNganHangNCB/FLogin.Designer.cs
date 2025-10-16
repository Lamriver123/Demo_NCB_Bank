using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DemoNganHangNCB
{
    partial class FLogin
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
            panel1 = new Panel();
            btnLogin = new Button();
            label5 = new Label();
            txtPassword = new TextBox();
            label4 = new Label();
            txtUserName = new TextBox();
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
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtUserName);
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Location = new Point(454, 67);
            panel1.Name = "panel1";
            panel1.Size = new Size(407, 507);
            panel1.TabIndex = 0;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.ActiveCaption;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new System.Drawing.Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = SystemColors.ControlLightLight;
            btnLogin.Location = new Point(56, 381);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(313, 49);
            btnLogin.TabIndex = 8;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(59, 237);
            label5.Name = "label5";
            label5.Size = new Size(75, 21);
            label5.TabIndex = 6;
            label5.Text = "Mật khẩu";
            // 
            // txtPassword
            // 
            txtPassword.Font = new System.Drawing.Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(56, 262);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(313, 35);
            txtPassword.TabIndex = 5;
            txtPassword.Text = "Linkq@2025";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(59, 159);
            label4.Name = "label4";
            label4.Size = new Size(111, 21);
            label4.TabIndex = 4;
            label4.Text = "Tên đăng nhập";
            // 
            // txtUserName
            // 
            txtUserName.Font = new System.Drawing.Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUserName.Location = new Point(56, 184);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(313, 35);
            txtUserName.TabIndex = 3;
            txtUserName.Text = "LINKQTWO";
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
            // FLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(958, 666);
            Controls.Add(panel1);
            Name = "FLogin";
            Text = "Form1";
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
        private Label label5;
        private TextBox txtPassword;
        private Label label4;
        private TextBox txtUserName;
        private Button btnLogin;
    }
}
