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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace QLyKhachHang
{
    public partial class frm_ThemGioChoi : Form
    {
        // Biến lưu tham chiếu tới form cha frm_KhachHang
        private frm_KhachHang _parentForm;

        // Constructor nhận tham chiếu form cha để có thể cập nhật dữ liệu khi cần
        public frm_ThemGioChoi(frm_KhachHang parent)
        {
            InitializeComponent();
            SetControlColors();

            _parentForm = parent;

            // Thêm các giá trị số giờ chơi (giả sử tính theo giờ) vào combobox
            cbNhapSoGioChoi.Items.Add("1");
            cbNhapSoGioChoi.Items.Add("2");
            cbNhapSoGioChoi.Items.Add("3");
            cbNhapSoGioChoi.Items.Add("4");
            cbNhapSoGioChoi.Items.Add("5");
            cbNhapSoGioChoi.Items.Add("6");
            cbNhapSoGioChoi.Items.Add("7");
            cbNhapSoGioChoi.Items.Add("8");
            cbNhapSoGioChoi.Items.Add("9");
            cbNhapSoGioChoi.Items.Add("10");
            cbNhapSoGioChoi.SelectedIndex = 0; // Mặc định chọn giá trị đầu tiên (1 giờ)
        }

        // Sự kiện vẽ gradient nền cho form
        private void fmr_ThemGioChoi_Paint(object sender, PaintEventArgs e)
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

        // Sự kiện vẽ gradient nền cho panel chính pnThemGioChoi
        private void pnThemGioChoi_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = pnThemGioChoi.ClientRectangle;
            using (LinearGradientBrush brush = new LinearGradientBrush(rect, ColorTranslator.FromHtml("#203a43"), ColorTranslator.FromHtml("#2c5364"), LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, rect);
            }
        }

        // Thiết lập màu sắc cho các control trên panel
        private void SetControlColors()
        {
            // Duyệt từng control trong panel pnThemGioChoi
            foreach (Control ctl in this.pnThemGioChoi.Controls)
            {
                if (ctl is Label)
                {
                    ctl.ForeColor = Color.White; // chữ màu trắng
                    ctl.BackColor = Color.Transparent; // nền trong suốt
                }
                else if (ctl is TextBox || ctl is DateTimePicker)
                {
                    ctl.BackColor = Color.White; // nền trắng cho textbox, datetimepicker
                    ctl.ForeColor = Color.Black; // chữ màu đen
                }
                else if (ctl is Button btn)
                {
                    // Thiết lập màu và viền cho nút bấm
                    btn.BackColor = Color.White;
                    btn.ForeColor = Color.FromArgb(15, 32, 39);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = Color.FromArgb(15, 32, 39);
                    btn.FlatAppearance.BorderSize = 1;
                }
            }
        }

        // Nút thoát form: hỏi xác nhận rồi đóng form nếu đồng ý
        private void btnTatThemGio_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frm_ThemGioChoi_Load(object sender, EventArgs e)
        {
            // Xử lý khi form load nếu cần
        }

        // Sự kiện nút Lưu để cộng thêm giờ chơi vào thời gian còn lại của khách hàng được chọn
        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra tham chiếu form cha tồn tại
            if (_parentForm == null)
            {
                MessageBox.Show("Không tìm thấy form cha để cập nhật dữ liệu.");
                return;
            }

            // Kiểm tra đã có khách hàng được chọn trong DataGridView của form cha chưa
            if (_parentForm.SelectedCustomerRow == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng trong danh sách.");
                return;
            }

            // Lấy dòng khách hàng được chọn
            var selectedRow = _parentForm.SelectedCustomerRow;

            // Lấy UserName để xác định khách hàng cần cập nhật
            string userName = selectedRow.Cells["UserName"].Value?.ToString();
            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("Không lấy được UserName khách hàng.");
                return;
            }

            // Lấy giá trị thời gian còn lại hiện tại (cột GioChoiConLai)
            string gioConLaiStr = selectedRow.Cells["GioChoiConLai"].Value?.ToString();
            double gioConLai = 0;
            double.TryParse(gioConLaiStr, out gioConLai);

            // Lấy số giờ muốn cộng thêm từ ComboBox
            if (cbNhapSoGioChoi.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn thời gian muốn thêm.");
                return;
            }
            double themGio = 0;
            if (!double.TryParse(cbNhapSoGioChoi.SelectedItem.ToString(), out themGio))
            {
                MessageBox.Show("Giá trị thời gian không hợp lệ.");
                return;
            }

            // Tính giờ mới sau khi cộng thêm
            double gioMoi = gioConLai + themGio;

            // Khởi tạo lớp dùng chung để thao tác với CSDL
            LOPDUNGCHUNG lopDungChung = new LOPDUNGCHUNG();

            // Câu truy vấn cập nhật thời gian chơi còn lại của khách hàng dựa trên UserName
            string sqlUpdate = $@"
                UPDATE KHACHHANG 
                SET GioChoiConLai = {gioMoi}
                WHERE UserID = (SELECT UserID FROM USERS WHERE UserName = '{userName}')";

            // Thực hiện cập nhật
            int ketQua = lopDungChung.ThemSuaXoa(sqlUpdate);

            if (ketQua > 0)
            {
                MessageBox.Show("Cập nhật thời gian chơi thành công!");

                // Gọi lại hàm LoadDataGridView() trên form cha để làm mới dữ liệu hiển thị
                _parentForm.LoadDataGridView();

                // Đóng form này sau khi cập nhật xong
                this.Close();
            }
            else
            {
                MessageBox.Show("Cập nhật thời gian chơi thất bại!");
            }
        }
    }
}
