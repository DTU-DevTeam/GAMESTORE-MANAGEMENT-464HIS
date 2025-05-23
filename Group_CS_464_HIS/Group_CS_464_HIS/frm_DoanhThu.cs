using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Group_CS_464_HIS
{
    public partial class frm_DoanhThu : Form
    {
        // Database connection
        private SqlConnection conn;
        private const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\GAMESTORE-MANAGEMENT-464HIS\Group_CS_464_HIS\Group_CS_464_HIS\GROUP.mdf;Integrated Security=True";

        // Controls
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private ComboBox cmbRevenueType;
        private Button btnViewReport;
        private Button btnExport;
        private GroupBox gbSummary;
        private Label lblTotalRevenue;
        private Label lblServiceRevenue;
        private Label lblComputerRevenue;
        private Label lblPromotionDiscount;
        private Label lblCustomerCount;
        private Chart chartRevenue;
        private DataGridView dgvRevenue;

        public frm_DoanhThu()
        {
            InitializeComponent();
            SetupForm();
            SetupControls();
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            conn = new SqlConnection(connectionString);
        }

        private void SetupForm()
        {
            this.Text = "Thống kê doanh thu";
            this.Size = new Size(1024, 768);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void SetupControls()
        {
            // Date Range Controls
            Label lblStartDate = new Label
            {
                Text = "Từ ngày:",
                Location = new Point(20, 20),
                AutoSize = true
            };

            dtpStartDate = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Location = new Point(90, 18),
                Width = 120
            };

            Label lblEndDate = new Label
            {
                Text = "Đến ngày:",
                Location = new Point(230, 20),
                AutoSize = true
            };

            dtpEndDate = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Location = new Point(300, 18),
                Width = 120
            };

            // Revenue Type Filter
            Label lblRevenueType = new Label
            {
                Text = "Loại doanh thu:",
                Location = new Point(440, 20),
                AutoSize = true
            };

            cmbRevenueType = new ComboBox
            {
                Location = new Point(530, 18),
                Width = 150,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbRevenueType.Items.AddRange(new string[] { 
                "Tất cả", 
                "Doanh thu máy", 
                "Doanh thu dịch vụ",
                "Khuyến mãi"
            });
            cmbRevenueType.SelectedIndex = 0;

            // Action Buttons
            btnViewReport = new Button
            {
                Text = "Xem báo cáo",
                Location = new Point(700, 17),
                Width = 100
            };
            btnViewReport.Click += BtnViewReport_Click;

            btnExport = new Button
            {
                Text = "Xuất Excel",
                Location = new Point(820, 17),
                Width = 100
            };
            btnExport.Click += BtnExport_Click;

            // Summary Group
            gbSummary = new GroupBox
            {
                Text = "Thông tin tổng hợp",
                Location = new Point(20, 60),
                Size = new Size(900, 100)
            };

            lblTotalRevenue = CreateSummaryLabel("Tổng doanh thu: 0 VNĐ", new Point(20, 30));
            lblComputerRevenue = CreateSummaryLabel("Doanh thu máy: 0 VNĐ", new Point(200, 30));
            lblServiceRevenue = CreateSummaryLabel("Doanh thu dịch vụ: 0 VNĐ", new Point(380, 30));
            lblPromotionDiscount = CreateSummaryLabel("Tổng khuyến mãi: 0 VNĐ", new Point(560, 30));
            lblCustomerCount = CreateSummaryLabel("Số lượng khách: 0", new Point(740, 30));

            gbSummary.Controls.AddRange(new Control[] {
                lblTotalRevenue, lblComputerRevenue, lblServiceRevenue,
                lblPromotionDiscount, lblCustomerCount
            });

            // Revenue Chart
            chartRevenue = new Chart
            {
                Location = new Point(20, 170),
                Size = new Size(900, 250),
                BackColor = Color.White
            };
            chartRevenue.ChartAreas.Add(new ChartArea("MainArea"));
            chartRevenue.Series.Add(new Series
            {
                ChartType = SeriesChartType.Column,
                Name = "Doanh thu"
            });

            // Data Grid
            dgvRevenue = new DataGridView
            {
                Location = new Point(20, 430),
                Size = new Size(900, 280),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true
            };
            SetupDataGridColumns();

            // Add all controls to form
            this.Controls.AddRange(new Control[] {
                lblStartDate, dtpStartDate,
                lblEndDate, dtpEndDate,
                lblRevenueType, cmbRevenueType,
                btnViewReport, btnExport,
                gbSummary,
                chartRevenue,
                dgvRevenue
            });
        }

        private Label CreateSummaryLabel(string text, Point location)
        {
            return new Label
            {
                Text = text,
                Location = location,
                AutoSize = true
            };
        }

        private void SetupDataGridColumns()
        {
            dgvRevenue.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn
                {
                    Name = "StatDate",
                    HeaderText = "Ngày",
                    DataPropertyName = "StatDate"
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "ComputerRevenue",
                    HeaderText = "Doanh thu máy",
                    DataPropertyName = "ComputerRevenue"
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "ServiceRevenue",
                    HeaderText = "Doanh thu dịch vụ",
                    DataPropertyName = "ServiceRevenue"
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "PromotionDiscount",
                    HeaderText = "Khuyến mãi",
                    DataPropertyName = "PromotionDiscount"
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "TotalRevenue",
                    HeaderText = "Tổng doanh thu",
                    DataPropertyName = "TotalRevenue"
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "CustomerCount",
                    HeaderText = "Số khách",
                    DataPropertyName = "CustomerCount"
                }
            });
        }

        private void BtnViewReport_Click(object sender, EventArgs e)
        {
            LoadRevenueData();
        }
        
        private void LoadRevenueData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            StatDate,
                            ComputerRevenue,
                            ServiceRevenue,
                            PromotionDiscount,
                            TotalRevenue,
                            CustomerCount
                        FROM Revenue_Statistics
                        WHERE StatDate BETWEEN @StartDate AND @EndDate
                        ORDER BY StatDate DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@StartDate", dtpStartDate.Value.Date);
                        cmd.Parameters.AddWithValue("@EndDate", dtpEndDate.Value.Date);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvRevenue.DataSource = dt;
                        UpdateSummary(dt);
                        UpdateChart(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateSummary(DataTable dt)
        {
            decimal totalRevenue = 0, computerRevenue = 0, serviceRevenue = 0, promotionDiscount = 0;
            int customerCount = 0;

            foreach (DataRow row in dt.Rows)
            {
                totalRevenue += Convert.ToDecimal(row["TotalRevenue"]);
                computerRevenue += Convert.ToDecimal(row["ComputerRevenue"]);
                serviceRevenue += Convert.ToDecimal(row["ServiceRevenue"]);
                promotionDiscount += Convert.ToDecimal(row["PromotionDiscount"]);
                customerCount += Convert.ToInt32(row["CustomerCount"]);
            }

            lblTotalRevenue.Text = $"Tổng doanh thu: {totalRevenue:N0} VNĐ";
            lblComputerRevenue.Text = $"Doanh thu máy: {computerRevenue:N0} VNĐ";
            lblServiceRevenue.Text = $"Doanh thu dịch vụ: {serviceRevenue:N0} VNĐ";
            lblPromotionDiscount.Text = $"Tổng khuyến mãi: {promotionDiscount:N0} VNĐ";
            lblCustomerCount.Text = $"Số lượng khách: {customerCount}";
        }

        private void UpdateChart(DataTable dt)
        {
            chartRevenue.Series[0].Points.Clear();
            foreach (DataRow row in dt.Rows)
            {
                chartRevenue.Series[0].Points.AddXY(
                    Convert.ToDateTime(row["StatDate"]).ToShortDateString(),
                    Convert.ToDecimal(row["TotalRevenue"])
                );
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx",
                FileName = $"DoanhThu_{DateTime.Now:yyyyMMdd}"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // TODO: Implement Excel export
                MessageBox.Show("Chức năng xuất Excel đang được phát triển", 
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frm_NHANVIEN_Load(object sender, EventArgs e)
        {

        }
    }
}
