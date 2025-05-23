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

namespace QLyKhachHang
{
    public partial class frm_KhachHang : Form
    {
        // Khai báo đối tượng lớp dùng chung để thực hiện truy vấn SQL
        LOPDUNGCHUNG lopDungChung = new LOPDUNGCHUNG();

        // Constructor form
        public frm_KhachHang()
        {
            InitializeComponent();

            // Thiết lập màu sắc cho các control trên form
            SetControlColors();

            // Tải dữ liệu khách hàng lên DataGridView khi form khởi tạo
            LoadDataGridView();
        }

        // Sự kiện load form (có thể dùng để thiết lập giao diện)
        private void frm_KhachHang_Load(object sender, EventArgs e)
        {
            // Đặt nền pictureBox1 trong suốt
            pictureBox1.BackColor = Color.Transparent;
        }

        // Hàm tải dữ liệu khách hàng lên DataGridView
        public void LoadDataGridView()
        {
            try
            {
                // Câu truy vấn lấy thông tin khách hàng và user tương ứng
                string sql = @"
                    SELECT 
                        KH.TenKhachHang,
                        U.UserName,
                        U.Password,
                        KH.SoDienThoai,
                        KH.SoDuTaiKhoan,
                        KH.GioChoiConLai,
                        KH.NgayDangKy
                    FROM 
                        KHACHHANG KH
                    INNER JOIN 
                        USERS U ON KH.UserID = U.UserID";

                // Thực thi câu truy vấn và lấy về DataTable
                DataTable dt = lopDungChung.LoadDL(sql);

                // Gán dữ liệu vào DataGridView
                dtvKhachHang.DataSource = dt;

                // Đặt lại tiêu đề các cột cho dễ hiểu
                dtvKhachHang.Columns["TenKhachHang"].HeaderText = "Tên Khách Hàng";
                dtvKhachHang.Columns["UserName"].HeaderText = "User";
                dtvKhachHang.Columns["Password"].HeaderText = "Mật Khẩu";
                dtvKhachHang.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
                dtvKhachHang.Columns["SoDuTaiKhoan"].HeaderText = "Số Dư Tài Khoản";
                dtvKhachHang.Columns["GioChoiConLai"].HeaderText = "Thời Gian Còn Lại";
                dtvKhachHang.Columns["NgayDangKy"].HeaderText = "Ngày Đăng Ký";

                // Chống người dùng sửa trực tiếp trên DataGridView
                dtvKhachHang.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        // Sự kiện vẽ gradient nền cho form chính
        private void frm_KhachHang_Paint(object sender, PaintEventArgs e)
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

        // Sự kiện vẽ gradient nền cho panel pnKhachHang1
        private void pnKhachHang1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = pnKhachHang1.ClientRectangle;
            using (LinearGradientBrush brush = new LinearGradientBrush(rect, ColorTranslator.FromHtml("#203a43"), ColorTranslator.FromHtml("#2c5364"), LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, rect);
            }
        }

        // Sự kiện vẽ gradient nền cho panel pnKhachHang2
        private void pnKhachHang2_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = pnKhachHang2.ClientRectangle;
            using (LinearGradientBrush brush = new LinearGradientBrush(rect, ColorTranslator.FromHtml("#203a43"), ColorTranslator.FromHtml("#2c5364"), LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, rect);
            }
        }

        // Thiết lập màu sắc cho các control trên 2 panel
        private void SetControlColors()
        {
            // Duyệt qua từng control trong panel 1
            foreach (Control ctl in this.pnKhachHang1.Controls)
            {
                if (ctl is Label)
                {
                    ctl.ForeColor = Color.White; // chữ màu trắng
                    ctl.BackColor = Color.Transparent; // nền trong suốt
                }
                else if (ctl is TextBox || ctl is DateTimePicker)
                {
                    ctl.BackColor = Color.White;
                    ctl.ForeColor = Color.Black;
                }
                else if (ctl is Button btn)
                {
                    // Thiết lập màu nút và viền
                    btn.BackColor = Color.White;
                    btn.ForeColor = Color.FromArgb(15, 32, 39);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = Color.FromArgb(15, 32, 39);
                    btn.FlatAppearance.BorderSize = 1;
                }
            }
            // Lặp lại cho panel 2
            foreach (Control ctl in this.pnKhachHang2.Controls)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện khi click vào pictureBox1 (hiện chưa có)
        }

