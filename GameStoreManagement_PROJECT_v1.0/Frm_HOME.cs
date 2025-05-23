using QlyKho;
using QUANLYNHANVIEN;
using QuanLyQuanNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsGiamGia;

namespace GameStoreManagement_PROJECT_v1._0
{
    public partial class Frm_HOME : Form
    {
        // Fix lỗi tránh bị DPI kh phù hợp với các máy tính khácl;
        public Frm_HOME()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(Frm_HOME_Paint);
            this.Shown += new EventHandler(Frm_HOME_Shown);
        }

        private void Frm_HOME_Load(object sender, EventArgs e)
        {
            this.Activate();
            this.Focus();

            ms_QUANLY.BackColor = Color.Transparent;

            lb_NAME.BackColor = Color.Transparent;
            lb_THOAT.BackColor = Color.Transparent;

            grc_HOME.BackColor = Color.Transparent;
        }

        // Gọi lại sự kiện PAINT khi form được hiển thị;
        private void Frm_HOME_Shown(object sender, EventArgs e)
        {
            this.Validate();
        }

        private void Frm_HOME_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = this.ClientRectangle;

            // Kiểm tra và đảm bảo kích thước hợp lệ;
            if (rect.Width <= 0 || rect.Height <= 0)
            {
                rect = new Rectangle(0, 0, Math.Max(1, this.Width), Math.Max(1, this.Height));
            }

            try
            {
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
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tô gradient Frm_HOME_Paint: {ex.Message}");
            }
        }

        private void ms_QUANLY_MouseHover(object sender, EventArgs e)
        {
            ms_QUANLY.Cursor = Cursors.Hand;
        }

        private void pb_SUPPORT_MouseHover(object sender, EventArgs e)
        {
            pb_SUPPORT.Cursor = Cursors.Hand;
        }

        private void pb_SUPPORT_Click(object sender, EventArgs e)
        {
            string guiDen = "leminhtuank0@gmail.com";
            string tieuDe = Uri.EscapeDataString("ROBOTCITY SUPPORT TICKET - HOME");
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

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void lb_THOAT_MouseHover(object sender, EventArgs e)
        {
            
        }
        private void lb_THOAT_MouseEnter(object sender, EventArgs e)
        {
            lb_THOAT.Cursor = Cursors.Hand;
            lb_THOAT.ForeColor = Color.DodgerBlue;
        }

        private void lb_THOAT_MouseLeave(object sender, EventArgs e)
        {
            lb_THOAT.Cursor = Cursors.Default;
            lb_THOAT.ForeColor = Color.White;
        }
        private void lb_THOAT_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Frm_LOGIN frmLogin = new Frm_LOGIN();
                frmLogin.FormClosed += (s, args) => this.Close();
                frmLogin.Show();
                this.Hide();
            }
        }

        private Frm_ComputerManager frmComputerManager = null;
        private Frm_KhuyenMai khuyenMai = null;
        private Frm_Kho frmKho = null;
        private Frm_NhapLieuHD frmNhapLieuHD = null;
        private Frm_MENU frmMenu = null;
        private Frm_LICHSU FrmLichSu = null;

        private void tìnhTrạngMáyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmComputerManager == null || frmComputerManager.IsDisposed)
            {
                frmComputerManager = new Frm_ComputerManager();
                frmComputerManager.Show();
            }
            else
            {
                frmComputerManager.BringToFront();
                frmComputerManager.Focus();
            }
        }

        private void khuyếnMãiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (khuyenMai == null || khuyenMai.IsDisposed)
            {
                khuyenMai = new Frm_KhuyenMai();
                khuyenMai.Show();
            }
            else
            {
                khuyenMai.BringToFront();
                khuyenMai.Focus();
            }
        }

        private void khoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmKho == null || frmKho.IsDisposed)
            {
                frmKho = new Frm_Kho();
                frmKho.Show();
            }
            else
            {
                frmKho.BringToFront();
                frmKho.Focus();
            }
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmNhapLieuHD == null || frmNhapLieuHD.IsDisposed)
            {
                frmNhapLieuHD = new Frm_NhapLieuHD();
                frmNhapLieuHD.Show();
            }
            else
            {
                frmNhapLieuHD.BringToFront();
                frmNhapLieuHD.Focus();
            }
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmMenu == null || frmMenu.IsDisposed)
            {
                frmMenu = new Frm_MENU();
                frmMenu.Show();
            }
            else
            {
                frmMenu.BringToFront();
                frmMenu.Focus();
            }
        }

        private void lịchSửToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FrmLichSu == null || FrmLichSu.IsDisposed)
            {
                FrmLichSu = new Frm_LICHSU();
                FrmLichSu.Show();
            }
            else
            {
                FrmLichSu.BringToFront();
                FrmLichSu.Focus();
            }
        }
    }
}
