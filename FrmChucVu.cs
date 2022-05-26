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
    public partial class FrmChucVu : Form
    {
        DataTable tblChucVu;
        public FrmChucVu()
        {
            InitializeComponent();
        }

        private void FrmChucVu_Load(object sender, EventArgs e)
        {
            Function.OpenConnection();
            LoadDataToGridview();
            tbMaChucVu.Enabled = false;
        }
        private void LoadDataToGridview()
        {
            string sql = "Select MaChucVu, TenChucVu from ChucVu where DaXoa=0";
            tblChucVu = Function.GetDataToTable(sql);
            GridViewChucVu.DataSource = tblChucVu;
        }
        private void GridViewChucVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tbMaChucVu.Text = GridViewChucVu.CurrentRow.Cells["MaChucVu"].Value.ToString();
            tbTenChucVu.Text = GridViewChucVu.CurrentRow.Cells["TenChucVu"].Value.ToString();
        }
        public void ResetValue()
        {
            tbMaChucVu.Text = "";
            tbTenChucVu.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValue();

            tbMaChucVu.Enabled = false;
            int count = 0;
            count = Convert.ToInt32(Function.GetFieldValues("select count(*) from LoaiSanPham"));
            if (count + 1 < 10)
            {
                tbMaChucVu.Text = "OKONO_CV0" + (count + 1).ToString();
            }
            else
                if (count + 1 < 100)
            {
                tbMaChucVu.Text = "OKONO_CV" + (count + 1).ToString();
            }
            btnLuu.Enabled = true;
            tbMaChucVu.Focus();
            btnXoa.Enabled = false;
            btnThoat.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblChucVu.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (tbMaChucVu.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "Update LoaiSanPham SET DaXoa = 1 where MaLoaiSanPham = '" + tbMaChucVu.Text + "'";
                Function.RunSql(sql);
                LoadDataToGridview();
            }
            ResetValue();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnThoat.Enabled = true;
            string sql;
            if (tbMaChucVu.Text == "")
            {
                MessageBox.Show("Bạn cần nhập mã của danh mục");
                tbMaChucVu.Focus();
                return;
            }
            if (tbTenChucVu.Text == "")
            {
                MessageBox.Show("Bạn cần nhập tên danh mục");
                tbTenChucVu.Focus();
                return;
            }

            sql = "select MaLoaiSanPham from LoaiSanPham where MaLoaiSanPham = '" + tbMaChucVu.Text + "'";
            if (Function.checkKeyExit(sql))
            {
                MessageBox.Show("Mã danh mục này đã tồn tại, bạn phải nhập mã khác", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbMaChucVu.Focus();
                tbMaChucVu.Text = "";
                return;
            }
            sql = "insert into LoaiSanPham values ('" + tbMaChucVu.Text + "', N'" + tbTenChucVu.Text + "', '0')";
            ResetValue();
            Function.RunSql(sql);
            LoadDataToGridview();
        }
    }
}
