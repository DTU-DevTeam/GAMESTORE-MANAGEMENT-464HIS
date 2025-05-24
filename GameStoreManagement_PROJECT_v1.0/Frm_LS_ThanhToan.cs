using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlyLichSu
{
    public partial class Frm_LS_ThanhToan: Form
    {
        public Frm_LS_ThanhToan()
        {
            InitializeComponent();
            this.Activate();
            this.Focus();
        }

        private void pnThanhToan2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
