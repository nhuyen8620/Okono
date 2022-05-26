using Okono;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Okono_Mmanagement
{
    public partial class FrmDaHoanThanhPDC : Form
    {
        private List<SanPham> danhSachSanPham = new List<SanPham>();
        DataTable pdcTable = new DataTable();
        public FrmDaHoanThanhPDC()
        {
            InitializeComponent();
        }

        private void FrmDaHoanThanhPDC_Load(object sender, EventArgs e)
        {
            // Lay danh sach phieu dieu chuyen
            reloadDanhSachPDC();
        }

        private void reloadDanhSachPDC()
        {
            // Lay lai danh sach phieu dieu chuyen
            string pdcQuery = "SELECT * FROM PhieuDieuChuyen WHERE TrangThai=N'Đã Hoàn Thành'";
            SqlDataAdapter pdcSqlData = new SqlDataAdapter(pdcQuery, Function.conn);
            pdcTable = new DataTable();
            pdcSqlData.Fill(pdcTable);
            cbMaPhieuDieuChuyen.DataSource = null;
            cbMaPhieuDieuChuyen.DataSource = pdcTable;
            cbMaPhieuDieuChuyen.ValueMember = pdcTable.Columns[0].ColumnName;
            cbMaPhieuDieuChuyen.DisplayMember = pdcTable.Columns[0].ColumnName;
        }

        private void cbMaPhieuDieuChuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaPhieuDieuChuyen.SelectedItem == null)
            {
                danhSachSanPham = new List<SanPham>();
                gridViewSanPham.DataSource = null;
            }
            else
            {
                reloadDanhSachSanPhamDaThem();
            }
        }
        private void reloadDanhSachSanPhamDaThem()
        {
            string maPhieuDieuChuyen = pdcTable.Rows[cbMaPhieuDieuChuyen.SelectedIndex].ItemArray[0].ToString();
            string chiTietPDCQuery = String.Format("SELECT sp.MaSanPham, sp.TenSanPham, c.SoLuongDC, sp.DonGiaBan, dv.TenDonViTinh FROM ChiTietPDC c LEFT JOIN SanPham sp ON c.MaSanPham = sp.MaSanPham LEFT JOIN DonViTinh dv ON sp.MaDonViTinh = dv.MaDonViTinh WHERE MaPhieuDieuChuyen = '{0}'", maPhieuDieuChuyen);
            SqlDataAdapter chiTietPDCSqlData = new SqlDataAdapter(chiTietPDCQuery, Function.conn);
            DataTable sanPhamTable = new DataTable();
            chiTietPDCSqlData.Fill(sanPhamTable);
            danhSachSanPham.Clear();
            foreach (DataRow row in sanPhamTable.Rows)
            {
                string maSanPham = row[0].ToString();
                string tenSanPham = row[1].ToString();
                int soLuong = Int32.Parse(row[2].ToString());
                string donGia = row[3].ToString();
                string donVi = row[4].ToString();
                SanPham sanPham = new SanPham()
                {
                    MaPhieuDieuChuyen = maPhieuDieuChuyen,
                    MaSanPham = maSanPham,
                    TenSanPham = tenSanPham,
                    KhoXuat = maSanPham,
                    KhoNhap = maSanPham,
                    SoLuong = soLuong,
                    DonVi = donVi,
                    DonGia = donGia
                };
                danhSachSanPham.Add(sanPham);
            }

            gridViewSanPham.DataSource = null;
            gridViewSanPham.DataSource = danhSachSanPham;
            DataGridViewColumn cotMaPhieuDC = gridViewSanPham.Columns["MaPhieuDieuChuyen"];
            DataGridViewColumn cotMaSanPham = gridViewSanPham.Columns["MaSanPham"];
            DataGridViewColumn cotTenSanPham = gridViewSanPham.Columns["TenSanPham"];
            DataGridViewColumn cotKhoXuat = gridViewSanPham.Columns["KhoXuat"];
            DataGridViewColumn cotKhoNhap = gridViewSanPham.Columns["KhoNhap"];
            DataGridViewColumn cotSoLuong = gridViewSanPham.Columns["SoLuong"];
            DataGridViewColumn cotDonVi = gridViewSanPham.Columns["DonVi"];
            DataGridViewColumn cotDonGia = gridViewSanPham.Columns["DonGia"];
            cotMaPhieuDC.ReadOnly = true;
            cotMaSanPham.ReadOnly = true;
            cotTenSanPham.ReadOnly = true;
            cotKhoXuat.ReadOnly = true;
            cotKhoNhap.ReadOnly = true;
            cotKhoXuat.Visible = false;
            cotKhoNhap.Visible = false;
            cotSoLuong.ReadOnly = true;
            cotDonVi.ReadOnly = true;
            cotDonGia.ReadOnly = true;

            cotMaPhieuDC.DisplayIndex = 0;
            cotMaSanPham.DisplayIndex = 1;
            cotTenSanPham.DisplayIndex = 2;
            cotKhoXuat.DisplayIndex = 3;
            cotKhoNhap.DisplayIndex = 4;
            cotSoLuong.DisplayIndex = 5;
            cotDonVi.DisplayIndex = 6;
            cotDonGia.DisplayIndex = 7;

            cotMaPhieuDC.HeaderText = "Mã Phiếu Điều Chuyển";
            cotMaSanPham.HeaderText = "Mã Sản Phẩm";
            cotTenSanPham.HeaderText = "Tên Sản Phẩm";
            cotKhoXuat.HeaderText = "Kho Xuất";
            cotKhoNhap.HeaderText = "Kho Nhập";
            cotSoLuong.HeaderText = "Số Lượng";
            cotDonVi.HeaderText = "Đơn Vị";
            cotDonGia.HeaderText = "Đơn Giá";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

