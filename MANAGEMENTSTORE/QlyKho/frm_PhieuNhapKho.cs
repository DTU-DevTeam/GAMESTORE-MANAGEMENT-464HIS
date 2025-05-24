using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlyKho
{
    public partial class frm_PhieuNhapMoi: Form
    {
        LOPDUNGCHUNG lopDungChung = new LOPDUNGCHUNG();
        public frm_PhieuNhapMoi()
        {
            InitializeComponent();
            //Thiết lập 2 comboBox ko cho phép nhập 
            cbDonVi.DropDownStyle = ComboBoxStyle.DropDownList;
            cbNhom.DropDownStyle = ComboBoxStyle.DropDownList;
            
            ApplyThemeColors(); //Áp dụng màu sắc cho form và controls
            LoadDonViToComboBox();  //Load dữ liệu đơn vị vào ComboBox
            LoadNhomSanPhamToComboBox();    //Load dữ liệu nhóm sản phẩm vào comboBox
        }
       
        
        private void frm_PhieuNhapMoi_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Vẽ nền gradient cho form (màu sắc chuyển dần từ trên xuống dưới)
        /// </summary>
        private void frm_PhieuNhapMoi_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = this.ClientRectangle;
            using (LinearGradientBrush brush = new LinearGradientBrush(rect, Color.Empty, Color.Empty, LinearGradientMode.Vertical))
            {
                ColorBlend colorBlend = new ColorBlend();
                colorBlend.Colors = new Color[]
                {
                    ColorTranslator.FromHtml("#0f2027"),
                    ColorTranslator.FromHtml("#203a43"),
                    ColorTranslator.FromHtml("#2c5364")
                };
                colorBlend.Positions = new float[] { 0f, 0.5f, 1f };

                brush.InterpolationColors = colorBlend;
                e.Graphics.FillRectangle(brush, rect);
            }
        }
        /// <summary>
        /// Xử lý sự kiện nhấn nút "Nhập"
        /// </summary>
        private void btnNhap_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu người dùng nhập từ các textbox và combobox
                string maPhieuNhap = txtMaNhap.Text.Trim();
                string maSanPham = txtMaNhap.Text.Trim();  // Hiện chưa có control riêng mã sản phẩm nên tạm dùng mã phiếu nhập
                string tenSanPham = txtTenSanPham.Text.Trim();
                string nhomSanPham = cbNhom.SelectedItem?.ToString() ?? "";
                string donVi = cbDonVi.SelectedItem?.ToString() ?? "";
                int soLuong = int.Parse(txtSoLuong.Text.Trim());
                int mucBaoHet = int.Parse(txtMucBaoHet.Text.Trim());
                decimal giaNhap = decimal.Parse(txtGiaNhap.Text.Trim());
                DateTime ngayNhap = dtpNgayNhap.Value;
                string nguonNhap = txtNguonNhap.Text.Trim();
                string lienLac = txtLienLac.Text.Trim();

                // 1. Kiểm tra phiếu nhập đã tồn tại chưa
                string sqlCheckPhieu = $"SELECT COUNT(*) FROM PHIEUNHAP WHERE MaPhieuNhap = N'{maPhieuNhap}'";
                int countPhieu = (int)lopDungChung.LayDuLieu(sqlCheckPhieu);
                if (countPhieu == 0)
                {
                    // Nếu chưa có thì thêm mới phiếu nhập
                    string sqlInsertPhieu = $"INSERT INTO PHIEUNHAP (MaPhieuNhap, NgayNhap, NguonNhap, LienLac) " +
                                            $"VALUES (N'{maPhieuNhap}', '{ngayNhap:yyyy-MM-dd}', N'{nguonNhap}', '{lienLac}')";
                    lopDungChung.ThemSuaXoa(sqlInsertPhieu);
                }

                // 2. Kiểm tra sản phẩm đã tồn tại chưa
                string sqlCheckSP = $"SELECT COUNT(*) FROM SANPHAM WHERE MaSanPham = N'{maSanPham}'";
                int countSP = (int)lopDungChung.LayDuLieu(sqlCheckSP);
                if (countSP == 0)
                {
                    // Thêm sản phẩm mới
                    string sqlInsertSP = $"INSERT INTO SANPHAM (MaSanPham, TenSanPham, NhomSanPham, DonVi, TonKho, MucBaoHet) " +
                                         $"VALUES (N'{maSanPham}', N'{tenSanPham}', N'{nhomSanPham}', N'{donVi}', 0, {mucBaoHet})";
                    lopDungChung.ThemSuaXoa(sqlInsertSP);
                }

                // 3. Thêm chi tiết phiếu nhập
                string sqlInsertChiTiet = $"INSERT INTO CHITIETPHIEUNHAP (MaPhieuNhap, MaSanPham, SoLuong, GiaNhap) " +
                                          $"VALUES (N'{maPhieuNhap}', N'{maSanPham}', {soLuong}, {giaNhap})";
                lopDungChung.ThemSuaXoa(sqlInsertChiTiet);

                // 4. Cập nhật tồn kho trong SANPHAM
                string sqlUpdateTonKho = $"UPDATE SANPHAM SET TonKho = TonKho + {soLuong} WHERE MaSanPham = N'{maSanPham}'";
                lopDungChung.ThemSuaXoa(sqlUpdateTonKho);

                MessageBox.Show("Nhập kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close(); // Đóng form nhập
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        /// <summary>
        /// Load dữ liệu danh sách đơn vị duy nhất vào ComboBox cbDonVi
        /// </summary>
        private void LoadDonViToComboBox()
        {
            string sql = "SELECT DISTINCT DonVi FROM SANPHAM";
            DataTable dt = lopDungChung.LoadDL(sql);

            cbDonVi.Items.Clear();
            cbDonVi.Items.Add("Chọn");  // Thêm mục mặc định để người dùng biết phải chọn
            foreach (DataRow row in dt.Rows)
            {
                cbDonVi.Items.Add(row["DonVi"].ToString());
            }
            cbDonVi.SelectedIndex = 0;  // Chọn mục mặc định "Chọn"
        }

        /// <summary>
        /// Load dữ liệu danh sách nhóm sản phẩm duy nhất vào ComboBox cbNhom
        /// </summary>
        private void LoadNhomSanPhamToComboBox()
        {
            string sql = "SELECT DISTINCT NhomSanPham FROM SANPHAM";
            DataTable dt = lopDungChung.LoadDL(sql);

            cbNhom.Items.Clear();
            cbNhom.Items.Add("Chọn"); // Thêm mục mặc định để người dùng biết phải chọn
            foreach (DataRow row in dt.Rows)
            {
                cbNhom.Items.Add(row["NhomSanPham"].ToString());
            }
            cbNhom.SelectedIndex = 0; // Chọn mục mặc định "Chọn"
        }

        /// <summary>
        /// Áp dụng màu sắc giao diện cho form và các control bên trong
        /// </summary>
        private void ApplyThemeColors()
        {
            // Màu nền cho panel1 và panel2
            panel1.BackColor = Color.FromArgb(230, 240, 250);
            panel2.BackColor = Color.FromArgb(230, 240, 250);

            // Viền nhẹ cho panel1 (tùy chọn)
            panel1.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, panel1.ClientRectangle,
                    Color.LightGray, 0, ButtonBorderStyle.None,
                    Color.LightGray, 0, ButtonBorderStyle.None,
                    Color.LightGray, 1, ButtonBorderStyle.Solid, // viền dưới
                    Color.LightGray, 0, ButtonBorderStyle.None);
            };

            // Tiêu đề màu đỏ nổi bật
            label1.ForeColor = Color.FromArgb(255, 59, 59);
            label1.Font = new Font(label1.Font, FontStyle.Bold | FontStyle.Italic);

            // Các label khác trong panel2 màu đen
            foreach (Control c in panel2.Controls)
            {
                if (c is Label)
                    c.ForeColor = Color.Black;
                else if (c is TextBox || c is ComboBox || c is DateTimePicker)
                {
                    c.BackColor = Color.White;
                    c.ForeColor = Color.Black;
                }
            }
            // Nút nhập màu đỏ nổi bật
            btnNhap.BackColor = Color.FromArgb(255, 59, 59);
            btnNhap.ForeColor = Color.White;


            // Nút tắt nền xanh đậm, không viền
            btnTat.FlatStyle = FlatStyle.Flat;
            btnTat.FlatAppearance.BorderSize = 0;
            
        }

        private void btnTat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void cbNhom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNhom.SelectedItem.ToString() == "Chọn")
            {
                // Không làm gì hoặc reset dữ liệu nhập
                return;
            }
        }
    }
}
