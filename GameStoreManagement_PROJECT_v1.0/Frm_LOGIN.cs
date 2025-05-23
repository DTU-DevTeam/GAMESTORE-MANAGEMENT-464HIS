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
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Diagnostics;

namespace GameStoreManagement_PROJECT_v1._0
{
    public partial class Frm_LOGIN : Form
    {

        // Lưu vai trò của người dùng hiện tại;
        private static string vaiTroHienTai = null;
        // Theo dõi trạng thái đăng nhập;
        private static bool daDangNhap = false;

        public Frm_LOGIN()
        {
            InitializeComponent();
            this.FormClosing += Frm_LOGIN_FormClosing;
        }

        /////////
        /// DATABASE;
        ////////

        // Kết nối đến SQL Server để lấy dữ liệu tài khoản;
        string chuoiKetNoiSQL = @"Data Source=.\SQLMINHTUAN;Initial Catalog=ROBOTCITYSTADIUM;Integrated Security=True";

        /////////
        /// LOAD FORM LOGIN;
        ////////

        private void Frm_LOGIN_Load(object sender, EventArgs e)
        {
            this.Activate();
            this.Focus();

            // Đặt lại trạng thái đăng nhập khi form tải;
            daDangNhap = false;

            // Thiết lập các đặc tính cho LABEL;
            lb_STORENAME.BackColor = Color.Transparent;
            lb_DIACHI.BackColor = Color.Transparent;

            // Thiết lập các đặc tính cho TEXTBOX;
            txt_TENDANGNHAP.Focus();
            txt_MATKHAU.PasswordChar = '●';


            // Thiết lập các đặc tính cho BUTTON;
            btn_EXIT.BackColor = Color.Transparent;
            btn_EXIT.FlatStyle = FlatStyle.Flat;
            btn_EXIT.FlatAppearance.BorderSize = 0;
            
            // Thiết lập các đặc tính cho PICTUREBOX;
            pb_MATKHAU.BackColor = Color.Transparent;
            pb_TENDANGNHAP.BackColor = Color.Transparent;
            pb_SUPPORT.BackColor = Color.Transparent;

            // Thiết lập các đặt tính cho GROUPCONTROL;
            grc_LOGIN.BackColor = Color.Transparent;

            // Kiểm tra trạng thái Capslock;
            kiemTraCapslock();

            // Lấy và tải dữ liệu đã lưu vào TÊN ĐĂNG NHẬP nếu REMEMBER ME được bật;
            if (Properties.Settings.Default.RememberMe)
            {
                txt_TENDANGNHAP.Text = Properties.Settings.Default.LuuTenDangNhap;
                tgs_REMEMBER.IsOn = true;
            }
            else
            {
                txt_TENDANGNHAP.Text = "";
                tgs_REMEMBER.IsOn = false;
            }
        }

        /////////
        /// FormCLosing FORM LOGIN;
        ////////
        
