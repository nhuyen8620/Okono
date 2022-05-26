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
    public partial class FrmThongKe : Form
    {
        DataTable tblThongKe;
        public FrmThongKe()
        {
            InitializeComponent();
        }

        private void FrmQuanLyHoaDon_Load(object sender, EventArgs e)
        {
            txtThang.Enabled = false;
            txtQuy.Enabled = false;
            txtNam_Thang.Enabled = false;
            txtNamQuy.Enabled = false;
            txtNam.Enabled = false;
            btnIn.Enabled = false;
            btnHuy.Enabled = false;
            btnNam.Enabled = false;
            btnQuy.Enabled = false;
            btnThang.Enabled = false;
            txtNam_Thang.Text = "2021";
            txtNamQuy.Text = "2021";
            txtNam.Text = "2021";
        }

        private void btnIn_Click(object sender, EventArgs e)
        {/*
            if(ckTopdau.Checked==true && btnThang.Enabled==true)
            {
                COMExcel.Application exApp = new COMExcel.Application();
                COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
                COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
                COMExcel.Range exRange;
                string sql;
                int hang = 0, cot = 0;
                DataTable tblThongtinHang;
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
                exRange.Range["A5:D5"].Value = "TOP CÁC SẢN PHẨM BÁN CHẠY ";
                exRange.Range["A6:D6"].Font.Size = 16;
                exRange.Range["A6:D6"].Font.Name = "Times new roman";
                exRange.Range["A6:D6"].Font.Bold = true;
                exRange.Range["A6:D6"].Font.ColorIndex = 3; //Màu đỏ
                exRange.Range["A6:D6"].MergeCells = true;
                exRange.Range["A6:D6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["A6:D6"].Value = "THÁNG " + txtThang.Text;
                // Biểu diễn thông tin chung của hóa đơn bán
                //Lấy thông tin các mặt hàng
                sql = sql = "select top (5) TenSanPham, sum(SoLuongBan), TenDonViTinh" +
                    " from ChiTietHDB a join SanPham b on a.MaSanPham = b.MaSanPham join HoaDonBan c on a.MaHoaDonBan = c.MaHoaDonBan join DonViTinh d on b.MaDonViTinh=d.MaDonViTinh" +
                    " where 1=1 and MONTH(NgayBan) = '" + txtThang.Text + "' and YEAR(NgayBan) = '" + txtNam_Thang.Text + "'" +
                    " group by TenSanPham, b.MaSanPham, TenDonViTinh order by sum(SoLuongBan) DESC";
                tblThongtinHang = Function.GetDataToTable(sql);
                //Tạo dòng tiêu đề bảng
                exRange.Range["A8:D8"].Font.Bold = true;
                exRange.Range["A8:D20"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["C8:D8"].ColumnWidth = 12;
                exRange.Range["A8:A8"].Value = "STT";
                exRange.Range["B8:B8"].Value = "Tên sản phẩm";
                exRange.Range["C8:C8"].Value = "Số lượng bán";
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
                exApp.Visible = true;
            }
            if (ckTopCuoi.Checked == true && btnThang.Enabled == true)
            {
                COMExcel.Application exApp = new COMExcel.Application();
                COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
                COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
                COMExcel.Range exRange;
                string sql;
                int hang = 0, cot = 0;
                DataTable tblThongtinHang;
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
                exRange.Range["A5:D5"].Value = "TOP CÁC SẢN PHẨM TIÊU THỤ KÉM " ;
                exRange.Range["A6:D6"].Font.Size = 16;
                exRange.Range["A6:D6"].Font.Name = "Times new roman";
                exRange.Range["A6:D6"].Font.Bold = true;
                exRange.Range["A6:D6"].Font.ColorIndex = 3; //Màu đỏ
                exRange.Range["A6:D6"].MergeCells = true;
                exRange.Range["A6:D6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["A6:D6"].Value = "THÁNG " + txtThang.Text;

                //Lấy thông tin các mặt hàng
                sql = "select top (5) TenSanPham, sum(SoLuongBan), TenDonViTinh" +
                    " from ChiTietHDB a join SanPham b on a.MaSanPham = b.MaSanPham join HoaDonBan c on a.MaHoaDonBan = c.MaHoaDonBan join DonViTinh d on b.MaDonViTinh=d.MaDonViTinh" +
                    " where 1=1 and MONTH(NgayBan) = '" + txtThang.Text + "' and YEAR(NgayBan) = '" + txtNam_Thang.Text + "'" +
                    " group by TenSanPham, b.MaSanPham, TenDonViTinh order by sum(SoLuongBan) ASC";
                tblThongtinHang = Function.GetDataToTable(sql);
                //Tạo dòng tiêu đề bảng
                exRange.Range["A8:D8"].Font.Bold = true;
                exRange.Range["A8:D20"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["C8:D8"].ColumnWidth = 12;
                exRange.Range["A8:A8"].Value = "STT";
                exRange.Range["B8:B8"].Value = "Tên sản phẩm";
                exRange.Range["C8:C8"].Value = "Số lượng bán";
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
                
                exApp.Visible = true;
            }
            if (ckTopdau.Checked == true && btnNam.Enabled == true)
            {
                COMExcel.Application exApp = new COMExcel.Application();
                COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
                COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
                COMExcel.Range exRange;
                string sql;
                int hang = 0, cot = 0;
                DataTable tblThongtinHang;
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
                exRange.Range["A5:D5"].Value = "TOP CÁC SẢN PHẨM TIÊU THỤ TỐT ";
                exRange.Range["A6:D6"].Font.Size = 16;
                exRange.Range["A6:D6"].Font.Name = "Times new roman";
                exRange.Range["A6:D6"].Font.Bold = true;
                exRange.Range["A6:D6"].Font.ColorIndex = 3; //Màu đỏ
                exRange.Range["A6:D6"].MergeCells = true;
                exRange.Range["A6:D6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["A6:D6"].Value = "NĂM " + txtNam.Text;

                //Lấy thông tin các mặt hàng
                sql = "select top (5) TenSanPham, sum(SoLuongBan), TenDonViTinh" +
                    " from ChiTietHDB a join SanPham b on a.MaSanPham = b.MaSanPham " +
                    "join HoaDonBan c on a.MaHoaDonBan = c.MaHoaDonBan join DonViTinh d on b.MaDonViTinh=d.MaDonViTinh" +
                    " where 1=1 and YEAR(NgayBan) = '" + txtNam.Text + "'" +
                    " group by TenSanPham, b.MaSanPham, TenDonViTinh order by sum(SoLuongBan) DESC";
                tblThongtinHang = Function.GetDataToTable(sql);
                //Tạo dòng tiêu đề bảng
                exRange.Range["A8:D8"].Font.Bold = true;
                exRange.Range["A8:D20"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["C8:D8"].ColumnWidth = 12;
                exRange.Range["A8:A8"].Value = "STT";
                exRange.Range["B8:B8"].Value = "Tên sản phẩm";
                exRange.Range["C8:C8"].Value = "Số lượng bán";
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

                exApp.Visible = true;
            }
            if (ckTopCuoi.Checked == true && btnNam.Enabled == true)
            {
                COMExcel.Application exApp = new COMExcel.Application();
                COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
                COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
                COMExcel.Range exRange;
                string sql;
                int hang = 0, cot = 0;
                DataTable tblThongtinHang;
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
                exRange.Range["A5:D5"].Value = "TOP CÁC SẢN PHẨM TIÊU THỤ KÉM ";
                exRange.Range["A6:D6"].Font.Size = 16;
                exRange.Range["A6:D6"].Font.Name = "Times new roman";
                exRange.Range["A6:D6"].Font.Bold = true;
                exRange.Range["A6:D6"].Font.ColorIndex = 3; //Màu đỏ
                exRange.Range["A6:D6"].MergeCells = true;
                exRange.Range["A6:D6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["A6:D6"].Value = "NĂM " + txtNam.Text;

                //Lấy thông tin các mặt hàng
                sql = "select top (5) TenSanPham, sum(SoLuongBan), TenDonViTinh" +
                    " from ChiTietHDB a join SanPham b on a.MaSanPham = b.MaSanPham " +
                    "join HoaDonBan c on a.MaHoaDonBan = c.MaHoaDonBan join DonViTinh d on b.MaDonViTinh=d.MaDonViTinh" +
                    " where 1=1 and YEAR(NgayBan) = '" + txtNam.Text + "'" +
                    " group by TenSanPham, b.MaSanPham, TenDonViTinh order by sum(SoLuongBan) ASC";
                tblThongtinHang = Function.GetDataToTable(sql);
                //Tạo dòng tiêu đề bảng
                exRange.Range["A8:D8"].Font.Bold = true;
                exRange.Range["A8:D20"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["C8:D8"].ColumnWidth = 12;
                exRange.Range["A8:A8"].Value = "STT";
                exRange.Range["B8:B8"].Value = "Tên sản phẩm";
                exRange.Range["C8:C8"].Value = "Số lượng bán";
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

                exApp.Visible = true;
            }

            if (ckTopdau.Checked == true && btnQuy.Enabled == true)
            {
                COMExcel.Application exApp = new COMExcel.Application();
                COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
                COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
                COMExcel.Range exRange;
                string sql;
                int hang = 0, cot = 0;
                DataTable tblThongtinHang;
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
                exRange.Range["A5:D5"].Value = "TOP CÁC SẢN PHẨM TIÊU THỤ TỐT ";
                exRange.Range["A6:D6"].Font.Size = 16;
                exRange.Range["A6:D6"].Font.Name = "Times new roman";
                exRange.Range["A6:D6"].Font.Bold = true;
                exRange.Range["A6:D6"].Font.ColorIndex = 3; //Màu đỏ
                exRange.Range["A6:D6"].MergeCells = true;
                exRange.Range["A6:D6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["A6:D6"].Value = "QUÝ " + txtQuy.Text + " NĂM "+txtNamQuy.Text;

                //Lấy thông tin các mặt hàng
                if (txtQuy.Value == 1)
                {
                    sql = "select top (5) TenSanPham, sum(SoLuongBan), TenDonViTinh" +
                    " from ChiTietHDB a join SanPham b on a.MaSanPham = b.MaSanPham " +
                    "join HoaDonBan c on a.MaHoaDonBan = c.MaHoaDonBan join DonViTinh d on b.MaDonViTinh=d.MaDonViTinh" +
                    " where 1=1 and NgayBan between '" + txtNamQuy.Text + "-01-01' and '" + txtNamQuy.Text + "-03-31'" +
                    " group by TenSanPham, b.MaSanPham, TenDonViTinh order by sum(SoLuongBan) DESC";

                }
                else if (txtQuy.Value == 2)
                {
                    sql = "select top (5) TenSanPham, sum(SoLuongBan), TenDonViTinh" +
                    " from ChiTietHDB a join SanPham b on a.MaSanPham = b.MaSanPham " +
                    "join HoaDonBan c on a.MaHoaDonBan = c.MaHoaDonBan join DonViTinh d on b.MaDonViTinh=d.MaDonViTinh" +
                    " where 1=1 and NgayBan between '" + txtNamQuy.Text + "-04-01' and '" + txtNamQuy.Text + "-06-30'" +
                    " group by TenSanPham, b.MaSanPham, TenDonViTinh order by sum(SoLuongBan) DESC";

                }
                else if (txtQuy.Value == 3)
                {
                    sql = "select top (5) TenSanPham, sum(SoLuongBan), TenDonViTinh" +
                    " from ChiTietHDB a join SanPham b on a.MaSanPham = b.MaSanPham " +
                    "join HoaDonBan c on a.MaHoaDonBan = c.MaHoaDonBan join DonViTinh d on b.MaDonViTinh=d.MaDonViTinh" +
                    " where 1=1 and NgayBan between '" + txtNamQuy.Text + "-07-01' and '" + txtNamQuy.Text + "-09-30'" +
                    " group by TenSanPham, b.MaSanPham, TenDonViTinh order by sum(SoLuongBan) DESC";

                }
                else
                {
                    sql = "select top (5) TenSanPham, sum(SoLuongBan), TenDonViTinh" +
                    " from ChiTietHDB a join SanPham b on a.MaSanPham = b.MaSanPham " +
                    "join HoaDonBan c on a.MaHoaDonBan = c.MaHoaDonBan join DonViTinh d on b.MaDonViTinh=d.MaDonViTinh" +
                    " where 1=1 and NgayBan between '" + txtNamQuy.Text + "-10-01' and '" + txtNamQuy.Text + "-12-31'" +
                    " group by TenSanPham, b.MaSanPham, TenDonViTinh order by sum(SoLuongBan) DESC";

                }
                
                tblThongtinHang = Function.GetDataToTable(sql);
                //Tạo dòng tiêu đề bảng
                exRange.Range["A8:D8"].Font.Bold = true;
                exRange.Range["A8:D20"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["C8:D8"].ColumnWidth = 12;
                exRange.Range["A8:A8"].Value = "STT";
                exRange.Range["B8:B8"].Value = "Tên sản phẩm";
                exRange.Range["C8:C8"].Value = "Số lượng bán";
                exRange.Range["D8:D8"].Value = "Đơn vị tính";
                for (hang = 0; hang <= tblThongtinHang.Rows.Count - 1; hang++)
                {
                    //Điền số thứ tự vào cột 1 từ dòng 9
                    exSheet.Cells[1][hang + 9] = hang + 1;
                    for (cot = 0; cot <= tblThongtinHang.Columns.Count - 1; cot++)
                        //Điền thông tin hàng từ cột thứ 2, dòng 12
                        exSheet.Cells[cot + 2][hang + 9] = tblThongtinHang.Rows[hang][cot].ToString();
                }              
                exApp.Visible = true;
            }
            if (ckTopCuoi.Checked == true && btnThang.Enabled == true)
            {
                COMExcel.Application exApp = new COMExcel.Application();
                COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
                COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
                COMExcel.Range exRange;
                string sql;
                int hang = 0, cot = 0;
                DataTable tblThongtinHang;
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
                exRange.Range["A5:D5"].Value = "TOP CÁC SẢN PHẨM TIÊU THỤ KÉM ";
                exRange.Range["A6:D6"].Font.Size = 16;
                exRange.Range["A6:D6"].Font.Name = "Times new roman";
                exRange.Range["A6:D6"].Font.Bold = true;
                exRange.Range["A6:D6"].Font.ColorIndex = 3; //Màu đỏ
                exRange.Range["A6:D6"].MergeCells = true;
                exRange.Range["A6:D6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["A6:D6"].Value = "QUÝ " + txtQuy.Text+" NĂM "+txtNamQuy.Text;

                //Lấy thông tin các mặt hàng
                if (txtQuy.Value == 1)
                {
                    sql = "select top (5) TenSanPham, sum(SoLuongBan), TenDonViTinh" +
                    " from ChiTietHDB a join SanPham b on a.MaSanPham = b.MaSanPham " +
                    "join HoaDonBan c on a.MaHoaDonBan = c.MaHoaDonBan join DonViTinh d on b.MaDonViTinh=d.MaDonViTinh" +
                    " where 1=1 and NgayBan between '" + txtNamQuy.Text + "-01-01' and '" + txtNamQuy.Text + "-03-31'" +
                    " group by TenSanPham, b.MaSanPham, TenDonViTinh order by sum(SoLuongBan) DESC";

                }
                else if (txtQuy.Value == 2)
                {
                    sql = "select top (5) TenSanPham, sum(SoLuongBan), TenDonViTinh" +
                    " from ChiTietHDB a join SanPham b on a.MaSanPham = b.MaSanPham " +
                    "join HoaDonBan c on a.MaHoaDonBan = c.MaHoaDonBan join DonViTinh d on b.MaDonViTinh=d.MaDonViTinh" +
                    " where 1=1 and NgayBan between '" + txtNamQuy.Text + "-04-01' and '" + txtNamQuy.Text + "-06-30'" +
                    " group by TenSanPham, b.MaSanPham, TenDonViTinh order by sum(SoLuongBan) DESC";

                }
                else if (txtQuy.Value == 3)
                {
                    sql = "select top (5) TenSanPham, sum(SoLuongBan), TenDonViTinh" +
                    " from ChiTietHDB a join SanPham b on a.MaSanPham = b.MaSanPham " +
                    "join HoaDonBan c on a.MaHoaDonBan = c.MaHoaDonBan join DonViTinh d on b.MaDonViTinh=d.MaDonViTinh" +
                    " where 1=1 and NgayBan between '" + txtNamQuy.Text + "-07-01' and '" + txtNamQuy.Text + "-09-30'" +
                    " group by TenSanPham, b.MaSanPham, TenDonViTinh order by sum(SoLuongBan) DESC";

                }
                else
                {
                    sql = "select top (5) TenSanPham, sum(SoLuongBan), TenDonViTinh" +
                    " from ChiTietHDB a join SanPham b on a.MaSanPham = b.MaSanPham " +
                    "join HoaDonBan c on a.MaHoaDonBan = c.MaHoaDonBan join DonViTinh d on b.MaDonViTinh=d.MaDonViTinh" +
                    " where 1=1 and NgayBan between '" + txtNamQuy.Text + "-10-01' and '" + txtNamQuy.Text + "-12-31'" +
                    " group by TenSanPham, b.MaSanPham, TenDonViTinh order by sum(SoLuongBan) DESC";

                }
                tblThongtinHang = Function.GetDataToTable(sql);
                //Tạo dòng tiêu đề bảng
                exRange.Range["A8:D8"].Font.Bold = true;
                exRange.Range["A8:D20"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["C8:D8"].ColumnWidth = 12;
                exRange.Range["A8:A8"].Value = "STT";
                exRange.Range["B8:B8"].Value = "Tên sản phẩm";
                exRange.Range["C8:C8"].Value = "Số lượng bán";
                exRange.Range["D8:D8"].Value = "Đơn vị tính";
                for (hang = 0; hang <= tblThongtinHang.Rows.Count - 1; hang++)
                {
                    //Điền số thứ tự vào cột 1 từ dòng 9
                    exSheet.Cells[1][hang + 9] = hang + 1;
                    for (cot = 0; cot <= tblThongtinHang.Columns.Count - 1; cot++)
                        //Điền thông tin hàng từ cột thứ 2, dòng 12
                        exSheet.Cells[cot + 2][hang + 9] = tblThongtinHang.Rows[hang][cot].ToString();
                }                
                exApp.Visible = true;
            }
            */
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThang_Click(object sender, EventArgs e)
        {
            /*txtThang.Enabled = true;
            txtQuy.Enabled = false;
            txtNam_Thang.Enabled = true;
            txtNamQuy.Enabled = false;
            txtNam.Enabled = false;*/
            
            btnIn.Enabled = true;
            btnHuy.Enabled = true;
            btnQuy.Enabled = false;
            btnNam.Enabled = false;
            ckTopdau.Enabled = false;
            ckTopCuoi.Enabled = false;
            string sql;
            if (ckTopdau.Checked==true)
            {
                
                sql = "select top (5) b.MaSanPham, TenSanPham, sum(SoLuongBan)" +
                    " from ChiTietHDB a join SanPham b on a.MaSanPham = b.MaSanPham join HoaDonBan c on a.MaHoaDonBan = c.MaHoaDonBan" +
                    " where 1=1 and MONTH(NgayBan) = '" + txtThang.Text + "' and YEAR(NgayBan) = '" + txtNam_Thang.Text + "'" +
                    " group by TenSanPham, b.MaSanPham order by sum(SoLuongBan) DESC";
                tblThongKe = Function.GetDataToTable(sql);
                dataGridView_SP.DataSource = tblThongKe;
                dataGridView_SP.Columns[0].HeaderText = "Mã Hàng";
                dataGridView_SP.Columns[1].HeaderText = "Tên mặt hàng";
                dataGridView_SP.Columns[2].HeaderText = "Số lượng bán ra";
                dataGridView_SP.Columns[0].Width = 80;
                dataGridView_SP.Columns[1].Width = 100;
                dataGridView_SP.Columns[2].Width = 100;
                dataGridView_SP.AllowUserToAddRows = false;
                dataGridView_SP.EditMode = DataGridViewEditMode.EditProgrammatically;
            }    
            if(ckTopCuoi.Checked==true)
            {
                sql = "select top (5) b.MaSanPham, TenSanPham, sum(SoLuongBan)" +
                    " from ChiTietHDB a join SanPham b on a.MaSanPham = b.MaSanPham join HoaDonBan c on a.MaHoaDonBan = c.MaHoaDonBan" +
                    " where 1=1 and MONTH(NgayBan) = '" + txtThang.Text + "' and YEAR(NgayBan) = '" + txtNam_Thang.Text + "'" +
                    " group by TenSanPham, b.MaSanPham order by sum(SoLuongBan) ASC";
                tblThongKe = Function.GetDataToTable(sql);
                dataGridView_SP.DataSource = tblThongKe;
                dataGridView_SP.Columns[0].HeaderText = "Mã Hàng";
                dataGridView_SP.Columns[1].HeaderText = "Tên mặt hàng";
                dataGridView_SP.Columns[2].HeaderText = "Số lượng bán ra";
                dataGridView_SP.Columns[0].Width = 80;
                dataGridView_SP.Columns[1].Width = 100;
                dataGridView_SP.Columns[2].Width = 100;
                dataGridView_SP.AllowUserToAddRows = false;
                dataGridView_SP.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            
        }

        private void btnQuy_Click(object sender, EventArgs e)
        {
            btnIn.Enabled = true;
            btnHuy.Enabled = true;
            btnThang.Enabled = false;
            btnNam.Enabled = false;
            ckTopdau.Enabled = false;
            ckTopCuoi.Enabled = false;
            if (ckTopdau.Checked==true)
            {
                string sql;
                if (txtQuy.Value == 1)
                {
                    sql = "select top (5) b.MaSanPham, TenSanPham, sum(SoLuongBan)" +
                    " from ChiTietHDB a join SanPham b on a.MaSanPham = b.MaSanPham join HoaDonBan c on a.MaHoaDonBan = c.MaHoaDonBan" +
                    " where 1=1 and NgayBan between '" + txtNamQuy.Text + "-01-01' and '" + txtNamQuy.Text + "-03-31'" +
                    " group by TenSanPham, b.MaSanPham order by sum(SoLuongBan) DESC";

                }
                else if (txtQuy.Value == 2)
                {
                    sql = "select top (5) b.MaSanPham, TenSanPham, sum(SoLuongBan)" +
                    " from ChiTietHDB a join SanPham b on a.MaSanPham = b.MaSanPham join HoaDonBan c on a.MaHoaDonBan = c.MaHoaDonBan" +
                    " where 1=1 and NgayBan between '" + txtNamQuy.Text + "-04-01' and '" + txtNamQuy.Text + "-06-30'" +
                    " group by TenSanPham, b.MaSanPham order by sum(SoLuongBan) DESC";

                }
                else if (txtQuy.Value == 3)
                {
                    sql = "select top (5) b.MaSanPham, TenSanPham, sum(SoLuongBan)" +
                     " from ChiTietHDB a join SanPham b on a.MaSanPham = b.MaSanPham join HoaDonBan c on a.MaHoaDonBan = c.MaHoaDonBan" +
                     " where 1=1 and NgayBan between '" + txtNamQuy.Text + "-07-01' and '" + txtNamQuy.Text + "-09-30'" +
                     " group by TenSanPham, b.MaSanPham order by sum(SoLuongBan) DESC";

                }
                else
                {
                    sql = "select top (5) b.MaSanPham, TenSanPham, sum(SoLuongBan)" +
                    " from ChiTietHDB a join SanPham b on a.MaSanPham = b.MaSanPham join HoaDonBan c on a.MaHoaDonBan = c.MaHoaDonBan" +
                    " where 1=1 and NgayBan between '" + txtNamQuy.Text + "-10-01' and '" + txtNamQuy.Text + "-12-31'" +
                    " group by TenSanPham, b.MaSanPham order by sum(SoLuongBan) DESC";
                }
                tblThongKe = Function.GetDataToTable(sql);
                dataGridView_SP.DataSource = tblThongKe;
                dataGridView_SP.Columns[0].HeaderText = "Mã Hàng";
                dataGridView_SP.Columns[1].HeaderText = "Tên mặt hàng";
                dataGridView_SP.Columns[2].HeaderText = "Số lượng bán ra";
                dataGridView_SP.Columns[0].Width = 80;
                dataGridView_SP.Columns[1].Width = 100;
                dataGridView_SP.Columns[2].Width = 100;
                dataGridView_SP.AllowUserToAddRows = false;
                dataGridView_SP.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            if (ckTopCuoi.Checked==true)
            {
                string sql;
                if (txtQuy.Value == 1)
                {
                    sql = "select top (5) b.MaSanPham, TenSanPham, sum(SoLuongBan)" +
                    " from ChiTietHDB a join SanPham b on a.MaSanPham = b.MaSanPham join HoaDonBan c on a.MaHoaDonBan = c.MaHoaDonBan" +
                    " where 1=1 and NgayBan between '" + txtNamQuy.Text + "-01-01' and '" + txtNamQuy.Text + "-03-31'" +
                    " group by TenSanPham, b.MaSanPham order by sum(SoLuongBan) ASC";

                }
                else if (txtQuy.Value == 2)
                {
                    sql = "select top (5) b.MaSanPham, TenSanPham, sum(SoLuongBan)" +
                    " from ChiTietHDB a join SanPham b on a.MaSanPham = b.MaSanPham join HoaDonBan c on a.MaHoaDonBan = c.MaHoaDonBan" +
                    " where 1=1 and NgayBan between '" + txtNamQuy.Text + "-04-01' and '" + txtNamQuy.Text + "-06-30'" +
                    " group by TenSanPham, b.MaSanPham order by sum(SoLuongBan) ASC";

                }
                else if (txtQuy.Value == 3)
                {
                    sql = "select top (5) b.MaSanPham, TenSanPham, sum(SoLuongBan)" +
                     " from ChiTietHDB a join SanPham b on a.MaSanPham = b.MaSanPham join HoaDonBan c on a.MaHoaDonBan = c.MaHoaDonBan" +
                     " where 1=1 and NgayBan between '" + txtNamQuy.Text + "-07-01' and '" + txtNamQuy.Text + "-09-30'" +
                     " group by TenSanPham, b.MaSanPham order by sum(SoLuongBan) ASC";

                }
                else
                {
                    sql = "select top (5) b.MaSanPham, TenSanPham, sum(SoLuongBan)" +
                    " from ChiTietHDB a join SanPham b on a.MaSanPham = b.MaSanPham join HoaDonBan c on a.MaHoaDonBan = c.MaHoaDonBan" +
                    " where 1=1 and NgayBan between '" + txtNamQuy.Text + "-10-01' and '" + txtNamQuy.Text + "-12-31'" +
                    " group by TenSanPham, b.MaSanPham order by sum(SoLuongBan) ASC";
                }
                tblThongKe = Function.GetDataToTable(sql);
                dataGridView_SP.DataSource = tblThongKe;
                dataGridView_SP.Columns[0].HeaderText = "Mã Hàng";
                dataGridView_SP.Columns[1].HeaderText = "Tên mặt hàng";
                dataGridView_SP.Columns[2].HeaderText = "Số lượng bán ra";
                dataGridView_SP.Columns[0].Width = 80;
                dataGridView_SP.Columns[1].Width = 100;
                dataGridView_SP.Columns[2].Width = 100;
                dataGridView_SP.AllowUserToAddRows = false;
                dataGridView_SP.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
        }

        private void btnNam_Click(object sender, EventArgs e)
        {
            btnIn.Enabled = true;
            btnHuy.Enabled = true;
            btnQuy.Enabled = false;
            btnThang.Enabled = false;
            ckTopdau.Enabled = false;
            ckTopCuoi.Enabled = false;
            if(ckTopdau.Checked==true)
            {
                string sql;
                sql = "select top (5) b.MaSanPham, TenSanPham, sum(SoLuongBan)" +
                    " from ChiTietHDB a join SanPham b on a.MaSanPham = b.MaSanPham join HoaDonBan c on a.MaHoaDonBan = c.MaHoaDonBan" +
                    " where 1=1 and YEAR(NgayBan) = '" + txtNam.Text + "'" +
                    " group by TenSanPham, b.MaSanPham order by sum(SoLuongBan) DESC";
                tblThongKe = Function.GetDataToTable(sql);
                dataGridView_SP.DataSource = tblThongKe;
                dataGridView_SP.Columns[0].HeaderText = "Mã Hàng";
                dataGridView_SP.Columns[1].HeaderText = "Tên mặt hàng";
                dataGridView_SP.Columns[2].HeaderText = "Số lượng bán ra";
                dataGridView_SP.Columns[0].Width = 80;
                dataGridView_SP.Columns[1].Width = 100;
                dataGridView_SP.Columns[2].Width = 100;
                dataGridView_SP.AllowUserToAddRows = false;
                dataGridView_SP.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            if (ckTopCuoi.Checked==true)
            {
                string sql;
                sql = "select top (5) b.MaSanPham, TenSanPham, sum(SoLuongBan)" +
                    " from ChiTietHDB a join SanPham b on a.MaSanPham = b.MaSanPham join HoaDonBan c on a.MaHoaDonBan = c.MaHoaDonBan" +
                    " where 1=1 and YEAR(NgayBan) = '" + txtNam.Text + "'" +
                    " group by TenSanPham, b.MaSanPham order by sum(SoLuongBan) ASC";
                tblThongKe = Function.GetDataToTable(sql);
                dataGridView_SP.DataSource = tblThongKe;
                dataGridView_SP.Columns[0].HeaderText = "Mã Hàng";
                dataGridView_SP.Columns[1].HeaderText = "Tên mặt hàng";
                dataGridView_SP.Columns[2].HeaderText = "Số lượng bán ra";
                dataGridView_SP.Columns[0].Width = 80;
                dataGridView_SP.Columns[1].Width = 100;
                dataGridView_SP.Columns[2].Width = 100;
                dataGridView_SP.AllowUserToAddRows = false;
                dataGridView_SP.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ckTopCuoi.Checked = false;
            ckTopdau.Checked = false;
            ckTopCuoi.Enabled = true;
            ckTopdau.Enabled = true;
            txtThang.Text = "";
            txtNam_Thang.Text = "2021";
            txtQuy.Text = "";
            txtNamQuy.Text = "2021";
            txtNam.Text = "2021";
            txtThang.Enabled = false;
            txtQuy.Enabled = false;
            txtNam_Thang.Enabled = false;
            txtNamQuy.Enabled = false;
            txtNam.Enabled = false;
            btnIn.Enabled = false;
            //btnHuy.Enabled = false;
        }         

        private void ckTopdau_CheckedChanged(object sender, EventArgs e)
        {
            ckTopCuoi.Enabled = false;
            btnThang.Enabled = true;
            btnQuy.Enabled = true;
            btnNam.Enabled = true;
            txtThang.Enabled = true;
            txtQuy.Enabled = true;
            txtNam_Thang.Enabled = true;
            txtNamQuy.Enabled = true;
            txtNam.Enabled = true;

        }

        private void ckTopCuoi_CheckedChanged(object sender, EventArgs e)
        {
            ckTopdau.Enabled = false;
            btnThang.Enabled = true;
            btnQuy.Enabled = true;
            btnNam.Enabled = true;
            txtThang.Enabled = true;
            txtQuy.Enabled = true;
            txtNam_Thang.Enabled = true;
            txtNamQuy.Enabled = true;
            txtNam.Enabled = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtThang_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtNam_Thang_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
