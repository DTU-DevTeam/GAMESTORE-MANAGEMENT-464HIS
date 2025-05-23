using QuanLyQuanNet.DAO;
using QuanLyQuanNet.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanNet
{
    public partial class Frm_ComputerManager : Form
    {
      /*  private Account loginAccount;
        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount.Type); }
        }*/

        public Frm_ComputerManager()
        {
            InitializeComponent();
            //this.LoginAccount = acc;
            LoadTable();

            LoadCategory();
        }

        #region Method
     /*   void ChangeAccount(int type)
        {
            adminToolStripMenuItem.Enabled = type == 1;
            thôngTinCáNhânToolStripMenuItem.Text += " (" + LoginAccount.DisplayName + ")";
        }*/
        void LoadCategory() 
        {
            List<Category> categoryList = CategoryDAO.Instance.LoadCategoryList();
            cbCategory.DataSource = categoryList;
            cbCategory.DisplayMember = "Name";
        }
        void LoadFoodListByCategoryID(int id)
        {
            List<Food> foodList = FoodDAO.Instance.LoadFoodListByCategoryID(id);
            cbFood.DataSource = foodList;
            cbFood.DisplayMember = "Name"; 
        }

        void LoadTable()
        {
            flpTable.Controls.Clear();
            List<Table> tableList = TableDAO.Instance.LoadTableList();

            foreach (Table item in tableList) 
            { 
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Click += btn_Click;
                btn.Tag = item;
                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.LightGreen;
                        break;
                    case "Đang sử dụng":
                        btn.BackColor = Color.Red;
                        break;
                    default:
                        break;
                }
                flpTable.Controls.Add(btn);
            }
        }

        void ShowBill(int id)
        {
            lsvBill.Items.Clear();
            List<DTO.Menu> billinfor = MenuDAO.Instance.GetListMenuByTable(id);
            float totalPrice = 0;
            foreach (DTO.Menu item in billinfor)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;
                lsvBill.Items.Add(lsvItem);
            }
            CultureInfo c = new CultureInfo("vi-VN");

            //Thread.CurrentThread.CurrentCulture = c;
            txbTotalPrice.Text = totalPrice.ToString("c", c);
        }
        #endregion

        #region Event
        private void btn_Click(object sender, EventArgs e)
        {
            int tableID= ((sender as Button).Tag as Table).ID;
            lsvBill.Tag = (sender as Button).Tag;
            ShowBill(tableID);
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
             this.Close();
        }

     /*   private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_AccountProfile f = new frm_AccountProfile(loginAccount);
            f.UpdateAccount1 += f_UpdateAccount1;
            f.ShowDialog();
        }*/
     /*   void f_UpdateAccount1(object sender, AccountEvent e)
        {
            thôngTinCáNhânToolStripMenuItem.Text = "Thông tin cá nhân (" + e.Account.DisplayName + ")";
        }*/

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if(cb.SelectedItem == null) return;
            Category selected = cb.SelectedItem as Category;
            id = selected.Id;
            LoadFoodListByCategoryID(id);
        }
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
            int foodID = (cbFood.SelectedItem as Food).iD;
            int count = (int)nmFoodCount.Value;
            if (idBill == -1)
            {
                BillDAO.Instance.insertBill(table.ID);
                BillinforDAO.Instance.InsertBillinfor(BillDAO.Instance.GetMaxIDBill(),foodID ,count);
            }
            else
            {
                BillinforDAO.Instance.InsertBillinfor(idBill, foodID, count);
            }
            ShowBill(table.ID);
            LoadTable();
        }
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
            int discount = (int)nmDiscount.Value;
            double totalPrice = Convert.ToDouble(txbTotalPrice.Text.Split(',')[0]);
            double finalTotalPrice = totalPrice - (totalPrice / 100) * discount;
            if (idBill == -1)
            {
                MessageBox.Show("Không có hóa đơn nào");
                return;
            }

            string message = string.Format(
                "Bạn có chắc chắn muốn thanh toán hóa đơn cho máy {0}?\n\nTổng tiền: {1} VNĐ\nGiảm giá: {2}%\nThành tiền: {3} VNĐ",
                table.Name,
                totalPrice.ToString("N0"),
                discount,
                finalTotalPrice.ToString("N0")
            );

            DialogResult result = MessageBox.Show(message, "Xác nhận thanh toán", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                BillDAO.Instance.CheckOut(idBill, discount);
                ShowBill(table.ID);
                LoadTable();
            }
        }


        #endregion

        private void flpTable_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
