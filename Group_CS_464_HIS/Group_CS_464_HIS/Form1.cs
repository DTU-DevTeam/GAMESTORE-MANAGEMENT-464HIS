using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group_CS_464_HIS
{
    public partial class Form1: Form
    {
        private frm_DoanhThu frm_NhanVien;
        private frm_DichVu frm_DichVu;
        private frm_KhuyenMai frm_KhuyenMai;
        private Panel panelContent;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void showUserControl(UserControl userControl)
        {
            
        }
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
                
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripNhanVien_Click(object sender, EventArgs e)
        {
            if (frm_NhanVien == null || frm_NhanVien.IsDisposed)
                frm_NhanVien = new frm_DoanhThu();
            frm_NhanVien.Show();
            frm_NhanVien.Activate();
        }

        private void toolStrip_KhachHang_Click(object sender, EventArgs e)
        {
          
        }

        private void toolStrip_KhuyenMai_Click(object sender, EventArgs e)
        {
            if(frm_KhuyenMai == null || frm_KhuyenMai.IsDisposed)
                frm_KhuyenMai = new frm_KhuyenMai();
            frm_KhuyenMai.Show();
            frm_KhuyenMai.Activate();
        }

        private void toolStrip_DichVu_Click(object sender, EventArgs e)
        {
            if(frm_DichVu == null || frm_DichVu.IsDisposed)
                frm_DichVu = new frm_DichVu();
            frm_DichVu.Show();
            frm_DichVu.Activate();
        }
    }
}
