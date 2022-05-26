
namespace Okono_Mmanagement
{
    partial class FrmTrangChu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTrangChu));
            this.MainNenu = new System.Windows.Forms.MenuStrip();
            this.thôngTinCửaHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSanPham = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBanHang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnDangNhap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuXuatHang = new System.Windows.Forms.ToolStripMenuItem();
            this.phiếuXuấtHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xácNhậnVàTìmKiếmPdcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pDCĐãXácNhậnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýDoanhThuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýHoáĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phiếuChốtCaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.quảnLýDoanhNghiệpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cơSởToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chứcVụToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMụcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainNenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainNenu
            // 
            this.MainNenu.BackColor = System.Drawing.Color.Tomato;
            this.MainNenu.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainNenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainNenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýDoanhNghiệpToolStripMenuItem,
            this.thôngTinCửaHàngToolStripMenuItem,
            this.mnuBanHang,
            this.mnDangNhap,
            this.mnuXuatHang,
            this.quảnLýToolStripMenuItem,
            this.toolStripMenuItem1,
            this.mnThoat});
            this.MainNenu.Location = new System.Drawing.Point(0, 0);
            this.MainNenu.Name = "MainNenu";
            this.MainNenu.Padding = new System.Windows.Forms.Padding(10);
            this.MainNenu.Size = new System.Drawing.Size(1177, 48);
            this.MainNenu.TabIndex = 0;
            this.MainNenu.Text = "MainMenu";
            this.MainNenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // thôngTinCửaHàngToolStripMenuItem
            // 
            this.thôngTinCửaHàngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSanPham,
            this.mnuNhanVien,
            this.mnuKhachHang,
            this.danhMụcToolStripMenuItem});
            this.thôngTinCửaHàngToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.LightSalmon;
            this.thôngTinCửaHàngToolStripMenuItem.Name = "thôngTinCửaHàngToolStripMenuItem";
            this.thôngTinCửaHàngToolStripMenuItem.Size = new System.Drawing.Size(195, 28);
            this.thôngTinCửaHàngToolStripMenuItem.Text = "Thông tin cửa hàng";
            // 
            // mnuSanPham
            // 
            this.mnuSanPham.BackColor = System.Drawing.Color.White;
            this.mnuSanPham.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.mnuSanPham.Name = "mnuSanPham";
            this.mnuSanPham.Size = new System.Drawing.Size(189, 28);
            this.mnuSanPham.Text = "Sản phẩm";
            this.mnuSanPham.Click += new System.EventHandler(this.mnuSanPham_Click);
            // 
            // mnuNhanVien
            // 
            this.mnuNhanVien.BackColor = System.Drawing.Color.White;
            this.mnuNhanVien.Name = "mnuNhanVien";
            this.mnuNhanVien.Size = new System.Drawing.Size(189, 28);
            this.mnuNhanVien.Text = "Nhân viên";
            this.mnuNhanVien.Click += new System.EventHandler(this.mnuNhanVien_Click);
            // 
            // mnuKhachHang
            // 
            this.mnuKhachHang.BackColor = System.Drawing.Color.White;
            this.mnuKhachHang.Name = "mnuKhachHang";
            this.mnuKhachHang.Size = new System.Drawing.Size(189, 28);
            this.mnuKhachHang.Text = "Khách hàng";
            this.mnuKhachHang.Click += new System.EventHandler(this.mnuKhachHang_Click);
            // 
            // mnuBanHang
            // 
            this.mnuBanHang.Name = "mnuBanHang";
            this.mnuBanHang.Size = new System.Drawing.Size(108, 28);
            this.mnuBanHang.Text = "Bán hàng";
            this.mnuBanHang.Click += new System.EventHandler(this.mnuBanHang_Click);
            // 
            // mnDangNhap
            // 
            this.mnDangNhap.Name = "mnDangNhap";
            this.mnDangNhap.Size = new System.Drawing.Size(104, 28);
            this.mnDangNhap.Text = "Đặt hàng";
            this.mnDangNhap.Click += new System.EventHandler(this.mnDangNhap_Click);
            // 
            // mnuXuatHang
            // 
            this.mnuXuatHang.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.phiếuXuấtHàngToolStripMenuItem,
            this.xácNhậnVàTìmKiếmPdcToolStripMenuItem,
            this.pDCĐãXácNhậnToolStripMenuItem});
            this.mnuXuatHang.Name = "mnuXuatHang";
            this.mnuXuatHang.Size = new System.Drawing.Size(180, 28);
            this.mnuXuatHang.Text = "Điều chuyển hàng";
            this.mnuXuatHang.Click += new System.EventHandler(this.mnuXuatHang_Click);
            // 
            // phiếuXuấtHàngToolStripMenuItem
            // 
            this.phiếuXuấtHàngToolStripMenuItem.Name = "phiếuXuấtHàngToolStripMenuItem";
            this.phiếuXuấtHàngToolStripMenuItem.Size = new System.Drawing.Size(323, 28);
            this.phiếuXuấtHàngToolStripMenuItem.Text = "Phiếu điều chuyển";
            this.phiếuXuấtHàngToolStripMenuItem.Click += new System.EventHandler(this.phiếuXuấtHàngToolStripMenuItem_Click);
            // 
            // xácNhậnVàTìmKiếmPdcToolStripMenuItem
            // 
            this.xácNhậnVàTìmKiếmPdcToolStripMenuItem.Name = "xácNhậnVàTìmKiếmPdcToolStripMenuItem";
            this.xácNhậnVàTìmKiếmPdcToolStripMenuItem.Size = new System.Drawing.Size(323, 28);
            this.xácNhậnVàTìmKiếmPdcToolStripMenuItem.Text = "Xác nhận và tìm kiếm PDC";
            this.xácNhậnVàTìmKiếmPdcToolStripMenuItem.Click += new System.EventHandler(this.xácNhậnVàTìmKiếmPdcToolStripMenuItem_Click);
            // 
            // pDCĐãXácNhậnToolStripMenuItem
            // 
            this.pDCĐãXácNhậnToolStripMenuItem.Name = "pDCĐãXácNhậnToolStripMenuItem";
            this.pDCĐãXácNhậnToolStripMenuItem.Size = new System.Drawing.Size(323, 28);
            this.pDCĐãXácNhậnToolStripMenuItem.Text = "PDC đã xác nhận";
            this.pDCĐãXácNhậnToolStripMenuItem.Click += new System.EventHandler(this.pDCĐãXácNhậnToolStripMenuItem_Click);
            // 
            // quảnLýToolStripMenuItem
            // 
            this.quảnLýToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýDoanhThuToolStripMenuItem,
            this.quảnLýHoáĐơnToolStripMenuItem,
            this.phiếuChốtCaToolStripMenuItem});
            this.quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            this.quảnLýToolStripMenuItem.Size = new System.Drawing.Size(91, 28);
            this.quảnLýToolStripMenuItem.Text = "Quản lý";
            // 
            // quảnLýDoanhThuToolStripMenuItem
            // 
            this.quảnLýDoanhThuToolStripMenuItem.Name = "quảnLýDoanhThuToolStripMenuItem";
            this.quảnLýDoanhThuToolStripMenuItem.Size = new System.Drawing.Size(243, 28);
            this.quảnLýDoanhThuToolStripMenuItem.Text = "Quản lý doanh thu";
            this.quảnLýDoanhThuToolStripMenuItem.Click += new System.EventHandler(this.quảnLýDoanhThuToolStripMenuItem_Click);
            // 
            // quảnLýHoáĐơnToolStripMenuItem
            // 
            this.quảnLýHoáĐơnToolStripMenuItem.Name = "quảnLýHoáĐơnToolStripMenuItem";
            this.quảnLýHoáĐơnToolStripMenuItem.Size = new System.Drawing.Size(243, 28);
            this.quảnLýHoáĐơnToolStripMenuItem.Text = "Thống kê";
            this.quảnLýHoáĐơnToolStripMenuItem.Click += new System.EventHandler(this.quảnLýHoáĐơnToolStripMenuItem_Click);
            // 
            // phiếuChốtCaToolStripMenuItem
            // 
            this.phiếuChốtCaToolStripMenuItem.Name = "phiếuChốtCaToolStripMenuItem";
            this.phiếuChốtCaToolStripMenuItem.Size = new System.Drawing.Size(243, 28);
            this.phiếuChốtCaToolStripMenuItem.Text = "Phiếu chốt ca";
            this.phiếuChốtCaToolStripMenuItem.Click += new System.EventHandler(this.phiếuChốtCaToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(145, 28);
            this.toolStripMenuItem1.Text = "Đăng nhập lại";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // mnThoat
            // 
            this.mnThoat.Name = "mnThoat";
            this.mnThoat.Size = new System.Drawing.Size(75, 28);
            this.mnThoat.Text = "Thoát";
            this.mnThoat.Click += new System.EventHandler(this.mnThoat_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // quảnLýDoanhNghiệpToolStripMenuItem
            // 
            this.quảnLýDoanhNghiệpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cơSởToolStripMenuItem,
            this.chứcVụToolStripMenuItem});
            this.quảnLýDoanhNghiệpToolStripMenuItem.Name = "quảnLýDoanhNghiệpToolStripMenuItem";
            this.quảnLýDoanhNghiệpToolStripMenuItem.Size = new System.Drawing.Size(215, 28);
            this.quảnLýDoanhNghiệpToolStripMenuItem.Text = "Quản lý doanh nghiệp";
            // 
            // cơSởToolStripMenuItem
            // 
            this.cơSởToolStripMenuItem.Name = "cơSởToolStripMenuItem";
            this.cơSởToolStripMenuItem.Size = new System.Drawing.Size(180, 28);
            this.cơSởToolStripMenuItem.Text = "Cơ sở";
            this.cơSởToolStripMenuItem.Click += new System.EventHandler(this.cơSởToolStripMenuItem_Click);
            // 
            // chứcVụToolStripMenuItem
            // 
            this.chứcVụToolStripMenuItem.Name = "chứcVụToolStripMenuItem";
            this.chứcVụToolStripMenuItem.Size = new System.Drawing.Size(180, 28);
            this.chứcVụToolStripMenuItem.Text = "Chức vụ";
            this.chứcVụToolStripMenuItem.Click += new System.EventHandler(this.chứcVụToolStripMenuItem_Click);
            // 
            // danhMụcToolStripMenuItem
            // 
            this.danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
            this.danhMụcToolStripMenuItem.Size = new System.Drawing.Size(189, 28);
            this.danhMụcToolStripMenuItem.Text = "Danh mục";
            this.danhMụcToolStripMenuItem.Click += new System.EventHandler(this.danhMụcToolStripMenuItem_Click);
            // 
            // FrmTrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1177, 721);
            this.Controls.Add(this.MainNenu);
            this.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.OrangeRed;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainNenu;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FrmTrangChu";
            this.Text = "Trang chủ";
            this.Load += new System.EventHandler(this.FrmTrangChu_Load);
            this.MainNenu.ResumeLayout(false);
            this.MainNenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainNenu;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCửaHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuSanPham;
        private System.Windows.Forms.ToolStripMenuItem mnuNhanVien;
        private System.Windows.Forms.ToolStripMenuItem mnuKhachHang;
        private System.Windows.Forms.ToolStripMenuItem mnuBanHang;
        private System.Windows.Forms.ToolStripMenuItem mnuXuatHang;
        private System.Windows.Forms.ToolStripMenuItem quảnLýToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnDangNhap;
        private System.Windows.Forms.ToolStripMenuItem mnThoat;
        private System.Windows.Forms.ToolStripMenuItem quảnLýDoanhThuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýHoáĐơnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phiếuXuấtHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phiếuChốtCaToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem xácNhậnVàTìmKiếmPdcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pDCĐãXácNhậnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýDoanhNghiệpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cơSởToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chứcVụToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhMụcToolStripMenuItem;
    }
}