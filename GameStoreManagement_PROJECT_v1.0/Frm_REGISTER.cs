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
using System.Diagnostics;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace GameStoreManagement_PROJECT_v1._0
{
    public partial class Frm_REGISTER : Form
    {
        public Frm_REGISTER()
        {
            InitializeComponent();
        }

        /////////
        /// DATABASE;
        ////////

        // Kết nối đến SQL Server để đưa dữ liệu tài khoản vào DATABASE;
        string chuoiKetNoiSQL = @"Data Source=.\SQLMINHTUAN;Initial Catalog=ROBOTCITYSTADIUM;Integrated Security=True";

        /////////
        /// LOAD FORM REGISTER;
        ////////

        private void Frm_REGISTER_Load(object sender, EventArgs e)
        {
            this.Activate();
            this.Focus();
            // Vô hiệu hóa nút ĐĂNG KÝ lúc ban đầu;
            btn_TAOTK.Enabled = false;
            btn_TAOTK.BackColor = Color.FromArgb(255, 15, 32, 39);
            btn_TAOTK.ForeColor = Color.Gray;

            // Thiết lập đặc tính cho BUTTON;
            btn_EXIT.BackColor = Color.Transparent;
            btn_EXIT.FlatStyle = FlatStyle.Flat;
            btn_EXIT.FlatAppearance.BorderSize = 0;

            // THiết lập đặc tính cho LABEL;
            lb_TAOTK.BackColor = Color.Transparent;
            lb_TERM.BackColor = Color.Transparent;
            lb_POLICY.BackColor = Color.Transparent;

            // THiết lập đặc tính cho GROUPCONTROL;
            grc_REGISTER.BackColor = Color.Transparent;
            grc_VAITRO.BackColor = Color.Transparent;

            // Thiết lập đặc tính cho TEXTBOX;
            txt_MANGUOIDUNG.Focus();
            txt_MATKHAU.PasswordChar = '●';
            txt_XACNHANMK.PasswordChar = '●';
        }

        /////////
        /// LABEL;
        ////////
        private void lb_TAOTK_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, lb_TAOTK.ClientRectangle,
                Color.Transparent, 0, ButtonBorderStyle.None,  // Viền trái;
                Color.Transparent, 0, ButtonBorderStyle.None,  // Viền trên;
                Color.Transparent, 0, ButtonBorderStyle.None,  // Viền phải;
                Color.White, 3, ButtonBorderStyle.Solid // Viền dưới;
            ); 
        }

        /////////
        /// BACKGROUND FORM REGISTER;
        ////////

        private void Frm_REGISTER_Paint(object sender, PaintEventArgs e)
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

        /////////
        /// NÚT THOÁT ỨNG DỤNG;
        ////////

        // Thiệt lập sự kiện và đặc tính cho nút THOÁT ỨNG DỤNG;
        private void btn_EXIT_MouseEnter(object sender, EventArgs e)
        {
            btn_EXIT.Cursor = Cursors.Hand;
            btn_EXIT.BackColor = Color.Transparent;
        }

        private void btn_EXIT_MouseLeave(object sender, EventArgs e)
        {
            btn_EXIT.BackColor = Color.Transparent;
        }
        private void btn_EXIT_Click(object sender, EventArgs e)
        {
            DialogResult thongBao = MessageBox.Show("Bạn chắc chắn không tạo tài khoản nữa?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (thongBao == DialogResult.Yes)
            {
                this.Close();
            }
        }

        /////////
        // TEXTBOX REGISTER;
        /////////
        
        // Thiết lập đặc tính cho các textbox ở FORM ĐĂNG KÝ;
        private void txt_MANGUOIDUNG_BackColorChanged(object sender, EventArgs e)
        {
            txt_MANGUOIDUNG.BackColor = Color.FromArgb(255, 15, 32, 39);
        }

        private void txt_TENDANGNHAP_BackColorChanged(object sender, EventArgs e)
        {
            txt_TENDANGNHAP.BackColor = Color.FromArgb(255, 15, 32, 39);
        }

        private void txt_EMAIL_BackColorChanged(object sender, EventArgs e)
        {
            txt_EMAIL.BackColor = Color.FromArgb(255, 15, 32, 39);
        }

        private void txt_MATKHAU_BackColorChanged(object sender, EventArgs e)
        {
            txt_MATKHAU.BackColor = Color.FromArgb(255, 15, 32, 39);
        }

        private void txt_XACNHANMK_BackColorChanged(object sender, EventArgs e)
        {
            txt_XACNHANMK.BackColor = Color.FromArgb(255, 15, 32, 39);
        }

        /////////
        /// LABEL QUAY LẠI ĐĂNG NHẬP;
        ////////

        // Thiết lập sự kiện khi HOVER vào Label QUAY LẠI ĐĂNG NHẬP;

        private void lb_DACOTAIKHOAN_MouseEnter(object sender, EventArgs e)
        {
            lb_DACOTAIKHOAN.ForeColor = Color.White; // Màu chữ khi HOVER;
            lb_DACOTAIKHOAN.Cursor = Cursors.Hand; // Con trỏ chuột khi HOVER;
        }

        // Thiết lập sự kiện khi RỜI KHỎI Label QUAY LẠI ĐĂNG NHẬP;

        private void lb_DACOTAIKHOAN_MouseLeave(object sender, EventArgs e)
        {
            lb_DACOTAIKHOAN.ForeColor = Color.FromArgb(128, 128, 255); // Màu chữ khi không HOVER;
        }

        // Thiết lập sự kiện khi click vào Label QUAY LẠI ĐĂNG NHẬP;
        private void lb_DACOTAIKHOAN_MouseClick(object sender, MouseEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_MANGUOIDUNG.Text) || !string.IsNullOrEmpty(txt_TENDANGNHAP.Text) ||
                !string.IsNullOrEmpty(txt_EMAIL.Text) || !string.IsNullOrEmpty(txt_MATKHAU.Text) ||
                !string.IsNullOrEmpty(txt_XACNHANMK.Text))
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có dữ đang nhập. Bạn có chắc muốn quay lại đăng nhập?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                    return;
            }
            this.Close();
        }

        /////////
        /// ROBOT CITY SUPPORT;
        ////////
        
        // THiết lập đặc tính khi HOVER;
        private void pb_LOGO_MouseHover(object sender, EventArgs e)
        {
            pb_SUPPORT.Cursor = Cursors.Hand; // Con trỏ chuột khi HOVER;
        }

        // Thiết lập sự kiện khi CLICK vào picturebox ROBOT CITY SUPPORT;
        private void pb_SUPPORT_Click(object sender, EventArgs e)
        {
            string guiDen = "leminhtuank0@gmail.com";
            string tieuDe = Uri.EscapeDataString("ROBOTCITY SUPPORT TICKET - REGISTER");
            string noiDung = Uri.EscapeDataString(
                @"Kính gửi đội ngũ hỗ trợ Robot City Stadium,

                Tôi là: [Họ tên khách hàng]
                Email: [Email liên hệ]
                Số điện thoại: [Số điện thoại liên hệ]
                Mã người dùng (nếu có): [Mã người dùng]

                Tôi gặp phải vấn đề sau:
                [Mô tả chi tiết sự cố: thời gian phát sinh, biểu hiện lỗi, ảnh hưởng, đã thử xử lý như thế nào,…]

                Tôi mong muốn nhận được sự hỗ trợ để:
                [Ví dụ: khắc phục lỗi, đổi sản phẩm, được tư vấn sử dụng,…]

                Đính kèm: [Hình ảnh / video minh họa lỗi (nếu có)]

                Mong nhận được phản hồi từ bộ phận hỗ trợ trong thời gian sớm nhất!

                Trân trọng,
                [Họ tên khách hàng]
                [Ngày gửi email]"
            );

            string gmailLink = $"https://mail.google.com/mail/?view=cm&fs=1&to={guiDen}&su={tieuDe}&body={noiDung}";

            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = gmailLink,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở Gmail. Vui lòng thử lại.\nChi tiết lỗi: " + ex.Message);
            }
        }

        /////////
        /// 2 CHECKBOX: TERM VÀ POLICY;
        ////////

        // Hàm kiểm tra điều kiện CHECKBOX và bật/tắt nút TẠO TÀI KHOẢN;
        private void KiemTraCheckBox()
        {
            if (ckb_TERM.Checked && ckb_POLICY.Checked)
            {
                btn_TAOTK.Enabled = true;
                btn_TAOTK.BackColor = Color.White;
                btn_TAOTK.ForeColor = Color.Black;
            }
            else
            {
                btn_TAOTK.Enabled = false;
                btn_TAOTK.BackColor = Color.FromArgb(255, 15, 32, 39);
                btn_TAOTK.ForeColor = Color.Gray;
            }
        }

        // Thiết lập sự kiện cho 2 CHECKBOX: TERM và POLICY;
        private void ckb_TERM_CheckedChanged(object sender, EventArgs e)
        {
            KiemTraCheckBox();
        }

        private void ckb_POLICY_CheckedChanged(object sender, EventArgs e)
        {
            KiemTraCheckBox();
        }

        // Thiết lập sự kiện cho TERMS OF SERVICE;
        private void lb_TERM_MouseEnter(object sender, EventArgs e)
        {
            lb_TERM.ForeColor = Color.White; // Màu chữ khi HOVER;
            lb_TERM.Cursor = Cursors.Hand; // Con trỏ chuột khi HOVER;
        }

        private void lb_TERM_MouseLeave(object sender, EventArgs e)
        {
            lb_TERM.ForeColor = Color.DodgerBlue; // Màu chữ khi không HOVER;
        }

        private void lb_TERM_MouseClick(object sender, MouseEventArgs e)
        {
            string term = "https://raw.githubusercontent.com/DTU-DevTeam/GAMESTORE-MANAGEMENT-464HIS/minhtuan/GameStoreManagement_PROJECT_v1.0/TermsOfService/TermsOfService.pdf";
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = term,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở file. Lỗi: " + ex.Message);
            }
        }

        // Thiết lập sự kiện cho PRIVACY POLICY;
        private void lb_POLICY_MouseEnter(object sender, EventArgs e)
        {
            lb_POLICY.ForeColor = Color.White; // Màu chữ khi HOVER;
            lb_POLICY.Cursor = Cursors.Hand; // Con trỏ chuột khi HOVER;
        }

        private void lb_POLICY_MouseLeave(object sender, EventArgs e)
        {
            lb_POLICY.ForeColor = Color.DodgerBlue; // Màu chữ khi không HOVER;
        }

        private void lb_POLICY_MouseClick(object sender, MouseEventArgs e)
        {
            string policy = "https://raw.githubusercontent.com/DTU-DevTeam/GAMESTORE-MANAGEMENT-464HIS/minhtuan/GameStoreManagement_PROJECT_v1.0/PrivacyPolicy/PrivacyPolicy.pdf";
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = policy,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở file. Lỗi: " + ex.Message);
            }
        }

        /////////
        /// NÚT ĐĂNG KÝ;
        ////////

        // Thiết lập đặc tính khi HOVER vào nút ĐĂNG KÝ;
        private void btn_TAOTK_MouseEnter(object sender, EventArgs e)
        {
            btn_TAOTK.BackColor = Color.Red; // Màu nền khi HOVER;
            btn_TAOTK.ForeColor = Color.White; // Màu chữ khi HOVER;
            btn_TAOTK.Cursor = Cursors.Hand; // Đổi con trỏ chuột khi HOVER vào nút ĐĂNG NHẬP;
        }

        // Thiết lập đặc tính khi RỜI KHỎI nút ĐĂNG KÝ;
        private void btn_TAOTK_MouseLeave(object sender, EventArgs e)
        {
            btn_TAOTK.BackColor = Color.Azure; // Màu nền khi không HOVER;
            btn_TAOTK.ForeColor = Color.Black; // Màu chữ khi không HOVER;
        }

        // Hàm mã hóa mật khẩu;
        private string MaHoaMatKhau(string password, string salt)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] saltInput = Encoding.Unicode.GetBytes(password + salt);
                byte[] hashInput = sha256.ComputeHash(saltInput);
                return BitConverter.ToString(hashInput).Replace("-", "");
            }
        }

        // THiết lập sự kiện cho nút ĐĂNG KÝ;
        private void btn_TAOTK_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các TextBox;
            string maNguoiDung = txt_MANGUOIDUNG.Text.Trim();
            string tenDangNhap = txt_TENDANGNHAP.Text.Trim();
            string email = txt_EMAIL.Text.Trim();
            string matKhau = txt_MATKHAU.Text.Trim();
            string xacNhanMK = txt_XACNHANMK.Text.Trim();
            string vaiTro = rb_VAITRO.Checked ? "Nhân Viên" : "Admin";
            string ngayTao = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            // Kiểm tra dữ liệu rỗng;
            if (string.IsNullOrEmpty(maNguoiDung) || string.IsNullOrEmpty(tenDangNhap) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(matKhau) || string.IsNullOrEmpty(xacNhanMK))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo Salt ngẫu nhiên;
            string salt = Guid.NewGuid().ToString();

            // Mã hóa mật khẩu;
            string hashPassword = MaHoaMatKhau(matKhau, salt);

            // Kiểm tra mật khẩu và xác nhận mật khẩu;
            if (matKhau != xacNhanMK)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(chuoiKetNoiSQL))
                {
                    conn.Open();

                    // Kiểm tra trùng mã người dùng;
                    string queryMaNguoiDung = $"SELECT COUNT(*) FROM ACCOUNT_STORE WHERE MaTaiKhoan = N'{maNguoiDung}'";
                    SqlCommand cmmCheck = new SqlCommand(queryMaNguoiDung, conn);

                    int dem = (int)cmmCheck.ExecuteScalar();
                    if (dem > 0)
                    {
                        MessageBox.Show("Mã người dùng đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Kiểm tra trùng tên đăng nhập;
                    string queryTenDangNhap = $"SELECT COUNT(*) FROM ACCOUNT_STORE WHERE TenDangNhap = N'{tenDangNhap}'";
                    cmmCheck = new SqlCommand(queryTenDangNhap, conn);
                    dem = (int)cmmCheck.ExecuteScalar();
                    if (dem > 0)
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // INSERT dữ liệu vào DATABASE;
                    string query = $@"
                        INSERT INTO ACCOUNT_STORE (MaTaiKhoan, TenDangNhap, MatKhau, Salt, VaiTro, NgayTao, Email)
                        VALUES (N'{maNguoiDung}', N'{tenDangNhap}', N'{hashPassword}', N'{salt}', N'{vaiTro}', '{ngayTao}', N'{email}')";

                    SqlCommand cmm = new SqlCommand(query, conn);
                    cmm.ExecuteNonQuery();

                    MessageBox.Show("Tạo tài khoản thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clean các trường đã nhập;
                    txt_MANGUOIDUNG.Clear();
                    txt_TENDANGNHAP.Clear();
                    txt_EMAIL.Clear();
                    txt_MATKHAU.Clear();
                    txt_XACNHANMK.Clear();
                    rb_VAITRO.Checked = true;
                    ckb_POLICY.Checked = false;
                    ckb_TERM.Checked = false;
                    txt_MANGUOIDUNG.Focus();

                    // Quay trở lại trang LOGIN nếu ĐĂNG KÝ thành công;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo tài khoản: " + ex.Message);
            }

        }
    }
}
