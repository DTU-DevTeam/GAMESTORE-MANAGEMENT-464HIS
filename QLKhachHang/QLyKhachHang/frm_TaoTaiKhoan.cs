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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace QLyKhachHang
{
    public partial class frm_TaoTaiKhoan : Form
    {
        // Biến lưu tham chiếu tới form cha frm_KhachHang để gọi reload dữ liệu sau khi tạo tài khoản
        private frm_KhachHang _parentForm;

        // Constructor, nhận tham chiếu form cha
        public frm_TaoTaiKhoan(frm_KhachHang parent)
        {
            InitializeComponent();

            // Thiết lập màu sắc cho các control trên form
            SetControlColors();

            _parentForm = parent; // lưu tham chiếu
        }

        // Sự kiện Paint vẽ gradient nền cho form
        private void frm_TaoTaiKhoan_Paint(object sender, PaintEventArgs e)
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

        // Sự kiện Paint vẽ gradient nền cho panel pnTaoTaiKhoan1
        private void pnTaoTaiKhoan1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = pnTaoTaiKhoan1.ClientRectangle;
            using (LinearGradientBrush brush = new LinearGradientBrush(rect, ColorTranslator.FromHtml("#203a43"), ColorTranslator.FromHtml("#2c5364"), LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, rect);
            }
        }

        // Sự kiện Paint vẽ gradient nền cho panel pnTaoTaiKhoan2
        private void pnTaoTaiKhoan2_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = pnTaoTaiKhoan2.ClientRectangle;
            using (LinearGradientBrush brush = new LinearGradientBrush(rect, ColorTranslator.FromHtml("#203a43"), ColorTranslator.FromHtml("#2c5364"), LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, rect);
            }
        }

        // Hàm thiết lập màu sắc cho các control trên 2 panel
        private void SetControlColors()
        {
            // Lặp qua tất cả control trong pnTaoTaiKhoan1
            foreach (Control ctl in this.pnTaoTaiKhoan1.Controls)
            {
                if (ctl is Label)
                {
                    ctl.ForeColor = Color.White;           // Chữ màu trắng
                    ctl.BackColor = Color.Transparent;    // Nền trong suốt
                }
                else if (ctl is TextBox || ctl is DateTimePicker)
                {
                    ctl.BackColor = Color.White;           // Nền trắng cho textbox, datetimepicker
                    ctl.ForeColor = Color.Black;            // Chữ màu đen
                }
                else if (ctl is Button btn)
                {
                    // Thiết lập màu sắc, viền cho nút
                    btn.BackColor = Color.White;
                    btn.ForeColor = Color.FromArgb(15, 32, 39);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = Color.FromArgb(15, 32, 39);
                    btn.FlatAppearance.BorderSize = 1;
                }
            }

            // Lặp lại cho pnTaoTaiKhoan2
            foreach (Control ctl in this.pnTaoTaiKhoan2.Controls)
            {
                if (ctl is Label)
                {
                    ctl.ForeColor = Color.White;
                    ctl.BackColor = Color.Transparent;
                }
                else if (ctl is TextBox || ctl is DateTimePicker)
                {
                    ctl.BackColor = Color.White;
                    ctl.ForeColor = Color.Black;
                }
                else if (ctl is Button btn)
                {
                    btn.BackColor = Color.White;
                    btn.ForeColor = Color.FromArgb(15, 32, 39);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = Color.FromArgb(15, 32, 39);
                    btn.FlatAppearance.BorderSize = 1;
                }
            }
        }

        // Nút thoát form: hỏi xác nhận trước khi đóng
        private void btnTatTaotaiKhoan_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frm_TaoTaiKhoan_Load(object sender, EventArgs e)
        {
            // Có thể thêm xử lý khi form load nếu cần
        }

        // Nút Tạo tài khoản mới
        private void btnTao_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ các control nhập liệu
                string userName = txtUsernameTaoTaiKhoan.Text.Trim();
                string password = txtPassTaoTaiKhoan.Text.Trim();
                string tenKH = txtTenKhachHangTaoTaiKhoan.Text.Trim();
                string soDienThoai = txtSoDienThoai.Text.Trim();
                string soDuTaiKhoan = txtSoDuTaiKhoan.Text.Trim();
                string ngayDangKy = dtpNgayDangKyTaiKhoan.Value.ToString("yyyy-MM-dd");

                // Kiểm tra dữ liệu bắt buộc (userName, password, tenKH) không được để trống
                if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(tenKH))
                {
                    MessageBox.Show("UserName, Password và Tên khách hàng không được để trống");
                    return;
                }

                LOPDUNGCHUNG lopDungChung = new LOPDUNGCHUNG();

                // Kiểm tra userName đã tồn tại trong database chưa
                string checkUserSql = $"SELECT COUNT(*) FROM USERS WHERE UserName = '{userName}'";
                int count = Convert.ToInt32(lopDungChung.LayDuLieu(checkUserSql));
                if (count > 0)
                {
                    MessageBox.Show("UserName đã tồn tại, vui lòng chọn tên khác");
                    return;
                }

                // Thêm bản ghi USERS mới với userName và password
                string sqlUser = $"INSERT INTO USERS (UserName, Password) VALUES ('{userName}', '{password}')";
                int rsUser = lopDungChung.ThemSuaXoa(sqlUser);

                if (rsUser > 0)
                {
                    // Lấy UserID mới được tạo ra
                    object userIDObj = lopDungChung.LayDuLieu($"SELECT UserID FROM USERS WHERE UserName = '{userName}'");
                    if (userIDObj != null)
                    {
                        int userID = Convert.ToInt32(userIDObj);

                        // Thêm bản ghi KHACHHANG tương ứng với UserID vừa lấy được
                        string sqlKH = $@"
                            INSERT INTO KHACHHANG (UserID, TenKhachHang, SoDienThoai, SoDuTaiKhoan, NgayDangKy)
                            VALUES ({userID}, N'{tenKH}', '{soDienThoai}', '{soDuTaiKhoan}', '{ngayDangKy}')";

                        int rsKH = lopDungChung.ThemSuaXoa(sqlKH);

                        if (rsKH > 0)
                        {
                            MessageBox.Show("Tạo tài khoản thành công!");

                            // Gọi lại LoadDataGridView của form cha để cập nhật danh sách khách hàng
                            _parentForm?.LoadDataGridView();

                            // Đóng form tạo tài khoản
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Lỗi thêm thông tin khách hàng");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lỗi lấy UserID mới tạo");
                    }
                }
                else
                {
                    MessageBox.Show("Tạo user thất bại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