        // Khi người dùng click vào 1 dòng trên DataGridView, hiện dữ liệu lên các textbox
        private void dtvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // tránh click header
            {
                DataGridViewRow row = dtvKhachHang.Rows[e.RowIndex];

                // Hiển thị dữ liệu khách hàng lên các textbox và datetimepicker
                txtTenKhachHang.Text = row.Cells["TenKhachHang"].Value?.ToString();
                txtUserKhachHang.Text = row.Cells["UserName"].Value?.ToString();
                txtPasswordKhachHang.Text = row.Cells["Password"].Value?.ToString();
                txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value?.ToString();
                txtSoDuTaiKhoan.Text = row.Cells["SoDuTaiKhoan"].Value?.ToString();

                if (DateTime.TryParse(row.Cells["NgayDangKy"].Value?.ToString(), out DateTime ngayDK))
                {
                    dtpNgayDangKy.Value = ngayDK;
                }
            }
        }

        // Sự kiện nút Thoát: hỏi xác nhận rồi đóng form nếu đồng ý
        private void btnTat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // Sự kiện nút Sửa: cập nhật dữ liệu khách hàng lên CSDL
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ các control
                string tenKhachHang = txtTenKhachHang.Text.Trim();
                string userName = txtUserKhachHang.Text.Trim();
                string password = txtPasswordKhachHang.Text.Trim();
                string soDienThoai = txtSoDienThoai.Text.Trim();
                string soDuTaiKhoan = txtSoDuTaiKhoan.Text.Trim();
                string ngayDangKy = dtpNgayDangKy.Value.ToString("yyyy-MM-dd");

                // Câu lệnh UPDATE bảng KHACHHANG dựa vào UserName
                string sqlUpdateKH = $@"
                    UPDATE KHACHHANG 
                    SET TenKhachHang = N'{tenKhachHang}', 
                        SoDienThoai = '{soDienThoai}', 
                        SoDuTaiKhoan = '{soDuTaiKhoan}', 
                        NgayDangKy = '{ngayDangKy}'
                    WHERE UserID = (SELECT UserID FROM USERS WHERE UserName = '{userName}')";

                // Câu lệnh UPDATE bảng USERS (đổi password)
                string sqlUpdateUser = $@"
                    UPDATE USERS 
                    SET Password = N'{password}'
                    WHERE UserName = N'{userName}'";

                // Thực thi cập nhật dữ liệu
                int kq1 = lopDungChung.ThemSuaXoa(sqlUpdateKH);
                int kq2 = lopDungChung.ThemSuaXoa(sqlUpdateUser);

                if (kq1 > 0 && kq2 > 0)
                {
                    MessageBox.Show("Sửa thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataGridView(); // Cập nhật lại DataGridView
                }
                else
                {
                    MessageBox.Show("Sửa thông tin khách hàng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Mở form tạo tài khoản mới, truyền tham chiếu form này để khi tạo xong reload DataGridView
        private void btnTaoTaiKhoan_Click(object sender, EventArgs e)
        {
            frm_TaoTaiKhoan frm = new frm_TaoTaiKhoan(this);
            frm.ShowDialog();
        }

        // Mở form thêm giờ chơi, truyền tham chiếu form này để cập nhật lại khi thêm giờ xong
        private void btnThemGioChoi_Click(object sender, EventArgs e)
        {
            frm_ThemGioChoi frm = new frm_ThemGioChoi(this);
            frm.ShowDialog();
        }

        // Property public giúp form con truy cập được dòng đang chọn trên DataGridView
        public DataGridViewRow SelectedCustomerRow
        {
            get
            {
                return dtvKhachHang.CurrentRow;
            }
        }

        // Sự kiện nút Xóa khách hàng
        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra có dòng nào được chọn không
            if (dtvKhachHang.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa.");
                return;
            }

            DataGridViewRow selectedRow = dtvKhachHang.CurrentRow;
            string userName = selectedRow.Cells["UserName"].Value?.ToString();

            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("Không lấy được UserName khách hàng để xóa.");
                return;
            }

            // Xác nhận xóa với người dùng
            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa khách hàng '{userName}' không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    LOPDUNGCHUNG lopDungChung = new LOPDUNGCHUNG();

                    // Xóa bản ghi trong bảng KHACHHANG theo UserID lấy từ USERS
                    string sqlXoaKH = $@"
                        DELETE FROM KHACHHANG 
                        WHERE UserID = (SELECT UserID FROM USERS WHERE UserName = '{userName}')";

                    // Xóa bản ghi trong bảng USERS sau khi đã xóa KHACHHANG để tránh lỗi FK
                    string sqlXoaUser = $"DELETE FROM USERS WHERE UserName = '{userName}'";

                    int kqKH = lopDungChung.ThemSuaXoa(sqlXoaKH);
                    int kqUser = lopDungChung.ThemSuaXoa(sqlXoaUser);

                    if (kqKH > 0 && kqUser > 0)
                    {
                        MessageBox.Show("Xóa khách hàng thành công.");
                        LoadDataGridView(); // Tải lại dữ liệu
                    }
                    else
                    {
                        MessageBox.Show("Xóa khách hàng thất bại.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa khách hàng: " + ex.Message);
                }
            }
        }
    }
}
