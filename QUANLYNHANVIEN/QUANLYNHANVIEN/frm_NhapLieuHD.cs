using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYNHANVIEN
{
    public partial class Frm_NhapLieuHD : Form
    {
        lopchung lopdungchung = new lopchung();

        public Frm_NhapLieuHD()
        {
            InitializeComponent();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            string manv = txt_manv.Text;
            string tennv = txt_tennv.Text;
            DateTime ngayvaolam = DateTime.Parse(date_ngayvaolam.Value.ToString("yyyy-MM-dd"));
            string diachi = txt_diachi.Text;
           // var phongban = cb_tenpb.SelectedValue;


            string sql = $"Insert into NHANVIEN values('{manv}', '{tennv}', '{ngayvaolam.ToString("yyyy-MM-dd")}', '{diachi}')";

            int kq = lopdungchung.Themsuaxoa(sql);

            if (kq >= 1)
            {
                MessageBox.Show("them thanh cong");
            }
            else
            {
                MessageBox.Show("them that bai");
            }

            LoadDL();

        }

        public void LoadDL()
        {
            string sql = "Select * from NHANVIEN";
            dataGridView1.DataSource = lopdungchung.LoadDl(sql);
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            string manv = txt_manv.Text;
            string tennv = txt_tennv.Text;
            DateTime ngayvaolam = DateTime.Parse(date_ngayvaolam.Value.ToString("yyyy-MM-dd"));
            string diachi = txt_diachi.Text;
            //var phongban = cb_tenpb.SelectedValue;

            string sql = $"Update NHANVIEN Set TENNV = '{tennv}', NGAYVAOLAM = '{ngayvaolam.ToString("yyyy-MM-dd")}', DIACHI = '{diachi}' WHERE MANV = '{manv}'";

            int kq = lopdungchung.Themsuaxoa(sql);

            if(kq >= 1)
            {
                MessageBox.Show("sua thanh cong");
            }
            else
            {
                MessageBox.Show("sua that bai");
            }

            LoadDL();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            string manv = txt_manv.Text;

            string sql = $"Delete from NHANVIEN WHERE MANV = '{manv}'";

            int kq = lopdungchung.Themsuaxoa(sql);

            if (kq >= 1)
            {
                MessageBox.Show("xoa thanh cong");
            }
            else
            {
                MessageBox.Show("xoa that bai");
            }

            LoadDL();
        }

        private void frm_NhapLieuHD_Load(object sender, EventArgs e)
        {
            LoadDL();
            string sql = "Select * from PhongBan";
           // cb_tenpb.DataSource = lopdungchung.LoadDl(sql);
           // cb_tenpb.DisplayMember = "TenPB";
           // cb_tenpb.ValueMember = "MaPB";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_manv.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_tennv.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            date_ngayvaolam.Value = DateTime.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());
            txt_diachi.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            //cb_tenpb.SelectedValue = dataGridView1.CurrentRow.Cells["MAPB"].Value.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_manv.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_tennv.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            date_ngayvaolam.Value = DateTime.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());
            txt_diachi.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            //cb_tenpb.SelectedValue = dataGridView1.CurrentRow.Cells["MAPB"].Value.ToString();
        }
    }
}
