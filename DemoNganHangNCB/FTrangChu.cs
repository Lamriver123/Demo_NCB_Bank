using DemoNganHangNCB.Models;
using DemoNganHangNCB.Services;
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
    public partial class FTrangChu : Form
    {
        public event Action? LogoutRequested;

        private List<LenhCKThuong> lenhCKTrongNgay;
        private List<LenhCKThuong> lenhCKCho;
        private List<LenhCKChiTiet> tatCaLenhCK;
        private int curPage = 1;
        private int totalPage = 1;
        public FTrangChu()
        {

            InitializeComponent();
            pContent.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void btnPre_Click(object sender, EventArgs e)
        {
            if (curPage > 0)
            {
                btnPre.Enabled = false;
                btnNext.Enabled = false;
                curPage -= 1;
                lblCurPage.Text = curPage.ToString();
                await LoadTatCaLenhAsync(curPage.ToString());
                btnPre.Enabled = true;
                btnNext.Enabled = true;
            }
        }

        private async void FTrangChu_Load(object sender, EventArgs e)
        {
            await LoadLenhChoAsync();
            await LoadLenhTrongNgayAsync();
            await LoadTatCaLenhAsync("1");
            pContent.Show();
        }

        private async Task LoadLenhChoAsync()
        {
            var traCuuService = new TraCuuService(AppState.virtualWeb);
            var data = await traCuuService.TraCuuDanhSachLenhThuong("WAITING");
            if (data == null)
            {
                MessageBox.Show("Phiên đăng nhập kết thúc, vui lòng đăng nhập lại", "Thông báo");
                LogoutRequested?.Invoke();

                return;
            }
            if (data.code == 200)
            {
                lblDanhSachCho.Text = "Danh sách lệnh chờ xử lý ( " + data.data.pagination.totalElements.ToString() + " )";
                lenhCKCho = data.data.content;
                dvDanhSachCho.Rows.Clear();
                int i = 1;
                foreach (var t in lenhCKCho)
                {
                    dvDanhSachCho.Rows.Add(
                        i,
                        t.typeTran,
                        t.createdBy,
                        t.createAtTran,
                        "",
                        t.amountTran,
                        t.beneficiaryName,
                        t.lastApprover,
                        t.typeTran,
                        "Xem"
                    );
                    i++;
                }
            }

        }

        private async Task LoadLenhTrongNgayAsync()
        {
            var traCuuService = new TraCuuService(AppState.virtualWeb);
            var data = await traCuuService.TraCuuDanhSachLenhThuong("APPROVED");
            if (data == null)
            {
                MessageBox.Show("Phiên đăng nhập kết thúc, vui lòng đăng nhập lại", "Thông báo");
                LogoutRequested?.Invoke();

                return;
            }
            if (data.code == 200)
            {
                lblDanhSachLenhNgay.Text = "Danh sách lệnh trong ngày ( " + data.data.pagination.totalElements.ToString() + " )";
                lenhCKTrongNgay = data.data.content;
                dvDanhSachTrongNgay.Rows.Clear();
                int i = 1;
                foreach (var t in lenhCKTrongNgay)
                {
                    dvDanhSachTrongNgay.Rows.Add(
                        i,
                        t.typeTran(),
                        t.createdBy,
                        t.createAtTran().ToString("dd/MM/yyyy HH:mm"),
                        "",
                        t.amountTran(),
                        t.beneficiaryName,
                        t.lastApprover,
                        t.statusTran(),
                        "Xem"
                    );
                    i++;
                }
            }
            else
            {
                MessageBox.Show("Thất bại");
            }

        }

        private async Task LoadTatCaLenhAsync(string page)
        {

            var traCuuService = new TraCuuService(AppState.virtualWeb);
            var data = await traCuuService.TraCuuDanhSachLenhChiTiet("APPROVED", page);
            if (data == null)
            {
                MessageBox.Show("Phiên đăng nhập kết thúc, vui lòng đăng nhập lại", "Thông báo");
                LogoutRequested?.Invoke();

                return;
            }
            if (data.code == 200)
            {
                
                lbldanhSachLenhT.Text = "Danh sách lệnh ( " + data.data.pagination.totalElements.ToString() + " )";
                lblTongTrang.Text = "Tổng trang: " + data.data.pagination.totalPages.ToString();
                totalPage = data.data.pagination.totalPages;
                tatCaLenhCK = data.data.content;
                dvDanhSachLenh.Rows.Clear();
                int i = 1;
                foreach (var t in tatCaLenhCK)
                {
                    dvDanhSachLenh.Rows.Add(
                    i,
                        t.channelName,
                        t.debitAcctNo,
                        t.creator,
                        t.createAtTran().ToString("dd/MM/yyyy HH:mm"),
                        "",
                        t.amountTran(),
                        t.creditAcctName,
                        t.lastApprover,
                        t.statusTran(),
                        "Xem"
                    );
                    i++;
                }
            }
            else
            {
                MessageBox.Show("Thất bại");
            }


        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            if(curPage < totalPage)
            {
                btnNext.Enabled = false;
                btnPre.Enabled = false;
                curPage += 1;
                lblCurPage.Text = curPage.ToString();
                await LoadTatCaLenhAsync(curPage.ToString());
                btnNext.Enabled = true;
                btnPre.Enabled = true;
            }
        }
    }
}