        private void Frm_LOGIN_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!tgs_REMEMBER.IsOn)
            {
                Properties.Settings.Default.LuuTenDangNhap = "";
                Properties.Settings.Default.RememberMe = false;
                Properties.Settings.Default.Save();
            }
        }

        /////////
        /// BACKGROUND FORM LOGIN;
        ////////

        // Thiết lập màu nền Gradient cho Frm_LOGIN();
        private void Frm_LOGIN_Paint(object sender, PaintEventArgs e)
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

        // Thiết lập sự kiện và đặc tính cho nút THOÁT ỨNG DỤNG;
        private void btn_EXIT_MouseEnter(object sender, EventArgs e)
        {
            btn_EXIT.Cursor = Cursors.Hand;
        }

        private void btn_EXIT_MouseLeave(object sender, EventArgs e)
        {
            btn_EXIT.BackColor = Color.Transparent;
        }

        private void btn_EXIT_Click(object sender, EventArgs e)
        {
            DialogResult thongBao = MessageBox.Show("Bạn chắc chắn muốn đóng ứng dụng?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (thongBao == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        /////////
        /// HÀM KIỂM TRA HOẠT ĐỘNG CỦA NÚT CAPSLOCK;
        ////////
        private void kiemTraCapslock()
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                MessageBox.Show("Caps Lock is ON", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /////////
        /// NÚT ĐĂNG NHẬP;
        ////////

        // Thiết lập hiệu ứng khi chuột HOVER ở nút ĐĂNG NHẬP;
        private void btn_DANGNHAP_MouseEnter(object sender, EventArgs e)
        {
            btn_DANGNHAP.BackColor = Color.Red; // Màu nền khi HOVER;
            btn_DANGNHAP.ForeColor = Color.White; // Màu chữ khi HOVER;
            btn_DANGNHAP.Cursor = Cursors.Hand; // Đổi con trỏ chuột khi HOVER vào nút ĐĂNG NHẬP;
        }

        // Thiết lập hiệu ứng khi chuột RỜI KHỎI nút ĐĂNG NHẬP;
        private void btn_DANGNHAP_MouseLeave(object sender, EventArgs e)
        {
            btn_DANGNHAP.BackColor = Color.Azure; // Màu nền khi không HOVER;
            btn_DANGNHAP.ForeColor = Color.Black; // Màu chữ khi không HOVER;
        }

        // Thiết lập nút ENTER là nút default cho nút ĐĂNG NHẬP;

        private void btn_DANGNHAP_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = btn_DANGNHAP;
        }

        // Xử lý mật khẩu đã được mã hóa (SHA-256);
        private string maHoaMKSH(string password, string salt)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.Unicode.GetBytes(password + salt);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "");
            }
        }

        // Thiết lập sự kiện khi click vào nút ĐĂNG NHẬP;
        private void btn_DANGNHAP_MouseClick(object sender, MouseEventArgs e)
        {
            // Khởi tạo TÊN ĐĂNG NHẬP và MẬT KHẨU;
            string username = txt_TENDANGNHAP.Text.Trim();
            string password = txt_MATKHAU.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Tài khoản và mật khẩu không được để trống!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(chuoiKetNoiSQL))
            {
                conn.Open();

                // 1. Lấy SALT (CHUỖI ĐẦU VÀO CHO MỘT HÀM BĂM (HASH) MỘT CHIỀU) từ DATABASE;
                string saltQuery = $"SELECT Salt FROM ACCOUNT_STORE WHERE TenDangNhap = '{username}'";
                SqlCommand cmmSalt = new SqlCommand(saltQuery, conn);
                object saltObj = cmmSalt.ExecuteScalar();

                if (saltObj == null)
                {
                    MessageBox.Show("Tài khoản không tồn tại.");
                    return;
                }

                string salt = saltObj.ToString();

                // 2. Sử dụng hàm băm một chiều HASH mật khẩu khi người dùng nhập + Salt từ DATABASE;
                string hashPassword = maHoaMKSH(password, salt);

                // 3. Đối chiếu chuỗi mã hóa HASH sau khi băm với chuỗi mã hóa trong DATABASE;
                string doiChieuQuery = $@"
                    SELECT MaTaiKhoan, VaiTro 
                    FROM ACCOUNT_STORE 
                    WHERE TenDangNhap = '{username}' AND MatKhau = '{hashPassword}'";
                SqlCommand cmmDoiChieu = new SqlCommand(doiChieuQuery, conn);
                SqlDataReader DR = cmmDoiChieu.ExecuteReader();

                // Kiểm tra trạng thái và gửi thông báo cho người dùng sau khi qua quá trình xử lý mật khẩu mã hóa;
                if (DR.Read())
                {
                    string role = DR["VaiTro"].ToString();
                    MessageBox.Show($"Đăng nhập thành công với vai trò: {role}");

                    // Cập nhật trạng thái đăng nhập;
                    daDangNhap = true;
                    vaiTroHienTai = role;
                    Properties.Settings.Default.LuuTenDangNhap = username;
                    Properties.Settings.Default.Save();

                    // Kiểm tra vai trò;
                    if (role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                    {
                        lb_TAOTAIKHOAN.Visible = true;
                        lb_TAOTAIKHOAN.Enabled = true;

                        // Hiển thị hộp thoại lựa chọn cho Admin;
                        DialogResult result = MessageBox.Show(
                            "Bạn muốn mở Form Home hay Form Tạo tài khoản mới?",
                            "Lựa chọn",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.DefaultDesktopOnly,
                            false);

                        if (result == DialogResult.Yes)
                        {
                            Frm_HOME frm_HOME = new Frm_HOME();
                            frm_HOME.FormClosed += (s, args) => this.Close();
                            frm_HOME.Show();
                            this.Hide();
                        }
                        else
                        {
                            Frm_REGISTER frmDKY = new Frm_REGISTER();
                            frmDKY.FormClosed += (s, args) => this.Show();
                            frmDKY.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn đang truy cập với vai trò là Nhân Viên nên chỉ được phép sử dụng HOME.");

                        // Vai trò Nhân Viên: Chỉ mở Form Home;
                        lb_TAOTAIKHOAN.Visible = false;
                        lb_TAOTAIKHOAN.Enabled = false;
                        // Bổ sung code MAIN: mở form HOME;
                        Frm_HOME frm_HOME = new Frm_HOME();
                        frm_HOME.FormClosed += (s, args) => this.Close();
                        frm_HOME.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.");
                }

                DR.Close();

                //////////
                // NÚT REMEMBER ME;
                /////////
                
                if (tgs_REMEMBER.IsOn)
                {
                    Properties.Settings.Default.RememberMe = true;
                    Properties.Settings.Default.LuuTenDangNhap = txt_TENDANGNHAP.Text;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.LuuTenDangNhap = "";
                    Properties.Settings.Default.RememberMe = false;
                    Properties.Settings.Default.Save();
                }
               
            }
        }

        /////////
        /// LABEL TẠO TÀI KHOẢN MỚI;
        ////////

        // Thiết lập hiệu ứng khi chuột HOVER vào label TẠO TÀI KHOẢN MỚI;
        private void lb_TAOTAIKHOAN_MouseEnter(object sender, EventArgs e)
        {
            lb_TAOTAIKHOAN.ForeColor = Color.White; // Màu chữ khi HOVER;
            lb_TAOTAIKHOAN.Cursor = Cursors.Hand; // Đổi con trỏ chuột khi HOVER vào label TẠO TÀI KHOẢN MỚI;
        }

        // Thiết lập hiệu ứng khi chuột RỜI KHỎI label TẠO TÀI KHOẢN MỚI;
        private void lb_TAOTAIKHOAN_MouseLeave(object sender, EventArgs e)
        {
            lb_TAOTAIKHOAN.ForeColor = Color.FromArgb(128, 128, 255); // Màu chữ khi không HOVER;

        }

        // Thiết lập sự kiện khi click vào label TẠO TÀI KHOẢN MỚI;
        private void lb_TAOTAIKHOAN_MouseClick(object sender, MouseEventArgs e)
        {

            if (!daDangNhap || string.IsNullOrEmpty(vaiTroHienTai))
            {
                MessageBox.Show("Bạn đang truy cập trái phép! Vui lòng sử dụng tài khoản Admin để đăng ký tài khoản.");
                return;
            }

            if (vaiTroHienTai.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                Frm_REGISTER frmDKY = new Frm_REGISTER();
                frmDKY.FormClosed += (s, args) => this.Show();
                frmDKY.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Bạn đang truy cập trái phép! Vui lòng sử dụng tài khoản Admin để đăng ký tài khoản.");
            }
        }

        /////////
        // TEXTBOX TÊN ĐĂNG NHẬP VÀ MẬT KHẨU;
        /////////

        // Thiết lập đặc tính và state Capslock ở txt TÊN ĐĂNG NHẬP;
        // NỀN;
        private void txt_TENDANGNHAP_BackColorChanged(object sender, EventArgs e)
        {
            txt_TENDANGNHAP.BackColor = Color.FromArgb(255, 15, 32, 39);
        }

        // STATE CAPSLOCK;
        private void txt_TENDANGNHAP_Enter(object sender, EventArgs e)
        {
            kiemTraCapslock();
        }

        private void txt_TENDANGNHAP_KeyUp(object sender, KeyEventArgs e)
        {
            kiemTraCapslock();
        }

        // Thiết lập đặc tính và state Capslock ở txt MẬT KHẨU;
        // NỀN;
        private void txt_MATKHAU_BackColorChanged(object sender, EventArgs e)
        {
            txt_MATKHAU.BackColor = Color.FromArgb(255, 15, 32, 39);
        }

        // STATE CAPSLOCK;
        private void txt_MATKHAU_Enter(object sender, EventArgs e)
        {
            kiemTraCapslock();
        }

        private void txt_MATKHAU_KeyUp(object sender, KeyEventArgs e)
        {
            kiemTraCapslock();
        }

        /////////
        // ROBOT CITY SUPPORT;
        /////////
        
        // Thiết lập đặc tính khi HOVER;
        private void pb_LOGO_MouseHover(object sender, EventArgs e)
        {
            pb_SUPPORT.Cursor = Cursors.Hand;
        }

        // Thiết lập sự kiện khi CLICK vào picturebox ROBOT CITY SUPPORT;
        private void pb_SUPPORT_Click(object sender, EventArgs e)
        {
            string guiDen = "leminhtuank0@gmail.com";
            string tieuDe = Uri.EscapeDataString("ROBOTCITY SUPPORT TICKET - LOGIN");
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
    }
}
