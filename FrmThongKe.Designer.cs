
namespace Okono_Mmanagement
{
    partial class FrmThongKe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmThongKe));
            this.dataGridView_SP = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNam_Thang = new System.Windows.Forms.TextBox();
            this.txtThang = new System.Windows.Forms.NumericUpDown();
            this.txtQuy = new System.Windows.Forms.NumericUpDown();
            this.txtNamQuy = new System.Windows.Forms.TextBox();
            this.txtNam = new System.Windows.Forms.TextBox();
            this.btnNam = new System.Windows.Forms.Button();
            this.btnQuy = new System.Windows.Forms.Button();
            this.btnThang = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.ckTopdau = new System.Windows.Forms.CheckBox();
            this.ckTopCuoi = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuy)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_SP
            // 
            this.dataGridView_SP.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_SP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_SP.Location = new System.Drawing.Point(592, 320);
            this.dataGridView_SP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView_SP.Name = "dataGridView_SP";
            this.dataGridView_SP.RowHeadersWidth = 51;
            this.dataGridView_SP.RowTemplate.Height = 24;
            this.dataGridView_SP.Size = new System.Drawing.Size(510, 268);
            this.dataGridView_SP.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(767, 284);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "DANH SÁCH SẢN PHẨM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(475, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(580, 40);
            this.label2.TabIndex = 4;
            this.label2.Text = "THỐNG KÊ TÌNH HÌNH TIÊU THỤ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(146, 337);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tháng:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(146, 426);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Quý:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(146, 523);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Năm:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(280, 337);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Năm:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(280, 426);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "Năm:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // txtNam_Thang
            // 
            this.txtNam_Thang.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNam_Thang.Location = new System.Drawing.Point(332, 334);
            this.txtNam_Thang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNam_Thang.MaxLength = 4;
            this.txtNam_Thang.Name = "txtNam_Thang";
            this.txtNam_Thang.Size = new System.Drawing.Size(68, 28);
            this.txtNam_Thang.TabIndex = 10;
            this.txtNam_Thang.TextChanged += new System.EventHandler(this.txtNam_Thang_TextChanged);
            // 
            // txtThang
            // 
            this.txtThang.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThang.Location = new System.Drawing.Point(209, 335);
            this.txtThang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtThang.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.txtThang.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtThang.Name = "txtThang";
            this.txtThang.Size = new System.Drawing.Size(52, 29);
            this.txtThang.TabIndex = 11;
            this.txtThang.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtThang.ValueChanged += new System.EventHandler(this.txtThang_ValueChanged);
            // 
            // txtQuy
            // 
            this.txtQuy.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuy.Location = new System.Drawing.Point(209, 424);
            this.txtQuy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtQuy.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.txtQuy.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtQuy.Name = "txtQuy";
            this.txtQuy.Size = new System.Drawing.Size(52, 28);
            this.txtQuy.TabIndex = 12;
            this.txtQuy.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtNamQuy
            // 
            this.txtNamQuy.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNamQuy.Location = new System.Drawing.Point(332, 418);
            this.txtNamQuy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNamQuy.MaxLength = 4;
            this.txtNamQuy.Name = "txtNamQuy";
            this.txtNamQuy.Size = new System.Drawing.Size(68, 28);
            this.txtNamQuy.TabIndex = 13;
            // 
            // txtNam
            // 
            this.txtNam.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNam.Location = new System.Drawing.Point(209, 511);
            this.txtNam.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNam.MaxLength = 4;
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(191, 28);
            this.txtNam.TabIndex = 14;
            // 
            // btnNam
            // 
            this.btnNam.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNam.ForeColor = System.Drawing.Color.Red;
            this.btnNam.Image = ((System.Drawing.Image)(resources.GetObject("btnNam.Image")));
            this.btnNam.Location = new System.Drawing.Point(447, 511);
            this.btnNam.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNam.Name = "btnNam";
            this.btnNam.Size = new System.Drawing.Size(34, 32);
            this.btnNam.TabIndex = 42;
            this.btnNam.UseVisualStyleBackColor = true;
            this.btnNam.Click += new System.EventHandler(this.btnNam_Click);
            // 
            // btnQuy
            // 
            this.btnQuy.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuy.ForeColor = System.Drawing.Color.Red;
            this.btnQuy.Image = ((System.Drawing.Image)(resources.GetObject("btnQuy.Image")));
            this.btnQuy.Location = new System.Drawing.Point(447, 414);
            this.btnQuy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnQuy.Name = "btnQuy";
            this.btnQuy.Size = new System.Drawing.Size(34, 32);
            this.btnQuy.TabIndex = 43;
            this.btnQuy.UseVisualStyleBackColor = true;
            this.btnQuy.Click += new System.EventHandler(this.btnQuy_Click);
            // 
            // btnThang
            // 
            this.btnThang.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThang.ForeColor = System.Drawing.Color.Red;
            this.btnThang.Image = ((System.Drawing.Image)(resources.GetObject("btnThang.Image")));
            this.btnThang.Location = new System.Drawing.Point(447, 332);
            this.btnThang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnThang.Name = "btnThang";
            this.btnThang.Size = new System.Drawing.Size(34, 32);
            this.btnThang.TabIndex = 44;
            this.btnThang.UseVisualStyleBackColor = true;
            this.btnThang.Click += new System.EventHandler(this.btnThang_Click);
            // 
            // btnIn
            // 
            this.btnIn.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.ForeColor = System.Drawing.Color.Red;
            this.btnIn.Image = global::Okono_Mmanagement.Properties.Resources.printer_okono;
            this.btnIn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIn.Location = new System.Drawing.Point(592, 634);
            this.btnIn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(85, 40);
            this.btnIn.TabIndex = 45;
            this.btnIn.Text = "  In";
            this.btnIn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.ForeColor = System.Drawing.Color.Red;
            this.btnHuy.Image = global::Okono_Mmanagement.Properties.Resources.delete_okono;
            this.btnHuy.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHuy.Location = new System.Drawing.Point(817, 639);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(85, 40);
            this.btnHuy.TabIndex = 46;
            this.btnHuy.Text = " Hủy";
            this.btnHuy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.Red;
            this.btnThoat.Image = global::Okono_Mmanagement.Properties.Resources.close_okono;
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThoat.Location = new System.Drawing.Point(1017, 639);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(85, 40);
            this.btnThoat.TabIndex = 47;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // ckTopdau
            // 
            this.ckTopdau.AutoSize = true;
            this.ckTopdau.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckTopdau.Location = new System.Drawing.Point(284, 206);
            this.ckTopdau.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ckTopdau.Name = "ckTopdau";
            this.ckTopdau.Size = new System.Drawing.Size(214, 24);
            this.ckTopdau.TabIndex = 48;
            this.ckTopdau.Text = "Top sản phẩm tiêu thụ tốt";
            this.ckTopdau.UseVisualStyleBackColor = true;
            this.ckTopdau.CheckedChanged += new System.EventHandler(this.ckTopdau_CheckedChanged);
            // 
            // ckTopCuoi
            // 
            this.ckTopCuoi.AutoSize = true;
            this.ckTopCuoi.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckTopCuoi.Location = new System.Drawing.Point(693, 206);
            this.ckTopCuoi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ckTopCuoi.Name = "ckTopCuoi";
            this.ckTopCuoi.Size = new System.Drawing.Size(226, 24);
            this.ckTopCuoi.TabIndex = 49;
            this.ckTopCuoi.Text = "Top sản phẩm tiêu thụ kém";
            this.ckTopCuoi.UseVisualStyleBackColor = true;
            this.ckTopCuoi.CheckedChanged += new System.EventHandler(this.ckTopCuoi_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(146, 601);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(345, 24);
            this.label12.TabIndex = 55;
            this.label12.Text = "OKONO chi nhánh 72 Khương Trung";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(205, 642);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(200, 24);
            this.label13.TabIndex = 56;
            this.label13.Text = "Thanh Xuân - Hà Nội";
            // 
            // FrmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Okono_Mmanagement.Properties.Resources.temp;
            this.ClientSize = new System.Drawing.Size(1284, 781);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.ckTopCuoi);
            this.Controls.Add(this.ckTopdau);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.btnThang);
            this.Controls.Add(this.btnQuy);
            this.Controls.Add(this.btnNam);
            this.Controls.Add(this.txtNam);
            this.Controls.Add(this.txtNamQuy);
            this.Controls.Add(this.txtQuy);
            this.Controls.Add(this.txtThang);
            this.Controls.Add(this.txtNam_Thang);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_SP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmThongKe";
            this.Text = "Thống kê sản phẩm tiêu thụ";
            this.Load += new System.EventHandler(this.FrmQuanLyHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_SP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNam_Thang;
        private System.Windows.Forms.NumericUpDown txtThang;
        private System.Windows.Forms.NumericUpDown txtQuy;
        private System.Windows.Forms.TextBox txtNamQuy;
        private System.Windows.Forms.TextBox txtNam;
        private System.Windows.Forms.Button btnNam;
        private System.Windows.Forms.Button btnQuy;
        private System.Windows.Forms.Button btnThang;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.CheckBox ckTopdau;
        private System.Windows.Forms.CheckBox ckTopCuoi;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}