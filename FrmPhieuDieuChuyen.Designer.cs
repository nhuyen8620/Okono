
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Okono
{
    partial class FrmPhieuDieuChuyen
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPhieuDieuChuyen));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbMaPhieuXuatHang = new System.Windows.Forms.TextBox();
            this.tbMaSanPham = new System.Windows.Forms.TextBox();
            this.tbNgayXuat = new System.Windows.Forms.TextBox();
            this.cbCoSoNhan = new System.Windows.Forms.ComboBox();
            this.cbMaNhanVienNhap = new System.Windows.Forms.ComboBox();
            this.cbMaNhanVien = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbSearchMaSanPham = new System.Windows.Forms.TextBox();
            this.gridViewSanPham = new System.Windows.Forms.DataGridView();
            this.gridViewSanPhamDaThem = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.tbTenSanPham = new System.Windows.Forms.TextBox();
            this.tbTenNhanVien = new System.Windows.Forms.TextBox();
            this.tbSoLuong = new System.Windows.Forms.NumericUpDown();
            this.cbMaSanPham = new System.Windows.Forms.CheckBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tbSearchMaSanPhamDaThem = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnXoaSearchMaSanPhamDaThem = new System.Windows.Forms.Button();
            this.tbNgayNhap = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSanPhamDaThem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSoLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(30)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(515, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(443, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "PHIẾU ĐIỀU CHUYỂN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(378, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã phiếu điều chuyển:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.2F);
            this.label3.Location = new System.Drawing.Point(86, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mã cơ sở nhận:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13.2F);
            this.label4.Location = new System.Drawing.Point(86, 237);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(183, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Mã nhân viên nhập:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 13.2F);
            this.label5.Location = new System.Drawing.Point(442, 369);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "Số lượng:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 13.2F);
            this.label6.Location = new System.Drawing.Point(86, 284);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Mã nhân viên xuất:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 13.2F);
            this.label7.Location = new System.Drawing.Point(442, 193);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 25);
            this.label7.TabIndex = 5;
            this.label7.Text = "Mã sản phẩm:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 13.2F);
            this.label8.Location = new System.Drawing.Point(442, 279);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 25);
            this.label8.TabIndex = 5;
            this.label8.Text = "Ngày xuất:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 13.2F);
            this.label9.Location = new System.Drawing.Point(437, 237);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(140, 25);
            this.label9.TabIndex = 5;
            this.label9.Text = "Tên sản phẩm:";
            // 
            // tbMaPhieuXuatHang
            // 
            this.tbMaPhieuXuatHang.Font = new System.Drawing.Font("Times New Roman", 13.2F);
            this.tbMaPhieuXuatHang.Location = new System.Drawing.Point(560, 139);
            this.tbMaPhieuXuatHang.Name = "tbMaPhieuXuatHang";
            this.tbMaPhieuXuatHang.Size = new System.Drawing.Size(226, 33);
            this.tbMaPhieuXuatHang.TabIndex = 6;
            // 
            // tbMaSanPham
            // 
            this.tbMaSanPham.Font = new System.Drawing.Font("Times New Roman", 13.2F);
            this.tbMaSanPham.Location = new System.Drawing.Point(560, 193);
            this.tbMaSanPham.Name = "tbMaSanPham";
            this.tbMaSanPham.Size = new System.Drawing.Size(160, 33);
            this.tbMaSanPham.TabIndex = 7;
            // 
            // tbNgayXuat
            // 
            this.tbNgayXuat.Font = new System.Drawing.Font("Times New Roman", 13.2F);
            this.tbNgayXuat.Location = new System.Drawing.Point(560, 279);
            this.tbNgayXuat.Name = "tbNgayXuat";
            this.tbNgayXuat.Size = new System.Drawing.Size(160, 33);
            this.tbNgayXuat.TabIndex = 7;
            // 
            // cbCoSoNhan
            // 
            this.cbCoSoNhan.Font = new System.Drawing.Font("Times New Roman", 13.2F);
            this.cbCoSoNhan.FormattingEnabled = true;
            this.cbCoSoNhan.Location = new System.Drawing.Point(239, 193);
            this.cbCoSoNhan.Name = "cbCoSoNhan";
            this.cbCoSoNhan.Size = new System.Drawing.Size(160, 33);
            this.cbCoSoNhan.TabIndex = 8;
            // 
            // cbMaNhanVienNhap
            // 
            this.cbMaNhanVienNhap.Font = new System.Drawing.Font("Times New Roman", 13.2F);
            this.cbMaNhanVienNhap.FormattingEnabled = true;
            this.cbMaNhanVienNhap.Location = new System.Drawing.Point(239, 234);
            this.cbMaNhanVienNhap.Name = "cbMaNhanVienNhap";
            this.cbMaNhanVienNhap.Size = new System.Drawing.Size(160, 33);
            this.cbMaNhanVienNhap.TabIndex = 8;
            // 
            // cbMaNhanVien
            // 
            this.cbMaNhanVien.Font = new System.Drawing.Font("Times New Roman", 13.2F);
            this.cbMaNhanVien.FormattingEnabled = true;
            this.cbMaNhanVien.Location = new System.Drawing.Point(239, 276);
            this.cbMaNhanVien.Name = "cbMaNhanVien";
            this.cbMaNhanVien.Size = new System.Drawing.Size(160, 33);
            this.cbMaNhanVien.TabIndex = 8;
            this.cbMaNhanVien.SelectedIndexChanged += new System.EventHandler(this.cbMaNhanVien_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(771, 187);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(223, 25);
            this.label10.TabIndex = 9;
            this.label10.Text = "Tìm kiếm theo mã SP:";
            // 
            // tbSearchMaSanPham
            // 
            this.tbSearchMaSanPham.Font = new System.Drawing.Font("Times New Roman", 13.2F);
            this.tbSearchMaSanPham.Location = new System.Drawing.Point(963, 183);
            this.tbSearchMaSanPham.Name = "tbSearchMaSanPham";
            this.tbSearchMaSanPham.Size = new System.Drawing.Size(217, 33);
            this.tbSearchMaSanPham.TabIndex = 10;
            this.tbSearchMaSanPham.TextChanged += new System.EventHandler(this.tbSearchMaSanPham_TextChanged);
            // 
            // gridViewSanPham
            // 
            this.gridViewSanPham.BackgroundColor = System.Drawing.Color.White;
            this.gridViewSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewSanPham.GridColor = System.Drawing.Color.White;
            this.gridViewSanPham.Location = new System.Drawing.Point(775, 222);
            this.gridViewSanPham.MultiSelect = false;
            this.gridViewSanPham.Name = "gridViewSanPham";
            this.gridViewSanPham.ReadOnly = true;
            this.gridViewSanPham.RowHeadersWidth = 51;
            this.gridViewSanPham.Size = new System.Drawing.Size(405, 167);
            this.gridViewSanPham.TabIndex = 11;
            this.gridViewSanPham.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridViewSanPham_CellContentClick);
            // 
            // gridViewSanPhamDaThem
            // 
            this.gridViewSanPhamDaThem.AllowUserToAddRows = false;
            this.gridViewSanPhamDaThem.AllowUserToDeleteRows = false;
            this.gridViewSanPhamDaThem.AllowUserToResizeColumns = false;
            this.gridViewSanPhamDaThem.AllowUserToResizeRows = false;
            this.gridViewSanPhamDaThem.BackgroundColor = System.Drawing.Color.White;
            this.gridViewSanPhamDaThem.ColumnHeadersHeight = 29;
            this.gridViewSanPhamDaThem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridViewSanPhamDaThem.Enabled = false;
            this.gridViewSanPhamDaThem.Location = new System.Drawing.Point(83, 451);
            this.gridViewSanPhamDaThem.MultiSelect = false;
            this.gridViewSanPhamDaThem.Name = "gridViewSanPhamDaThem";
            this.gridViewSanPhamDaThem.ReadOnly = true;
            this.gridViewSanPhamDaThem.RowHeadersWidth = 51;
            this.gridViewSanPhamDaThem.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridViewSanPhamDaThem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridViewSanPhamDaThem.ShowEditingIcon = false;
            this.gridViewSanPhamDaThem.Size = new System.Drawing.Size(1097, 187);
            this.gridViewSanPhamDaThem.TabIndex = 12;
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(30)))), ((int)(((byte)(0)))));
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.Location = new System.Drawing.Point(83, 672);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(95, 40);
            this.btnThem.TabIndex = 13;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.them_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(30)))), ((int)(((byte)(0)))));
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuu.Location = new System.Drawing.Point(330, 672);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(95, 40);
            this.btnLuu.TabIndex = 13;
            this.btnLuu.Text = " Lưu";
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnIn
            // 
            this.btnIn.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(30)))), ((int)(((byte)(0)))));
            this.btnIn.Image = ((System.Drawing.Image)(resources.GetObject("btnIn.Image")));
            this.btnIn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIn.Location = new System.Drawing.Point(577, 672);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(95, 40);
            this.btnIn.TabIndex = 13;
            this.btnIn.Text = "  In";
            this.btnIn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(30)))), ((int)(((byte)(0)))));
            this.btnHuy.Image = ((System.Drawing.Image)(resources.GetObject("btnHuy.Image")));
            this.btnHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHuy.Location = new System.Drawing.Point(839, 670);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(95, 40);
            this.btnHuy.TabIndex = 13;
            this.btnHuy.Text = " Huỷ";
            this.btnHuy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(30)))), ((int)(((byte)(0)))));
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThoat.Location = new System.Drawing.Point(1085, 670);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(95, 40);
            this.btnThoat.TabIndex = 13;
            this.btnThoat.Text = " Thoát";
            this.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 13.2F);
            this.label11.Location = new System.Drawing.Point(86, 322);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(141, 25);
            this.label11.TabIndex = 16;
            this.label11.Text = "Tên nhân viên:";
            // 
            // tbTenSanPham
            // 
            this.tbTenSanPham.Font = new System.Drawing.Font("Times New Roman", 13.2F);
            this.tbTenSanPham.Location = new System.Drawing.Point(560, 234);
            this.tbTenSanPham.Name = "tbTenSanPham";
            this.tbTenSanPham.Size = new System.Drawing.Size(160, 33);
            this.tbTenSanPham.TabIndex = 17;
            // 
            // tbTenNhanVien
            // 
            this.tbTenNhanVien.Font = new System.Drawing.Font("Times New Roman", 13.2F);
            this.tbTenNhanVien.Location = new System.Drawing.Point(239, 319);
            this.tbTenNhanVien.Name = "tbTenNhanVien";
            this.tbTenNhanVien.Size = new System.Drawing.Size(160, 33);
            this.tbTenNhanVien.TabIndex = 18;
            // 
            // tbSoLuong
            // 
            this.tbSoLuong.Font = new System.Drawing.Font("Times New Roman", 13.2F);
            this.tbSoLuong.Location = new System.Drawing.Point(560, 361);
            this.tbSoLuong.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.tbSoLuong.Name = "tbSoLuong";
            this.tbSoLuong.Size = new System.Drawing.Size(160, 33);
            this.tbSoLuong.TabIndex = 19;
            // 
            // cbMaSanPham
            // 
            this.cbMaSanPham.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbMaSanPham.AutoSize = true;
            this.cbMaSanPham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbMaSanPham.Font = new System.Drawing.Font("Times New Roman", 13.2F);
            this.cbMaSanPham.Image = ((System.Drawing.Image)(resources.GetObject("cbMaSanPham.Image")));
            this.cbMaSanPham.Location = new System.Drawing.Point(726, 191);
            this.cbMaSanPham.Name = "cbMaSanPham";
            this.cbMaSanPham.Size = new System.Drawing.Size(34, 34);
            this.cbMaSanPham.TabIndex = 20;
            this.cbMaSanPham.UseVisualStyleBackColor = true;
            //this.cbMaSanPham.CheckedChanged += new System.EventHandler(this.cbMaSanPham_CheckedChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "tick_okono.png");
            // 
            // checkBox1
            // 
            this.checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox1.AutoSize = true;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.Font = new System.Drawing.Font("Times New Roman", 13.2F);
            this.checkBox1.Image = ((System.Drawing.Image)(resources.GetObject("checkBox1.Image")));
            this.checkBox1.Location = new System.Drawing.Point(1342, 75);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(34, 34);
            this.checkBox1.TabIndex = 20;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // tbSearchMaSanPhamDaThem
            // 
            this.tbSearchMaSanPhamDaThem.Font = new System.Drawing.Font("Times New Roman", 13.2F);
            this.tbSearchMaSanPhamDaThem.Location = new System.Drawing.Point(203, 411);
            this.tbSearchMaSanPhamDaThem.Name = "tbSearchMaSanPhamDaThem";
            this.tbSearchMaSanPhamDaThem.Size = new System.Drawing.Size(259, 33);
            this.tbSearchMaSanPhamDaThem.TabIndex = 21;
            this.tbSearchMaSanPhamDaThem.TextChanged += new System.EventHandler(this.tbSearchSanPhamDaThem_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(86, 420);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(147, 25);
            this.label12.TabIndex = 22;
            this.label12.Text = "Mã sản phẩm:";
            // 
            // btnXoaSearchMaSanPhamDaThem
            // 
            this.btnXoaSearchMaSanPhamDaThem.Font = new System.Drawing.Font("Times New Roman", 13.2F);
            this.btnXoaSearchMaSanPhamDaThem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(30)))), ((int)(((byte)(0)))));
            this.btnXoaSearchMaSanPhamDaThem.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaSearchMaSanPhamDaThem.Image")));
            this.btnXoaSearchMaSanPhamDaThem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoaSearchMaSanPhamDaThem.Location = new System.Drawing.Point(480, 407);
            this.btnXoaSearchMaSanPhamDaThem.Name = "btnXoaSearchMaSanPhamDaThem";
            this.btnXoaSearchMaSanPhamDaThem.Size = new System.Drawing.Size(39, 34);
            this.btnXoaSearchMaSanPhamDaThem.TabIndex = 24;
            this.btnXoaSearchMaSanPhamDaThem.UseVisualStyleBackColor = true;
            this.btnXoaSearchMaSanPhamDaThem.Click += new System.EventHandler(this.btnXoaSearchMaSanPhamDaThem_Click);
            // 
            // tbNgayNhap
            // 
            this.tbNgayNhap.Font = new System.Drawing.Font("Times New Roman", 13.2F);
            this.tbNgayNhap.Location = new System.Drawing.Point(560, 322);
            this.tbNgayNhap.Name = "tbNgayNhap";
            this.tbNgayNhap.Size = new System.Drawing.Size(160, 33);
            this.tbNgayNhap.TabIndex = 25;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 13.2F);
            this.label13.Location = new System.Drawing.Point(442, 325);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 25);
            this.label13.TabIndex = 26;
            this.label13.Text = "Ngày nhập:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(736, 407);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(0, 25);
            this.label15.TabIndex = 29;
            // 
            // FrmPhieuDieuChuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1284, 781);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tbNgayNhap);
            this.Controls.Add(this.btnXoaSearchMaSanPhamDaThem);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbSearchMaSanPhamDaThem);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.cbMaSanPham);
            this.Controls.Add(this.tbSoLuong);
            this.Controls.Add(this.tbTenNhanVien);
            this.Controls.Add(this.tbTenSanPham);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.gridViewSanPhamDaThem);
            this.Controls.Add(this.gridViewSanPham);
            this.Controls.Add(this.tbSearchMaSanPham);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbMaNhanVien);
            this.Controls.Add(this.cbMaNhanVienNhap);
            this.Controls.Add(this.cbCoSoNhan);
            this.Controls.Add(this.tbMaSanPham);
            this.Controls.Add(this.tbNgayXuat);
            this.Controls.Add(this.tbMaPhieuXuatHang);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPhieuDieuChuyen";
            this.Text = "Phiếu điều chuyển";
            this.Load += new System.EventHandler(this.FrmPhieuXuatHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSanPhamDaThem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSoLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox tbMaPhieuXuatHang;
        private TextBox tbMaSanPham;
        private TextBox tbNgayXuat;
        private ComboBox cbCoSoNhan;
        private ComboBox cbMaNhanVienNhap;
        private ComboBox cbMaNhanVien;
        private Label label10;
        private TextBox tbSearchMaSanPham;
        private DataGridView gridViewSanPham;
        private DataGridView gridViewSanPhamDaThem;
        private Button btnThem;
        private Button btnLuu;
        private Button btnIn;
        private Button btnHuy;
        private Button btnThoat;
        private Label label11;
        private TextBox tbTenSanPham;
        private TextBox tbTenNhanVien;
        private NumericUpDown tbSoLuong;
        private CheckBox cbMaSanPham;
        private ImageList imageList1;
        private CheckBox checkBox1;
        private TextBox tbSearchMaSanPhamDaThem;
        private Label label12;
        private Button btnXoaSearchMaSanPhamDaThem;
        private TextBox tbNgayNhap;
        private Label label13;
        private Label label15;
    }
}

