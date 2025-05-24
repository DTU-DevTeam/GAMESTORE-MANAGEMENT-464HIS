using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanNet.DTO;
namespace QuanLyQuanNet.DAO
{
    public class MenuDAO
    {
        private MenuDAO() { }
        private static MenuDAO instance;
        public static MenuDAO Instance
        {
            get { if (instance == null) instance = new MenuDAO(); return MenuDAO.instance; }
            private set { MenuDAO.instance = value; }
        }

        public List<DTO.Menu> GetListMenuByTable(int id)
        {
            List<DTO.Menu> listMenu = new List<DTO.Menu>();
            string query = $"SELECT f.ten, bi.count, f.price, f.price * bi.count AS totalPrice " +
                           $"FROM dbo.BillInfo AS bi, dbo.Bill AS b, dbo.Food AS f " +
                           $"WHERE bi.idBill = b.id AND bi.idFood = f.id AND b.status = 0 AND b.idComputer = {id}";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                QuanLyQuanNet.DTO.Menu menu = new QuanLyQuanNet.DTO.Menu(item);
                listMenu.Add(menu);
            }

            return listMenu;
        }
    }
}
