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
    public partial class FrmDanhMuc : Form
    {
        DataTable tblDanhMuc;
        public FrmDanhMuc()
        {
            InitializeComponent();
        }

        private void FrmDanhMuc_Load(object sender, EventArgs e)
        {
            Function.OpenConnection();
            LoadDataToGridview();
            txtMaDanhMuc.Enabled = false;
            btnLuu.Enabled = false;
        }
        private void LoadDataToGridview()
        {
            string sql = "Select MaLoaiSanPham, TenLoaiSanPham from LoaiSanPham where DaXoa=0";
            tblDanhMuc = Function.GetDataToTable(sql);
            gridViewDanhMuc.DataSource = tblDanhMuc;
        }
        private void gridViewDanhMuc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaDanhMuc.Text = gridViewDanhMuc.CurrentRow.Cells["MaLoaiSanPham"].Value.ToString();
            txtTenDanhMuc.Text = gridViewDanhMuc.CurrentRow.Cells["TenLoaiSanPham"].Value.ToString();
        }
        public void ResetValue()
        {
            txtMaDanhMuc.Text = "";
            txtTenDanhMuc.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValue();

            txtMaDanhMuc.Enabled = false;
            int count = 0;
            count = Convert.ToInt32(Function.GetFieldValues("select count(*) from LoaiSanPham"));
            if (count + 1 < 10)
            {
                txtMaDanhMuc.Text = "OKONO_LSP0" + (count + 1).ToString();
            }
            else
                if (count + 1 < 100)
            {
                txtMaDanhMuc.Text = "OKONO_LSP" + (count + 1).ToString();
            }
            btnLuu.Enabled = true;
            txtMaDanhMuc.Focus();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThoat.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThoat.Enabled = true;
            string sql;
            if (txtMaDanhMuc.Text == "")
            {
                MessageBox.Show("Bạn cần nhập mã của danh mục");
                txtMaDanhMuc.Focus();
                return;
            }
            if (txtTenDanhMuc.Text == "")
            {
                MessageBox.Show("Bạn cần nhập tên danh mục");
                txtTenDanhMuc.Focus();
                return;
            }

            sql = "select MaLoaiSanPham from LoaiSanPham where MaLoaiSanPham = '" + txtMaDanhMuc.Text + "'";
            if (Function.checkKeyExit(sql))
            {
                MessageBox.Show("Mã danh mục này đã tồn tại, bạn phải nhập mã khác", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaDanhMuc.Focus();
                txtMaDanhMuc.Text = "";
                return;
            }
            sql = "insert into LoaiSanPham values ('" + txtMaDanhMuc.Text + "', N'" + txtTenDanhMuc.Text + "', '0')";
            ResetValue();
            Function.RunSql(sql);
            LoadDataToGridview();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblDanhMuc.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaDanhMuc.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "update LoaiSanPham set TenLoaiSanPham= N'" + txtTenDanhMuc.Text + "' where MaLoaiSanPham = '" + txtMaDanhMuc.Text + "' AND DaXoa='0'";
            Function.RunSql(sql);
            LoadDataToGridview();
            ResetValue();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblDanhMuc.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaDanhMuc.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "Update LoaiSanPham SET DaXoa = 1 where MaLoaiSanPham = '" + txtMaDanhMuc.Text + "'";
                Function.RunSql(sql);
                LoadDataToGridview();
            }
            ResetValue();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
