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
    public partial class frm_KhuyenMai : Form
    {
        public frm_KhuyenMai()
        {
            InitializeComponent();
            this.Size = new Size(1024, 768);

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void frm_KhuyenMai_Load(object sender, EventArgs e)
        {

        }
    }
}
