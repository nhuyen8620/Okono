using Okono;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Okono_Mmanagement
{
    public partial class FrmTimKiemPDC : Form
    {
        DataTable pdcTable = new DataTable();
        DataTable coSoTable = new DataTable();
        DataTable nhanVienNhapTable = new DataTable();
        private List<SanPhamDC> danhSachSanPhamDC = new List<SanPhamDC>();
        private List<SanPham> danhSachSanPham = new List<SanPham>();

        public FrmTimKiemPDC()
        {
            InitializeComponent();
        }

        private void FrmTimKiemPDC_Load(object sender, EventArgs e)
        {
            // Lay danh sach ma co so
            string coSoQuery = "SELECT MaCoSo FROM CoSo";
            SqlDataAdapter coSoSqlData = new SqlDataAdapter(coSoQuery, Function.conn);
            coSoSqlData.Fill(coSoTable);
            cbMaCoSoNhan.DataSource = coSoTable;
            cbMaCoSoNhan.ValueMember = coSoTable.Columns[0].ColumnName;
            cbMaCoSoNhan.DisplayMember = coSoTable.Columns[0].ColumnName;
            cbMaCoSoNhan.SelectedItem = null;

            // Lay danh sach nhan vien
            string nhanVienQuery = "SELECT MaNhanVien, TenNhanVien FROM NhanVien";
            SqlDataAdapter nhanVienSqlData = new SqlDataAdapter(nhanVienQuery, Function.conn);

            nhanVienSqlData.Fill(nhanVienNhapTable);
            cbMaNhanVienNhap.DataSource = nhanVienNhapTable;
            cbMaNhanVienNhap.ValueMember = nhanVienNhapTable.Columns[0].ColumnName;
            cbMaNhanVienNhap.DisplayMember = nhanVienNhapTable.Columns[0].ColumnName;
            cbMaNhanVienNhap.SelectedItem = null;

            // Lay danh sach phieu dieu chuyen
            reloadDanhSachPDC();
        }

        private void cbMaPhieuDieuChuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaPhieuDieuChuyen.SelectedItem == null)
            {
                cbMaCoSoNhan.SelectedItem = null;
                cbMaNhanVienNhap.SelectedItem = null;
                tbNgayNhap.Text = "";
                tbNgayXuat.Text = "";
                tbTenNhanVien.Text = "";
                danhSachSanPhamDC = new List<SanPhamDC>();
                gridViewSanPham.DataSource = null;
            }
            else
            {
                reloadData();
            }
        }

        private void reloadData()
        {
            cbMaCoSoNhan.SelectedIndex = cbMaCoSoNhan.FindStringExact(pdcTable.Rows[cbMaPhieuDieuChuyen.SelectedIndex].ItemArray[3].ToString());
            cbMaNhanVienNhap.SelectedIndex = cbMaNhanVienNhap.FindStringExact(pdcTable.Rows[cbMaPhieuDieuChuyen.SelectedIndex].ItemArray[2].ToString());
            cbMaNhanVienNhap.SelectedIndex = cbMaNhanVienNhap.FindStringExact(pdcTable.Rows[cbMaPhieuDieuChuyen.SelectedIndex].ItemArray[1].ToString());
            string ngayXuat = pdcTable.Rows[cbMaPhieuDieuChuyen.SelectedIndex].ItemArray[4].ToString();
            if (ngayXuat != "")
            {
                tbNgayXuat.Text = DateTime.Parse(ngayXuat).ToString("yyyy-MM-dd");
            }
            else
            {
                tbNgayXuat.Text = "";
            }
            string ngayNhap = pdcTable.Rows[cbMaPhieuDieuChuyen.SelectedIndex].ItemArray[5].ToString();
            if (ngayNhap != "")
            {
                tbNgayNhap.Text = DateTime.Parse(ngayNhap).ToString("yyyy-MM-dd");
            }
            else
            {
                tbNgayNhap.Text = "";
            }

            // Lay danh sach san pham
            reloadDanhSachSanPhamDaThem();
        }

        private void cbMaNhanVienXuat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaNhanVienNhap.SelectedItem == null)
            {
                tbTenNhanVien.Text = "";
            }
            else
            {
                tbTenNhanVien.Text = nhanVienNhapTable.Rows[cbMaNhanVienNhap.SelectedIndex].ItemArray[1].ToString();
            }
        }

        // Danh dau co sua so luong san pham khong
        bool isEditChiTietPDC = false;
        private void btnLuu_Click(object sender, EventArgs e)
        {
            bool success = false;
            // Cap nhat so luong trong chi tiet pdc
            if (isEditChiTietPDC)
            {
                foreach (SanPhamDC sanPhamDC in danhSachSanPhamDC)
                {
                    // Kiem tra so luong ton
                    string maSanPham = sanPhamDC.MaSanPham;
                    string sanPhamQuery = String.Format("SELECT SoLuongTon FROM SanPham WHERE MaSanPham='{0}'", maSanPham);
                    SqlDataAdapter sanPhamSqlData = new SqlDataAdapter(sanPhamQuery, Function.conn);
                    DataTable spdt = new DataTable();
                    sanPhamSqlData.Fill(spdt);
                    if (spdt.Rows.Count > 0)
                    {
                        int soLuongTonCu = int.Parse(spdt.Rows[0][0].ToString());
                        int soLuongCu = sanPhamDC.SoLuong;
                        int soLuongMoi = sanPhamDC.SoLuongMoi;
                        int chenhLech = soLuongMoi - soLuongCu;
                        if (chenhLech > soLuongTonCu)
                        {
                            MessageBox.Show("Số lượng sản phẩm vượt quá số lượng tồn!");
                        }
                        else
                        {
                            // Giam so luong ton
                            int soLuongTonMoi = soLuongTonCu - chenhLech;
                            string suaSoLuongTonSql = String.Format("UPDATE SanPham SET SoLuongTon = {0} WHERE MaSanPham = '{1}'", soLuongTonMoi, maSanPham);
                            SqlCommand suaSoLuongTonCmd = new SqlCommand();
                            suaSoLuongTonCmd.Connection = Function.conn;
                            suaSoLuongTonCmd.CommandText = suaSoLuongTonSql;
                            using (DbDataReader suaSoLuongTonReader = suaSoLuongTonCmd.ExecuteReader())
                            {
                                suaSoLuongTonReader.Close();
                            }

                            string suaChiTietPhieuDieuChuyenSql = String.Format("UPDATE ChiTietPDC SET SoLuongDC={0} WHERE MaPhieuDieuChuyen='{1}' AND MaSanPham='{2}'", soLuongMoi, cbMaPhieuDieuChuyen.SelectedValue, maSanPham);
                            SqlCommand suaChiTietPhieuDieuChuyenCmd = new SqlCommand();
                            suaChiTietPhieuDieuChuyenCmd.Connection = Function.conn;
                            suaChiTietPhieuDieuChuyenCmd.CommandText = suaChiTietPhieuDieuChuyenSql;
                            using (DbDataReader suaChiTietPhieuDieuChuyenReader = suaChiTietPhieuDieuChuyenCmd.ExecuteReader())
                            {
                                if (suaChiTietPhieuDieuChuyenReader.RecordsAffected > 0)
                                {
                                    success = true;
                                }
                                else
                                {
                                    MessageBox.Show("Sửa chi tiết phiếu điều chuyển thất bại!");
                                    success = false;
                                }
                                suaChiTietPhieuDieuChuyenReader.Close();
                            }
                        }
                    }
                    isEditChiTietPDC = false;
                }
            }
            if (success)
            {
                // Sua phieu dieu chuyen
                string suaPhieuDieuChuyenSql = String.Format("UPDATE PhieuDieuChuyen SET MaNhanVien='{0}', MaCoSo='{1}' WHERE MaPhieuDieuChuyen='{2}'", cbMaNhanVienNhap.SelectedValue, cbMaCoSoNhan.SelectedValue, cbMaPhieuDieuChuyen.SelectedValue);
                SqlCommand suaPhieuDieuChuyenCmd = new SqlCommand();
                suaPhieuDieuChuyenCmd.Connection = Function.conn;
                suaPhieuDieuChuyenCmd.CommandText = suaPhieuDieuChuyenSql;
                using (DbDataReader suaPhieuDieuChuyenReader = suaPhieuDieuChuyenCmd.ExecuteReader())
                {
                    if (suaPhieuDieuChuyenReader.RecordsAffected > 0)
                    {
                        MessageBox.Show("Thành công!");
                        success = true;
                    }
                    else
                    {
                        MessageBox.Show("Sửa phiếu điều chuyển thất bại!");
                        success = false;
                    }
                    suaPhieuDieuChuyenReader.Close();
                }
            }
            if (success)
            {
                // Lay lai danh sach phieu dieu chuyen
                reloadDanhSachPDC();
            }
        }

        private void reloadDanhSachPDC()
        {
            // Lay lai danh sach phieu dieu chuyen
            string pdcQuery = "SELECT * FROM PhieuDieuChuyen WHERE TrangThai=N'Đang Tiến Hành'";
            SqlDataAdapter pdcSqlData = new SqlDataAdapter(pdcQuery, Function.conn);
            pdcTable = new DataTable();
            pdcSqlData.Fill(pdcTable);
            cbMaPhieuDieuChuyen.DataSource = null;
            cbMaPhieuDieuChuyen.DataSource = pdcTable;
            cbMaPhieuDieuChuyen.ValueMember = pdcTable.Columns[0].ColumnName;
            cbMaPhieuDieuChuyen.DisplayMember = pdcTable.Columns[0].ColumnName;
        }

        private void reloadDanhSachSanPhamDaThem()
        {
            string maPhieuDieuChuyen = pdcTable.Rows[cbMaPhieuDieuChuyen.SelectedIndex].ItemArray[0].ToString();
            string chiTietPDCQuery = String.Format("SELECT sp.MaSanPham, sp.TenSanPham, c.SoLuongDC, sp.DonGiaBan, dv.TenDonViTinh FROM ChiTietPDC c LEFT JOIN SanPham sp ON c.MaSanPham = sp.MaSanPham LEFT JOIN DonViTinh dv ON sp.MaDonViTinh = dv.MaDonViTinh WHERE MaPhieuDieuChuyen = '{0}'", maPhieuDieuChuyen);
            SqlDataAdapter chiTietPDCSqlData = new SqlDataAdapter(chiTietPDCQuery, Function.conn);
            DataTable sanPhamTable = new DataTable();
            chiTietPDCSqlData.Fill(sanPhamTable);
            danhSachSanPhamDC.Clear();
            foreach (DataRow row in sanPhamTable.Rows)
            {
                string maSanPham = row[0].ToString();
                string tenSanPham = row[1].ToString();
                int soLuong = Int32.Parse(row[2].ToString());
                string donGia = row[3].ToString();
                string donVi = row[4].ToString();
                SanPhamDC sanPhamDC = new SanPhamDC()
                {
                    MaPhieuDieuChuyen = maPhieuDieuChuyen,
                    MaSanPham = maSanPham,
                    TenSanPham = tenSanPham,
                    KhoXuat = "",
                    KhoNhap = "",
                    SoLuong = soLuong,
                    DonVi = donVi,
                    DonGia = donGia,
                    SoLuongMoi = soLuong
                };
                danhSachSanPhamDC.Add(sanPhamDC);
                reloadDSSPDCGridView();
            }
        }

        private void reloadDSSPDCGridView()
        {
            gridViewSanPham.DataSource = null;
            gridViewSanPham.DataSource = danhSachSanPhamDC;
            DataGridViewColumn cotMaPhieuDC = gridViewSanPham.Columns["MaPhieuDieuChuyen"];
            DataGridViewColumn cotMaSanPham = gridViewSanPham.Columns["MaSanPham"];
            DataGridViewColumn cotTenSanPham = gridViewSanPham.Columns["TenSanPham"];
            DataGridViewColumn cotKhoXuat = gridViewSanPham.Columns["KhoXuat"];
            DataGridViewColumn cotKhoNhap = gridViewSanPham.Columns["KhoNhap"];
            DataGridViewColumn cotSoLuong = gridViewSanPham.Columns["SoLuong"];
            DataGridViewColumn cotSoLuongMoi = gridViewSanPham.Columns["SoLuongMoi"];
            DataGridViewColumn cotDonVi = gridViewSanPham.Columns["DonVi"];
            DataGridViewColumn cotDonGia = gridViewSanPham.Columns["DonGia"];
            cotMaPhieuDC.ReadOnly = true;
            cotMaSanPham.ReadOnly = true;
            cotTenSanPham.ReadOnly = true;
            cotKhoXuat.ReadOnly = true;
            cotKhoXuat.Visible = false;
            cotKhoNhap.ReadOnly = true;
            cotKhoNhap.Visible = false;
            cotSoLuong.ReadOnly = true;
            cotSoLuongMoi.ValueType = typeof(int);
            cotDonVi.ReadOnly = true;
            cotDonGia.ReadOnly = true;

            cotMaPhieuDC.DisplayIndex = 0;
            cotMaSanPham.DisplayIndex = 1;
            cotTenSanPham.DisplayIndex = 2;
            cotKhoXuat.DisplayIndex = 3;
            cotKhoNhap.DisplayIndex = 4;
            cotSoLuong.DisplayIndex = 5;
            cotSoLuongMoi.DisplayIndex = 6;
            cotDonVi.DisplayIndex = 7;
            cotDonGia.DisplayIndex = 8;

            cotMaPhieuDC.HeaderText = "Mã Phiếu Điều Chuyển";
            cotMaSanPham.HeaderText = "Mã Sản Phẩm";
            cotTenSanPham.HeaderText = "Tên Sản Phẩm";
            cotKhoXuat.HeaderText = "Kho Xuất";
            cotKhoNhap.HeaderText = "Kho Nhập";
            cotSoLuong.HeaderText = "Số Lượng Cũ";
            cotSoLuongMoi.HeaderText = "Số Lượng Mới";
            cotDonVi.HeaderText = "Đơn Vị";
            cotDonGia.HeaderText = "Đơn Giá";
        }

        private void dataGridViewSanPham_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            isEditChiTietPDC = true;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            bool success = true;
            // Cap nhat trang thai phieu dieu chuyen
            string capNhatTrangThaiSql = String.Format("UPDATE PhieuDieuChuyen SET TrangThai=N'Đã Hoàn Thành' WHERE MaPhieuDieuChuyen='"+ cbMaPhieuDieuChuyen.Text + "'");
            SqlCommand capNhatTrangThaiCmd = new SqlCommand();
            capNhatTrangThaiCmd.Connection = Function.conn;
            capNhatTrangThaiCmd.CommandText = capNhatTrangThaiSql;
            using (DbDataReader capNhatTrangThaiReader = capNhatTrangThaiCmd.ExecuteReader())
            {
                if (capNhatTrangThaiReader.RecordsAffected <= 0)
                {
                    success = false;
                }
                capNhatTrangThaiReader.Close();
            }
            if (success)
            {
                // Tang so luong san pham
                foreach (SanPhamDC sanPhamDC in danhSachSanPhamDC)
                {
                    // Kiem tra so luong ton
                    string maSanPham = sanPhamDC.MaSanPham;
                    string sanPhamQuery = String.Format("SELECT SoLuongTon FROM SanPham WHERE MaSanPham='{0}'", maSanPham);
                    SqlDataAdapter sanPhamSqlData = new SqlDataAdapter(sanPhamQuery, Function.conn);
                    DataTable spdt = new DataTable();
                    sanPhamSqlData.Fill(spdt);
                    if (spdt.Rows.Count > 0)
                    {
                        int soLuongTonCu = int.Parse(spdt.Rows[0][0].ToString());
                        int soLuongMoi = sanPhamDC.SoLuongMoi;
                        int soluongtonmoi = soLuongTonCu + soLuongMoi;


                        string suaSoLuongTonSql = String.Format("UPDATE SanPham SET SoLuongTon = {0} WHERE MaSanPham = '{1}'", soluongtonmoi, maSanPham);
                        SqlCommand suaSoLuongTonCmd = new SqlCommand();
                        suaSoLuongTonCmd.Connection = Function.conn;
                        suaSoLuongTonCmd.CommandText = suaSoLuongTonSql;
                        using (DbDataReader suaSoLuongTonReader = suaSoLuongTonCmd.ExecuteReader())
                        {
                            suaSoLuongTonReader.Close();
                        }

                    }
                }
                } else
            {
                MessageBox.Show("Cập nhật trạng thái phiếu điều chuyển thất bại!");
            }
            if (success)
            {
                MessageBox.Show("Thành công!");
                // Refresh lai danh sach
                reloadDanhSachPDC();
            }
            else
            {
                MessageBox.Show("Cập nhật số lượng sản phẩm thất bại!");
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void tbNgayNhap_TextChanged(object sender, EventArgs e)
        {
            if (tbNgayNhap.Text == "")
            {
                btnXacNhan.Enabled = false;
            } else
            {
                btnXacNhan.Enabled = true;
            }
        }

        private void cbMaCoSoNhan_SelectedValueChanged(object sender, EventArgs e)
        {
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
