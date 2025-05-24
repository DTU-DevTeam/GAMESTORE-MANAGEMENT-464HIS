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

namespace GameStoreManagement_PROJECT_v1._0
{
    public partial class Frm_MENU : Form
    {
        List<Panel> listPanel = new List<Panel>();
        int index;

        public Frm_MENU()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(Frm_MENU_Paint);
            this.Shown += new EventHandler(Frm_MENU_Shown);
        }
        private void Frm_MENU_Load(object sender, EventArgs e)
        {
            this.Activate();
            this.Focus();

            Point commonLocation = new Point(250, 89);
            Size commonSize = new Size(1217, 610);

            pn_DUPC.Location = commonLocation;
            pn_DODC.Location = commonLocation;
            pn_DOANVAT.Location = commonLocation;
            pn_COMMY.Location = commonLocation;
            pn_THUOCLA.Location = commonLocation;

            pn_DUPC.Size = commonSize;
            pn_DODC.Size = commonSize;
            pn_DOANVAT.Size = commonSize;
            pn_COMMY.Size = commonSize;
            pn_THUOCLA.Size = commonSize;


            pn_DUPC.BackColor = Color.Transparent;
            pn_DODC.BackColor = Color.Transparent;
            pn_DOANVAT.BackColor = Color.Transparent;
            pn_COMMY.BackColor = Color.Transparent;
            pn_THUOCLA.BackColor = Color.Transparent;

            listPanel.Add(pn_DUPC);
            listPanel.Add(pn_DODC);
            listPanel.Add(pn_DOANVAT);
            listPanel.Add(pn_COMMY);
            listPanel.Add(pn_THUOCLA);

            pn_DUPC.Tag = "Đồ uống pha chế";
            pn_DODC.Tag = "Đồ uống đóng chai";
            pn_DOANVAT.Tag = "Đồ ăn vặt";
            pn_COMMY.Tag = "Cơm mỳ";
            pn_THUOCLA.Tag = "Thuốc lá";

            // Ẩn hết các panel trước;
            foreach (var pnl in listPanel)
            {
                pnl.Visible = false;
            }

            // Hiển thị panel đầu tiên;
            index = 0;
            listPanel[index].Visible = true;
            listPanel[index].BringToFront();

        }

        // Gọi lại sự kiện PAINT khi form được hiển thị;
        private void Frm_MENU_Shown(object sender, EventArgs e)
        {
            this.Validate();

        }

        private void Frm_MENU_Paint(object sender, PaintEventArgs e)
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
        private void ShowPanel(int panelIndex)
        {
            if (panelIndex < 0 || panelIndex >= listPanel.Count)
                return;

            // Ẩn tất cả panel trước;
            foreach (Panel pnl in listPanel)
            {
                pnl.Visible = false;
            }

            // Hiển thị panel được chọn;
            listPanel[panelIndex].Visible = true;
            listPanel[panelIndex].BringToFront();

            index = panelIndex;
        }

        private void btn_DUPC_Click(object sender, EventArgs e)
        {
            ShowPanel(0); // Hiển thị trang đồ uống pha chế;
        }

        private void btn_DUDC_Click(object sender, EventArgs e)
        {
            ShowPanel(1); // Hiển thị đồ uống đóng chai;
        }

        private void btn_DAV_Click(object sender, EventArgs e)
        {
            ShowPanel(2); // Hiển thị đồ ăn vặt;
        }

        private void btn_COMMY_Click(object sender, EventArgs e)
        {
            ShowPanel(3); // Hiển thị cơm và mỳ;
        }

        private void btn_THUOCLA_Click(object sender, EventArgs e)
        {
            ShowPanel(4); // Hiển thị thuốc lá;
        }

        private void btn_SEARCH_Click(object sender, EventArgs e)
        {
            string tuTimKiem = txt_SEARCH.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(tuTimKiem))
            {
                // Nếu từ khóa rỗng, hiển thị panel hiện tại;
                ShowPanel(index);
                return;
            }

            bool timKiem = false;

            for (int i = 0; i < listPanel.Count; i++)
            {
                Panel pn = listPanel[i];

                foreach (Control ctrl in pn.Controls)
                {
                    if (ctrl is GroupBox groupBox)
                    {
                        if (groupBox.Text.ToLower().Contains(tuTimKiem))
                        {
                            ShowPanel(i);
                            timKiem = true;
                            break;
                        }
                    }
                }

                if (timKiem)
                    break;
            }

            if (!timKiem)
            {
                MessageBox.Show("Không tìm thấy sản phẩm phù hợp!", "Tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
