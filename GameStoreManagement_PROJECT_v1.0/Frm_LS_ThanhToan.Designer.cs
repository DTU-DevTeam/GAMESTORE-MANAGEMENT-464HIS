namespace QlyLichSu
{
    partial class Frm_LS_ThanhToan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_LS_ThanhToan));
            this.pnThanhToan1 = new System.Windows.Forms.Panel();
            this.btnTat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnThanhToan2 = new System.Windows.Forms.Panel();
            this.btnXuatFile = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dtvThanhToan = new System.Windows.Forms.DataGridView();
            this.txtMaGiaoDich = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbTrangThaiThanhToan = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbHinhThucThanhToan = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSoTienThanhToan = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbLoaiThanhToan = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpThoiGianThanhToan = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpThoiGian = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKhachHang = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaThanhToan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnThanhToan1.SuspendLayout();
            this.pnThanhToan2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtvThanhToan)).BeginInit();
            this.SuspendLayout();
            // 
            // pnThanhToan1
            // 
            this.pnThanhToan1.BackColor = System.Drawing.Color.White;
            this.pnThanhToan1.Controls.Add(this.btnTat);
            this.pnThanhToan1.Controls.Add(this.label1);
            this.pnThanhToan1.Location = new System.Drawing.Point(31, 26);
            this.pnThanhToan1.Name = "pnThanhToan1";
            this.pnThanhToan1.Size = new System.Drawing.Size(1192, 74);
            this.pnThanhToan1.TabIndex = 0;
            // 
            // btnTat
            // 
            this.btnTat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTat.Image = global::GameStoreManagement_PROJECT_v1._0.Properties.Resources.off;
            this.btnTat.Location = new System.Drawing.Point(1096, 16);
            this.btnTat.Name = "btnTat";
            this.btnTat.Size = new System.Drawing.Size(75, 46);
            this.btnTat.TabIndex = 1;
            this.btnTat.UseVisualStyleBackColor = true;
            this.btnTat.Click += new System.EventHandler(this.btnTat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(374, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(375, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "LỊCH SỬ THANH TOÁN";
            // 
            // pnThanhToan2
            // 
            this.pnThanhToan2.BackColor = System.Drawing.Color.White;
            this.pnThanhToan2.Controls.Add(this.btnXuatFile);
            this.pnThanhToan2.Controls.Add(this.btnTimKiem);
            this.pnThanhToan2.Controls.Add(this.dtvThanhToan);
            this.pnThanhToan2.Controls.Add(this.txtMaGiaoDich);
            this.pnThanhToan2.Controls.Add(this.label10);
            this.pnThanhToan2.Controls.Add(this.cbTrangThaiThanhToan);
            this.pnThanhToan2.Controls.Add(this.label9);
            this.pnThanhToan2.Controls.Add(this.cbHinhThucThanhToan);
            this.pnThanhToan2.Controls.Add(this.label8);
            this.pnThanhToan2.Controls.Add(this.txtSoTienThanhToan);
            this.pnThanhToan2.Controls.Add(this.label7);
            this.pnThanhToan2.Controls.Add(this.cbLoaiThanhToan);
            this.pnThanhToan2.Controls.Add(this.label6);
            this.pnThanhToan2.Controls.Add(this.dtpThoiGianThanhToan);
            this.pnThanhToan2.Controls.Add(this.label5);
            this.pnThanhToan2.Controls.Add(this.dtpThoiGian);
            this.pnThanhToan2.Controls.Add(this.label4);
            this.pnThanhToan2.Controls.Add(this.txtKhachHang);
            this.pnThanhToan2.Controls.Add(this.label3);
            this.pnThanhToan2.Controls.Add(this.txtMaThanhToan);
            this.pnThanhToan2.Controls.Add(this.label2);
            this.pnThanhToan2.Location = new System.Drawing.Point(31, 125);
            this.pnThanhToan2.Name = "pnThanhToan2";
            this.pnThanhToan2.Size = new System.Drawing.Size(1192, 645);
            this.pnThanhToan2.TabIndex = 1;
            this.pnThanhToan2.Paint += new System.Windows.Forms.PaintEventHandler(this.pnThanhToan2_Paint);
            // 
            // btnXuatFile
            // 
            this.btnXuatFile.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatFile.Location = new System.Drawing.Point(629, 224);
            this.btnXuatFile.Name = "btnXuatFile";
            this.btnXuatFile.Size = new System.Drawing.Size(163, 43);
            this.btnXuatFile.TabIndex = 20;
            this.btnXuatFile.Text = "Xuất File ";
            this.btnXuatFile.UseVisualStyleBackColor = true;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(292, 224);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(163, 43);
            this.btnTimKiem.TabIndex = 19;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // dtvThanhToan
            // 
            this.dtvThanhToan.BackgroundColor = System.Drawing.Color.White;
            this.dtvThanhToan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtvThanhToan.Location = new System.Drawing.Point(18, 283);
            this.dtvThanhToan.Name = "dtvThanhToan";
            this.dtvThanhToan.RowHeadersWidth = 51;
            this.dtvThanhToan.RowTemplate.Height = 24;
            this.dtvThanhToan.Size = new System.Drawing.Size(1134, 350);
            this.dtvThanhToan.TabIndex = 18;
            // 
            // txtMaGiaoDich
            // 
            this.txtMaGiaoDich.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaGiaoDich.Location = new System.Drawing.Point(857, 165);
            this.txtMaGiaoDich.Multiline = true;
            this.txtMaGiaoDich.Name = "txtMaGiaoDich";
            this.txtMaGiaoDich.ReadOnly = true;
            this.txtMaGiaoDich.Size = new System.Drawing.Size(295, 32);
            this.txtMaGiaoDich.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(736, 174);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 23);
            this.label10.TabIndex = 16;
            this.label10.Text = "Mã giao dịch";
            // 
            // cbTrangThaiThanhToan
            // 
            this.cbTrangThaiThanhToan.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTrangThaiThanhToan.FormattingEnabled = true;
            this.cbTrangThaiThanhToan.Location = new System.Drawing.Point(505, 171);
            this.cbTrangThaiThanhToan.Name = "cbTrangThaiThanhToan";
            this.cbTrangThaiThanhToan.Size = new System.Drawing.Size(213, 31);
            this.cbTrangThaiThanhToan.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(396, 179);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 23);
            this.label9.TabIndex = 14;
            this.label9.Text = "Trạng thái";
            // 
            // cbHinhThucThanhToan
            // 
            this.cbHinhThucThanhToan.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHinhThucThanhToan.FormattingEnabled = true;
            this.cbHinhThucThanhToan.Location = new System.Drawing.Point(214, 171);
            this.cbHinhThucThanhToan.Name = "cbHinhThucThanhToan";
            this.cbHinhThucThanhToan.Size = new System.Drawing.Size(156, 31);
            this.cbHinhThucThanhToan.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(181, 23);
            this.label8.TabIndex = 12;
            this.label8.Text = "Hình thức thanh toán";
            // 
            // txtSoTienThanhToan
            // 
            this.txtSoTienThanhToan.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoTienThanhToan.Location = new System.Drawing.Point(817, 94);
            this.txtSoTienThanhToan.Multiline = true;
            this.txtSoTienThanhToan.Name = "txtSoTienThanhToan";
            this.txtSoTienThanhToan.ReadOnly = true;
            this.txtSoTienThanhToan.Size = new System.Drawing.Size(335, 32);
            this.txtSoTienThanhToan.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(736, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 23);
            this.label7.TabIndex = 10;
            this.label7.Text = "Số tiền";
            // 
            // cbLoaiThanhToan
            // 
            this.cbLoaiThanhToan.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLoaiThanhToan.FormattingEnabled = true;
            this.cbLoaiThanhToan.Location = new System.Drawing.Point(537, 95);
            this.cbLoaiThanhToan.Name = "cbLoaiThanhToan";
            this.cbLoaiThanhToan.Size = new System.Drawing.Size(181, 31);
            this.cbLoaiThanhToan.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(385, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 23);
            this.label6.TabIndex = 8;
            this.label6.Text = "Loại thanh toán";
            // 
            // dtpThoiGianThanhToan
            // 
            this.dtpThoiGianThanhToan.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpThoiGianThanhToan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpThoiGianThanhToan.Location = new System.Drawing.Point(211, 96);
            this.dtpThoiGianThanhToan.Name = "dtpThoiGianThanhToan";
            this.dtpThoiGianThanhToan.Size = new System.Drawing.Size(159, 30);
            this.dtpThoiGianThanhToan.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 23);
            this.label5.TabIndex = 6;
            this.label5.Text = "Thời gian thanh toán";
            // 
            // dtpThoiGian
            // 
            this.dtpThoiGian.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpThoiGian.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpThoiGian.Location = new System.Drawing.Point(817, 26);
            this.dtpThoiGian.Name = "dtpThoiGian";
            this.dtpThoiGian.Size = new System.Drawing.Size(335, 30);
            this.dtpThoiGian.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(724, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Thời Gian";
            // 
            // txtKhachHang
            // 
            this.txtKhachHang.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKhachHang.Location = new System.Drawing.Point(505, 23);
            this.txtKhachHang.Multiline = true;
            this.txtKhachHang.Name = "txtKhachHang";
            this.txtKhachHang.Size = new System.Drawing.Size(213, 32);
            this.txtKhachHang.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(385, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Khách hàng";
            // 
            // txtMaThanhToan
            // 
            this.txtMaThanhToan.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaThanhToan.Location = new System.Drawing.Point(160, 23);
            this.txtMaThanhToan.Multiline = true;
            this.txtMaThanhToan.Name = "txtMaThanhToan";
            this.txtMaThanhToan.Size = new System.Drawing.Size(210, 32);
            this.txtMaThanhToan.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã thanh toán";
            // 
            // Frm_LS_ThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 782);
            this.Controls.Add(this.pnThanhToan2);
            this.Controls.Add(this.pnThanhToan1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_LS_ThanhToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lịch Sử Thanh Toán";
            this.pnThanhToan1.ResumeLayout(false);
            this.pnThanhToan1.PerformLayout();
            this.pnThanhToan2.ResumeLayout(false);
            this.pnThanhToan2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtvThanhToan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnThanhToan1;
        private System.Windows.Forms.Button btnTat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnThanhToan2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbLoaiThanhToan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpThoiGianThanhToan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpThoiGian;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtKhachHang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaThanhToan;
        private System.Windows.Forms.TextBox txtSoTienThanhToan;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbTrangThaiThanhToan;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbHinhThucThanhToan;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMaGiaoDich;
        private System.Windows.Forms.DataGridView dtvThanhToan;
        private System.Windows.Forms.Button btnXuatFile;
        private System.Windows.Forms.Button btnTimKiem;
    }
}

