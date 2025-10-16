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
    public partial class FHome : Form
    {
        public FHome()
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

    }
}
