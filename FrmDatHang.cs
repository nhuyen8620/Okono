using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using COMExcel = Microsoft.Office.Interop.Excel;

namespace Okono_Mmanagement
{
    /*public class SanPham
    {
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        //public string KhoXuat { get; set; }
        public int SoLuongNhap { get; set; }
        public string MaDonViTinh { get; set; }
    }*/
    public partial class FrmDatHang : Form
    {
        DataTable tblHDN;
        public FrmDatHang()
        {
            InitializeComponent();
        }

        private void FrmNhapHang_Load(object sender, EventArgs e)
        {
            Function.OpenConnection();
            btnIn.Enabled = false;
            btnHuy.Enabled = false;
            btnThemSP.Enabled = false;
            cboMaNV.Enabled = false;
            LoadDataToGridview();
            LoadDataToGridviewSP();
            Function.FillDataToCombo("select MaNhanVien from NhanVien where DaXoa=0", cboMaNV, "MaNhanVien", "MaNhanVien");
            cboMaNV.SelectedIndex = -1;

            //Function.FillDataToCombo("select MaCoSo from CoSo", cboMaCNX, "MaCoSo","MaCoSo");
            //cboMaCNX.SelectedIndex = -1;
        }
        private void LoadDataToGridviewSP()
        {
            string sql;
            sql = "SELECT MaSanPham, TenSanPham, SoLuongTon,b.TenDonViTinh " +
                "FROM SanPham a join DonViTinh b on a.MaDonViTinh=b.MaDonViTinh where a.DaXoa=0";
            tblHDN = Function.GetDataToTable(sql);
            dataGridview_SP.DataSource = tblHDN;
            dataGridview_SP.Columns[0].HeaderText = "Mã sản phẩm";
            dataGridview_SP.Columns[1].HeaderText = "Tên sản phẩm";
            dataGridview_SP.Columns[2].HeaderText = "Số lượng";
            dataGridview_SP.Columns[3].HeaderText = "Đơn vị tính";
            dataGridview_SP.Columns[0].Width = 110;
            dataGridview_SP.Columns[1].Width = 130;
            dataGridview_SP.Columns[2].Width = 70;
            dataGridview_SP.Columns[3].Width = 50;
            dataGridview_SP.AllowUserToAddRows = false;
            dataGridview_SP.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void LoadDataToGridview()
        {
            string sql = "select b.MaSanPham, c.TenSanPham, b.SoLuongDat, f.TenDonViTinh, a.GhiChu " +
                "from PhieuDatHang a left join ChiTietPDH b on a.MaPhieuDatHang = b.MaPhieuDatHang " +
                "left join SanPham c on b.MaSanPham = c.MaSanPham " +
                "left join DonViTinh f on c.MaDonViTinh = f.MaDonViTinh where a.MaPhieuDatHang='" + txtMaHD.Text + "'";
            tblHDN = Function.GetDataToTable(sql);
            dataGridView_PNH.DataSource = tblHDN;
            dataGridView_PNH.Columns[0].HeaderText = "Mã sản phẩm";
            dataGridView_PNH.Columns[1].HeaderText = "Tên sản phẩm";
            dataGridView_PNH.Columns[2].HeaderText = "Số lượng đặt";
            dataGridView_PNH.Columns[3].HeaderText = "Đơn vị tính";
            dataGridView_PNH.Columns[4].HeaderText = "Ghi chú";
            dataGridView_PNH.Columns[0].Width = 180;
            dataGridView_PNH.Columns[1].Width = 290;
            dataGridView_PNH.Columns[2].Width = 210;
            dataGridView_PNH.Columns[3].Width = 180;
            dataGridView_PNH.Columns[4].Width = 200;
            dataGridView_PNH.AllowUserToAddRows = false;
            dataGridView_PNH.EditMode = DataGridViewEditMode.EditProgrammatically;
        }


        private void ResetValues()
        {
            txtMaHD.Text = "";
            txtSanPham.Text = "";
            numSoLuong.Value = 0;
            cboMaNV.Text = "";
            mskNgayNhap.Text = "";
            txtMaSP.Text = "";
            txtTenNV.Text = "";
            txtChiNhanh.Text = "";
            txtSPXoa.Text = "";
            txtTimKiem.Text = "";
        }

        private void ResetValueSP()
        {
            txtMaSP.Text = "";
            txtSanPham.Text = "";
            numSoLuong.Value = 0;
        }

        private void dataGridView_PNH_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            /*txtMaSP.Text = dataGridView_PNH.CurrentRow.Cells["MaSanPham"].Value.ToString();
            txtSanPham.Text = dataGridView_PNH.CurrentRow.Cells["TenSanPham"].Value.ToString();
            numSoLuong.Text = dataGridView_PNH.CurrentRow.Cells["SoLuongDat"].Value.ToString();*/
            txtSPXoa.Text = dataGridView_PNH.CurrentRow.Cells["MaSanPham"].Value.ToString();
        }
        
        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaHD.Enabled = true;
            btnThem.Enabled = true;
            btnThemSP.Enabled = false;
            btnIn.Enabled = false;
            btnTimKiem.Enabled = true;
            ResetValues();
            LoadDataToGridview();
            LoadDataToGridviewSP();
        }

