namespace QLyKhachHang
{
    partial class frm_TaoTaiKhoan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_TaoTaiKhoan));
            this.pnTaoTaiKhoan1 = new System.Windows.Forms.Panel();
            this.btnTatTaiKhoan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnTaoTaiKhoan2 = new System.Windows.Forms.Panel();
            this.txtUsernameTaoTaiKhoan = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPassTaoTaiKhoan = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnTao = new System.Windows.Forms.Button();
            this.dtpNgayDangKyTaiKhoan = new System.Windows.Forms.DateTimePicker();
            this.txtSoDuTaiKhoan = new System.Windows.Forms.TextBox();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.txtTenKhachHangTaoTaiKhoan = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnTaoTaiKhoan1.SuspendLayout();
            this.pnTaoTaiKhoan2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnTaoTaiKhoan1
            // 
            this.pnTaoTaiKhoan1.BackColor = System.Drawing.Color.White;
            this.pnTaoTaiKhoan1.Controls.Add(this.btnTatTaiKhoan);
            this.pnTaoTaiKhoan1.Controls.Add(this.label1);
            this.pnTaoTaiKhoan1.Location = new System.Drawing.Point(13, 24);
            this.pnTaoTaiKhoan1.Name = "pnTaoTaiKhoan1";
            this.pnTaoTaiKhoan1.Size = new System.Drawing.Size(895, 85);
            this.pnTaoTaiKhoan1.TabIndex = 0;
            this.pnTaoTaiKhoan1.Paint += new System.Windows.Forms.PaintEventHandler(this.pnTaoTaiKhoan1_Paint);
            // 
            // btnTatTaiKhoan
            // 
            this.btnTatTaiKhoan.Image = ((System.Drawing.Image)(resources.GetObject("btnTatTaiKhoan.Image")));
            this.btnTatTaiKhoan.Location = new System.Drawing.Point(807, 31);
            this.btnTatTaiKhoan.Name = "btnTatTaiKhoan";
            this.btnTatTaiKhoan.Size = new System.Drawing.Size(43, 32);
            this.btnTatTaiKhoan.TabIndex = 2;
            this.btnTatTaiKhoan.UseVisualStyleBackColor = true;
            this.btnTatTaiKhoan.Click += new System.EventHandler(this.btnTatTaotaiKhoan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tạo Tài Khoản ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(17, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên khách hàng";
            // 
            // pnTaoTaiKhoan2
            // 
            this.pnTaoTaiKhoan2.BackColor = System.Drawing.Color.White;
            this.pnTaoTaiKhoan2.Controls.Add(this.txtUsernameTaoTaiKhoan);
            this.pnTaoTaiKhoan2.Controls.Add(this.label7);
            this.pnTaoTaiKhoan2.Controls.Add(this.txtPassTaoTaiKhoan);
            this.pnTaoTaiKhoan2.Controls.Add(this.label6);
            this.pnTaoTaiKhoan2.Controls.Add(this.btnTao);
            this.pnTaoTaiKhoan2.Controls.Add(this.dtpNgayDangKyTaiKhoan);
            this.pnTaoTaiKhoan2.Controls.Add(this.txtSoDuTaiKhoan);
            this.pnTaoTaiKhoan2.Controls.Add(this.txtSoDienThoai);
            this.pnTaoTaiKhoan2.Controls.Add(this.txtTenKhachHangTaoTaiKhoan);
            this.pnTaoTaiKhoan2.Controls.Add(this.label5);
            this.pnTaoTaiKhoan2.Controls.Add(this.label4);
            this.pnTaoTaiKhoan2.Controls.Add(this.label3);
            this.pnTaoTaiKhoan2.Controls.Add(this.label2);
            this.pnTaoTaiKhoan2.Location = new System.Drawing.Point(13, 161);
            this.pnTaoTaiKhoan2.Name = "pnTaoTaiKhoan2";
            this.pnTaoTaiKhoan2.Size = new System.Drawing.Size(895, 340);
            this.pnTaoTaiKhoan2.TabIndex = 2;
            this.pnTaoTaiKhoan2.Paint += new System.Windows.Forms.PaintEventHandler(this.pnTaoTaiKhoan2_Paint);
            // 
            // txtUsernameTaoTaiKhoan
            // 
            this.txtUsernameTaoTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsernameTaoTaiKhoan.Location = new System.Drawing.Point(276, 50);
            this.txtUsernameTaoTaiKhoan.Multiline = true;
            this.txtUsernameTaoTaiKhoan.Name = "txtUsernameTaoTaiKhoan";
            this.txtUsernameTaoTaiKhoan.Size = new System.Drawing.Size(286, 28);
            this.txtUsernameTaoTaiKhoan.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(267, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 23);
            this.label7.TabIndex = 13;
            this.label7.Text = "Username";
            // 
            // txtPassTaoTaiKhoan
            // 
            this.txtPassTaoTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassTaoTaiKhoan.Location = new System.Drawing.Point(276, 151);
            this.txtPassTaoTaiKhoan.Multiline = true;
            this.txtPassTaoTaiKhoan.Name = "txtPassTaoTaiKhoan";
            this.txtPassTaoTaiKhoan.Size = new System.Drawing.Size(282, 28);
            this.txtPassTaoTaiKhoan.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(272, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 23);
            this.label6.TabIndex = 11;
            this.label6.Text = "Password";
            // 
            // btnTao
            // 
            this.btnTao.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTao.ForeColor = System.Drawing.Color.Black;
            this.btnTao.Location = new System.Drawing.Point(314, 223);
            this.btnTao.Name = "btnTao";
            this.btnTao.Size = new System.Drawing.Size(212, 70);
            this.btnTao.TabIndex = 9;
            this.btnTao.Text = "Tạo";
            this.btnTao.UseVisualStyleBackColor = true;
            this.btnTao.Click += new System.EventHandler(this.btnTao_Click);
            // 
            // dtpNgayDangKyTaiKhoan
            // 
            this.dtpNgayDangKyTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayDangKyTaiKhoan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayDangKyTaiKhoan.Location = new System.Drawing.Point(564, 151);
            this.dtpNgayDangKyTaiKhoan.Name = "dtpNgayDangKyTaiKhoan";
            this.dtpNgayDangKyTaiKhoan.Size = new System.Drawing.Size(306, 30);
            this.dtpNgayDangKyTaiKhoan.TabIndex = 8;
            // 
            // txtSoDuTaiKhoan
            // 
            this.txtSoDuTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoDuTaiKhoan.Location = new System.Drawing.Point(23, 154);
            this.txtSoDuTaiKhoan.Multiline = true;
            this.txtSoDuTaiKhoan.Name = "txtSoDuTaiKhoan";
            this.txtSoDuTaiKhoan.Size = new System.Drawing.Size(238, 28);
            this.txtSoDuTaiKhoan.TabIndex = 7;
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoDienThoai.Location = new System.Drawing.Point(568, 50);
            this.txtSoDienThoai.Multiline = true;
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(302, 28);
            this.txtSoDienThoai.TabIndex = 6;
            // 
            // txtTenKhachHangTaoTaiKhoan
            // 
            this.txtTenKhachHangTaoTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenKhachHangTaoTaiKhoan.Location = new System.Drawing.Point(23, 50);
            this.txtTenKhachHangTaoTaiKhoan.Multiline = true;
            this.txtTenKhachHangTaoTaiKhoan.Name = "txtTenKhachHangTaoTaiKhoan";
            this.txtTenKhachHangTaoTaiKhoan.Size = new System.Drawing.Size(238, 28);
            this.txtTenKhachHangTaoTaiKhoan.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(564, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ngày đăng ký";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(19, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Số dư tài khoản ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(570, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số điện thoại";
            // 
            // frm_TaoTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 559);
            this.Controls.Add(this.pnTaoTaiKhoan2);
            this.Controls.Add(this.pnTaoTaiKhoan1);
            this.ForeColor = System.Drawing.Color.Red;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_TaoTaiKhoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_TaoTaiKhoan";
            this.Load += new System.EventHandler(this.frm_TaoTaiKhoan_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frm_TaoTaiKhoan_Paint);
            this.pnTaoTaiKhoan1.ResumeLayout(false);
            this.pnTaoTaiKhoan1.PerformLayout();
            this.pnTaoTaiKhoan2.ResumeLayout(false);
            this.pnTaoTaiKhoan2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnTaoTaiKhoan1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTatTaiKhoan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnTaoTaiKhoan2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnTao;
        private System.Windows.Forms.DateTimePicker dtpNgayDangKyTaiKhoan;
        private System.Windows.Forms.TextBox txtSoDuTaiKhoan;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.TextBox txtTenKhachHangTaoTaiKhoan;
        private System.Windows.Forms.TextBox txtPassTaoTaiKhoan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUsernameTaoTaiKhoan;
        private System.Windows.Forms.Label label7;
    }
}