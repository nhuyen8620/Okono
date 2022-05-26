using Okono_Mmanagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;
//using COMExcel = Microsoft.Office.Interop.Excel;

namespace Okono
{
    public partial class FrmPhieuDieuChuyen : Form
    {
        DataTable coSoTable = new DataTable();
        DataTable nhanVienNhapTable = new DataTable();
        DataTable nhanVienXuatTable = new DataTable();
        private List<SanPham> danhSachSanPhamDaThem = new List<SanPham>();
        public FrmPhieuDieuChuyen()
        {
            InitializeComponent();
            InitDatabase();
        }

        private void InitDatabase()
        {
            try
            {
                // Lay danh sach san pham
                string sanPhamQuery = "SELECT MaSanPham AS 'Mã Sản Phẩm', TenSanPham AS 'Tên Sản Phẩm'," +
                    " SoLuongTon AS 'Số Lượng Tồn', DonGiaBan AS 'Đơn Giá Bán', DonViTinh.TenDonViTinh AS 'Đơn Vị'" +
                    " FROM SanPham LEFT JOIN DonViTinh ON SanPham.MaDonViTinh = DonViTinh.MaDonViTinh where SanPham.DaXoa=0";
                SqlDataAdapter sanPhamSqlData = new SqlDataAdapter(sanPhamQuery, Function.conn);
                DataTable sanPhamTable = new DataTable();
                sanPhamSqlData.Fill(sanPhamTable);
                gridViewSanPham.DataSource = sanPhamTable;

                // Lay danh sach co so
                string coSoQuery = "SELECT MaCoSo, TenCoSo FROM CoSo";
                SqlDataAdapter coSoSqlData = new SqlDataAdapter(coSoQuery, Function.conn);
                coSoSqlData.Fill(coSoTable);
                cbCoSoNhan.DataSource = coSoTable;
                cbCoSoNhan.ValueMember = coSoTable.Columns[0].ColumnName;
                cbCoSoNhan.DisplayMember = coSoTable.Columns[0].ColumnName;
                cbCoSoNhan.SelectedItem = null;

                // Lay danh sach nhan vien
                string nhanVienQuery = "SELECT MaNhanVien, TenNhanVien FROM NhanVien where NhanVien.DaXoa=0";
                SqlDataAdapter nhanVienSqlData = new SqlDataAdapter(nhanVienQuery, Function.conn);
                nhanVienSqlData.Fill(nhanVienNhapTable);
                nhanVienSqlData.Fill(nhanVienXuatTable);

                cbMaNhanVienNhap.DataSource = nhanVienNhapTable;
                cbMaNhanVienNhap.ValueMember = nhanVienNhapTable.Columns[0].ColumnName;
                cbMaNhanVienNhap.DisplayMember = nhanVienNhapTable.Columns[0].ColumnName;
                cbMaNhanVienNhap.SelectedItem = null;

                cbMaNhanVien.DataSource = nhanVienXuatTable;
                cbMaNhanVien.ValueMember = nhanVienXuatTable.Columns[0].ColumnName;
                cbMaNhanVien.DisplayMember = nhanVienXuatTable.Columns[0].ColumnName;
                cbMaNhanVien.SelectedItem = null;

                reloadDanhSachSanPhamDaThem();

                tbNgayXuat.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void them_Click(object sender, EventArgs e)
        {
            resetValue();
            tbSoLuong.Enabled = true;
            cbMaSanPham.Enabled = true;
            tbSoLuong.Enabled = true;
            tbMaPhieuXuatHang.Text = Function.CreateKey("PDC");
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnIn.Enabled = false;
            btnThoat.Enabled = false;
            tbMaPhieuXuatHang.ReadOnly = false;
            tbMaSanPham.ReadOnly = false;
            tbNgayNhap.ReadOnly = false;
            tbNgayXuat.ReadOnly = false;
            tbSearchMaSanPham.ReadOnly = false;
            tbSearchMaSanPhamDaThem.ReadOnly = false;
            tbTenNhanVien.ReadOnly = false;
            tbSearchMaSanPhamDaThem.ReadOnly = false;
            cbCoSoNhan.Enabled = true;
            cbMaNhanVien.Enabled = true;
            cbMaNhanVienNhap.Enabled = true;
            cbMaSanPham.Enabled = true;
            btnXoaSearchMaSanPhamDaThem.Enabled = true;
            tbTenSanPham.ReadOnly = false;
        }
        public void resetValue()
        {
            tbMaPhieuXuatHang.Text = "";
            tbTenNhanVien.Text = "";
            tbMaSanPham.Text = "";
            tbTenSanPham.Text = "";
            tbNgayXuat.Text = DateTime.Now.ToString("dd/MM/yyyy");
            tbNgayNhap.Text = "";
            tbSoLuong.Value = 0;
            cbCoSoNhan.SelectedItem = null;
            cbMaNhanVienNhap.SelectedItem = null;
            cbMaNhanVien.SelectedItem = null;
            danhSachSanPhamDaThem.Clear();
            reloadDanhSachSanPhamDaThem();
        }

        private void tbSearchMaSanPham_TextChanged(object sender, EventArgs e)
        {
            // Search san pham theo ma san pham
            string sanPhamQuery = String.Format("SELECT MaSanPham, TenSanPham, SoLuongTon, DonGiaBan" +
                " FROM SanPham WHERE MaSanPham LIKE '%{0}%'", tbSearchMaSanPham.Text);
            SqlDataAdapter sanPhamSqlData = new SqlDataAdapter(sanPhamQuery, Function.conn);
            DataTable sanPhamTable = new DataTable();
            try
            {
                sanPhamSqlData.Fill(sanPhamTable);
                gridViewSanPham.DataSource = sanPhamTable;
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void cbMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaNhanVien.SelectedItem == null)
            {
                tbTenNhanVien.Text = "";
            }
            else
            {
                tbTenNhanVien.Text = nhanVienXuatTable.Rows[cbMaNhanVien.SelectedIndex].ItemArray[1].ToString();
                // Lay kho xuat
                string khoXuatQuery = String.Format("SELECT MaCoSo FROM NhanVien WHERE MaNhanVien='{0}'", cbMaNhanVien.SelectedValue);
                SqlDataAdapter khoXuatSqlData = new SqlDataAdapter(khoXuatQuery, Function.conn);
                DataTable khoXuatTable = new DataTable();
                khoXuatSqlData.Fill(khoXuatTable);
                if (khoXuatTable.Rows.Count > 0)
                {
                    string maCoSo = khoXuatTable.Rows[0][0].ToString();
                    if (maCoSo != null)
                    {
                        // Thay doi kho xuat
                        foreach (SanPham sanPham in danhSachSanPhamDaThem)
                        {
                            sanPham.KhoXuat = maCoSo;
                        }
                        reloadDanhSachSanPhamDaThem();
                    }
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Them phieu xuat hang
            if (cbCoSoNhan.SelectedItem == null ||
                cbMaNhanVien.SelectedItem == null ||
                tbMaSanPham.Text == "" ||
                tbTenSanPham.Text == "" ||
                tbNgayXuat.Text == "" ||
                tbMaPhieuXuatHang.Text == null ||
                tbMaPhieuXuatHang.Text == "" ||
                tbSoLuong.Value <= 0 ||
                danhSachSanPhamDaThem.Count == 0)
            {
                MessageBox.Show("Vui lòng nhập dữ liệu hợp lệ");
            }
            else
            {
                // Lay danh sach san pham
                string spQuery = "SELECT MaSanPham, SoLuongTon FROM SanPham WHERE SanPham.DaXoa = 0";
                SqlDataAdapter spSqlData = new SqlDataAdapter(spQuery, Function.conn);
                DataTable spTable = new DataTable();
                spSqlData.Fill(spTable);
                // Kiem tra so luong
                foreach (SanPham sanPham in danhSachSanPhamDaThem)
                {
                    for (int i = 0; i < spTable.Rows.Count; i++)
                    {
                        if (sanPham.MaSanPham.Equals(spTable.Rows[i][0]))
                        {
                            if (sanPham.SoLuong > Int32.Parse(spTable.Rows[i][1].ToString()))
                            {
                                // Qua so luong, khong luu duoc
                                MessageBox.Show(String.Format("Sản phẩm {0} vượt quá số lượng, không xuất được!", sanPham.TenSanPham));
                                return;
                            }
                        }
                    }
                }
                string themPhieuDieuChuyenSql = String.Format("INSERT INTO PhieuDieuChuyen(MaPhieuDieuChuyen, MaNhanVien, MaCoSo, NgayXuat, TrangThai) VALUES('{0}', '{1}', '{2}', '{3}', N'Đang Tiến Hành')",
                    tbMaPhieuXuatHang.Text, cbMaNhanVien.SelectedValue, cbCoSoNhan.SelectedValue, DateTime.Now.ToString("yyyy-MM-dd"));
                try
                {
                    SqlCommand themPhieuDieuChuyenCmd = new SqlCommand();
                    themPhieuDieuChuyenCmd.Connection = Function.conn;
                    themPhieuDieuChuyenCmd.CommandText = themPhieuDieuChuyenSql;
                    Boolean success = true;
                    using (DbDataReader themPhieuDieuChuyenReader = themPhieuDieuChuyenCmd.ExecuteReader())
                    {
                        if (themPhieuDieuChuyenReader.RecordsAffected <= 0)
                        {
                            success = false;
                        }
                        themPhieuDieuChuyenReader.Close();
                    }
                    if (success == true)
                    {
                        // Them chi tiet phieu xuat hang
                        foreach (SanPham sanPham in danhSachSanPhamDaThem)
                        {
                            string themChiTietPhieuDieuChuyenSql = String.Format("INSERT INTO ChiTietPDC(MaPhieuDieuChuyen, MaSanPham, SoLuongDC) VALUES('{0}', '{1}', '{2}')", tbMaPhieuXuatHang.Text, sanPham.MaSanPham, sanPham.SoLuong);
                            SqlCommand themChiTietPhieuDieuChuyenCmd = new SqlCommand();
                            themChiTietPhieuDieuChuyenCmd.Connection = Function.conn;
                            themChiTietPhieuDieuChuyenCmd.CommandText = themChiTietPhieuDieuChuyenSql;
                            using (DbDataReader themChiTietPhieuDieuChuyenReader = themChiTietPhieuDieuChuyenCmd.ExecuteReader())
                            {
                                if (themChiTietPhieuDieuChuyenReader.RecordsAffected <= 0)
                                {
                                    success = false;
                                }
                                themChiTietPhieuDieuChuyenReader.Close();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Thêm phiếu xuất hàng thất Bại");
                    }
                    if (success == true)
                    {
                        // Giam so luong san pham
                        foreach (SanPham sanPham in danhSachSanPhamDaThem)
                        {
                            string giamSoLuongSanPhamSql = String.Format("UPDATE SanPham SET SoLuongTon = SoLuongTon - {0} WHERE MaSanPham = '{1}'", sanPham.SoLuong, sanPham.MaSanPham);
                            SqlCommand giamSoLuongSanPhamCmd = new SqlCommand();
                            giamSoLuongSanPhamCmd.Connection = Function.conn;
                            giamSoLuongSanPhamCmd.CommandText = giamSoLuongSanPhamSql;
                            using (DbDataReader giamSoLuongSanPhamReader = giamSoLuongSanPhamCmd.ExecuteReader())
                            {
                                if (giamSoLuongSanPhamReader.RecordsAffected <= 0)
                                {
                                    success = false;
                                }
                                giamSoLuongSanPhamReader.Close();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Thêm chi tiết phiếu xuất hàng thất Bại");
                    }
                    if (success == true)
                    {
                        MessageBox.Show("Thành Công");
                    }
                    else
                    {
                        MessageBox.Show("Giảm số lượng tồn của sản phẩm thất Bại");
                    }
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.Message);
                }
                // Lay lai danh sach san pham
                string sanPhamQuery = "SELECT MaSanPham AS 'Mã Sản Phẩm', TenSanPham AS 'Tên Sản Phẩm'," +
                    " SoLuongTon AS 'Số Lượng Tồn', DonGiaBan AS 'Đơn Giá Bán', DonViTinh.TenDonViTinh AS 'Đơn Vị'" +
                    " FROM SanPham LEFT JOIN DonViTinh ON SanPham.MaDonViTinh = DonViTinh.MaDonViTinh WHERE SanPham.DaXoa = 0";
                SqlDataAdapter sanPhamSqlData = new SqlDataAdapter(sanPhamQuery, Function.conn);
                DataTable sanPhamTable = new DataTable();
                sanPhamSqlData.Fill(sanPhamTable);
                gridViewSanPham.DataSource = null;
                gridViewSanPham.DataSource = sanPhamTable;
                btnIn.Enabled = true;
                btnThem.Enabled = true;
                btnThoat.Enabled = true;
                cbMaSanPham.Enabled = false;
                btnHuy.Enabled = false;
                tbMaPhieuXuatHang.ReadOnly = true;
                tbMaSanPham.ReadOnly = true;
                tbNgayNhap.ReadOnly = true;
                tbNgayXuat.ReadOnly = true;
                tbSearchMaSanPham.ReadOnly = true;
                tbSearchMaSanPhamDaThem.ReadOnly = true;
                tbTenNhanVien.ReadOnly = true;
                tbSearchMaSanPhamDaThem.ReadOnly = true;
                tbSoLuong.Enabled = false;
                cbCoSoNhan.Enabled = false;
                cbMaNhanVien.Enabled = false;
                cbMaNhanVienNhap.Enabled = false;
                cbMaSanPham.Enabled = false;
                btnXoaSearchMaSanPhamDaThem.Enabled = false;
                tbTenSanPham.ReadOnly = true;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnXoaSearchMaSanPhamDaThem.Enabled = true;
            btnThoat.Enabled = true;
            btnLuu.Enabled = false;
            btnIn.Enabled = false;
            btnThem.Enabled = true;
            // Xoa het thong tin
            cbCoSoNhan.SelectedItem = null;
            cbCoSoNhan.SelectedItem = null;
            cbMaNhanVien.SelectedItem = null;
            tbTenNhanVien.Text = null;
            tbMaSanPham.Text = null;
            tbTenSanPham.Text = null;
            tbNgayXuat.Text = "";
            tbSoLuong.Value = 0;
            danhSachSanPhamDaThem.Clear();
            tbMaPhieuXuatHang.Text = "";
            tbSoLuong.Value = 0;
            reloadDanhSachSanPhamDaThem();
        }

        private void gridViewSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                tbMaSanPham.Text = gridViewSanPham[0, e.RowIndex].Value.ToString();
                tbTenSanPham.Text = gridViewSanPham[1, e.RowIndex].Value.ToString();
            }
        }

        private void tbSearchSanPhamDaThem_TextChanged(object sender, EventArgs e)
        {
            // Search danh sach san pham da them
            List<SanPham> searchDanhSachSanPhamDaThem = new List<SanPham>();
            foreach (SanPham sanPham in danhSachSanPhamDaThem)
            {
                if (sanPham.MaSanPham.Contains(tbSearchMaSanPhamDaThem.Text))
                {
                    searchDanhSachSanPhamDaThem.Add(sanPham);
                }
            }
            // Refresh danh sach san pham
            reloadDanhSachSanPhamDaThem();
        }

        private void btnXoaSearchMaSanPhamDaThem_Click(object sender, EventArgs e)
        {
            // Search danh sach san pham da them
            List<SanPham> searchDanhSachSanPhamDaThem = new List<SanPham>();
            foreach (SanPham sanPham in danhSachSanPhamDaThem)
            {
                if (sanPham.MaSanPham.Contains(tbSearchMaSanPhamDaThem.Text))
                {
                    searchDanhSachSanPhamDaThem.Add(sanPham);
                }
            }
            // Xoa danh sach san pham da them
            foreach (SanPham sanPham in searchDanhSachSanPhamDaThem)
            {
                if (danhSachSanPhamDaThem.Contains(sanPham))
                {
                    danhSachSanPhamDaThem.Remove(sanPham);
                }
            }
            // Refresh danh sach san pham
            reloadDanhSachSanPhamDaThem();
            // Xoa search danh sach san pham da them
            tbSearchMaSanPhamDaThem.Text = null;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            /* btnThoat.Enabled = true;
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            cbMaSanPham.Enabled = true;
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            DataTable tblThongtinHD;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = (COMExcel.Worksheet)exBook.Worksheets[1];
            // Định dạng chung
            exRange = (COMExcel.Range)exSheet.Cells[1, 1];
            exRange.Range["A1:G50"].Font.Name = "Times new roman";
            exRange.Range["A1:D3"].Font.Size = 10;
            exRange.Range["A1:D3"].Font.Name = "Times new roman";
            exRange.Range["A1:G3"].Font.Bold = true;
            exRange.Range["A1:D3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 25;
            exRange.Range["A1:D1"].MergeCells = true;
            exRange.Range["A1:D1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:D2"].MergeCells = true;
            exRange.Range["A2:D2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:D2"].Value = "72 Khương Trung - Thanh Xuân - Hà Nội";
            exRange.Range["A3:D3"].MergeCells = true;
            exRange.Range["A3:D3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:D3"].Value = "Điện thoại: (04)37562222";
            exRange.Range["A7:A7"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["B7:B7"].Value = "Tên nhân viên: ";
            exRange.Range["C7:D7"].MergeCells = true;
            exRange.Range["C7:D7"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignLeft;
            exRange.Range["C7:D7"].Value = tbTenNhanVien.Text;
            exRange.Range["A5:D5"].Font.Size = 16;
            exRange.Range["A5:E5"].Font.Name = "Times new roman";
            exRange.Range["A5:D5"].Font.Bold = true;
            exRange.Range["A5:D5"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["A5:D5"].MergeCells = true;
            exRange.Range["A5:D5"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A5:D5"].Value = "PHIẾU ĐIỀU CHUYỂN HÀNG";
            // Biểu diễn thông tin chung của hóa đơn bán
            sql = "SELECT a.MaPhieuDieuChuyen, a.NgayXuat, b.TenNhanVien FROM PhieuDieuChuyen AS a INNER JOIN NhanVien AS b ON a.MaNhanVien = b.MaNhanVien WHERE a.MaPhieuDieuChuyen = N'" + tbMaPhieuXuatHang.Text + "'";
            tblThongtinHD = Function.GetDataToTable(sql);
            if (tblThongtinHD.Rows.Count <= 0)
            {
                MessageBox.Show("Phải lưu phiếu xuất hàng trước");
            }
            else
            {
                // Ngay
                DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
                exRange.Range["A1:D1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
                exRange.Range["B6:C9"].Font.Size = 12;
                exRange.Range["B6:C9"].Font.Name = "Times new roman";
                exRange.Range["B6:B6"].Value = "Mã Phiếu xuất hàng:";
                exRange.Range["C6:D6"].MergeCells = true;
                exRange.Range["C6:D6"].Value = tblThongtinHD.Rows[0][0].ToString();
                //Tạo dòng tiêu đề bảng
                exRange.Range["A8:G8"].Font.Bold = true;
                exRange.Range["A8:E8"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["C8:E8"].ColumnWidth = 12;
                exRange.Range["A8:A8"].Value = "STT";
                exRange.Range["B8:B8"].Value = "Tên sản phẩm";
                exRange.Range["C8:C8"].Value = "Kho xuất";
                exRange.Range["D8:D8"].Value = "Kho nhập";
                exRange.Range["E8:E8"].Value = "Số lượng";
                exRange.Range["F8:F8"].Value = "Đơn vị";
                exRange.Range["G8:G8"].Value = "Đơn giá";
                int hang = 0;
                foreach (SanPham sanPham in danhSachSanPhamDaThem)
                {
                    //Điền số thứ tự vào cột 1 từ dòng 9
                    exSheet.Cells[hang + 9, 1] = hang + 1;
                    exSheet.Cells[hang + 9, 2] = sanPham.TenSanPham;
                    exSheet.Cells[hang + 9, 3] = sanPham.KhoXuat;
                    exSheet.Cells[hang + 9, 4] = sanPham.KhoNhap;
                    exSheet.Cells[hang + 9, 5] = sanPham.SoLuong;
                    exSheet.Cells[hang + 9, 6] = sanPham.DonVi;
                    exSheet.Cells[hang + 9, 7] = sanPham.DonGia;
                    hang++;
                }
                //exRange = (COMExcel.Range)exSheet.Cells[cot, hang + 11];
                //exRange.Font.Bold = true;
                //exRange.Value2 = "Tổng tiền:";
                //exRange = (COMExcel.Range)exSheet.Cells[cot + 1, hang + 11];
                exRange.Font.Bold = true;
                //exRange.Value2 = tblThongtinHD.Rows[0][2].ToString();
                exRange = (COMExcel.Range)exSheet.Cells[1, hang + 12]; //Ô A1 
                //exRange.Range["A1:D1"].MergeCells = true;
                //exRange.Range["A1:D1"].Font.Bold = true;
                //exRange.Range["A1:D1"].Font.Italic = true;
                //exRange.Range["A1:D1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
                //exRange.Range["A1:D1"].Value = "Bằng chữ: 12345";
                //exRange = (COMExcel.Range)exSheet.Cells[2, hang + 14]; //Ô A1 
                //exRange.Range["A1:D1"].MergeCells = true;
                //exRange.Range["A1:D1"].Font.Italic = true;
                //exRange.Range["A1:D1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                //exRange.Range["A2:C2"].MergeCells = true;
                //exRange.Range["A2:C2"].Font.Italic = true;
                //exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                //exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
                exRange.Range["A6:C6"].MergeCells = true;
                exRange.Range["A6:C6"].Font.Italic = true;
                exSheet.Name = "PHIẾU XUẤT HÀNG";
                exApp.Visible = true;
            }
        }

        private void cbMaSanPham_CheckedChanged(object sender, EventArgs e)
        {
            if (tbMaSanPham.Text == "" ||
                tbTenSanPham.Text == "" ||
                tbSoLuong.Value <= 0)
            {
                MessageBox.Show("Vui lòng nhập dữ liệu hợp lệ");
            }
            else
            {
                // Them 1 san pham hoac tang so luong
                bool tangSoluong = false;
                foreach (SanPham sanPham in danhSachSanPhamDaThem)
                {
                    if (sanPham.MaSanPham == tbMaSanPham.Text)
                    {
                        // Tang so luong
                        sanPham.SoLuong += (int)tbSoLuong.Value;
                        tangSoluong = true;
                    }
                }
                if (tangSoluong == false)
                {
                    // Neu khong tang so luong thi them san pham
                    // Lay kho xuat
                    string khoXuat = cbCoSoNhan.Text;
                    string khoXuatQuery = String.Format("SELECT MaCoSo FROM NhanVien WHERE MaNhanVien='{0}'", cbMaNhanVien.SelectedValue);
                    SqlDataAdapter khoXuatSqlData = new SqlDataAdapter(khoXuatQuery, Function.conn);
                    DataTable khoXuatTable = new DataTable();
                    khoXuatSqlData.Fill(khoXuatTable);
                    if (khoXuatTable.Rows.Count > 0)
                    {
                        // Thay doi kho xuat
                        khoXuat = khoXuatTable.Rows[0][0].ToString();
                        if (khoXuat != null)
                        {
                            khoXuat = cbCoSoNhan.Text;
                        }
                    }
                    danhSachSanPhamDaThem.Add(new SanPham()
                    {
                        MaPhieuDieuChuyen = tbMaPhieuXuatHang.Text,
                        MaSanPham = tbMaSanPham.Text,
                        TenSanPham = tbTenSanPham.Text,
                        KhoXuat = khoXuat,
                        KhoNhap = cbCoSoNhan.Text,
                        SoLuong = (int)tbSoLuong.Value,
                        DonVi = gridViewSanPham[4, gridViewSanPham.CurrentCell.RowIndex].Value.ToString(),
                        DonGia = gridViewSanPham[3, gridViewSanPham.CurrentCell.RowIndex].Value.ToString(),
                    });
                }
                // Refresh danh sach san pham
                reloadDanhSachSanPhamDaThem();
            }
            */
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            /*// Search san pham theo ma san pham
           string sanPhamQuery = String.Format("SELECT MaSanPham, TenSanPham, SoLuongTon, DonGiaBan" +
               " FROM SanPham WHERE MaSanPham LIKE '%{0}%'", tbSearchMaSanPham.Text);
           SqlDataAdapter sanPhamSqlData = new SqlDataAdapter(sanPhamQuery, Function.conn);
           DataTable sanPhamTable = new DataTable();
           try
           {
               sanPhamSqlData.Fill(sanPhamTable);
               gridViewSanPham.DataSource = sanPhamTable;
           }
           catch (Exception es)
           {
               MessageBox.Show(es.Message);
           }*/
        }

        private void FrmPhieuXuatHang_Load(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            cbMaSanPham.Enabled = false;
            btnIn.Enabled = false;
            btnThem.Enabled = true;
            btnHuy.Enabled = false;
            tbMaPhieuXuatHang.ReadOnly = true;
            tbMaSanPham.ReadOnly = true;
            tbNgayNhap.ReadOnly = true;
            tbNgayXuat.ReadOnly = true;
            tbSearchMaSanPham.ReadOnly = true;
            tbSearchMaSanPhamDaThem.ReadOnly = true;
            tbTenNhanVien.ReadOnly = true;
            tbSearchMaSanPhamDaThem.ReadOnly = true;
            tbSoLuong.Enabled = false;
            cbCoSoNhan.Enabled = false;
            cbMaNhanVien.Enabled = false;
            cbMaNhanVienNhap.Enabled = false;
            btnXoaSearchMaSanPhamDaThem.Enabled = false;
            btnThoat.Enabled = true;
            tbTenSanPham.ReadOnly = true;
        }

        private void reloadDanhSachSanPhamDaThem()
        {
            gridViewSanPhamDaThem.DataSource = null;
            gridViewSanPhamDaThem.DataSource = danhSachSanPhamDaThem;
            gridViewSanPhamDaThem.Columns[0].HeaderText = "Mã Phiếu Điều Chuyển";
            gridViewSanPhamDaThem.Columns[1].HeaderText = "Mã Sản Phẩm";
            gridViewSanPhamDaThem.Columns[2].HeaderText = "Tên Sản Phẩm";
            gridViewSanPhamDaThem.Columns[3].HeaderText = "Kho Xuất";
            gridViewSanPhamDaThem.Columns[4].HeaderText = "Kho Nhập";
            gridViewSanPhamDaThem.Columns[5].HeaderText = "Số Lượng";
            gridViewSanPhamDaThem.Columns[6].HeaderText = "Đơn Vị";
            gridViewSanPhamDaThem.Columns[7].HeaderText = "Đơn Giá";
        }

        private void cbXacNhan_Click(object sender, EventArgs e)
        {
            // Them phieu nhap hang
            if (cbCoSoNhan.SelectedItem == null ||
                cbMaNhanVien.SelectedItem == null ||
                cbMaNhanVienNhap.SelectedItem == null ||
                tbMaSanPham.Text == "" ||
                tbTenSanPham.Text == "" ||
                tbNgayNhap.Text == "" ||
                tbMaPhieuXuatHang.Text == "" ||
                tbSoLuong.Value <= 0 ||
                danhSachSanPhamDaThem.Count == 0)
            {
                MessageBox.Show("Vui lòng nhập dữ liệu hợp lệ");
            }
            else
            {
                string themPhieuDieuChuyenSql = String.Format("INSERT INTO PhieuDieuChuyen(MaPhieuDieuChuyen, MaNhanVien, MaNhanVienNhap, MaCoSo, NgayNhap) VALUES('{0}', '{1}', '{2}', '{3}', '{4}')",
                    tbMaPhieuXuatHang.Text, cbMaNhanVien.SelectedValue, cbMaNhanVienNhap.SelectedValue, cbCoSoNhan.SelectedValue, DateTime.Now.ToString("yyyy-MM-dd"));
                try
                {
                    SqlCommand themPhieuDieuChuyenCmd = new SqlCommand();
                    themPhieuDieuChuyenCmd.Connection = Function.conn;
                    themPhieuDieuChuyenCmd.CommandText = themPhieuDieuChuyenSql;
                    Boolean success = true;
                    using (DbDataReader themPhieuDieuChuyenReader = themPhieuDieuChuyenCmd.ExecuteReader())
                    {
                        if (themPhieuDieuChuyenReader.RecordsAffected <= 0)
                        {
                            success = false;
                        }
                        themPhieuDieuChuyenReader.Close();
                    }
                    if (success == true)
                    {
                        // Them chi tiet phieu nhap hang
                        foreach (SanPham sanPham in danhSachSanPhamDaThem)
                        {
                            string themChiTietPhieuDieuChuyenSql = String.Format("INSERT INTO ChiTietPDC(MaPhieuDieuChuyen, MaSanPham, SoLuongDC) VALUES('{0}', '{1}', '{2}')", tbMaPhieuXuatHang.Text, sanPham.MaSanPham, sanPham.SoLuong);
                            SqlCommand themChiTietPhieuDieuChuyenCmd = new SqlCommand();
                            themChiTietPhieuDieuChuyenCmd.Connection = Function.conn;
                            themChiTietPhieuDieuChuyenCmd.CommandText = themChiTietPhieuDieuChuyenSql;
                            using (DbDataReader themChiTietPhieuDieuChuyenReader = themChiTietPhieuDieuChuyenCmd.ExecuteReader())
                            {
                                if (themChiTietPhieuDieuChuyenReader.RecordsAffected <= 0)
                                {
                                    success = false;
                                }
                                themChiTietPhieuDieuChuyenReader.Close();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Thêm phiếu xuất hàng thất Bại");
                    }
                    if (success == true)
                    {
                        // Tang so luong san pham
                        foreach (SanPham sanPham in danhSachSanPhamDaThem)
                        {
                            string giamSoLuongSanPhamSql = String.Format("UPDATE SanPham SET SoLuongTon = SoLuongTon + {0} WHERE MaSanPham = '{1}'", sanPham.SoLuong, sanPham.MaSanPham);
                            SqlCommand tangSoLuongSanPhamCmd = new SqlCommand();
                            tangSoLuongSanPhamCmd.Connection = Function.conn;
                            tangSoLuongSanPhamCmd.CommandText = giamSoLuongSanPhamSql;
                            using (DbDataReader tangSoLuongSanPhamReader = tangSoLuongSanPhamCmd.ExecuteReader())
                            {
                                if (tangSoLuongSanPhamReader.RecordsAffected <= 0)
                                {
                                    success = false;
                                }
                                tangSoLuongSanPhamReader.Close();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Thêm chi tiết phiếu điều chuyển thất Bại");
                    }
                    if (success == true)
                    {
                        MessageBox.Show("Thành Công");
                    }
                    else
                    {
                        MessageBox.Show("Tăng số lượng tồn của sản phẩm thất Bại");
                    }
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.Message);
                }
                // Lay lai danh sach san pham
                string sanPhamQuery = "SELECT MaSanPham AS 'Mã Sản Phẩm', TenSanPham AS 'Tên Sản Phẩm'," +
                    " SoLuongTon AS 'Số Lượng Tồn', DonGiaBan AS 'Đơn Giá Bán', DonViTinh.TenDonViTinh AS 'Đơn Vị'" +
                    " FROM SanPham LEFT JOIN DonViTinh ON SanPham.MaDonViTinh = DonViTinh.MaDonViTinh";
                SqlDataAdapter sanPhamSqlData = new SqlDataAdapter(sanPhamQuery, Function.conn);
                DataTable sanPhamTable = new DataTable();
                sanPhamSqlData.Fill(sanPhamTable);
                gridViewSanPham.DataSource = null;
                gridViewSanPham.DataSource = sanPhamTable;
                btnIn.Enabled = true;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            FrmTimKiemPDC f = new FrmTimKiemPDC();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }
    }
}
