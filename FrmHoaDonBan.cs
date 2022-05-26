using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace Okono_Mmanagement
{
    public partial class FrmHoaDonBan : Form
    {
        DataTable ChiTietHDB;
        public FrmHoaDonBan()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmHoaDonBan_Load(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnIn.Enabled = false;
            btnThemSP.Enabled = false;
            btnHuySP.Enabled = false;
            btnOK.Enabled = false;
            btnLoadGiamGia.Enabled = false;
            txtMaHoaDon.ReadOnly = true;
            txtThoiGian.ReadOnly = true;
            txtTenKhachHang.ReadOnly = true;
            txtTenSanPham.ReadOnly = true;
            txtTongTien.ReadOnly = true;
            txtGiamGia.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
            txtGiaBan.ReadOnly = true;
            txtTienSP.ReadOnly = true;
            txtMaSanPham.ReadOnly = true;
            btnLoad.Enabled = false;
            btnHuySP.Enabled = false;
            txtTimKiem.Text = "";
            txtTienSP.Text = "0";
            udSoLuong.Value = 0;
            txtTongTien.Text = "0";
            txtGiamGia.Text = "0";
            txtThanhTien.Text = "0";
            txtTimKiem.Text = "";
            Function.FillDataToCombo("SELECT MaNhanVien FROM NhanVien where DaXoa=0", cmbMaNhanVien, "MaNhanVien", "MaNhanVien");
            cmbMaNhanVien.SelectedIndex = -1;
        }
        private void Load_DataGridViewSanPham()
        {
            string sql;
            sql = "SELECT MaSanPham, TenSanPham, SoLuongTon, DonGiaBan FROM SanPham WHERE MaSanPham LIKE '%"+txtTimKiem.Text.Trim()+"%' AND DaXoa = 0";
            ChiTietHDB = Function.GetDataToTable(sql);
            dataGridViewSanPham.DataSource = ChiTietHDB;
            dataGridViewSanPham.Columns[0].HeaderText = "Mã sản phẩm";
            dataGridViewSanPham.Columns[1].HeaderText = "Tên sản phẩm";
            dataGridViewSanPham.Columns[2].HeaderText = "Số lượng";
            dataGridViewSanPham.Columns[3].HeaderText = "Đơn giá";
            dataGridViewSanPham.Columns[0].Width = 110;
            dataGridViewSanPham.Columns[1].Width = 180;
            dataGridViewSanPham.Columns[2].Width = 50;
            dataGridViewSanPham.Columns[3].Width = 60;
            dataGridViewSanPham.AllowUserToAddRows = false;
            dataGridViewSanPham.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void ResetValues()
        {
            txtMaHoaDon.Text = "";
            txtThoiGian.Text = "";
            cmbMaNhanVien.Text = "";
            cmbMaKhachHang.Text = "";
            txtTenKhachHang.Text = "";
            txtTenSanPham.Text = "";
            txtTienSP.Text = "0";
            txtGiaBan.Text = "0";
            udSoLuong.Value = 0;
            txtTongTien.Text = "0";
            txtGiamGia.Text = "0";
            txtThanhTien.Text = "0";
            txtTimKiem.Text = "";

        }
        private void dataGridViewSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSanPham.Text = dataGridViewSanPham.CurrentRow.Cells["MaSanPham"].Value.ToString();
            txtTenSanPham.Text = dataGridViewSanPham.CurrentRow.Cells["TenSanPham"].Value.ToString();
            txtGiaBan.Text = dataGridViewSanPham.CurrentRow.Cells["DonGiaBan"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnHuy.Enabled = true;
            btnThoat.Enabled = false;
            btnLuu.Enabled = false;
            btnIn.Enabled = false;
            btnThem.Enabled = false;
            btnThemSP.Enabled = false;
            btnLoad.Enabled = true;
            btnOK.Enabled = true;
            txtGiamGia.ReadOnly = true;
            ResetValues();
            txtMaHoaDon.Text = Function.CreateKey("HDB");
            txtThoiGian.Text = DateTime.Now.ToShortDateString();
            btnLoadGiamGia.Enabled = false;
            Load_DataGridViewSanPham();
            txtTongTien.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
            Load_DataGridViewMua();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Load_DataGridViewSanPham();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            //Tính tổng tiền sản phẩm
            if (udSoLuong.Value != 0)
            {
                btnThemSP.Enabled = true;
                double giasp = Convert.ToInt32(txtGiaBan.Text);
                int soluong = Convert.ToInt32(udSoLuong.Value);
                int soluongton = Convert.ToInt32(Function.GetFieldValues("SELECT SoLuongTon FROM SanPham WHERE MaSanPham = '" + txtMaSanPham.Text + "'"));
                if (Convert.ToDouble(udSoLuong.Text) > soluongton)
                {
                    MessageBox.Show("Số lượng mặt hàng này chỉ còn " + soluongton, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    udSoLuong.Value = 0;
                    udSoLuong.Focus();
                    return;
                }
                if (soluong <= soluongton)
                {
                    double tiensp = giasp * soluong;
                    txtTienSP.Text = Convert.ToString(tiensp);
                }    
            }
            else
            {
                btnThemSP.Enabled = false;
            }    
        }
        private void ResetValuesSanPham()
        {
            txtMaSanPham.Text = "";
            txtTenSanPham.Text = "";
            udSoLuong.Value = 0;
            txtGiaBan.Text = "0";
            txtTienSP.Text = "0";
        }
        private void Load_DataGridViewMua()
        {
            string sql;
            sql = "SELECT a.MaSanPham, a.TenSanPham, b.SoLuongBan, c.TenDonViTinh, a.DonGiaBan FROM DonViTinh AS c INNER JOIN SanPham AS a ON c.MaDonViTInh = a.MaDonViTinh INNER JOIN ChiTietHDB AS b ON a.MaSanPham = b.MaSanPham WHERE b.MaHoaDonBan = '"+txtMaHoaDon.Text+"' AND c.MaDonViTinh = a.MaDonViTinh";
            ChiTietHDB = Function.GetDataToTable(sql);
            dataGridViewMua.DataSource = ChiTietHDB;
            dataGridViewMua.Columns[0].HeaderText = "Mã sản phẩm";
            dataGridViewMua.Columns[1].HeaderText = "Tên sản phẩm";
            dataGridViewMua.Columns[2].HeaderText = "Số lượng";
            dataGridViewMua.Columns[3].HeaderText = "Đơn vị tính";
            dataGridViewMua.Columns[4].HeaderText = "Đơn giá bán";
            dataGridViewMua.Columns[0].Width = 200;
            dataGridViewMua.Columns[1].Width = 400;
            dataGridViewMua.Columns[2].Width = 160;
            dataGridViewMua.Columns[3].Width = 180;
            dataGridViewMua.Columns[4].Width = 180;
            dataGridViewMua.AllowUserToAddRows = false;
            dataGridViewMua.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void btnThemSP_Click(object sender, EventArgs e)
        {
            string sql;
            double tong, Tongmoi;
            int SLcon;
            int sl = Convert.ToInt32(Function.GetFieldValues("SELECT SoLuongTon FROM SanPham WHERE MaSanPham = '" + txtMaSanPham.Text + "'"));
            sql = "SELECT MaHoaDonBan FROM HoaDonBan WHERE MaHoaDonBan = '" + txtMaHoaDon.Text + "'";
            if (!Function.checkKeyExit(sql))
            {
                // Mã hóa đơn chưa có, tiến hành lưu các thông tin chung
                // Mã HDBan được sinh tự động do đó không có trường hợp trùng khóa
                if (cmbMaNhanVien.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập thông tin nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbMaNhanVien.Focus();
                    return;
                }
                sql = "INSERT INTO HoaDonBan (MaHoaDonBan, MaNhanVien, NgayBan, TongTien) VALUES ('" + txtMaHoaDon.Text + "', '"+ cmbMaNhanVien.Text + "', '" +
                        Function.ConvertDateTime(txtThoiGian.Text) + "', '')";
                Function.RunSql(sql);
            }
            // Lưu thông tin của các mặt hàng
            if (txtMaSanPham.Text.Trim().Length == 0)
            {
                MessageBox.Show("Mã sản phẩm không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSanPham.Focus();
                return;
            }
            if ((udSoLuong.Text.Trim().Length == 0) || (udSoLuong.Text == "0"))
            {
                MessageBox.Show("Số lượng không được bằng 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                udSoLuong.Value = 0;
                udSoLuong.Focus();
                return;
            }
            sql = "INSERT INTO ChiTietHDB (MaHoaDonBan, MaSanPham,SoLuongBan) VALUES ('" + txtMaHoaDon.Text.Trim() + "', '" + txtMaSanPham.Text.Trim() +
"'," + udSoLuong.Value + ")";
            Function.RunSql(sql);
            Load_DataGridViewMua();
            // Cập nhật lại số lượng của mặt hàng vào bảng SanPham
            SLcon = sl - Convert.ToInt32(udSoLuong.Text);
            sql = "UPDATE SanPham SET SoLuongTon =" + SLcon + " WHERE MaSanPham = N'" + txtMaSanPham.Text + "'";
            Function.RunSql(sql);
            // Cập nhật lại tổng tiền cho hóa đơn bán
            tong = Convert.ToDouble(Function.GetFieldValues("SELECT TongTien FROM HoaDonBan WHERE MaHoaDonBan = N'" + txtMaHoaDon.Text + "'"));
            Tongmoi = tong + Convert.ToDouble(txtTienSP.Text);
            sql = "UPDATE HoaDonBan SET TongTien =" + Tongmoi + " WHERE MaHoaDonBan = N'" + txtMaHoaDon.Text + "'";
            Function.RunSql(sql);
            txtTongTien.Text = Tongmoi.ToString();
            txtThanhTien.Text = Convert.ToString(txtTongTien.Text);
            Load_DataGridViewSanPham();
            ResetValuesSanPham();
            btnHuy.Enabled = true;
            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnIn.Enabled = false;
            txtGiamGia.ReadOnly = false;
            txtTongTien.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
            btnLoadGiamGia.Enabled = true;
            btnThoat.Enabled = false;
            btnThemSP.Enabled = false;
            btnHuySP.Enabled = true;
        }

        private void btnLoadGiamGia_Click(object sender, EventArgs e)
        {
            if (txtGiamGia.Text == "")
            {
                MessageBox.Show("Giảm giá không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiamGia.Text = "0";
                txtGiamGia.Focus();
                return;
            }    
            double tongtien = Convert.ToDouble(txtTongTien.Text);
            double giamgia = Convert.ToDouble(txtGiamGia.Text);
            double thanhtien = tongtien - giamgia;
            txtThanhTien.Text = Convert.ToString(thanhtien);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            btnHuy.Enabled = false;
            btnThoat.Enabled = true;
            double tienban = Convert.ToDouble(txtThanhTien.Text);
            if (txtGiamGia.Text != "0")
            {
                double tiengiam = Convert.ToDouble(txtGiamGia.Text);
                string sqlgg;
                sqlgg = "UPDATE HoaDonBan SET GiamGia = " + tiengiam + " WHERE MaHoaDonBan = '" + txtMaHoaDon.Text + "'";
                Function.RunSql(sqlgg);
            }    
            string sql;
            sql = "UPDATE HoaDonBan SET TongTien = "+ tienban +" WHERE MaHoaDonBan = '"+txtMaHoaDon.Text+"'";
            Function.RunSql(sql);
            btnIn.Enabled = true;
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnOK.Enabled = false;
            btnHuySP.Enabled = false;
            btnLoadGiamGia.Enabled = false;
            btnLoad.Enabled = false;
            MessageBox.Show("Lưu hoá đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHD, tblThongtinHang;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:D50"].Font.Name = "Times new roman";
            exRange.Range["A1:D3"].Font.Size = 10;
            exRange.Range["A1:D3"].Font.Name = "Times new roman";
            exRange.Range["A1:D3"].Font.Bold = true;
            exRange.Range["A1:D3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 25;
            exRange.Range["A1:D1"].MergeCells = true;
            exRange.Range["A1:D1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:D1"].Value = "OKONO";
            exRange.Range["A2:D2"].MergeCells = true;
            exRange.Range["A2:D2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:D2"].Value = "72 Khương Trung - Thanh Xuân - Hà Nội";
            exRange.Range["A3:D3"].MergeCells = true;
            exRange.Range["A3:D3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:D3"].Value = "Điện thoại: (04)37562222";
            exRange.Range["A5:D5"].Font.Size = 16;
            exRange.Range["A5:D5"].Font.Name = "Times new roman";
            exRange.Range["A5:D5"].Font.Bold = true;
            exRange.Range["A5:D5"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["A5:D5"].MergeCells = true;
            exRange.Range["A5:D5"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A5:D5"].Value = "HÓA ĐƠN BÁN HÀNG";
            // Biểu diễn thông tin chung của hóa đơn bán
            sql = "SELECT a.MaHoaDonBan, a.NgayBan, a.TongTien, b.TenNhanVien FROM HoaDonBan AS a INNER JOIN NhanVien AS b ON a.MaNhanVien = b.MaNhanVien WHERE a.MaHoaDonBan = N'" + txtMaHoaDon.Text + "'";
            tblThongtinHD = Function.GetDataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:C9"].Font.Name = "Times new roman";
            exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
            exRange.Range["C6:D6"].MergeCells = true;
            exRange.Range["C6:D6"].Value = tblThongtinHD.Rows[0][0].ToString();
            //Lấy thông tin các mặt hàng
            sql = "SELECT b.TenSanPham, a.SoLuongBan, b.DonGiaBan FROM ChiTietHDB AS a INNER JOIN SanPham AS b ON a.MaSanPham = b.MaSanPham WHERE a.MaHoaDonBan = N'" +txtMaHoaDon.Text + "' AND a.MaSanPham = b.MaSanPham";
            tblThongtinHang = Function.GetDataToTable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A8:D8"].Font.Bold = true;
            exRange.Range["A8:D8"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C8:D8"].ColumnWidth = 12;
            exRange.Range["A8:A8"].Value = "STT";
            exRange.Range["B8:B8"].Value = "Tên sản phẩm";
            exRange.Range["C8:C8"].Value = "Số lượng";
            exRange.Range["D8:D8"].Value = "Đơn giá";
            for (hang = 0; hang <= tblThongtinHang.Rows.Count - 1; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 9
                exSheet.Cells[1][hang + 9] = hang + 1;
                for (cot = 0; cot <= tblThongtinHang.Columns.Count - 1; cot++)
                    //Điền thông tin hàng từ cột thứ 2, dòng 12
                    exSheet.Cells[cot + 2][hang + 9] = tblThongtinHang.Rows[hang][cot].ToString();
            }
            exRange = exSheet.Cells[cot][hang + 11];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 11];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHD.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 12]; //Ô A1 
            exRange.Range["A1:D1"].MergeCells = true;
            exRange.Range["A1:D1"].Font.Bold = true;
            exRange.Range["A1:D1"].Font.Italic = true;
            exRange.Range["A1:D1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range["A1:D1"].Value = "Bằng chữ: " + Function.ChuyenSoSangChu(tblThongtinHD.Rows[0][2].ToString());
            exRange = exSheet.Cells[2][hang + 14]; //Ô A1 
            exRange.Range["A1:D1"].MergeCells = true;
            exRange.Range["A1:D1"].Font.Italic = true;
            exRange.Range["A1:D1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exSheet.Name = "Hóa đơn bán hàng";
            exApp.Visible = true;
        }

        private void btnHuySP_Click(object sender, EventArgs e)
        {
            // Update số lượng sau khi huỷ sản phẩm
            int soluonghuy = Convert.ToInt32(Function.GetFieldValues("SELECT SoLuongBan FROM ChiTietHDB WHERE MaSanPham = '" + txtMaSanPhamXoa.Text + "' AND MaHoaDonBan = '"+txtMaHoaDon.Text+"'"));
            int soluongsau = Convert.ToInt32(Function.GetFieldValues("SELECT SoLuongTon FROM SanPham WHERE MaSanPham = '" + txtMaSanPhamXoa.Text + "'")) + soluonghuy;
            string sql_update = "UPDATE SanPham SET SoLuongTon = " + soluongsau + " WHERE MaSanPham = '" + txtMaSanPhamXoa.Text + "'";
            Function.RunSql(sql_update);
            //Delete sản phẩm
            string sql = "DELETE FROM ChiTietHDB WHERE MaHoaDonBan = '" + txtMaHoaDon.Text + "' AND MaSanPham = '"+txtMaSanPhamXoa.Text+"'";
            Function.RunSql(sql);
            double soluongsp = Convert.ToDouble(Function.GetFieldValues("SELECT COUNT(*) FROM ChiTietHDB WHERE MaHoaDonBan = '" + txtMaHoaDon.Text + "'"));
            if (soluongsp == 0)
            {
                string sqlxoa = "DELETE FROM HoaDonBan WHERE MaHoaDonBan = '" + txtMaHoaDon.Text + "'";
                Function.RunSql(sqlxoa);
                MessageBox.Show("Huỷ hoá đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                btnHuy.Enabled = false;
                btnLuu.Enabled = false;
                btnThem.Enabled = true;
                btnThoat.Enabled = true;
                txtGiamGia.Enabled = true;
                btnHuySP.Enabled = false;
                btnLoad.Enabled = false;
                btnLoadGiamGia.Enabled = false;
                btnOK.Enabled = false;
                txtMaHoaDon.Text = "";
                txtThoiGian.Text = "";
                cmbMaNhanVien.Text = "";
                txtThoiGian.Enabled = true;
                btnThemSP.Enabled = false;
            }
            else
            {
                MessageBox.Show("Xoá sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            // Update tổng tiền sau khi huỷ sản phẩm
            double giaban = Convert.ToDouble(Function.GetFieldValues("SELECT DonGiaBan FROM SanPham WHERE MaSanPham = '" + txtMaSanPhamXoa.Text + "'"));
            double tongtien = Convert.ToDouble(txtTongTien.Text) - giaban * soluonghuy;
            double thanhtien = Convert.ToDouble(txtThanhTien.Text) - giaban * soluonghuy;
            txtThanhTien.Text = Convert.ToString(thanhtien);
            txtTongTien.Text = Convert.ToString(tongtien);
            string update_tongtien = "UPDATE HoaDonBan SET TongTien = '" + txtTongTien.Text + "' WHERE MaHoaDonBan = '" + txtMaHoaDon.Text + "'";
            Function.RunSql(update_tongtien);
            Load_DataGridViewMua();
            Load_DataGridViewSanPham();
            txtMaSanPhamXoa.Text = "";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnThoat.Enabled = true;
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnIn.Enabled = false;
            txtTongTien.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
            txtGiamGia.ReadOnly = true;
            txtThanhTien.Text = "0";
            txtGiamGia.Text = "0";
            txtTongTien.Text = "0";
            btnHuySP.Enabled = false;
            btnLoad.Enabled = false;
            btnThemSP.Enabled = false;
            btnLoadGiamGia.Enabled = false;
            btnOK.Enabled = false;
            ResetValues();
            // Update số lượng sau khi huỷ hoá đơn
            string sql = "DELETE FROM ChiTietHDB WHERE MaHoaDonBan = '" + txtMaHoaDon.Text + "'";
            Function.RunSql(sql);
            string sqlxoa = "DELETE FROM HoaDonBan WHERE MaHoaDonBan = '" + txtMaHoaDon.Text + "'";
            Function.RunSql(sqlxoa);
            MessageBox.Show("Huỷ hoá đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
            Load_DataGridViewMua();
            Load_DataGridViewSanPham();
            btnHuy.Enabled = false;
            btnHuySP.Enabled = false;
        }

        private void dataGridViewMua_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSanPhamXoa.Text = dataGridViewMua.CurrentRow.Cells["MaSanPham"].Value.ToString();
        }
    }
}
