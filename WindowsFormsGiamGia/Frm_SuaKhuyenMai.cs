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
    public partial class Frm_SuaKhuyenMai : Form
    {
        public DataRepository dataRepository = new DataRepository();
        private DataTable _data;

        public Frm_SuaKhuyenMai(DataTable dataTable)
        {
            InitializeComponent();
            _data = dataTable;
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            string makm = txt_makm.Text;
            string tenkm = txt_tenkm.Text;
            DateTime ngaybatdau = date_ngaybatdau.Value;
            DateTime ngayketthuc = date_ngayketthuc.Value;
            string giam = txt_giam.Text;

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


            if(checkbox_enabledkgiamgia.Checked)
            {
                string mucgiamapdung = txt_mucgiamgiaapdung.Text;
                string mucgiamtoida = txt_mucgiamgiatoida.Text;
                string soluongapdung = txt_soluongapdung.Text;

                string query = $"Update GiamGia set TenKM = '{tenkm}', GiamGia = '{giam}', MucGiamGiaApDung = '{mucgiamapdung}', MucGiamGiaToiDa = '{mucgiamtoida}', SoLuongApDung = '{soluongapdung}', NgayBatDau = '{ngaybatdau}', NgayKetThuc = '{ngayketthuc}' where MaKM = '{makm}'";
                int kq = dataRepository.ThemSuaXoa(query);

                if (kq >= 1)
                {
                    MessageBox.Show("Cập nhật thành công");
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại");
                }
            }
            else
            {
                string query = $"Update GiamGia set TenKM = '{tenkm}', GiamGia = '{giam}', NgayBatDau = '{ngaybatdau}', NgayKetThuc = '{ngayketthuc}' where MaKM = '{makm}'";
                int kq = dataRepository.ThemSuaXoa(query);

                if (kq >= 1)
                {
                    MessageBox.Show("Cập nhật thành công");
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại");
                }
            }

          
        }

        private void SuaKhuyenMai_Load(object sender, EventArgs e)
        {




            if (_data == null || _data.Rows.Count == 0)
            {
                MessageBox.Show("Dữ liệu khuyến mãi không hợp lệ.");
                return;
            }


            if (_data is DataTable dataTable)
            {
                txt_makm.Text = dataTable.Rows[0]["MaKM"].ToString();
                txt_tenkm.Text = dataTable.Rows[0]["TenKM"].ToString();
                txt_giam.Text = dataTable.Rows[0]["GiamGia"].ToString();

                date_ngaybatdau.Value = DateTime.Parse(dataTable.Rows[0]["NgayBatDau"].ToString());
                date_ngayketthuc.Value = DateTime.Parse(dataTable.Rows[0]["NgayKetThuc"].ToString());

                txt_mucgiamgiaapdung.Text = dataTable.Rows[0]["MucGiamGiaApDung"].ToString();
                txt_mucgiamgiatoida.Text = dataTable.Rows[0]["MucGiamGiaToiDa"].ToString();
                txt_soluongapdung.Text = dataTable.Rows[0]["SoLuongApDung"].ToString();



                if (!txt_mucgiamgiaapdung.Text.Equals("") || !txt_mucgiamgiatoida.Text.Equals("") || !txt_soluongapdung.Text.Equals(""))
                {
                    group_giamgia.Enabled = true;
                    checkbox_enabledkgiamgia.Checked = true;
                }

            }
        }

        private DataTable getKhuyenMaiById(string maKm)
        {
            string query = $"Select * from GiamGia where MaKM = '{maKm}'";
            DataTable dataTable = dataRepository.LoadDL(query);
            return dataTable;
        }

        private void checkbox_enabledkgiamgia_CheckedChanged(object sender, EventArgs e)
        {
            if(checkbox_enabledkgiamgia.Checked)
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
