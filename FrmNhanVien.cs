using Okono_Mmanagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Okono
{
    public partial class FrmNhanVien : Form
    {
        List<GioiTinh> gioiTinh = new List<GioiTinh>();

        public FrmNhanVien()
        {
            InitializeComponent();
        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            tbMaNhanVien.ReadOnly = true;
            tbTenNhanVien.ReadOnly = true;
            tbNgaySinh.ReadOnly = true;
            cbGioiTinh.Enabled = false;
            tbDiaChi.ReadOnly = true;
            tbSoDienThoai.ReadOnly = true;
            tbLuongCoBan.ReadOnly = true;
            cbCaLamViec.Enabled = false;
            cbChucVu.Enabled = false;
            cbDiaChiLamViec.Enabled = false;
            tbTenTaiKhoan.ReadOnly = true;
            tbMatKhau.ReadOnly = true;
            // Lay danh sach nhan vien
            layLaiDanhSachNhanVien();

            // Lay danh sach gioi tinh
            gioiTinh.Add(new GioiTinh()
            {
                Key = "Nam",
                Value = "Nam"
            });
            gioiTinh.Add(new GioiTinh()
            {
                Key = "Nữ",
                Value = "Nữ"
            });
            cbGioiTinh.DataSource = gioiTinh;
            cbGioiTinh.ValueMember = "Key";
            cbGioiTinh.DisplayMember = "Value";
            cbGioiTinh.SelectedItem = null;

            // Lay danh sach ca lam viec
            string caLamViecSql = "SELECT MaCaLamViec, TenCaLamViec FROM CaLamViec WHERE CaLamViec.DaXoa = 0";
            SqlDataAdapter caLamViecSqlData = new SqlDataAdapter(caLamViecSql, Function.conn);
            DataTable calamViecTable = new DataTable();
            caLamViecSqlData.Fill(calamViecTable);
            cbCaLamViec.DataSource = calamViecTable;
            cbCaLamViec.ValueMember = calamViecTable.Columns[0].ColumnName;
            cbCaLamViec.DisplayMember = calamViecTable.Columns[1].ColumnName;
            cbCaLamViec.SelectedItem = null;

            // Lay danh sach chuc vu
            string chucVuSql = "SELECT MaChucVu, TenChucVu FROM ChucVu WHERE ChucVu.DaXoa = 0";
            SqlDataAdapter chucVuSqlData = new SqlDataAdapter(chucVuSql, Function.conn);
            DataTable chucVuTable = new DataTable();
            chucVuSqlData.Fill(chucVuTable);
            cbChucVu.DataSource = chucVuTable;
            cbChucVu.ValueMember = chucVuTable.Columns[0].ColumnName;
            cbChucVu.DisplayMember = chucVuTable.Columns[1].ColumnName;
            cbChucVu.SelectedItem = null;

            // Lay danh sach dia chi lam viec
            string diaChiSql = "SELECT MaCoSo, TenCoSo FROM CoSo WHERE CoSo.DaXoa = 0";
            SqlDataAdapter diaChiSqlData = new SqlDataAdapter(diaChiSql, Function.conn);
            DataTable diaChiTable = new DataTable();
            diaChiSqlData.Fill(diaChiTable);
            cbDiaChiLamViec.DataSource = diaChiTable;
            cbDiaChiLamViec.ValueMember = diaChiTable.Columns[0].ColumnName;
            cbDiaChiLamViec.DisplayMember = diaChiTable.Columns[1].ColumnName;
            cbDiaChiLamViec.SelectedItem = null;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = true;
        }
        public void ResetValue()
        {
            tbMaNhanVien.Text = "";
            tbTenNhanVien.Text = "";
            tbDiaChi.Text = "";
            tbLuongCoBan.Text = "";
            tbMatKhau.Text = "";
            tbNgaySinh.Text = "";
            tbSoDienThoai.Text = "";
            tbTenTaiKhoan.Text = "";
            tbTimKiem.Text = "";
            cbCaLamViec.SelectedItem = null;
            cbChucVu.SelectedItem = null;
            cbDiaChiLamViec.SelectedItem = null;
            cbGioiTinh.SelectedItem = null;
        }    

        int soThuTu = 0;
        private void btnThem_Click(object sender, EventArgs e)
        {
            // Them ma nhan vien
            //tbMaNhanVien.Text = Function.CreateKey("NV");
            ResetValue();
            soThuTu = gridViewDanhSachNhanVien.Rows.Count;
            tbMaNhanVien.Text = "OKONO01_NV0" + soThuTu;
            soThuTu++;
            btnLuu.Enabled = true;
            tbMaNhanVien.ReadOnly = false;
            tbTenNhanVien.ReadOnly = false;
            tbNgaySinh.ReadOnly = false;
            cbGioiTinh.Enabled = true;
            tbDiaChi.ReadOnly = false;
            tbSoDienThoai.ReadOnly = false;
            tbLuongCoBan.ReadOnly = false;
            cbCaLamViec.Enabled = true;
            cbChucVu.Enabled = true;
            cbDiaChiLamViec.Enabled = true;
            tbTenTaiKhoan.ReadOnly = false;
            tbMatKhau.ReadOnly = false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (tbMaNhanVien.Text == "" ||
                cbChucVu.SelectedItem == null ||
                cbDiaChiLamViec.SelectedItem == null ||
                cbCaLamViec.SelectedItem == null ||
                tbTenNhanVien.Text == "" ||
                tbTenTaiKhoan.Text == "" ||
                tbMatKhau.Text == "" ||
                cbGioiTinh.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập các trường Mã nhân viên, Giới Tính, Chức vụ, Tên tài khoản, Mật khẩu, Địa chỉ làm việc, Tên tài khoản, Ngày làm việc, Ca làm việc hợp lệ");
            }
            else
            {
                bool success = true;
                try {
                        MD5 mh = MD5.Create();
                        //Chuyển kiểu chuổi thành kiểu byte
                        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(tbMatKhau.Text);
                        //mã hóa chuỗi đã chuyển
                        byte[] hash = mh.ComputeHash(inputBytes);
                        //tạo đối tượng StringBuilder (làm việc với kiểu dữ liệu lớn)
                        StringBuilder sb = new StringBuilder();

                        for (int i = 0; i < hash.Length; i++)
                        {
                            sb.Append(hash[i].ToString("X2"));
                        }
                    // Them nhan vien
                    string themNhanVienSql = String.Format("INSERT INTO NhanVien (MaNhanVien, MaChucVu, MaCoSo, MaCaLamViec, TenNhanVien, GioiTinh, NgaySinh, SoDienThoai, DiaChi, LuongCoBan, TenTaiKhoan, MatKhau) VALUES ('{0}', '{1}', '{2}', '{3}', N'{4}', N'{5}', '{6}', '{7}', N'{8}', '{9}', '{10}', '{11}')",
                        tbMaNhanVien.Text,
                        cbChucVu.SelectedValue,
                        cbDiaChiLamViec.SelectedValue,
                        cbCaLamViec.SelectedValue,
                        tbTenNhanVien.Text,
                        cbGioiTinh.SelectedValue,
                        tbNgaySinh.Text,
                        tbSoDienThoai.Text,
                        tbDiaChi.Text,
                        tbLuongCoBan.Text,
                        tbTenTaiKhoan.Text,
                        sb);
                    SqlCommand themNhanVienCmd = new SqlCommand();
                    themNhanVienCmd.Connection = Function.conn;
                    themNhanVienCmd.CommandText = themNhanVienSql;
                    using (DbDataReader themNhanVienReader = themNhanVienCmd.ExecuteReader())
                    {
                        if (themNhanVienReader.RecordsAffected <= 0)
                        {
                            success = false;
                        }
                        themNhanVienReader.Close();
                    }
                    if (success == true)
                    {
                        MessageBox.Show("Thành Công");
                    }
                    else
                    {
                        MessageBox.Show("Thêm nhân viên thất bại");
                    }
                    // Lay lai danh sach nhan vien
                    layLaiDanhSachNhanVien();
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.Message);
                }
                btnXoa.Enabled = true;
            }
        }

        private void layLaiDanhSachNhanVien()
        {
            string nhanVienQuery = "SELECT nv.MaNhanVien AS 'Mã nhân viên', TenNhanVien AS 'Tên nhân viên', NgaySinh AS 'Ngày Sinh', nv.GioiTinh AS 'Giới Tính', nv.SoDienThoai AS 'Số điện thoại', nv.DiaChi AS 'Địa chỉ', cv.TenChucVu AS 'Chức vụ', LuongCoBan AS 'Lương cơ bản', cn.TenCoSo AS 'Cơ Sở', clv.TenCaLamViec AS 'Ca làm việc', nv.TenTaiKhoan AS 'Tên Tài Khoản', nv.MatKhau AS 'Mật Khẩu' FROM NhanVien nv LEFT JOIN ChucVu cv ON nv.MaChucVu = cv.MaChucVu LEFT JOIN CoSo cn ON cn.MaCoSo = nv.MaCoSo LEFT JOIN CaLamViec clv ON clv.MaCaLamViec = nv.MaCaLamViec WHERE nv.DaXoa = 0";
            SqlDataAdapter nhanVienSqlData = new SqlDataAdapter(nhanVienQuery, Function.conn);
            DataTable nhanVienTable = new DataTable();
            nhanVienSqlData.Fill(nhanVienTable);
            gridViewDanhSachNhanVien.DataSource = null;
            gridViewDanhSachNhanVien.DataSource = nhanVienTable;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Hoi co muon xoa khong
            string message = "Bạn có muốn xoá nhân viên " + gridViewDanhSachNhanVien[1, gridViewDanhSachNhanVien.CurrentCell.RowIndex].Value + "?";
            string title = "Xoá nhân viên";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                // Them nhan vien
                string xoaNhanVienSql = String.Format("UPDATE NhanVien SET DaXoa = 1 WHERE MaNhanVien = '{0}'", gridViewDanhSachNhanVien[0, gridViewDanhSachNhanVien.CurrentCell.RowIndex].Value);
                SqlCommand xoaNhanVienCmd = new SqlCommand();
                xoaNhanVienCmd.Connection = Function.conn;
                xoaNhanVienCmd.CommandText = xoaNhanVienSql;
                using (DbDataReader xoaNhanVienReader = xoaNhanVienCmd.ExecuteReader())
                {
                    if (xoaNhanVienReader.RecordsAffected > 0)
                    {
                        MessageBox.Show("Thành Công");
                    }
                    else
                    {
                        MessageBox.Show("Xoá nhân viên thất bại");
                    }
                    xoaNhanVienReader.Close();
                }
                // Lay lai danh sach nhan vien
                layLaiDanhSachNhanVien();
            }
        }

        private void tbTimKiem_TextChanged(object sender, EventArgs e)
        {
            // Tim kiem nhan vien
            string nhanVienQuery = String.Format("SELECT nv.MaNhanVien AS 'Mã nhân viên', TenNhanVien AS 'Tên nhân viên', NgaySinh AS 'Ngày Sinh', nv.GioiTinh AS 'Giới Tính', nv.SoDienThoai AS 'Số điện thoại', nv.DiaChi AS 'Địa chỉ', cv.TenChucVu AS 'Chức vụ', LuongCoBan AS 'Lương cơ bản', cn.TenCoSo AS 'Cơ Sở', clv.TenCaLamViec AS 'Ca làm việc', nv.TenTaiKhoan AS 'Tên Tài Khoản', nv.MatKhau AS 'Mật Khẩu' FROM NhanVien nv LEFT JOIN ChucVu cv ON nv.MaChucVu = cv.MaChucVu LEFT JOIN CoSo cn ON cn.MaCoSo = nv.MaCoSo LEFT JOIN CaLamViec clv ON clv.MaCaLamViec = nv.MaCaLamViec WHERE nv.DaXoa = 0 AND nv.MaNhanVien LIKE '%{0}%'", tbTimKiem.Text);
            SqlDataAdapter nhanVienSqlData = new SqlDataAdapter(nhanVienQuery, Function.conn);
            DataTable nhanVienTable = new DataTable();
            nhanVienSqlData.Fill(nhanVienTable);
            gridViewDanhSachNhanVien.DataSource = null;
            gridViewDanhSachNhanVien.DataSource = nhanVienTable;
        }

        private void gridViewDanhSachNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Dien thong tin vao form
                tbMaNhanVien.Text = gridViewDanhSachNhanVien[0, e.RowIndex].Value.ToString();
                tbTenNhanVien.Text = gridViewDanhSachNhanVien[1, e.RowIndex].Value.ToString();
                DateTime ngaySinh = DateTime.Parse(gridViewDanhSachNhanVien[2, e.RowIndex].Value.ToString());
                tbNgaySinh.Text = ngaySinh.ToString("yyyy-MM-dd");
                cbGioiTinh.SelectedIndex = cbGioiTinh.FindStringExact(gridViewDanhSachNhanVien[3, e.RowIndex].Value.ToString());
                tbSoDienThoai.Text = gridViewDanhSachNhanVien[4, e.RowIndex].Value.ToString();
                tbDiaChi.Text = gridViewDanhSachNhanVien[5, e.RowIndex].Value.ToString();
                cbChucVu.SelectedIndex = cbChucVu.FindStringExact(gridViewDanhSachNhanVien[6, e.RowIndex].Value.ToString());
                tbLuongCoBan.Text = gridViewDanhSachNhanVien[7, e.RowIndex].Value.ToString();
                cbDiaChiLamViec.SelectedIndex = cbDiaChiLamViec.FindStringExact(gridViewDanhSachNhanVien[8, e.RowIndex].Value.ToString());
                cbCaLamViec.SelectedIndex = cbCaLamViec.FindStringExact(gridViewDanhSachNhanVien[9, e.RowIndex].Value.ToString());
                tbTenTaiKhoan.Text = gridViewDanhSachNhanVien[10, e.RowIndex].Value.ToString();
                tbMatKhau.Text = gridViewDanhSachNhanVien[11, e.RowIndex].Value.ToString();
                btnSua.Enabled = true;
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            tbMaNhanVien.ReadOnly = false;
            tbTenNhanVien.ReadOnly = false;
            tbNgaySinh.ReadOnly = false;
            cbGioiTinh.Enabled = true;
            tbDiaChi.ReadOnly = false;
            tbSoDienThoai.ReadOnly = false;
            tbLuongCoBan.ReadOnly = false;
            cbCaLamViec.Enabled = true;
            cbChucVu.Enabled = true;
            cbDiaChiLamViec.Enabled = true;
            tbTenTaiKhoan.ReadOnly = false;
            tbMatKhau.ReadOnly = false;
            if (tbMaNhanVien.Text == "" ||
                cbChucVu.SelectedItem == null ||
                cbDiaChiLamViec.SelectedItem == null ||
                cbCaLamViec.SelectedItem == null ||
                tbTenNhanVien.Text == "")
            {
                MessageBox.Show("Vui lòng nhập các trường Mã nhân viên, Chức vụ, Địa chỉ làm việc, Tên tài khoản, Ngày làm việc, Ca làm việc hợp lệ");
            }
            else
            {
                bool success = true;
                try
                {
                    // Luu nhan vien
                    string themNhanVienSql = String.Format("UPDATE NhanVien SET TenNhanVien=N'{0}', NgaySinh='{1}', SoDienThoai='{2}', DiaChi=N'{3}', MaChucVu='{4}', LuongCoBan='{5}', MaCoSo='{6}', MaCaLamViec='{7}' WHERE MaNhanVien='{8}'",
                        tbTenNhanVien.Text,
                        tbNgaySinh.Text,
                        tbSoDienThoai.Text,
                        tbDiaChi.Text,
                        cbChucVu.SelectedValue,
                        tbLuongCoBan.Text,
                        cbDiaChiLamViec.SelectedValue,
                        cbCaLamViec.SelectedValue,
                        tbMaNhanVien.Text);
                    SqlCommand themNhanVienCmd = new SqlCommand();
                    themNhanVienCmd.Connection = Function.conn;
                    themNhanVienCmd.CommandText = themNhanVienSql;
                    using (DbDataReader themNhanVienReader = themNhanVienCmd.ExecuteReader())
                    {
                        if (themNhanVienReader.RecordsAffected <= 0)
                        {
                            success = false;
                        }
                        themNhanVienReader.Close();
                    }
                    if (success == true)
                    {
                        MessageBox.Show("Thành Công");
                    }
                    else
                    {
                        MessageBox.Show("Sửa nhân viên thất bại");
                    }
                    // Lay lai danh sach nhan vien
                    layLaiDanhSachNhanVien();
                }
                catch (Exception es)
                {
                    MessageBox.Show(es.Message);
                }
            }
        }

        private void cbMaSanPham_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
