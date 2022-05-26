using Okono;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Okono_Mmanagement
{
    public partial class FrmTrangChuNhanVien : Form
    {
        public FrmTrangChuNhanVien()
        {
            InitializeComponent();
        }

        

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void mnuSanPham_Click(object sender, EventArgs e)
        {
            Okono_Mmanagement.FrmSanPham f = new Okono_Mmanagement.FrmSanPham();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            FrmNhanVien f = new FrmNhanVien();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {

        }

        private void mnuBanHang_Click(object sender, EventArgs e)
        {
            Okono_Mmanagement.FrmHoaDonBan f = new Okono_Mmanagement.FrmHoaDonBan();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuNhapHang_Click(object sender, EventArgs e)
        {
            Okono_Mmanagement.FrmDatHang f = new Okono_Mmanagement.FrmDatHang();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void mnuXuatHang_Click(object sender, EventArgs e)
        {

        }

        private void mnuTraHang_Click(object sender, EventArgs e)
        {

        }

        private void mnCaLamViec_Click(object sender, EventArgs e)
        {

        }

        private void mnuDoanhThuTuan_Click(object sender, EventArgs e)
        {

        }

        private void mnuDoanhThuQuy_Click(object sender, EventArgs e)
        {

        }

        private void mnuDoanhThuThang_Click(object sender, EventArgs e)
        {

        }

        private void mnuDoanhThuNam_Click(object sender, EventArgs e)
        {

        }

        private void mnThoat_Click(object sender, EventArgs e)
        {
            Function.CloseConnetion();
            Application.Exit();
        }

        private void mnDangNhap_Click(object sender, EventArgs e)
        {

            Okono_Mmanagement.FrmDatHang f = new Okono_Mmanagement.FrmDatHang();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void quảnLýDoanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Okono_Mmanagement.FrmQuanLyDoanhThu f = new Okono_Mmanagement.FrmQuanLyDoanhThu();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void quảnLýHoáĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Okono_Mmanagement.FrmThongKe f = new Okono_Mmanagement.FrmThongKe();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void phiếuXuấtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPhieuDieuChuyen f = new FrmPhieuDieuChuyen();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();

        }

        private void phiếuChốtCaToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Function.CloseConnetion();
            Application.Exit();
        }

        private void đăngNhậpLạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmDangNhap f = new FrmDangNhap();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void xácNhậnVàTìmKiếmPDCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTimKiemPDC f = new FrmTimKiemPDC();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void phiếuĐiềuChuyểnĐãHoànThànhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDaHoanThanhPDC f = new FrmDaHoanThanhPDC();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void FrmTrangChuNhanVien_Load(object sender, EventArgs e)
        {

        }
    }
}
