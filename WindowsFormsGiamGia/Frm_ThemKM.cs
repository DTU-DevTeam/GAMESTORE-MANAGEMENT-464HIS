using DevExpress.XtraEditors.Filtering.Templates;
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
    public partial class Frm_ThemKM : Form
    {
        DataRepository dataRepository = new DataRepository();

        public Frm_ThemKM()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

       

        private void btn_themmoi_Click(object sender, EventArgs e)
        {
            string makm = txt_makm.Text;
            string tenkm = txt_tenkm.Text;
            DateTime ngaybatdau = date_ngaybatdau.Value;
            DateTime ngayketthuc = date_ngayketthuc.Value;
            string giam = txt_giam.Text;

            string mucgiamapdung = txt_mucgiamgiaapdung.Text;
            string mucgiamtoida = txt_mucgiamgiatoida.Text;
            string soluongapdung = txt_soluongapdung.Text;
            string trangthai;

            if (ngayketthuc < DateTime.UtcNow)
            {
                MessageBox.Show("Ngày kết thúc không được nhỏ hơn ngày hiện tại");
                return;
            }

            if (ngaybatdau > ngayketthuc)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc");
                return;
            }

            if (ngaybatdau < DateTime.UtcNow)
            {
                MessageBox.Show("Ngày bắt đầu không được nhỏ hơn ngày hiện tại");
                return;
            }

            if (ngaybatdau.Day == DateTime.UtcNow.Day && ngaybatdau.Month == DateTime.UtcNow.Month && ngaybatdau.Year == DateTime.UtcNow.Year)
            {
                 trangthai = "Đang áp dụng";
            }
            else
            {
                 trangthai = "chưa được áp dụng";
            }

            string query = $"Insert into GiamGia values('{makm}', '{tenkm}', '{giam}', '{mucgiamapdung}', '{mucgiamtoida}', '{soluongapdung}', '{ngaybatdau}', '{ngayketthuc}', '{trangthai}')";

            if (!checkbox_enabledkgiamgia.Checked)
            {
                query = $"Insert into GiamGia (MaKM, TenKM, GiamGia, NgayBatDau, NgayKetThuc, TrangThai) values('{makm}', '{tenkm}', '{giam}', '{ngaybatdau}', '{ngayketthuc}', '{trangthai}')";
            }

            int kq = dataRepository.ThemSuaXoa(query);

            if(kq >= 1)
            {
                txt_message.Text = "Them thanh cong";
            }
            else
            {
                txt_message.Text = "them that bai";
            }


        }

        private void ThemKM_Load(object sender, EventArgs e)
        {
          

           
        }

        private void checkbox_enabledkgiamgia_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox_enabledkgiamgia.Checked)
            {
                group_giamgia.Enabled = true;
            }
            else
            {
                group_giamgia.Enabled = false;
            }
        }
    }
}
