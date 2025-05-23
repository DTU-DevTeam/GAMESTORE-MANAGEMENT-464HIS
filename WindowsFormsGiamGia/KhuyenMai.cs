using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsGiamGia

{
    public partial class KhuyenMai : Form
    {
        public DataRepository DataRepository = new DataRepository();

        public KhuyenMai()
        {
            InitializeComponent();
        }

        private void KhuyenMai_Load(object sender, EventArgs e)
        {
            LoadDl();
        }

        public void LoadDl()
        {
            string khuyenmaiSql = "Select * from GiamGia";

            DataTable dataTable = DataRepository.LoadDL(khuyenmaiSql);

            dataGridView1.DataSource = dataTable;


            dataGridView1.Columns[0].HeaderText = "Mã khuyến mãi";
            dataGridView1.Columns[1].HeaderText = "Tên khuyến mãi";
            dataGridView1.Columns[2].HeaderText = "Giảm giá";
            dataGridView1.Columns[3].HeaderText = "Mức giảm áp dụng";
            dataGridView1.Columns[4].HeaderText = "Mức giảm tối đa";
            dataGridView1.Columns[5].HeaderText = "Số lượng áp dụng";
            dataGridView1.Columns[6].HeaderText = "Ngày bắt đầu";
            dataGridView1.Columns[7].HeaderText = "Ngày kết thúc";
            dataGridView1.Columns[8].HeaderText = "Trạng thái";


        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            ThemKM themKM = new ThemKM();
            themKM.Show();

            LoadDl();
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lb_getdataID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lb_getdataID.Text))
            {
                MessageBox.Show("Vui lòng chọn 1 hàng hợp lệ.");
                return;
            }

            string getdata = lb_getdataID.Text;

            string khuyenmaiSql = $"SELECT * FROM GiamGia WHERE MaKM = '{getdata}'";
            DataTable dataTable = DataRepository.LoadDL(khuyenmaiSql);

            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy khuyến mãi.");
                return;
            }

            //DataTable dataTable = DataRepository.LoadDL(khuyenmaiSql);

            SuaKhuyenMai suaKhuyenMai = new SuaKhuyenMai(dataTable);
            suaKhuyenMai.Show();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            string getdataID = lb_getdataID.Text;


            if (string.IsNullOrEmpty(getdataID))
            {
                MessageBox.Show("Vui lòng chọn khuyến mãi để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lb_getdataID.Text.Contains(", "))
            {
                string[] MaKMs = lb_getdataID.Text.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (string makm in MaKMs)
                    {
                        string makhuyenmaiSql = $"Delete from GiamGia where MaKM = '{makm}'";
                        DataRepository.ThemSuaXoa(makhuyenmaiSql);
                    }

                }


            }
            else
            {
                lb_getdataID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                

                string khuyenmaiSql = $"Delete from GiamGia where MaKM = '{getdataID}'";

                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataRepository.ThemSuaXoa(khuyenmaiSql);

                }
            }

            LoadDl();

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            UpdateSelectedIDs();
        }

        private void UpdateSelectedIDs()
        {
            List<string> selectedIDs = new List<string>();

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                selectedIDs.Add(row.Cells[0].Value?.ToString());
            }

            lb_getdataID.Text = string.Join(", ", selectedIDs);
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            LoadDl();
           
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            string timkiem = txt_timkiem.Text;

            string khuyenmaiSql = $"Select * from GiamGia where MaKM like N'%{timkiem}%' or TenKM like N'%{timkiem}%'";

            DataTable dataTable = DataRepository.LoadDL(khuyenmaiSql);

            dataGridView1.DataSource = dataTable;
        }

       
    }
}
