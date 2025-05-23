namespace QlyKho
{
    partial class frm_XemChiTiet
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtvChiTietKhoNhap = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSuaChiTiet = new System.Windows.Forms.Button();
            this.cbNhomChiTiet = new System.Windows.Forms.ComboBox();
            this.cbDonViChiTiet = new System.Windows.Forms.ComboBox();
            this.dtpNgayNhapChiTiet = new System.Windows.Forms.DateTimePicker();
            this.txtLienLacChiTiet = new System.Windows.Forms.TextBox();
            this.txtNguonNhapChiTiet = new System.Windows.Forms.TextBox();
            this.txtGiaNhapChitiet = new System.Windows.Forms.TextBox();
            this.txtSoLuongChiTiet = new System.Windows.Forms.TextBox();
            this.txtSanPhamChiTiet = new System.Windows.Forms.TextBox();
            this.txtMaNhapChiTiet = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtvChiTietKhoNhap)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnTat);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1151, 69);
            this.panel1.TabIndex = 0;
            // 
            // btnTat
            // 
            this.btnTat.Image = global::QlyKho.Properties.Resources.turn_off;
            this.btnTat.Location = new System.Drawing.Point(1083, 13);
            this.btnTat.Name = "btnTat";
            this.btnTat.Size = new System.Drawing.Size(41, 35);
            this.btnTat.TabIndex = 4;
            this.btnTat.UseVisualStyleBackColor = true;
            this.btnTat.Click += new System.EventHandler(this.btnTat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(18, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chi Tiết Nhập Kho";
            // 
            // dtvChiTietKhoNhap
            // 
            this.dtvChiTietKhoNhap.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtvChiTietKhoNhap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtvChiTietKhoNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtvChiTietKhoNhap.Location = new System.Drawing.Point(12, 98);
            this.dtvChiTietKhoNhap.Name = "dtvChiTietKhoNhap";
            this.dtvChiTietKhoNhap.RowHeadersWidth = 51;
            this.dtvChiTietKhoNhap.RowTemplate.Height = 24;
            this.dtvChiTietKhoNhap.Size = new System.Drawing.Size(678, 502);
            this.dtvChiTietKhoNhap.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnSuaChiTiet);
            this.panel2.Controls.Add(this.cbNhomChiTiet);
            this.panel2.Controls.Add(this.cbDonViChiTiet);
            this.panel2.Controls.Add(this.dtpNgayNhapChiTiet);
            this.panel2.Controls.Add(this.txtLienLacChiTiet);
            this.panel2.Controls.Add(this.txtNguonNhapChiTiet);
            this.panel2.Controls.Add(this.txtGiaNhapChitiet);
            this.panel2.Controls.Add(this.txtSoLuongChiTiet);
            this.panel2.Controls.Add(this.txtSanPhamChiTiet);
            this.panel2.Controls.Add(this.txtMaNhapChiTiet);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(697, 98);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(467, 502);
            this.panel2.TabIndex = 2;
            // 
            // btnSuaChiTiet
            // 
            this.btnSuaChiTiet.Font = new System.Drawing.Font("Segoe UI Black", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaChiTiet.Location = new System.Drawing.Point(156, 405);
            this.btnSuaChiTiet.Name = "btnSuaChiTiet";
            this.btnSuaChiTiet.Size = new System.Drawing.Size(156, 57);
            this.btnSuaChiTiet.TabIndex = 18;
            this.btnSuaChiTiet.Text = "Sửa";
            this.btnSuaChiTiet.UseVisualStyleBackColor = true;
            this.btnSuaChiTiet.Click += new System.EventHandler(this.btnSuaChiTiet_Click);
            // 
            // cbNhomChiTiet
            // 
            this.cbNhomChiTiet.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNhomChiTiet.FormattingEnabled = true;
            this.cbNhomChiTiet.Location = new System.Drawing.Point(297, 135);
            this.cbNhomChiTiet.Name = "cbNhomChiTiet";
            this.cbNhomChiTiet.Size = new System.Drawing.Size(143, 28);
            this.cbNhomChiTiet.TabIndex = 17;
            // 
            // cbDonViChiTiet
            // 
            this.cbDonViChiTiet.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDonViChiTiet.FormattingEnabled = true;
            this.cbDonViChiTiet.Location = new System.Drawing.Point(169, 135);
            this.cbDonViChiTiet.Name = "cbDonViChiTiet";
            this.cbDonViChiTiet.Size = new System.Drawing.Size(119, 28);
            this.cbDonViChiTiet.TabIndex = 16;
            // 
            // dtpNgayNhapChiTiet
            // 
            this.dtpNgayNhapChiTiet.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayNhapChiTiet.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayNhapChiTiet.Location = new System.Drawing.Point(240, 224);
            this.dtpNgayNhapChiTiet.Name = "dtpNgayNhapChiTiet";
            this.dtpNgayNhapChiTiet.Size = new System.Drawing.Size(200, 30);
            this.dtpNgayNhapChiTiet.TabIndex = 15;
            // 
            // txtLienLacChiTiet
            // 
            this.txtLienLacChiTiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLienLacChiTiet.Location = new System.Drawing.Point(231, 319);
            this.txtLienLacChiTiet.Multiline = true;
            this.txtLienLacChiTiet.Name = "txtLienLacChiTiet";
            this.txtLienLacChiTiet.Size = new System.Drawing.Size(218, 33);
            this.txtLienLacChiTiet.TabIndex = 14;
            // 
            // txtNguonNhapChiTiet
            // 
            this.txtNguonNhapChiTiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNguonNhapChiTiet.Location = new System.Drawing.Point(20, 319);
            this.txtNguonNhapChiTiet.Multiline = true;
            this.txtNguonNhapChiTiet.Name = "txtNguonNhapChiTiet";
            this.txtNguonNhapChiTiet.Size = new System.Drawing.Size(199, 33);
            this.txtNguonNhapChiTiet.TabIndex = 13;
            // 
            // txtGiaNhapChitiet
            // 
            this.txtGiaNhapChitiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiaNhapChitiet.Location = new System.Drawing.Point(20, 224);
            this.txtGiaNhapChitiet.Multiline = true;
            this.txtGiaNhapChitiet.Name = "txtGiaNhapChitiet";
            this.txtGiaNhapChitiet.Size = new System.Drawing.Size(199, 33);
            this.txtGiaNhapChitiet.TabIndex = 12;
            // 
            // txtSoLuongChiTiet
            // 
            this.txtSoLuongChiTiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoLuongChiTiet.Location = new System.Drawing.Point(20, 135);
            this.txtSoLuongChiTiet.Multiline = true;
            this.txtSoLuongChiTiet.Name = "txtSoLuongChiTiet";
            this.txtSoLuongChiTiet.Size = new System.Drawing.Size(100, 33);
            this.txtSoLuongChiTiet.TabIndex = 11;
            // 
            // txtSanPhamChiTiet
            // 
            this.txtSanPhamChiTiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSanPhamChiTiet.Location = new System.Drawing.Point(169, 45);
            this.txtSanPhamChiTiet.Multiline = true;
            this.txtSanPhamChiTiet.Name = "txtSanPhamChiTiet";
            this.txtSanPhamChiTiet.Size = new System.Drawing.Size(280, 33);
            this.txtSanPhamChiTiet.TabIndex = 10;
            // 
            // txtMaNhapChiTiet
            // 
            this.txtMaNhapChiTiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNhapChiTiet.Location = new System.Drawing.Point(20, 45);
            this.txtMaNhapChiTiet.Multiline = true;
            this.txtMaNhapChiTiet.Name = "txtMaNhapChiTiet";
            this.txtMaNhapChiTiet.Size = new System.Drawing.Size(100, 33);
            this.txtMaNhapChiTiet.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(16, 274);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 20);
            this.label11.TabIndex = 8;
            this.label11.Text = "Nguồn nhập";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(227, 274);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 20);
            this.label10.TabIndex = 7;
            this.label10.Text = "Liên lạc";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(227, 188);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 20);
            this.label9.TabIndex = 6;
            this.label9.Text = "Ngày nhập";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 20);
            this.label8.TabIndex = 5;
            this.label8.Text = "Giá nhập";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(293, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Nhóm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(165, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Đơn vị";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Số lượng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(165, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Tên sản phẩm ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mã nhập";
            // 
            // frm_XemChiTiet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1176, 612);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dtvChiTietKhoNhap);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_XemChiTiet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XemChiTiết";
            this.Load += new System.EventHandler(this.frm_XemChiTiet_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frm_XemChiTiet_Paint);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtvChiTietKhoNhap)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtvChiTietKhoNhap;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaNhapChiTiet;
        private System.Windows.Forms.ComboBox cbNhomChiTiet;
        private System.Windows.Forms.ComboBox cbDonViChiTiet;
        private System.Windows.Forms.DateTimePicker dtpNgayNhapChiTiet;
        private System.Windows.Forms.TextBox txtLienLacChiTiet;
        private System.Windows.Forms.TextBox txtNguonNhapChiTiet;
        private System.Windows.Forms.TextBox txtGiaNhapChitiet;
        private System.Windows.Forms.TextBox txtSoLuongChiTiet;
        private System.Windows.Forms.TextBox txtSanPhamChiTiet;
        private System.Windows.Forms.Button btnSuaChiTiet;
        private System.Windows.Forms.Button btnTat;
    }
}