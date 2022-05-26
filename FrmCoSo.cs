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
    public partial class FrmCoSo : Form
    {
        DataTable tblCoSo;
        public FrmCoSo()
        {
            InitializeComponent();
        }

        private void FrmCoSo_Load(object sender, EventArgs e)
        {
            Function.OpenConnection();
            LoadDataToGridview();
            txtMaCoSo.Enabled = false;
            btnLuu.Enabled = false;
        }
        private void LoadDataToGridview()
        {
            string sql = "Select MaCoSo, TenCoSo, DiaChi, SoDienThoai from CoSo where DaXoa=0";
            tblCoSo = Function.GetDataToTable(sql);
            gridViewCoSo.DataSource = tblCoSo;
        }
        private void gridViewCoSo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaCoSo.Text = gridViewCoSo.CurrentRow.Cells["MaCoSo"].Value.ToString();
            txtTenCoSo.Text = gridViewCoSo.CurrentRow.Cells["TenCoSo"].Value.ToString();
            txtDiaChi.Text = gridViewCoSo.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtSoDienThoai.Text = gridViewCoSo.CurrentRow.Cells["SoDienThoai"].Value.ToString();
        }
        public void ResetValue()
        {
            txtMaCoSo.Text = "";
            txtTenCoSo.Text = "";
            txtDiaChi.Text = "";
            txtSoDienThoai.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValue();

            txtMaCoSo.Enabled = false;
            int count = 0;
            count = Convert.ToInt32(Function.GetFieldValues("select count(*) from CoSo"));
            if (count + 1 < 10)
            {
                txtMaCoSo.Text = "OKONO_CS0" + (count + 1).ToString();
            }
            else
                if (count + 1 < 100)
            {
                txtMaCoSo.Text = "OKONO_CS" + (count + 1).ToString();
            }
            btnLuu.Enabled = true;
            txtMaCoSo.Focus();
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
            if (txtMaCoSo.Text == "")
            {
                MessageBox.Show("Bạn cần nhập mã của cơ sở");
                txtMaCoSo.Focus();
                return;
            }
            if (txtTenCoSo.Text == "")
            {
                MessageBox.Show("Bạn cần nhập tên cơ sở");
                txtTenCoSo.Focus();
                return;
            }
            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Bạn cần nhập địa chỉ của cơ sở");
                txtDiaChi.Focus();
                return;
            }
            if (txtSoDienThoai.Text == "")
            {
                MessageBox.Show("Bạn cần nhập số điện thoại của cơ sở");
                txtSoDienThoai.Focus();
                return;
            }

            sql = "select MaCoSo from CoSo where MaCoSo = '" + txtMaCoSo.Text + "'";
            if (Function.checkKeyExit(sql))
            {
                MessageBox.Show("Mã cơ sở này đã tồn tại, bạn phải nhập mã khác", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaCoSo.Focus();
                txtMaCoSo.Text = "";
                return;
            }
            sql = "insert into CoSo (MaCoSo, TenCoSo, DiaChi, SoDienThoai, DaXoa) values ('" + txtMaCoSo.Text + "', N'" + txtTenCoSo.Text + "', N'" + txtDiaChi.Text +
                    "', '" + txtSoDienThoai.Text + "', '0')";
            ResetValue();
            Function.RunSql(sql);
            LoadDataToGridview();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblCoSo.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaCoSo.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "update CoSo set TenCoSo= N'" + txtTenCoSo.Text + "', DiaChi = N'" + txtDiaChi.Text +
                "', SoDienThoai= '" + txtSoDienThoai.Text + "' where MaCoSo = '" + txtMaCoSo.Text + "' AND DaXoa='0'";
            Function.RunSql(sql);
            LoadDataToGridview();
            ResetValue();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblCoSo.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaCoSo.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "Update CoSo SET DaXoa = 1 where MaCoSo = '" + txtMaCoSo.Text + "'";
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
