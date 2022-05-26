using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Okono_Mmanagement
{

    public partial class FrmSanPham : Form
    {
        DataTable tblSP;
        public FrmSanPham()
        {
            InitializeComponent();
        }

        private void FrmSanPham_Load(object sender, EventArgs e)
        {
            Function.OpenConnection();
            LoadDataToGridview();
            Function.FillDataToCombo("select TenLoaiSanPham from LoaiSanPham", cboMaLoaiSP, "TenLoaiSanPham", "TenLoaiSanPham");
            cboMaLoaiSP.SelectedIndex = -1;
            Function.FillDataToCombo("select TenDonViTinh from DonViTinh", cboMaDVT, "TenDonViTinh", "TenDonViTinh");
            cboMaDVT.SelectedIndex = -1;
            txtMaSP.Enabled = false;
            // btnThem.Enabled = false;
            // btnSua.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            //btnXoa.Enabled = false;
            
        }
        private void LoadDataToGridview()
        {
            string sql = "Select a.MaSanPham, a.TenSanPham, a.DonGiaBan, a.SoLuongTon, b.TenDonViTinh, c.TenLoaiSanPham " +
                "from SanPham a join DonViTinh b on a.MaDonViTinh=b.MaDonViTinh join LoaiSanPham c on a.MaLoaiSanPham=c.MaLoaiSanPham and a.DaXoa = 0";
            tblSP = Function.GetDataToTable(sql);
            dataGridView_SP.DataSource = tblSP;
        }

        private void dataGridView_SP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSP.Text = dataGridView_SP.CurrentRow.Cells["MaSanPham"].Value.ToString();
            txtTenSP.Text = dataGridView_SP.CurrentRow.Cells["TenSanPham"].Value.ToString();
            txtDonGiaBan.Text = dataGridView_SP.CurrentRow.Cells["DonGiaBan"].Value.ToString();
            cboMaLoaiSP.Text = dataGridView_SP.CurrentRow.Cells["TenLoaiSanPham"].Value.ToString();
            cboMaDVT.Text = dataGridView_SP.CurrentRow.Cells["TenDonViTinh"].Value.ToString();
            txtSL.Text = dataGridView_SP.CurrentRow.Cells["SoLuongTon"].Value.ToString();
        }
        private void ResetValue()
        {
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtDonGiaBan.Text = "";
            cboMaDVT.Text = "";
            cboMaLoaiSP.Text = "";
            cboMaDVT.Text = "";
            cboMaLoaiSP.Text = "";
            txtMaLoaiSP.Text = "";
            txtMaDVT.Text = "";
            txtTimKiem.Text = "";
            txtSL.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValue();
            txtSL.Enabled = false;
            btnLuu.Enabled = true;
            txtMaSP.Focus();
            txtMaSP.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnDong.Enabled = false;
            btnThem.Enabled = false;
            btnHuy.Enabled = true;

        }

        private void cboMaLoaiSP_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaLoaiSP.Text == "")
                txtMaLoaiSP.Text = "";
            str = "SELECT MaLoaiSanPham FROM LoaiSanPham WHERE TenLoaiSanPham = N'" + cboMaLoaiSP.SelectedValue + "'";
            txtMaLoaiSP.Text = Function.GetFieldValues(str);
        }


        private void cboMaDVT_TextChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaDVT.Text == "")
                txtMaDVT.Text = "";
            str = "SELECT MaDonViTinh FROM DonViTinh WHERE TenDonViTinh = N'" + cboMaDVT.SelectedValue + "'";
            txtMaDVT.Text = Function.GetFieldValues(str);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            txtSL.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnDong.Enabled = true;
            string sql;
            if (txtMaSP.Text == "")
            {
                MessageBox.Show("Bạn cần nhập mã của sản phẩm");
                txtMaSP.Focus();
                return;
            }
            if (txtTenSP.Text == "")
            {
                MessageBox.Show("Bạn cần nhập tên sản phẩm");
                txtTenSP.Focus();
                return;
            }
            if (txtDonGiaBan.Text == "")
            {
                MessageBox.Show("Bạn cần nhập đơn giá bán sản phẩm");
                txtDonGiaBan.Focus();
                return;
            }


            if (cboMaDVT.Text == "")
            {
                MessageBox.Show("Bạn cần chọn đơn vị tính");
                cboMaDVT.Focus();
                return;
            }
            if (cboMaLoaiSP.Text == "")
            {
                MessageBox.Show("Bạn cần chọn loại sản phẩm");
                cboMaLoaiSP.Focus();
                return;
            }

            sql = "select MaSanPham from SanPham where MaSanPham = '" + txtMaSP.Text + "'";
            if (Function.checkKeyExit(sql))
            {
                MessageBox.Show("Mã sản phẩm này đã tồn tại, bạn phải nhập mã khác", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSP.Focus();
                txtMaSP.Text = "";
                return;
            }
            sql = "insert into SanPham (MaSanPham,MaLoaiSanPham, MaDonViTinh, TenSanPham, DonGiaBan) values ('" + txtMaSP.Text + "', '" + txtMaLoaiSP.Text + "', '" + txtMaDVT.Text +
                    "', N'" + txtTenSP.Text + "', '" + txtDonGiaBan.Text + "')";

            Function.RunSql(sql);
            LoadDataToGridview();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            txtSL.Enabled = true;
            btnHuy.Enabled = true;
            btnDong.Enabled = true;
            string sql;
            if (txtTimKiem.Text == "")
            {
                MessageBox.Show("Bạn cần nhập mã sản phẩm cần tìm!", "Yêu cầu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "Select a.MaSanPham, a.TenSanPham, a.DonGiaBan, a.SoLuongTon, b.TenDonViTinh, c.TenLoaiSanPham " +
                "from SanPham a join DonViTinh b on a.MaDonViTinh=b.MaDonViTinh join LoaiSanPham c on a.MaLoaiSanPham=c.MaLoaiSanPham " +
                "where DaXoa=0 and a.MaSanPham Like '%"+txtTimKiem.Text+"%'";
            tblSP = Function.GetDataToTable(sql);
            if (tblSP.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi nào thỏa mãn", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Có " + tblSP.Rows.Count + " bản ghi thỏa mãn", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dataGridView_SP.DataSource = tblSP;
            ResetValue();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtSL.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnThem.Enabled = true;
            btnDong.Enabled = true;
            string sql;
            if (tblSP.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaSP.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "update SanPham set MaLoaiSanPham= '" + txtMaLoaiSP.Text + "', TenSanPham = N'" + txtTenSP.Text +
                "', MaDonViTinh= '" + txtMaDVT.Text + "', DonGiaBan= '" + txtDonGiaBan.Text +
                "', SoLuongTon = "+txtSL.Text+" where MaSanPham= '" + txtMaSP.Text + "'";
            Function.RunSql(sql);
            LoadDataToGridview();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtSL.Enabled = true;
            string sql;
            if (tblSP.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaSP.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "Update SanPham SET DaXoa = 1 where MaSanPham = '" + txtMaSP.Text + "'";
                Function.RunSql(sql);
                LoadDataToGridview();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetValue();
            txtSL.Enabled = true;
            LoadDataToGridview();
            btnLuu.Enabled = false;
            txtMaSP.Enabled = false;
            btnDong.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
        }
    }
}