        private void cboMaNV_TextChanged_1(object sender, EventArgs e)
        {
            string str;
            if (cboMaNV.Text == "")
                txtTenNV.Text = "";
            str = "SELECT TenNhanVien FROM NhanVien WHERE MaNhanVien = N'" + cboMaNV.SelectedValue + "'";
            txtTenNV.Text = Function.GetFieldValues(str);

            str = "SELECT TenCoSo FROM CoSo a join NhanVien b on a.MaCoSo=b.MaCoSo WHERE MaNhanVien = N'" + cboMaNV.SelectedValue + "'";
            txtChiNhanh.Text = Function.GetFieldValues(str);
        }



        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValues();
            btnTimKiem.Enabled = false;
            btnIn.Enabled = false;
            btnHuy.Enabled = true;
            btnThemSP.Enabled = true;
            txtMaHD.Enabled = false;
            mskNgayNhap.Enabled = false;
            cboMaNV.Enabled = true;
            txtMaHD.Text = Function.CreateKey("PDH");
            mskNgayNhap.Text = DateTime.Now.ToShortDateString();
            LoadDataToGridview();
            LoadDataToGridviewSP();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnHuy.Enabled = true;
            btnIn.Enabled = true;
            btnThemSP.Enabled = false;
            string sql;
            if (txtMaHD.Text == "")
            {
                MessageBox.Show("Bạn cần nhập mã phiếu đặt hàng để tìm kiếm", "Yêu cầu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "select b.MaSanPham, b.SoLuongDat, c.TenSanPham, f.TenDonViTinh " +
                "from PhieuDatHang a left join ChiTietPDH b on a.MaPhieuDatHang = b.MaPhieuDatHang " +
                "left join SanPham c on b.MaSanPham = c.MaSanPham " +
                "left join DonViTinh f on c.MaDonViTinh = f.MaDonViTinh";
            if (txtMaHD.Text != "")
            {
                sql = sql + " where a.MaPhieuDatHang ='" + txtMaHD.Text + "'";
            }

            tblHDN = Function.GetDataToTable(sql);
            dataGridView_PNH.DataSource = tblHDN;
        }

        private void dataGridview_SP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSanPham.Text = dataGridview_SP.CurrentRow.Cells["TenSanPham"].Value.ToString();
            txtMaSP.Text = dataGridview_SP.CurrentRow.Cells["MaSanPham"].Value.ToString();
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            btnIn.Enabled = true;
             string sql;
             //int SLcon;
             //int sl = Convert.ToInt32(Function.GetFieldValues("SELECT SoLuongTon FROM SanPham WHERE MaSanPham = '" + txtMaSP.Text + "'"));
             sql = "SELECT MaPhieuDatHang FROM PhieuDatHang WHERE MaPhieuDatHang = '" + txtMaHD.Text + "'";
             if (!Function.checkKeyExit(sql))
             {
                 // Mã hóa đơn chưa có, tiến hành lưu các thông tin chung
                 // Mã HDBan được sinh tự động do đó không có trường hợp trùng khóa
                 if (cboMaNV.Text.Length == 0)
                 {
                     MessageBox.Show("Bạn phải nhập thông tin nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     cboMaNV.Focus();
                     return;
                 }
                
                     sql = "INSERT INTO PhieuDatHang (MaPhieuDatHang, MaNhanVien, NgayDat) " +
                     "VALUES ('" + txtMaHD.Text + "', '" + cboMaNV.Text + "', '" + Function.ConvertDateTime(mskNgayNhap.Text) + "')";
                 
                 Function.RunSql(sql);

             }
             string SP = Function.GetFieldValues("SELECT MaSanPham from ChiTietPDH where MaPhieuDatHang='" + txtMaHD.Text + "'");
            
             // Lưu thông tin của các mặt hàng
             if (txtMaSP.Text.Trim().Length == 0)
             {
                 MessageBox.Show("Mã sản phẩm không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 txtMaSP.Focus();
                 return;
             }
             if ((numSoLuong.Text.Trim().Length == 0) || (numSoLuong.Text == "0"))
             {
                 MessageBox.Show("Số lượng không được bằng 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 numSoLuong.Value = 0;
                 numSoLuong.Focus();
                 return;
             }
             //Check trùng mặt hàng
             if(SP==txtMaSP.Text )
            {
                int slnhapcu = Convert.ToInt32(Function.GetFieldValues("SELECT SoLuongDat from ChiTietPDH where MaSanPham='" + txtMaSP.Text + "' and MaPhieuDatHang='" + txtMaHD.Text + "'"));
                int slnhapmoi = slnhapcu + Convert.ToInt32(numSoLuong.Value);
                sql = "UPDATE ChiTietPDH SET SoLuongDat=" + slnhapmoi +" where MaSanPham='" + txtMaSP.Text + "' and MaPhieuDatHang='" + txtMaHD.Text + "'";
                Function.RunSql(sql);
            } 
             else
            {
                sql = "INSERT INTO ChiTietPDH (MaPhieuDatHang, MaSanPham,SoLuongDat) VALUES ('" + txtMaHD.Text.Trim() + "', '" + txtMaSP.Text.Trim() +
 "'," + numSoLuong.Value + ")";
                Function.RunSql(sql);
            }    
             
             LoadDataToGridview();
             // Cập nhật lại số lượng của mặt hàng vào bảng SanPham
             //SLcon = sl + Convert.ToInt32(numSoLuong.Text);
             //sql = "UPDATE SanPham SET SoLuongTon =" + SLcon + " WHERE MaSanPham = N'" + txtMaSP.Text + "'";
             //Function.RunSql(sql);
             //LoadDataToGridviewSP();
             ResetValueSP();
        }

        private void btnTimSP_Click(object sender, EventArgs e)
        {
            btnHuy.Enabled = true;
            string sql;
            if (txtTimKiem.Text == "")
            {
                MessageBox.Show("Bạn cần nhập điều kiện để tìm kiếm", "Yêu cầu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT a.MaSanPham, TenSanPham, SoLuongTon, b.TenDonViTinh " +
                "FROM SanPham a join DonViTinh b on a.MaDonViTinh =b. MaDonViTinh where 1 = 1 and a.DaXoa = 0 ";
            if (txtTimKiem.Text != "")
            {
                sql = sql + "and a.MaSanPham like N'%" + txtTimKiem.Text + "%' or TenSanPham like N'%" + txtTimKiem.Text + "%'";
            }
            tblHDN = Function.GetDataToTable(sql);
            dataGridview_SP.DataSource = tblHDN;
            

        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            /*COMExcel.Application exApp = new COMExcel.Application();
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
            exRange.Range["A5:D5"].Value = "PHIẾU ĐẶT HÀNG";
            // Biểu diễn thông tin chung của hóa đơn bán
            sql = "SELECT a.MaPhieuDatHang, a.NgayDat, b.TenNhanVien FROM PhieuDatHang AS a INNER JOIN NhanVien AS b ON a.MaNhanVien = b.MaNhanVien WHERE a.MaPhieuDatHang = N'" + txtMaHD.Text + "'";
            tblThongtinHD = Function.GetDataToTable(sql);
            exRange.Range["A6:D20"].Font.Size = 13;
            exRange.Range["B6:C20"].Font.Name = "Times new roman";
            exRange.Range["B6:B6"].Value = "Mã phiếu:";
            exRange.Range["C6:D6"].MergeCells = true;
            exRange.Range["C6:D6"].Value = tblThongtinHD.Rows[0][0].ToString();
            //Lấy thông tin các mặt hàng
            sql = "SELECT b.TenSanPham, a.SoLuongDat, c.TenDonViTinh " +
                "FROM ChiTietPDH AS a INNER JOIN SanPham AS b ON a.MaSanPham = b.MaSanPham JOIN DonViTinh c on b.MaDonViTinh=c.MaDonViTinh" +
                " WHERE a.MaPhieuDatHang = N'" + txtMaHD.Text + "' AND a.MaSanPham = b.MaSanPham";
            tblThongtinHang = Function.GetDataToTable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A8:D8"].Font.Bold = true;
            exRange.Range["A8:D20"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C8:D8"].ColumnWidth = 12;
            exRange.Range["A8:A8"].Value = "STT";
            exRange.Range["B8:B8"].Value = "Tên sản phẩm";
            exRange.Range["C8:C8"].Value = "Số lượng";
            exRange.Range["D8:D8"].Value = "Đơn vị tính";
            for (hang = 0; hang <= tblThongtinHang.Rows.Count - 1; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 9
                exSheet.Cells[1][hang + 9] = hang + 1;
                for (cot = 0; cot <= tblThongtinHang.Columns.Count - 1; cot++)
                    //Điền thông tin hàng từ cột thứ 2, dòng 12
                    exSheet.Cells[cot + 2][hang + 9] = tblThongtinHang.Rows[hang][cot].ToString();
            }
            exRange = exSheet.Cells[cot][hang + 11];
            exRange = exSheet.Cells[2][hang + 12]; //Ô A1 
            exRange.Range["A1:D1"].MergeCells = true;
            exRange.Range["A1:D1"].Font.Italic = true;
            exRange.Range["A1:D1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên đặt hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exSheet.Name = "Phiếu đặt hàng";
            exApp.Visible = true;
            */
        }       

        private void btnXoa_Click(object sender, EventArgs e)
        {
           
            //Delete sản phẩm
            string sql = "DELETE FROM ChiTietPDH WHERE MaPhieuDatHang = '" + txtMaHD.Text + "' AND MaSanPham = '" + txtSPXoa.Text + "'";
            Function.RunSql(sql);
            double soluongsp = Convert.ToDouble(Function.GetFieldValues("SELECT COUNT(*) FROM ChiTietPDH WHERE MaPhieuDatHang = '" + txtMaHD.Text + "'"));
            if (soluongsp == 0)
            {
                string sqlxoa = "DELETE FROM PhieuDatHang WHERE MaPhieuDatHang = '" + txtMaHD.Text + "'";
                Function.RunSql(sqlxoa);
                MessageBox.Show("Huỷ đơn đặt hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                ResetValues();
                // btnHuy.Enabled = false;
                // btnThem.Enabled = true;
                // btnThoat.Enabled = true;
            }
            else
            {
                MessageBox.Show("Xoá sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                
            }
            LoadDataToGridview();      
            txtSPXoa.Text = "";
        }

        private void dataGridView_PNH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
