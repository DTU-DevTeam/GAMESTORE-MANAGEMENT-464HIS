namespace QLyKhachHang
{
    partial class frm_ThemGioChoi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ThemGioChoi));
            this.pnThemGioChoi = new System.Windows.Forms.Panel();
            this.btnTatThemGio = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.cbNhapSoGioChoi = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnThemGioChoi.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnThemGioChoi
            // 
            this.pnThemGioChoi.BackColor = System.Drawing.Color.White;
            this.pnThemGioChoi.Controls.Add(this.btnTatThemGio);
            this.pnThemGioChoi.Controls.Add(this.btnLuu);
            this.pnThemGioChoi.Controls.Add(this.cbNhapSoGioChoi);
            this.pnThemGioChoi.Controls.Add(this.label1);
            this.pnThemGioChoi.Location = new System.Drawing.Point(28, 21);
            this.pnThemGioChoi.Name = "pnThemGioChoi";
            this.pnThemGioChoi.Size = new System.Drawing.Size(489, 252);
            this.pnThemGioChoi.TabIndex = 0;
            this.pnThemGioChoi.Paint += new System.Windows.Forms.PaintEventHandler(this.pnThemGioChoi_Paint);
            // 
            // btnTatThemGio
            // 
            this.btnTatThemGio.Image = ((System.Drawing.Image)(resources.GetObject("btnTatThemGio.Image")));
            this.btnTatThemGio.Location = new System.Drawing.Point(422, 19);
            this.btnTatThemGio.Name = "btnTatThemGio";
            this.btnTatThemGio.Size = new System.Drawing.Size(34, 27);
            this.btnTatThemGio.TabIndex = 4;
            this.btnTatThemGio.UseVisualStyleBackColor = true;
            this.btnTatThemGio.Click += new System.EventHandler(this.btnTatThemGio_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Location = new System.Drawing.Point(153, 160);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(133, 49);
            this.btnLuu.TabIndex = 2;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // cbNhapSoGioChoi
            // 
            this.cbNhapSoGioChoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNhapSoGioChoi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNhapSoGioChoi.FormattingEnabled = true;
            this.cbNhapSoGioChoi.Location = new System.Drawing.Point(87, 89);
            this.cbNhapSoGioChoi.Name = "cbNhapSoGioChoi";
            this.cbNhapSoGioChoi.Size = new System.Drawing.Size(288, 36);
            this.cbNhapSoGioChoi.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(148, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập số giờ chơi";
            // 
            // frm_ThemGioChoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 303);
            this.Controls.Add(this.pnThemGioChoi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_ThemGioChoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fmr_ThemGioChoi";
            this.Load += new System.EventHandler(this.frm_ThemGioChoi_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.fmr_ThemGioChoi_Paint);
            this.pnThemGioChoi.ResumeLayout(false);
            this.pnThemGioChoi.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnThemGioChoi;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.ComboBox cbNhapSoGioChoi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTatThemGio;
    }
}