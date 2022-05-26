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
    public partial class FrmQuanLyDoanhThu : Form
    {
        DataTable DoanhThu;
        public FrmQuanLyDoanhThu()
        {
            InitializeComponent();
        }

        private void FrmQuanLyDoanhThu_Load(object sender, EventArgs e)
        {
            txtThang.Value = 1;
            txtQuy.Value = 1;
            txtNam_Quy.Text = "2021";
            txtNam_Thang.Text = "2021";
            txtNam.Text = "2021";
            txtTongTien.Text = "0";
            txtSoHoaDon.Text = "0";
            txtSoHoaDon.ReadOnly = true;
            btnInBC.Enabled = false;
            btnHuy.Enabled = false;
            txtTongTien.ReadOnly = true;
        }
        private void Load_DataGridViewHoaDon()
        {
            string sql;
            sql = "SELECT MaHoaDonBan, NgayBan, GiamGia, TongTien FROM HoaDonBan WHERE 1=1";
            DoanhThu = Function.GetDataToTable(sql);
            dataGridViewDanhSach.DataSource = DoanhThu;
            dataGridViewDanhSach.Columns[0].HeaderText = "Mã HĐB";
            dataGridViewDanhSach.Columns[1].HeaderText = "Ngày bán";
            dataGridViewDanhSach.Columns[2].HeaderText = "Giảm giá";
            dataGridViewDanhSach.Columns[3].HeaderText = "Tổng tiền";
            dataGridViewDanhSach.Columns[0].Width = 180;
            dataGridViewDanhSach.Columns[1].Width = 100;
            dataGridViewDanhSach.Columns[2].Width = 100;
            dataGridViewDanhSach.Columns[3].Width = 115;
            dataGridViewDanhSach.AllowUserToAddRows = false;
            dataGridViewDanhSach.EditMode = DataGridViewEditMode.EditProgrammatically;
            txtTongTien.Text = Convert.ToString(Function.GetFieldValues("SELECT SUM (TongTien) FROM HoaDonBan WHERE 1=1"));
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNgay_Click(object sender, EventArgs e)
        {
            btnThoat.Enabled = false;
            btnThang.Enabled = false;
            btnQuy.Enabled = false;
            btnNam.Enabled = false;
            btnInBC.Enabled = true;
            btnHuy.Enabled = true;
            btnThoat.Enabled = false;
            txtTongTien.ReadOnly = true;
            txtSoHoaDon.ReadOnly = true;
            string sql;
            sql = "SELECT MaHoaDonBan, NgayBan, GiamGia, TongTien FROM HoaDonBan WHERE 1=1 AND NgayBan = '" + Function.ConvertDateTime(dateNgay.Text) + "'";
            DoanhThu = Function.GetDataToTable(sql);
            dataGridViewDanhSach.DataSource = DoanhThu;
            dataGridViewDanhSach.Columns[0].HeaderText = "Mã HĐB";
            dataGridViewDanhSach.Columns[1].HeaderText = "Ngày bán";
            dataGridViewDanhSach.Columns[2].HeaderText = "Giảm giá";
            dataGridViewDanhSach.Columns[3].HeaderText = "Tổng tiền";
            dataGridViewDanhSach.Columns[0].Width = 180;
            dataGridViewDanhSach.Columns[1].Width = 100;
            dataGridViewDanhSach.Columns[2].Width = 100;
            dataGridViewDanhSach.Columns[3].Width = 115;
            dataGridViewDanhSach.AllowUserToAddRows = false;
            dataGridViewDanhSach.EditMode = DataGridViewEditMode.EditProgrammatically;
            txtSoHoaDon.Text = Convert.ToString(Function.GetFieldValues("SELECT COUNT (MaHoaDonBan) FROM HoaDonBan WHERE 1=1 AND NgayBan = '" + Function.ConvertDateTime(dateNgay.Text) + "'"));
            txtTongTien.Text = Convert.ToString(Function.GetFieldValues("SELECT SUM (TongTien) FROM HoaDonBan WHERE 1=1 AND NgayBan = '" + Function.ConvertDateTime(dateNgay.Text) + "'"));
            if (txtSoHoaDon.Text == "0" || txtTongTien.Text == "0")
            {
                btnInBC.Enabled = false;
            }
        }

        private void btnThang_Click(object sender, EventArgs e)
        {
            btnThoat.Enabled = false;
            btnNgay.Enabled = false;
            btnQuy.Enabled = false;
            btnNam.Enabled = false;
            btnInBC.Enabled = true;
            btnHuy.Enabled = true;
            btnThoat.Enabled = false;
            txtTongTien.ReadOnly = true;
            txtSoHoaDon.ReadOnly = true;
            string sql;
            sql = "SELECT MaHoaDonBan, NgayBan, GiamGia, TongTien FROM HoaDonBan WHERE 1=1 AND MONTH (NgayBan) = '" + txtThang.Text + "' AND YEAR (NgayBan) = '" + txtNam_Thang.Text.Trim() + "'";
            DoanhThu = Function.GetDataToTable(sql);
            dataGridViewDanhSach.DataSource = DoanhThu;
            dataGridViewDanhSach.Columns[0].HeaderText = "Mã HĐB";
            dataGridViewDanhSach.Columns[1].HeaderText = "Ngày bán";
            dataGridViewDanhSach.Columns[2].HeaderText = "Giảm giá";
            dataGridViewDanhSach.Columns[3].HeaderText = "Tổng tiền";
            dataGridViewDanhSach.Columns[0].Width = 180;
            dataGridViewDanhSach.Columns[1].Width = 100;
            dataGridViewDanhSach.Columns[2].Width = 100;
            dataGridViewDanhSach.Columns[3].Width = 115;
            dataGridViewDanhSach.AllowUserToAddRows = false;
            dataGridViewDanhSach.EditMode = DataGridViewEditMode.EditProgrammatically;
            txtSoHoaDon.Text = Convert.ToString(Function.GetFieldValues("SELECT COUNT (MaHoaDonBan) FROM HoaDonBan WHERE 1=1 AND MONTH (NgayBan) = '" + txtThang.Text + "' AND YEAR (NgayBan) = '" + txtNam_Thang.Text + "'"));
            txtTongTien.Text = Convert.ToString(Function.GetFieldValues("SELECT SUM (TongTien) FROM HoaDonBan WHERE 1=1 AND MONTH (NgayBan) = '" + txtThang.Text + "' AND YEAR (NgayBan) = '" + txtNam_Thang.Text + "'"));
            if (txtSoHoaDon.Text == "0" || txtTongTien.Text == "0")
            {
                btnInBC.Enabled = false;
            }
        }

        private void btnQuy_Click(object sender, EventArgs e)
        {
            if (txtSoHoaDon.Text == "0" || txtTongTien.Text == "0")
            {
                btnInBC.Enabled = false;
            }
            btnThoat.Enabled = false;
            btnThang.Enabled = false;
            btnNgay.Enabled = false;
            btnNam.Enabled = false;
            btnInBC.Enabled = true;
            btnHuy.Enabled = true;
            btnThoat.Enabled = false;
            txtTongTien.ReadOnly = true;
            txtSoHoaDon.ReadOnly = true;
            //Xác định các quý trong năm:
            string sql;
            if (txtQuy.Value == 1)
            {
                sql = "SELECT MaHoaDonBan, NgayBan, GiamGia, TongTien FROM HoaDonBan WHERE 1=1 AND NgayBan >= '" + txtNam_Quy.Text + "-01-01' AND NgayBan <= '" + txtNam_Quy.Text + "-03-31'";
                txtTongTien.Text = Convert.ToString(Function.GetFieldValues("SELECT SUM (TongTien) FROM HoaDonBan WHERE 1=1 AND NgayBan >= '" + txtNam_Quy.Text + "-01-01' AND NgayBan <= '" + txtNam_Quy.Text + "-03-31'"));
                txtSoHoaDon.Text = Convert.ToString(Function.GetFieldValues("SELECT COUNT (MaHoaDonBan) FROM HoaDonBan WHERE 1=1 AND NgayBan >= '" + txtNam_Quy.Text + "-01-01' AND NgayBan <= '" + txtNam_Quy.Text + "-03-31'"));
            }
            else if (txtQuy.Value == 2)
            {
                sql = "SELECT MaHoaDonBan, NgayBan, GiamGia, TongTien FROM HoaDonBan WHERE 1=1 AND NgayBan >= '" + txtNam_Quy.Text + "-04-01' AND NgayBan <= '" + txtNam_Quy.Text + "-06-30'";
                txtTongTien.Text = Convert.ToString(Function.GetFieldValues("SELECT SUM (TongTien) FROM HoaDonBan WHERE 1=1 AND NgayBan >= '" + txtNam_Quy.Text + "-04-01' AND NgayBan <= '" + txtNam_Quy.Text + "-06-30'"));
                txtSoHoaDon.Text = Convert.ToString(Function.GetFieldValues("SELECT COUNT (MaHoaDonBan) FROM HoaDonBan WHERE 1=1 AND NgayBan >= '" + txtNam_Quy.Text + "-04-01' AND NgayBan <= '" + txtNam_Quy.Text + "-06-30'"));
            }
            else if (txtQuy.Value == 3)
            {
                sql = "SELECT MaHoaDonBan, NgayBan, GiamGia, TongTien FROM HoaDonBan WHERE 1=1 AND NgayBan >= '" + txtNam_Quy.Text + "-07-01' AND NgayBan <= '" + txtNam_Quy.Text + "-09-30'";
                txtTongTien.Text = Convert.ToString(Function.GetFieldValues("SELECT SUM (TongTien) FROM HoaDonBan WHERE 1=1 AND NgayBan >= '" + txtNam_Quy.Text + "-07-01' AND NgayBan <= '" + txtNam_Quy.Text + "-09-30'"));
                txtSoHoaDon.Text = Convert.ToString(Function.GetFieldValues("SELECT COUNT (MaHoaDonBan) FROM HoaDonBan WHERE 1=1 AND NgayBan >= '" + txtNam_Quy.Text + "-07-01' AND NgayBan <= '" + txtNam_Quy.Text + "-09-30'"));
            }
            else
            {
                sql = "SELECT MaHoaDonBan, NgayBan, GiamGia, TongTien FROM HoaDonBan WHERE 1=1 AND NgayBan >= '" + txtNam_Quy.Text + "-10-01' AND NgayBan <= '" + txtNam_Quy.Text + "-12-31'";
                txtTongTien.Text = Convert.ToString(Function.GetFieldValues("SELECT SUM (TongTien) FROM HoaDonBan WHERE 1=1 AND NgayBan >= '" + txtNam_Quy.Text + "-10-01' AND NgayBan <= '" + txtNam_Quy.Text + "-12-31'"));
                txtSoHoaDon.Text = Convert.ToString(Function.GetFieldValues("SELECT COUNT (MaHoaDonBan) FROM HoaDonBan WHERE 1=1 AND NgayBan >= '" + txtNam_Quy.Text + "-10-01' AND NgayBan <= '" + txtNam_Quy.Text + "-12-31'"));
            }
            DoanhThu = Function.GetDataToTable(sql);
            dataGridViewDanhSach.DataSource = DoanhThu;
            dataGridViewDanhSach.Columns[0].HeaderText = "Mã HĐB";
            dataGridViewDanhSach.Columns[1].HeaderText = "Ngày bán";
            dataGridViewDanhSach.Columns[2].HeaderText = "Giảm giá";
            dataGridViewDanhSach.Columns[3].HeaderText = "Tổng tiền";
            dataGridViewDanhSach.Columns[0].Width = 180;
            dataGridViewDanhSach.Columns[1].Width = 100;
            dataGridViewDanhSach.Columns[2].Width = 100;
            dataGridViewDanhSach.Columns[3].Width = 115;
            dataGridViewDanhSach.AllowUserToAddRows = false;
            dataGridViewDanhSach.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnNam_Click(object sender, EventArgs e)
        {
            if (txtSoHoaDon.Text == "0" || txtTongTien.Text == "0")
            {
                btnInBC.Enabled = false;
            }
            btnThoat.Enabled = false;
            btnThang.Enabled = false;
            btnQuy.Enabled = false;
            btnNgay.Enabled = false;
            btnInBC.Enabled = true;
            btnHuy.Enabled = true;
            btnThoat.Enabled = false;
            txtTongTien.ReadOnly = true;
            txtSoHoaDon.ReadOnly = true;
            string sql;
            sql = "SELECT MaHoaDonBan, NgayBan, GiamGia, TongTien FROM HoaDonBan WHERE 1=1 AND YEAR (NgayBan) = '" + txtNam.Text.Trim() + "'";
            DoanhThu = Function.GetDataToTable(sql);
            dataGridViewDanhSach.DataSource = DoanhThu;
            dataGridViewDanhSach.Columns[0].HeaderText = "Mã HĐB";
            dataGridViewDanhSach.Columns[1].HeaderText = "Ngày bán";
            dataGridViewDanhSach.Columns[2].HeaderText = "Giảm giá";
            dataGridViewDanhSach.Columns[3].HeaderText = "Tổng tiền";
            dataGridViewDanhSach.Columns[0].Width = 180;
            dataGridViewDanhSach.Columns[1].Width = 100;
            dataGridViewDanhSach.Columns[2].Width = 100;
            dataGridViewDanhSach.Columns[3].Width = 115;
            dataGridViewDanhSach.AllowUserToAddRows = false;
            dataGridViewDanhSach.EditMode = DataGridViewEditMode.EditProgrammatically;
            txtSoHoaDon.Text = Convert.ToString(Function.GetFieldValues("SELECT COUNT (MaHoaDonBan) FROM HoaDonBan WHERE 1=1 AND YEAR (NgayBan) = '" + txtNam.Text.Trim() + "'"));
            txtTongTien.Text = Convert.ToString(Function.GetFieldValues("SELECT SUM (TongTien) FROM HoaDonBan WHERE 1=1 AND YEAR (NgayBan) = '" + txtNam.Text.Trim() + "'"));
            if (txtSoHoaDon.Text == "0" || txtTongTien.Text == "0")
            {
                btnInBC.Enabled = false;
            }
        }

        private void btnInBC_Click(object sender, EventArgs e)
        {
            /*txtTongTien.ReadOnly = true;
            btnThoat.Enabled = false;
            txtSoHoaDon.ReadOnly = true;
            //In thông tin
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql_sohd, tien, ngay, thang, quy, nam;
            DataTable tblThongtinHD, tblThongTinTien;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:D50"].Font.Name = "Times new roman";
            exRange.Range["A1:D3"].Font.Size = 10;
            exRange.Range["A1:D3"].Font.Name = "Times new roman";
            exRange.Range["A1:D3"].Font.Bold = true;
            exRange.Range["A1:D3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 5;
            exRange.Range["B1:B1"].ColumnWidth = 20;
            exRange.Range["C1:C1"].ColumnWidth = 15;
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
            exRange.Range["A5:D5"].Value = "BÁO CÁO DOANH THU";
            // Theo ngày:
            if (btnNgay.Enabled == true)
            {
                sql_sohd = "SELECT COUNT (MaHoaDonBan) FROM HoaDonBan WHERE 1=1 AND NgayBan = '" + dateNgay.Text + "'";
                tien = "SELECT SUM(TongTien) FROM HoaDonBan WHERE 1 = 1 AND NgayBan = '" + dateNgay.Text + "'";
                ngay = Convert.ToString(dateNgay.Text);
                tblThongtinHD = Function.GetDataToTable(sql_sohd);
                tblThongTinTien = Function.GetDataToTable(tien);

                exRange.Range["B6:B6"].Font.Size = 12;
                exRange.Range["B6:B6"].Font.Name = "Times new roman";
                exRange.Range["B6:B6"].Font.Bold = true;
                exRange.Range["B6:B6"].Value = "Ngày:";
                exRange.Range["C6:C6"].Font.Bold = true;
                exRange.Range["C6:C6"].MergeCells = true;
                exRange.Range["C6:C6"].Value = ngay.ToString();
                exRange.Range["B8:B8"].Font.Size = 12;
                exRange.Range["B8:B8"].Font.Name = "Times new roman";
                exRange.Range["B8:B8"].Value = "Số hóa đơn bán:";
                exRange.Range["C8:C8"].MergeCells = true;
                exRange.Range["C8:C8"].Value = tblThongtinHD.Rows[0][0].ToString();
                exRange.Range["B9:B9"].Font.Size = 12;
                exRange.Range["B9:B9"].Font.Name = "Times new roman";
                exRange.Range["B9:B9"].Value = "Tổng doanh thu:";
                exRange.Range["C9:C9"].MergeCells = true;
                exRange.Range["C9:C9"].Value = tblThongTinTien.Rows[0][0].ToString();
                exRange.Range["A10:D10"].MergeCells = true;
                exRange.Range["A10:D10"].Font.Italic = true;
                exRange.Range["A10:D10"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
                exRange.Range["A10:D10"].Value = "Bằng chữ: " + Function.ChuyenSoSangChu(tblThongTinTien.Rows[0][0].ToString());
                exRange.Range["B12:D12"].MergeCells = true;
                exRange.Range["B12:D12"].Font.Italic = true;
                exRange.Range["B12:D12"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["B12:D12"].MergeCells = true;
                exRange.Range["B12:D12"].Font.Italic = true;
                DateTime d = Convert.ToDateTime(DateTime.Now);
                exRange.Range["B12:D12"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
                exSheet.Name = "Báo cáo doanh thu";
                exApp.Visible = true;
            }
            //Theo tháng:
            else if (btnThang.Enabled == true)
            {
                sql_sohd = "SELECT COUNT (MaHoaDonBan) FROM HoaDonBan WHERE 1=1 AND MONTH (NgayBan) = '" + txtThang.Text + "' AND YEAR (NgayBan) = '" + txtNam_Thang.Text + "'";
                tien = "SELECT SUM (TongTien) FROM HoaDonBan WHERE 1=1 AND MONTH (NgayBan) = '" + txtThang.Text + "' AND YEAR (NgayBan) = '" + txtNam_Thang.Text + "'";
                thang = Convert.ToString(txtThang.Text);
                nam = Convert.ToString(txtNam_Thang.Text);
                tblThongtinHD = Function.GetDataToTable(sql_sohd);
                tblThongTinTien = Function.GetDataToTable(tien);

                exRange.Range["B6:B6"].Font.Size = 12;
                exRange.Range["B6:B6"].Font.Name = "Times new roman";
                exRange.Range["B6:B6"].Font.Bold = true;
                exRange.Range["B6:B6"].Value = "Tháng:";
                exRange.Range["C6:C6"].Font.Bold = true;
                exRange.Range["C6:C6"].MergeCells = true;
                exRange.Range["C6:C6"].Value = thang.ToString();
                exRange.Range["B7:B7"].Font.Size = 12;
                exRange.Range["B7:B7"].Font.Name = "Times new roman";
                exRange.Range["B7:B7"].Font.Bold = true;
                exRange.Range["B7:B7"].Value = "Năm:";
                exRange.Range["C7:C7"].Font.Bold = true;
                exRange.Range["C7:C7"].MergeCells = true;
                exRange.Range["C7:C7"].Value = nam.ToString();

                exRange.Range["B9:B9"].Font.Size = 12;
                exRange.Range["B9:B9"].Font.Name = "Times new roman";
                exRange.Range["B9:B9"].Value = "Số hóa đơn bán:";
                exRange.Range["C9:C9"].MergeCells = true;
                exRange.Range["C9:C9"].Value = tblThongtinHD.Rows[0][0].ToString();
                exRange.Range["B10:B10"].Font.Size = 12;
                exRange.Range["B10:B10"].Font.Name = "Times new roman";
                exRange.Range["B10:B10"].Value = "Tổng doanh thu:";
                exRange.Range["C10:C10"].MergeCells = true;
                exRange.Range["C10:C10"].Value = tblThongTinTien.Rows[0][0].ToString();
                exRange.Range["A11:D11"].MergeCells = true;
                exRange.Range["A11:D11"].Font.Italic = true;
                exRange.Range["A11:D11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
                exRange.Range["A11:D11"].Value = "Bằng chữ: " + Function.ChuyenSoSangChu(tblThongTinTien.Rows[0][0].ToString());
                exRange.Range["B13:D13"].MergeCells = true;
                exRange.Range["B13:D13"].Font.Italic = true;
                exRange.Range["B13:D13"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["B13:D13"].MergeCells = true;
                exRange.Range["B13:D13"].Font.Italic = true;
                DateTime d = Convert.ToDateTime(DateTime.Now);
                exRange.Range["B13:D13"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
                exSheet.Name = "Báo cáo doanh thu";
                exApp.Visible = true;
            }
            //Theo quý:
            else if (btnQuy.Enabled == true)
            {
                if (txtQuy.Value == 1)
                {
                    tien = Convert.ToString(Function.GetFieldValues("SELECT SUM (TongTien) FROM HoaDonBan WHERE 1=1 AND NgayBan >= '" + txtNam_Quy.Text + "-01-01' AND NgayBan <= '" + txtNam_Quy.Text + "-03-31'"));
                    sql_sohd = Convert.ToString(Function.GetFieldValues("SELECT COUNT (MaHoaDonBan) FROM HoaDonBan WHERE 1=1 AND NgayBan >= '" + txtNam_Quy.Text + "-01-01' AND NgayBan <= '" + txtNam_Quy.Text + "-03-31'"));
                    quy = Convert.ToString(txtQuy.Text);
                    nam = Convert.ToString(txtNam_Quy.Text);
                    tblThongtinHD = Function.GetDataToTable(sql_sohd);
                    tblThongTinTien = Function.GetDataToTable(tien);

                    exRange.Range["B6:B6"].Font.Size = 12;
                    exRange.Range["B6:B6"].Font.Name = "Times new roman";
                    exRange.Range["B6:B6"].Font.Bold = true;
                    exRange.Range["B6:B6"].Value = "Quý:";
                    exRange.Range["C6:C6"].Font.Bold = true;
                    exRange.Range["C6:C6"].MergeCells = true;
                    exRange.Range["C6:C6"].Value = quy.ToString();
                    exRange.Range["B7:B7"].Font.Size = 12;
                    exRange.Range["B7:B7"].Font.Name = "Times new roman";
                    exRange.Range["B7:B7"].Font.Bold = true;
                    exRange.Range["B7:B7"].Value = "Năm:";
                    exRange.Range["C7:C7"].Font.Bold = true;
                    exRange.Range["C7:C7"].MergeCells = true;
                    exRange.Range["C7:C7"].Value = nam.ToString();

                    exRange.Range["B9:B9"].Font.Size = 12;
                    exRange.Range["B9:B9"].Font.Name = "Times new roman";
                    exRange.Range["B9:B9"].Value = "Số hóa đơn bán:";
                    exRange.Range["C9:C9"].MergeCells = true;
                    exRange.Range["C9:C9"].Value = tblThongtinHD.Rows[0][0].ToString();
                    exRange.Range["B10:B10"].Font.Size = 12;
                    exRange.Range["B10:B10"].Font.Name = "Times new roman";
                    exRange.Range["B10:B10"].Value = "Tổng doanh thu:";
                    exRange.Range["C10:C10"].MergeCells = true;
                    exRange.Range["C10:C10"].Value = tblThongTinTien.Rows[0][0].ToString();
                    exRange.Range["A11:D11"].MergeCells = true;
                    exRange.Range["A11:D11"].Font.Italic = true;
                    exRange.Range["A11:D11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
                    exRange.Range["A11:D11"].Value = "Bằng chữ: " + Function.ChuyenSoSangChu(tblThongTinTien.Rows[0][0].ToString());
                    exRange.Range["B13:D13"].MergeCells = true;
                    exRange.Range["B13:D13"].Font.Italic = true;
                    exRange.Range["B13:D13"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    exRange.Range["B13:D13"].MergeCells = true;
                    exRange.Range["B13:D13"].Font.Italic = true;
                    DateTime d = Convert.ToDateTime(DateTime.Now);
                    exRange.Range["B13:D13"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;

                    exSheet.Name = "Báo cáo doanh thu";
                    exApp.Visible = true;
                }
                else if (txtQuy.Value == 2)
                {
                    tien = Convert.ToString(Function.GetFieldValues("SELECT SUM (TongTien) FROM HoaDonBan WHERE 1=1 AND NgayBan >= '" + txtNam_Quy.Text + "-04-01' AND NgayBan <= '" + txtNam_Quy.Text + "-06-30'"));
                    sql_sohd = Convert.ToString(Function.GetFieldValues("SELECT COUNT (MaHoaDonBan) FROM HoaDonBan WHERE 1=1 AND NgayBan >= '" + txtNam_Quy.Text + "-04-01' AND NgayBan <= '" + txtNam_Quy.Text + "-06-30'"));
                    quy = Convert.ToString(txtQuy.Value);
                    nam = Convert.ToString(txtNam_Quy.Text);
                    tblThongtinHD = Function.GetDataToTable(sql_sohd);
                    tblThongTinTien = Function.GetDataToTable(tien);

                    exRange.Range["B6:B6"].Font.Size = 12;
                    exRange.Range["B6:B6"].Font.Name = "Times new roman";
                    exRange.Range["B6:B6"].Font.Bold = true;
                    exRange.Range["B6:B6"].Value = "Quý:";
                    exRange.Range["C6:C6"].Font.Bold = true;
                    exRange.Range["C6:C6"].MergeCells = true;
                    exRange.Range["C6:C6"].Value = quy.ToString();
                    exRange.Range["B7:B7"].Font.Size = 12;
                    exRange.Range["B7:B7"].Font.Name = "Times new roman";
                    exRange.Range["B7:B7"].Font.Bold = true;
                    exRange.Range["B7:B7"].Value = "Năm:";
                    exRange.Range["C7:C7"].Font.Bold = true;
                    exRange.Range["C7:C7"].MergeCells = true;
                    exRange.Range["C7:C7"].Value = nam.ToString();

                    exRange.Range["B9:B9"].Font.Size = 12;
                    exRange.Range["B9:B9"].Font.Name = "Times new roman";
                    exRange.Range["B9:B9"].Value = "Số hóa đơn bán:";
                    exRange.Range["C9:C9"].MergeCells = true;
                    exRange.Range["C9:C9"].Value = tblThongtinHD.Rows[0][0].ToString();
                    exRange.Range["B10:B10"].Font.Size = 12;
                    exRange.Range["B10:B10"].Font.Name = "Times new roman";
                    exRange.Range["B10:B10"].Value = "Tổng doanh thu:";
                    exRange.Range["C10:C10"].MergeCells = true;
                    exRange.Range["C10:C10"].Value = tblThongTinTien.Rows[0][0].ToString();
                    exRange.Range["A11:D11"].MergeCells = true;
                    exRange.Range["A11:D11"].Font.Italic = true;
                    exRange.Range["A11:D11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
                    exRange.Range["A11:D11"].Value = "Bằng chữ: " + Function.ChuyenSoSangChu(tblThongTinTien.Rows[0][0].ToString());
                    exRange.Range["B13:D13"].MergeCells = true;
                    exRange.Range["B13:D13"].Font.Italic = true;
                    exRange.Range["B13:D13"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    exRange.Range["B13:D13"].MergeCells = true;
                    exRange.Range["B13:D13"].Font.Italic = true;
                    DateTime d = Convert.ToDateTime(DateTime.Now);
                    exRange.Range["B13:D13"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;

                    exSheet.Name = "Báo cáo doanh thu";
                    exApp.Visible = true;
                }
                else if (txtQuy.Value == 3)
                {
                    tien = Convert.ToString(Function.GetFieldValues("SELECT SUM (TongTien) FROM HoaDonBan WHERE 1=1 AND NgayBan >= '" + txtNam_Quy.Text + "-07-01' AND NgayBan <= '" + txtNam_Quy.Text + "-09-30'"));
                    sql_sohd = Convert.ToString(Function.GetFieldValues("SELECT COUNT (MaHoaDonBan) FROM HoaDonBan WHERE 1=1 AND NgayBan >= '" + txtNam_Quy.Text + "-07-01' AND NgayBan <= '" + txtNam_Quy.Text + "-09-30'"));
                    quy = Convert.ToString(txtQuy.Text);
                    nam = Convert.ToString(txtNam_Quy.Text);
                    tblThongtinHD = Function.GetDataToTable(sql_sohd);
                    tblThongTinTien = Function.GetDataToTable(tien);

                    exRange.Range["B6:B6"].Font.Size = 12;
                    exRange.Range["B6:B6"].Font.Name = "Times new roman";
                    exRange.Range["B6:B6"].Font.Bold = true;
                    exRange.Range["B6:B6"].Value = "Quý:";
                    exRange.Range["C6:C6"].Font.Bold = true;
                    exRange.Range["C6:C6"].MergeCells = true;
                    exRange.Range["C6:C6"].Value = quy.ToString();
                    exRange.Range["B7:B7"].Font.Size = 12;
                    exRange.Range["B7:B7"].Font.Name = "Times new roman";
                    exRange.Range["B7:B7"].Font.Bold = true;
                    exRange.Range["B7:B7"].Value = "Năm:";
                    exRange.Range["C7:C7"].Font.Bold = true;
                    exRange.Range["C7:C7"].MergeCells = true;
                    exRange.Range["C7:C7"].Value = nam.ToString();

                    exRange.Range["B9:B9"].Font.Size = 12;
                    exRange.Range["B9:B9"].Font.Name = "Times new roman";
                    exRange.Range["B9:B9"].Value = "Số hóa đơn bán:";
                    exRange.Range["C9:C9"].MergeCells = true;
                    exRange.Range["C9:C9"].Value = tblThongtinHD.Rows[0][0].ToString();
                    exRange.Range["B10:B10"].Font.Size = 12;
                    exRange.Range["B10:B10"].Font.Name = "Times new roman";
                    exRange.Range["B10:B10"].Value = "Tổng doanh thu:";
                    exRange.Range["C10:C10"].MergeCells = true;
                    exRange.Range["C10:C10"].Value = tblThongTinTien.Rows[0][0].ToString();
                    exRange.Range["A11:D11"].MergeCells = true;
                    exRange.Range["A11:D11"].Font.Italic = true;
                    exRange.Range["A11:D11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
                    exRange.Range["A11:D11"].Value = "Bằng chữ: " + Function.ChuyenSoSangChu(tblThongTinTien.Rows[0][0].ToString());
                    exRange.Range["B13:D13"].MergeCells = true;
                    exRange.Range["B13:D13"].Font.Italic = true;
                    exRange.Range["B13:D13"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    exRange.Range["B13:D13"].MergeCells = true;
                    exRange.Range["B13:D13"].Font.Italic = true;
                    DateTime d = Convert.ToDateTime(DateTime.Now);
                    exRange.Range["B13:D13"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;

                    exSheet.Name = "Báo cáo doanh thu";
                    exApp.Visible = true;
                }
                else if (txtQuy.Value == 4)
                {
                    tien = Convert.ToString(Function.GetFieldValues("SELECT SUM (TongTien) FROM HoaDonBan WHERE 1=1 AND NgayBan >= '" + txtNam_Quy.Text + "-10-01' AND NgayBan <= '" + txtNam_Quy.Text + "-12-31'"));
                    sql_sohd = Convert.ToString(Function.GetFieldValues("SELECT COUNT (MaHoaDonBan) FROM HoaDonBan WHERE 1=1 AND NgayBan >= '" + txtNam_Quy.Text + "-10-01' AND NgayBan <= '" + txtNam_Quy.Text + "-12-31'"));
                    quy = Convert.ToString(txtQuy.Text);
                    nam = Convert.ToString(txtNam_Quy.Text);
                    tblThongtinHD = Function.GetDataToTable(sql_sohd);
                    tblThongTinTien = Function.GetDataToTable(tien);

                    exRange.Range["B6:B6"].Font.Size = 12;
                    exRange.Range["B6:B6"].Font.Name = "Times new roman";
                    exRange.Range["B6:B6"].Font.Bold = true;
                    exRange.Range["B6:B6"].Value = "Quý:";
                    exRange.Range["C6:C6"].Font.Bold = true;
                    exRange.Range["C6:C6"].MergeCells = true;
                    exRange.Range["C6:C6"].Value = quy.ToString();
                    exRange.Range["B7:B7"].Font.Size = 12;
                    exRange.Range["B7:B7"].Font.Name = "Times new roman";
                    exRange.Range["B7:B7"].Font.Bold = true;
                    exRange.Range["B7:B7"].Value = "Năm:";
                    exRange.Range["C7:C7"].Font.Bold = true;
                    exRange.Range["C7:C7"].MergeCells = true;
                    exRange.Range["C7:C7"].Value = nam.ToString();

                    exRange.Range["B9:B9"].Font.Size = 12;
                    exRange.Range["B9:B9"].Font.Name = "Times new roman";
                    exRange.Range["B9:B9"].Value = "Số hóa đơn bán:";
                    exRange.Range["C9:C9"].MergeCells = true;
                    exRange.Range["C9:C9"].Value = tblThongtinHD.Rows[0][0].ToString();
                    exRange.Range["B10:B10"].Font.Size = 12;
                    exRange.Range["B10:B10"].Font.Name = "Times new roman";
                    exRange.Range["B10:B10"].Value = "Tổng doanh thu:";
                    exRange.Range["C10:C10"].MergeCells = true;
                    exRange.Range["C10:C10"].Value = tblThongTinTien.Rows[0][0].ToString();
                    exRange.Range["A11:D11"].MergeCells = true;
                    exRange.Range["A11:D11"].Font.Italic = true;
                    exRange.Range["A11:D11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
                    exRange.Range["A11:D11"].Value = "Bằng chữ: " + Function.ChuyenSoSangChu(tblThongTinTien.Rows[0][0].ToString());
                    exRange.Range["B13:D13"].MergeCells = true;
                    exRange.Range["B13:D13"].Font.Italic = true;
                    exRange.Range["B13:D13"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                    exRange.Range["B13:D13"].MergeCells = true;
                    exRange.Range["B13:D13"].Font.Italic = true;
                    DateTime d = Convert.ToDateTime(DateTime.Now);
                    exRange.Range["B13:D13"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;

                    exSheet.Name = "Báo cáo doanh thu";
                    exApp.Visible = true;
                }
            }
            //Theo năm:
            else if (btnNam.Enabled == true)
            {
                sql_sohd = "SELECT COUNT (MaHoaDonBan) FROM HoaDonBan WHERE 1=1 AND YEAR (NgayBan) = '" + txtNam.Text.Trim() + "'";
                tien = "SELECT SUM(TongTien) FROM HoaDonBan WHERE  1=1 AND YEAR (NgayBan) = '" + txtNam.Text.Trim() + "'";
                nam = Convert.ToString(txtNam.Text);
                tblThongtinHD = Function.GetDataToTable(sql_sohd);
                tblThongTinTien = Function.GetDataToTable(tien);

                exRange.Range["B6:B6"].Font.Size = 12;
                exRange.Range["B6:B6"].Font.Name = "Times new roman";
                exRange.Range["B6:B6"].Font.Bold = true;
                exRange.Range["B6:B6"].Value = "Năm:";
                exRange.Range["C6:C6"].Font.Bold = true;
                exRange.Range["C6:C6"].MergeCells = true;
                exRange.Range["C6:C6"].Value = nam.ToString();
                exRange.Range["B8:B8"].Font.Size = 12;
                exRange.Range["B8:B8"].Font.Name = "Times new roman";
                exRange.Range["B8:B8"].Value = "Số hóa đơn bán:";
                exRange.Range["C8:C8"].MergeCells = true;
                exRange.Range["C8:C8"].Value = tblThongtinHD.Rows[0][0].ToString();
                exRange.Range["B9:B9"].Font.Size = 12;
                exRange.Range["B9:B9"].Font.Name = "Times new roman";
                exRange.Range["B9:B9"].Value = "Tổng doanh thu:";
                exRange.Range["C9:C9"].MergeCells = true;
                exRange.Range["C9:C9"].Value = tblThongTinTien.Rows[0][0].ToString();
                exRange.Range["A10:D10"].MergeCells = true;
                exRange.Range["A10:D10"].Font.Italic = true;
                exRange.Range["A10:D10"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
                exRange.Range["A10:D10"].Value = "Bằng chữ: " + Function.ChuyenSoSangChu(tblThongTinTien.Rows[0][0].ToString());
                exRange.Range["B12:D12"].MergeCells = true;
                exRange.Range["B12:D12"].Font.Italic = true;
                exRange.Range["B12:D12"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
                exRange.Range["B12:D12"].MergeCells = true;
                exRange.Range["B12:D12"].Font.Italic = true;
                DateTime d = Convert.ToDateTime(DateTime.Now);
                exRange.Range["B12:D12"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
                exSheet.Name = "Báo cáo doanh thu";
                exApp.Visible = true;
            }
            */
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtThang.Value = 1;
            txtQuy.Value = 1;
            txtNam_Quy.Text = "2021";
            txtNam_Thang.Text = "2021";
            txtNam.Text = "2021";
            txtTongTien.Text = "0";
            txtSoHoaDon.ReadOnly = true;
            txtSoHoaDon.Text = "0";
            Load_DataGridViewHoaDon();
            btnInBC.Enabled = false;
            btnHuy.Enabled = false;
            btnThoat.Enabled = true;
            btnNgay.Enabled = true;
            btnQuy.Enabled = true;
            btnThang.Enabled = true;
            btnNam.Enabled = true;
            txtTongTien.ReadOnly = true;
        }

       
    }
}
