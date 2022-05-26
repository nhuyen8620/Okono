
namespace Okono_Mmanagement
{
    partial class FrmTimKiemPDC
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTimKiemPDC));
            this.label1 = new System.Windows.Forms.Label();
            this.gridViewSanPham = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.cbMaPhieuDieuChuyen = new System.Windows.Forms.ComboBox();
            this.cbMaNhanVienNhap = new System.Windows.Forms.ComboBox();
            this.cbMaCoSoNhan = new System.Windows.Forms.ComboBox();
            this.tbTenNhanVien = new System.Windows.Forms.TextBox();
            this.tbNgayNhap = new System.Windows.Forms.TextBox();
            this.tbNgayXuat = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(30)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(516, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(384, 40);
            this.label1.TabIndex = 2;
            this.label1.Text = "PHIẾU ĐIỀU CHUYỂN";
            // 
            // gridViewSanPham
            // 
            this.gridViewSanPham.AllowUserToAddRows = false;
            this.gridViewSanPham.AllowUserToDeleteRows = false;
            this.gridViewSanPham.BackgroundColor = System.Drawing.Color.White;
            this.gridViewSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewSanPham.Location = new System.Drawing.Point(128, 423);
            this.gridViewSanPham.Name = "gridViewSanPham";
            this.gridViewSanPham.RowHeadersWidth = 51;
            this.gridViewSanPham.RowTemplate.Height = 24;
            this.gridViewSanPham.Size = new System.Drawing.Size(1024, 191);
            this.gridViewSanPham.TabIndex = 3;
            this.gridViewSanPham.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSanPham_CellEndEdit);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(337, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "Tìm mã phiếu điều chuyển:";
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Enabled = false;
            this.btnXacNhan.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(30)))), ((int)(((byte)(0)))));
            this.btnXacNhan.Image = global::Okono_Mmanagement.Properties.Resources.tick_okono;
            this.btnXacNhan.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXacNhan.Location = new System.Drawing.Point(541, 661);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(125, 47);
            this.btnXacNhan.TabIndex = 14;
            this.btnXacNhan.Text = " Xác nhận";
            this.btnXacNhan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(30)))), ((int)(((byte)(0)))));
            this.btnLuu.Image = global::Okono_Mmanagement.Properties.Resources.Background1;
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuu.Location = new System.Drawing.Point(264, 661);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(120, 45);
            this.btnLuu.TabIndex = 29;
            this.btnLuu.Text = "   Sửa";
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // cbMaPhieuDieuChuyen
            // 
            this.cbMaPhieuDieuChuyen.Font = new System.Drawing.Font("Times New Roman", 13.2F);
            this.cbMaPhieuDieuChuyen.FormattingEnabled = true;
            this.cbMaPhieuDieuChuyen.Location = new System.Drawing.Point(550, 166);
            this.cbMaPhieuDieuChuyen.Name = "cbMaPhieuDieuChuyen";
            this.cbMaPhieuDieuChuyen.Size = new System.Drawing.Size(382, 28);
            this.cbMaPhieuDieuChuyen.TabIndex = 30;
            this.cbMaPhieuDieuChuyen.SelectedIndexChanged += new System.EventHandler(this.cbMaPhieuDieuChuyen_SelectedIndexChanged);
            // 
            // cbMaNhanVienNhap
            // 
            this.cbMaNhanVienNhap.Font = new System.Drawing.Font("Times New Roman", 13.2F);
            this.cbMaNhanVienNhap.FormattingEnabled = true;
            this.cbMaNhanVienNhap.Location = new System.Drawing.Point(782, 240);
            this.cbMaNhanVienNhap.Name = "cbMaNhanVienNhap";
            this.cbMaNhanVienNhap.Size = new System.Drawing.Size(250, 28);
            this.cbMaNhanVienNhap.TabIndex = 31;
            this.cbMaNhanVienNhap.SelectedIndexChanged += new System.EventHandler(this.cbMaNhanVienXuat_SelectedIndexChanged);
            // 
            // cbMaCoSoNhan
            // 
            this.cbMaCoSoNhan.Font = new System.Drawing.Font("Times New Roman", 13.2F);
            this.cbMaCoSoNhan.FormattingEnabled = true;
            this.cbMaCoSoNhan.Location = new System.Drawing.Point(252, 240);
            this.cbMaCoSoNhan.Name = "cbMaCoSoNhan";
            this.cbMaCoSoNhan.Size = new System.Drawing.Size(250, 28);
            this.cbMaCoSoNhan.TabIndex = 33;
            this.cbMaCoSoNhan.SelectedValueChanged += new System.EventHandler(this.cbMaCoSoNhan_SelectedValueChanged);
            // 
            // tbTenNhanVien
            // 
            this.tbTenNhanVien.Font = new System.Drawing.Font("Times New Roman", 13.2F);
            this.tbTenNhanVien.Location = new System.Drawing.Point(782, 309);
            this.tbTenNhanVien.Name = "tbTenNhanVien";
            this.tbTenNhanVien.Size = new System.Drawing.Size(250, 28);
            this.tbTenNhanVien.TabIndex = 34;
            // 
            // tbNgayNhap
            // 
            this.tbNgayNhap.Font = new System.Drawing.Font("Times New Roman", 13.2F);
            this.tbNgayNhap.Location = new System.Drawing.Point(252, 370);
            this.tbNgayNhap.Name = "tbNgayNhap";
            this.tbNgayNhap.Size = new System.Drawing.Size(250, 28);
            this.tbNgayNhap.TabIndex = 36;
            this.tbNgayNhap.TextChanged += new System.EventHandler(this.tbNgayNhap_TextChanged);
            // 
            // tbNgayXuat
            // 
            this.tbNgayXuat.Font = new System.Drawing.Font("Times New Roman", 13.2F);
            this.tbNgayXuat.Location = new System.Drawing.Point(252, 306);
            this.tbNgayXuat.Name = "tbNgayXuat";
            this.tbNgayXuat.Size = new System.Drawing.Size(250, 28);
            this.tbNgayXuat.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.2F);
            this.label3.Location = new System.Drawing.Point(124, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 20);
            this.label3.TabIndex = 40;
            this.label3.Text = "Mã cơ sở nhận:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 13.2F);
            this.label6.Location = new System.Drawing.Point(624, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 20);
            this.label6.TabIndex = 42;
            this.label6.Text = "Mã nhân viên nhập:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 13.2F);
            this.label11.Location = new System.Drawing.Point(624, 309);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(117, 20);
            this.label11.TabIndex = 43;
            this.label11.Text = "Tên nhân viên:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 13.2F);
            this.label8.Location = new System.Drawing.Point(124, 309);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 20);
            this.label8.TabIndex = 46;
            this.label8.Text = "Ngày xuất:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 13.2F);
            this.label13.Location = new System.Drawing.Point(124, 373);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 20);
            this.label13.TabIndex = 47;
            this.label13.Text = "Ngày nhập:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(30)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(548, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(325, 40);
            this.label4.TabIndex = 48;
            this.label4.Text = "ĐANG TIẾN HÀNH";
            // 
            // btnThoat
            // 
            this.btnThoat.Enabled = false;
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(30)))), ((int)(((byte)(0)))));
            this.btnThoat.Image = global::Okono_Mmanagement.Properties.Resources.close_okono;
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThoat.Location = new System.Drawing.Point(845, 661);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(125, 47);
            this.btnThoat.TabIndex = 49;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // FrmTimKiemPDC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1284, 781);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbNgayXuat);
            this.Controls.Add(this.tbNgayNhap);
            this.Controls.Add(this.tbTenNhanVien);
            this.Controls.Add(this.cbMaCoSoNhan);
            this.Controls.Add(this.cbMaNhanVienNhap);
            this.Controls.Add(this.cbMaPhieuDieuChuyen);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gridViewSanPham);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmTimKiemPDC";
            this.Text = "FrmTimKiemPDC";
            this.Load += new System.EventHandler(this.FrmTimKiemPDC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSanPham)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gridViewSanPham;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.ComboBox cbMaPhieuDieuChuyen;
        private System.Windows.Forms.ComboBox cbMaNhanVienNhap;
        private System.Windows.Forms.ComboBox cbMaCoSoNhan;
        private System.Windows.Forms.TextBox tbTenNhanVien;
        private System.Windows.Forms.TextBox tbNgayNhap;
        private System.Windows.Forms.TextBox tbNgayXuat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnThoat;
    }
}