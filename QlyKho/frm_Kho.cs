using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace QlyKho
{
    public partial class frm_Kho: Form
    {
        // Khai báo lớp dùng chung để truy vấn database
        LOPDUNGCHUNG lopDungChung = new LOPDUNGCHUNG();
        public frm_Kho()
        {
            InitializeComponent();
            // Áp dụng theme màu cho form
            ApplyThemecolor();
            //Load dữ liệu sản phẩm lên DataGridView
            LoadDataToGrid();
            // Load danh sách nhóm sản phẩm vào comboBox 
            LoadNhomSanPhamToComboBox();
        }

        private void frm_Kho_Load(object sender, EventArgs e)
        {
            // Khi form Load, gọi lại dữ liệu lên bảng 
            LoadDataToGrid();
            this.Activate();
            this.Focus();
        }

        /// <summary>
        /// Load dữ liệu sản phẩm từ Database lên DataGridView 
        /// </summary>
        public void LoadDataToGrid()
        {
            string sql = "SELECT * FROM SANPHAM";   // Lấy tất cả sản phẩm
            DataTable dt = lopDungChung.LoadDL(sql);    //lấy dữ liệu
            
            dgvKho.DataSource = dt; //Gán dữ liệu vào DataGridView 

            //Chỉnh sửa cột sau khi load dữ liệu
            dgvKho.Columns["MaSanPham"].HeaderText = "Mã sản phẩm";   
            dgvKho.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";
            dgvKho.Columns["TonKho"].HeaderText = "Tồn dư";
            dgvKho.Columns["DonVi"].HeaderText = "Đơn Vị";
            dgvKho.Columns["NhomSanPham"].HeaderText = "Nhóm sản phẩm";
            dgvKho.Columns["MucBaoHet"].HeaderText = "Mức Báo Hết";
        }

        /// <summary>
        /// Vẽ Nền gradient cho form
        /// </summary>
        private void frm_Kho_Paint(object sender, PaintEventArgs e)
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
        /// Đóng form khi nhấn nút "Tắt"
        /// </summary>
        private void btnTat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Mở Form nhập kho mới và Load lại dữ liệu
        /// </summary>
        private void btnPhieuNhapMoi_Click(object sender, EventArgs e)
        {
            frm_PhieuNhapMoi formNhapKho = new frm_PhieuNhapMoi();
            formNhapKho.ShowDialog();
            LoadDataToGrid(); //Load lại dữ liệu khi thêm mới
        }

        /// <summary>
        /// Tìm kiếm sản phẩm theo tên và lọc nhóm sản phẩm 
        /// </summary>
        
        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();    //Từ khóa tìm kiếm
            string selectedNhom = cbNhomSanPham.SelectedItem.ToString();    //Nhóm sản phẩm đã chọn

            //Câu lệnh sql cơ bản, thêm điều kiện nếu có 
            string sql = "SELECT * FROM SANPHAM WHERE 1=1 ";

            if (!string.IsNullOrEmpty(keyword)) 
            {
                sql += $" AND TenSanPham LIKE N'%{keyword}%'";  //Tìm kiếm theo tên sản phẩm
            }

            if (selectedNhom != "Tất cả")
            {
                sql += $" AND NhomSanPham = N'{selectedNhom}'"; //Lọc theo nhóm sản phẩm
            }

            DataTable dt = lopDungChung.LoadDL(sql);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sản phẩm nào phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dgvKho.DataSource = dt; //Hiển thị kết quả tìm kiếm 
            }
        }

        /// <summary>
        /// Load danh sách nhóm sản phẩm duy nhất vào comboBox, thêm lựa chọn "Tất Cả"
        /// </summary>
        private void LoadNhomSanPhamToComboBox()
        {
            string sql = "SELECT DISTINCT NhomSanPham FROM SANPHAM";
            DataTable dt = lopDungChung.LoadDL(sql);

            cbNhomSanPham.Items.Clear();
            cbNhomSanPham.Items.Add("Tất cả"); // thêm tùy chọn xem tất cả nhóm sản phẩm

            foreach (DataRow row in dt.Rows)
            {
                cbNhomSanPham.Items.Add(row["NhomSanPham"].ToString());
            }

            cbNhomSanPham.SelectedIndex = 0; // chọn mặc định "Tất cả"
        }

        /// <summary>
        /// Khi chọn nhóm sản phẩm trong comboBox thì lọc lại dữ liệu tương ứng 
        /// </summary>
        
        private void cbNhomSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedNhom = cbNhomSanPham.SelectedItem.ToString();

            string sql;

            if (selectedNhom == "Tất cả")
            {
                sql = "SELECT * FROM SANPHAM";  //Hiển thị tất cả sản phẩm 
            }
            else
            {
                sql = $"SELECT * FROM SANPHAM WHERE NhomSanPham = N'{selectedNhom}'";   //Lọc theo nhóm
            }

            DataTable dt = lopDungChung.LoadDL(sql);
            dgvKho.DataSource = dt;
        }

        /// <summary>
        /// Xem chi tiết sản phẩm được chọn trong dataGridView
        /// </summary>
        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (dgvKho.CurrentRow != null)
            {
                var selectedRow = dgvKho.CurrentRow;

                string maSanPham = selectedRow.Cells["MaSanPham"].Value?.ToString();
                string tenSanPham = selectedRow.Cells["TenSanPham"].Value?.ToString();
                string tonDu = selectedRow.Cells["TonKho"].Value?.ToString();
                string donVi = selectedRow.Cells["DonVi"].Value?.ToString();
                string nhomSanPham = selectedRow.Cells["NhomSanPham"].Value?.ToString();
                string mucBaoHet = selectedRow.Cells["MucBaoHet"].Value?.ToString();

                frm_XemChiTiet frmChiTiet = new frm_XemChiTiet();

                // Truyền tham chiếu form kho vào form chi tiết
                frmChiTiet.SetParentForm(this);

                frmChiTiet.SetChiTietSanPham(maSanPham, tenSanPham, tonDu, donVi, nhomSanPham, mucBaoHet);

                frmChiTiet.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xem chi tiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// Xóa sản phẩm được chọn trong dataGridView
        /// </summary>
        
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvKho.CurrentRow != null)
            {
                string maSanPham = dgvKho.CurrentRow.Cells["MaSanPham"].Value.ToString();

                DialogResult dr = MessageBox.Show($"Bạn có chắc muốn xóa sản phẩm mã {maSanPham} không? (Lưu ý: Dữ liệu liên quan trong phiếu nhập cũng sẽ bị xóa)", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        // Xóa dữ liệu liên quan ở bảng CHITIETPHIEUNHAP trước
                        string sqlXoaChiTiet = $"DELETE FROM CHITIETPHIEUNHAP WHERE MaSanPham = '{maSanPham}'";
                        lopDungChung.ThemSuaXoa(sqlXoaChiTiet);

                        // Xóa dữ liệu ở bảng SANPHAM
                        string sqlXoaSanPham = $"DELETE FROM SANPHAM WHERE MaSanPham = '{maSanPham}'";
                        int ketQua = lopDungChung.ThemSuaXoa(sqlXoaSanPham);

                        if (ketQua > 0)
                        {
                            MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDataToGrid();   
                        }
                        else
                        {
                            MessageBox.Show("Xóa dữ liệu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ExportDataGridViewToExcel(DataGridView dgv, string filename)
        {
            try
            {
                // Tạo app Excel mới
                Excel.Application excelApp = new Excel.Application();
                if (excelApp == null)
                {
                    MessageBox.Show("Excel không được cài đặt trên máy tính này.");
                    return;
                }

                excelApp.Visible = false;
                Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];
                worksheet.Name = "DanhSachSanPham";

                // Ghi tiêu đề cột
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dgv.Columns[i].HeaderText;
                }

                // Ghi dữ liệu từng dòng
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        // Kiểm tra null tránh lỗi
                        worksheet.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value?.ToString() ?? "";
                    }
                }

                // Lưu file Excel
                workbook.SaveAs(filename);
                workbook.Close();
                excelApp.Quit();

                MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Activate();
                this.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất file Excel: " + ex.Message);
                this.Activate();
                this.Focus();
            }
        }

        /// <summary>
        /// Áp dụng màu sắc cho các control trong form
        /// </summary>
        private void ApplyThemecolor()
        {
            // Màu nền 2 panel
            panel1.BackColor = Color.FromArgb(230, 240, 250);  // Panel tiêu đề: trắng
            panel2.BackColor = Color.FromArgb(230, 240, 250); // Panel nội dung: xanh nhạt dịu mắt

            // Viền nhẹ cho panel1 (tùy chọn)
            panel1.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, panel1.ClientRectangle,
                    Color.LightGray, 0, ButtonBorderStyle.None,
                    Color.LightGray, 0, ButtonBorderStyle.None,
                    Color.LightGray, 1, ButtonBorderStyle.Solid, // viền dưới
                    Color.LightGray, 0, ButtonBorderStyle.None);
            };

            // Màu chữ tiêu đề nổi bật
            label1.ForeColor = Color.FromArgb(255, 59, 59); // đỏ nổi bật
            label1.Font = new Font(label1.Font, FontStyle.Bold);

            label5.ForeColor = Color.Black;
            lbTenNhanVien.ForeColor = Color.Black;

            // Các control khác có thể set màu tùy ý (nếu muốn)
        
            txtTimKiem.BackColor = Color.White;
            txtTimKiem.ForeColor = Color.Black;

            cbNhomSanPham.BackColor = Color.White;
            cbNhomSanPham.ForeColor = Color.Black;

            dgvKho.BackgroundColor = Color.White;
            dgvKho.ForeColor = Color.Black;
            dgvKho.GridColor = Color.Gray;

            // Nút xóa màu đỏ nổi bật
            btnXoa.BackColor = Color.FromArgb(255, 59, 59);
            btnXoa.ForeColor = Color.White;

            // Các nút khác nền trắng chữ đen
            btnKiemTra.BackColor = Color.White;
            btnKiemTra.ForeColor = Color.Black;

            btnXuatFile.BackColor = Color.White;
            btnXuatFile.ForeColor = Color.Black;

            btnXemChiTiet.BackColor = Color.White;
            btnXemChiTiet.ForeColor = Color.Black;

            btnPhieuNhapMoi.BackColor = Color.White;
            btnPhieuNhapMoi.ForeColor = Color.Black;

            // Nút tắt nền xanh đậm, không viền
            btnTat.FlatStyle = FlatStyle.Flat;
            btnTat.FlatAppearance.BorderSize = 0;
            
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại chọn nơi lưu file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Lưu file Excel";
            saveFileDialog.FileName = "DanhSachSanPham.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportDataGridViewToExcel(dgvKho, saveFileDialog.FileName);
            }
        }
    }     
}
