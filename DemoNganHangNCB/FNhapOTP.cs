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
    public partial class FNhapOTP : Form
    {
        public FNhapOTP(string userName, string passWord)
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            AppState.Reset();

            using (var fLogin = new FLogin())
            {
                fLogin.ShowDialog();
            }
        }
    }
}
