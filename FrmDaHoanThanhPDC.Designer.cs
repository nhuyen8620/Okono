
namespace Okono_Mmanagement
{
    partial class FrmDaHoanThanhPDC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDaHoanThanhPDC));
            this.gridViewSanPham = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbMaPhieuDieuChuyen = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // gridViewSanPham
            // 
            this.gridViewSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewSanPham.Location = new System.Drawing.Point(128, 325);
            this.gridViewSanPham.Name = "gridViewSanPham";
            this.gridViewSanPham.RowHeadersWidth = 51;
            this.gridViewSanPham.RowTemplate.Height = 24;
            this.gridViewSanPham.Size = new System.Drawing.Size(1019, 326);
            this.gridViewSanPham.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(30)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(529, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(384, 40);
            this.label1.TabIndex = 3;
            this.label1.Text = "PHIẾU ĐIỀU CHUYỂN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(286, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tìm mã phiếu điều chuyển:";
            // 
            // cbMaPhieuDieuChuyen
            // 
            this.cbMaPhieuDieuChuyen.Font = new System.Drawing.Font("Times New Roman", 13.2F);
            this.cbMaPhieuDieuChuyen.FormattingEnabled = true;
            this.cbMaPhieuDieuChuyen.Location = new System.Drawing.Point(493, 244);
            this.cbMaPhieuDieuChuyen.Name = "cbMaPhieuDieuChuyen";
            this.cbMaPhieuDieuChuyen.Size = new System.Drawing.Size(382, 28);
            this.cbMaPhieuDieuChuyen.TabIndex = 31;
            this.cbMaPhieuDieuChuyen.SelectedIndexChanged += new System.EventHandler(this.cbMaPhieuDieuChuyen_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(30)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(560, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(315, 40);
            this.label3.TabIndex = 32;
            this.label3.Text = "ĐÃ HOÀN THÀNH";
            // 
            // btnThoat
            // 
            this.btnThoat.Enabled = false;
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(30)))), ((int)(((byte)(0)))));
            this.btnThoat.Image = global::Okono_Mmanagement.Properties.Resources.close_okono;
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThoat.Location = new System.Drawing.Point(652, 686);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(36, 41);
            this.btnThoat.TabIndex = 50;
            this.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // FrmDaHoanThanhPDC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1284, 781);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbMaPhieuDieuChuyen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridViewSanPham);
            this.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDaHoanThanhPDC";
            this.Text = "Phiếu điều chuyển đã hoàn thành";
            this.Load += new System.EventHandler(this.FrmDaHoanThanhPDC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSanPham)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridViewSanPham;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbMaPhieuDieuChuyen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnThoat;
    }
}