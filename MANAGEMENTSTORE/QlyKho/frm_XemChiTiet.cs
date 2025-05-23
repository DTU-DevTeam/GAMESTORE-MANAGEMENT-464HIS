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
    public partial class Frm_XemChiTiet : Form
    {
        private LOPDUNGCHUNG lopDungChung = new LOPDUNGCHUNG();

        // Biến lưu tham chiếu tới form Kho để gọi reload dữ liệu khi cần
        private Frm_Kho parentFormKho;

        // Biến lưu mã sản phẩm hiện tại đang xem/sửa
        private string currentMaSanPham;

        // Thiết lập form cha (form Kho)
        public void SetParentForm(Frm_Kho parent)
        {
            parentFormKho = parent;
        }

        public Frm_XemChiTiet()
        {
            InitializeComponent();

            // Áp dụng màu sắc theme cho form và controls
            ApplyThemeColors();
        }

        private void frm_XemChiTiet_Load(object sender, EventArgs e)
        {
            // Có thể thêm code khi form load nếu cần
        }

        /// <summary>
        /// Load dữ liệu chi tiết phiếu nhập kho của sản phẩm lên DataGridView
        /// </summary>
        public void LoadChiTietNhapKho(string maSanPham)
        {
            // Câu truy vấn lấy thông tin chi tiết phiếu nhập và sản phẩm
            string sql = $@"
            SELECT 
                CT.MaPhieuNhap,              -- Mã phiếu nhập để làm key cho update
                CT.MaSanPham AS [Mã],        -- Mã sản phẩm
                CT.SoLuong AS [Số lượng],    -- Số lượng trong chi tiết phiếu nhập
                SP.DonVi AS [Đơn vị],        -- Đơn vị tính
                CT.GiaNhap AS [Giá Nhập],    -- Giá nhập
                PN.NgayNhap AS [Ngày Nhập]   -- Ngày nhập trong phiếu
            FROM 
                CHITIETPHIEUNHAP CT
                INNER JOIN PHIEUNHAP PN ON CT.MaPhieuNhap = PN.MaPhieuNhap
                INNER JOIN SANPHAM SP ON CT.MaSanPham = SP.MaSanPham
            WHERE 
                CT.MaSanPham = N'{maSanPham}'";  // Lọc theo mã sản phẩm truyền vào

            DataTable dt = lopDungChung.LoadDL(sql);

            // Gán dữ liệu vào DataGridView hiển thị chi tiết
            dtvChiTietKhoNhap.DataSource = dt;

            // Định dạng lại cột ngày nhập hiển thị cho dễ nhìn
            dtvChiTietKhoNhap.Columns["Ngày Nhập"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void frm_XemChiTiet_Paint(object sender, PaintEventArgs e)
        {
            // Vẽ nền gradient cho form tạo giao diện đẹp mắt
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
        /// Thiết lập thông tin chi tiết sản phẩm lên các control trên form
        /// </summary>
        public void SetChiTietSanPham(string maSanPham, string tenSanPham, string tonDu, string donVi, string nhomSanPham, string mucBaoHet)
        {
            // Lưu mã sản phẩm để dùng cho các thao tác update sau này
            currentMaSanPham = maSanPham;

            // Gán dữ liệu lên các control trên form để người dùng xem và sửa
            txtSanPhamChiTiet.Text = tenSanPham;
            txtSoLuongChiTiet.Text = tonDu;
            cbDonViChiTiet.Text = donVi;
            cbNhomChiTiet.Text = nhomSanPham;

            // Load dữ liệu chi tiết phiếu nhập cho sản phẩm này
            LoadChiTietNhapKho(maSanPham);
        }

        private void btnTat_Click(object sender, EventArgs e)
        {
            // Đóng form khi người dùng nhấn nút tắt
            this.Close();
        }

        /// <summary>
        /// Áp dụng màu sắc và theme cho form và controls để giao diện đẹp hơn
        /// </summary>
        private void ApplyThemeColors()
        {
            // Màu nền cho 2 panel chính
            panel1.BackColor = Color.FromArgb(230, 240, 250);
            panel2.BackColor = Color.FromArgb(230, 240, 250);

            // Vẽ viền nhẹ cho panel1 (tùy chọn)
            panel1.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, panel1.ClientRectangle,
                    Color.LightGray, 0, ButtonBorderStyle.None,
                    Color.LightGray, 0, ButtonBorderStyle.None,
                    Color.LightGray, 1, ButtonBorderStyle.Solid, // viền dưới
                    Color.LightGray, 0, ButtonBorderStyle.None);
            };

            // Màu chữ tiêu đề nổi bật
            label1.ForeColor = Color.FromArgb(255, 59, 59);
            label1.Font = new Font(label1.Font, FontStyle.Bold | FontStyle.Italic);

            // Cấu hình màu sắc cho DataGridView hiển thị chi tiết
            dtvChiTietKhoNhap.BackgroundColor = Color.White;
            dtvChiTietKhoNhap.ForeColor = Color.Black;
            dtvChiTietKhoNhap.GridColor = Color.Gray;

            // Màu sắc cho các Label, TextBox, ComboBox, DateTimePicker trong panel2
            foreach (Control c in panel2.Controls)
            {
                if (c is Label)
                    c.ForeColor = Color.Black;
                else if (c is TextBox || c is ComboBox || c is DateTimePicker)
                {
                    c.BackColor = Color.White;
                    c.ForeColor = Color.Black;
                }
                else if (c is Button btn)
                {
                    btn.BackColor = Color.FromArgb(255, 59, 59);
                    btn.ForeColor = Color.White;
                }
            }

            // Cấu hình nút tắt có nền xanh đậm, không viền
            btnTat.FlatStyle = FlatStyle.Flat;
            btnTat.FlatAppearance.BorderSize = 0;
        }

        /// <summary>
        /// Xử lý sự kiện khi người dùng nhấn nút "Sửa" để cập nhật số lượng
        /// </summary>
        private void btnSuaChiTiet_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra có chọn dòng trong DataGridView không
                if (dtvChiTietKhoNhap.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn một dòng để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy mã phiếu nhập từ dòng được chọn để xác định bản ghi cập nhật
                string maPhieuNhap = dtvChiTietKhoNhap.CurrentRow.Cells["MaPhieuNhap"]?.Value?.ToString();
                if (string.IsNullOrEmpty(maPhieuNhap))
                {
                    MessageBox.Show("Không lấy được mã phiếu nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lấy số lượng hiện tại trong chi tiết phiếu nhập
                int soLuongChiTietHienTai = Convert.ToInt32(dtvChiTietKhoNhap.CurrentRow.Cells["Số lượng"].Value);

                // Lấy số lượng người dùng nhập để cộng thêm vào tồn kho kho
                if (!int.TryParse(txtSoLuongChiTiet.Text.Trim(), out int soLuongSua))
                {
                    MessageBox.Show("Số lượng nhập không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra số lượng phải lớn hơn 0
                if (soLuongSua <= 0)
                {
                    MessageBox.Show("Số lượng sửa phải lớn hơn 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra số lượng muốn giảm không vượt quá số lượng hiện có trong phiếu nhập
                if (soLuongChiTietHienTai < soLuongSua)
                {
                    MessageBox.Show("Số lượng muốn sửa vượt quá số lượng hiện có trong phiếu nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Cập nhật giảm số lượng trong CHITIETPHIEUNHAP
                string sqlGiamChiTiet = $"UPDATE CHITIETPHIEUNHAP SET SoLuong = SoLuong - {soLuongSua} WHERE MaPhieuNhap = N'{maPhieuNhap}' AND MaSanPham = N'{currentMaSanPham}'";
                lopDungChung.ThemSuaXoa(sqlGiamChiTiet);

                // Cập nhật cộng số lượng tương ứng vào tồn kho trong SANPHAM
                string sqlTangTonKho = $"UPDATE SANPHAM SET TonKho = TonKho + {soLuongSua} WHERE MaSanPham = N'{currentMaSanPham}'";
                lopDungChung.ThemSuaXoa(sqlTangTonKho);

                MessageBox.Show("Cập nhật thành công: Đã cộng số lượng vào kho và giảm số lượng trong phiếu nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Load lại dữ liệu chi tiết trong form XemChiTiet
                LoadChiTietNhapKho(currentMaSanPham);

                // Gọi load lại dữ liệu trên form Kho cha để cập nhật DataGridView
                parentFormKho?.LoadDataToGrid();
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi nếu có ngoại lệ
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
