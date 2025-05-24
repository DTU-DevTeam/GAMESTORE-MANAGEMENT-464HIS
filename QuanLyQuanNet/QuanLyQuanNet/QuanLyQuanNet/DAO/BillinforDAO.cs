using QuanLyQuanNet.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanNet.DAO
{
    public class BillinforDAO
    {
        private static BillinforDAO instance;
        public static BillinforDAO Instance
        {
            get { if (instance == null) instance = new BillinforDAO(); return BillinforDAO.instance; }
            private set { BillinforDAO.instance = value; }
        }
        private BillinforDAO() { }
        public List<Billinfor> GetListBillinforByBillID(int id)
        {
           List<Billinfor> billinfors = new List<Billinfor>();
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from dbo.BillInfo where idBill =" + id);
            foreach (DataRow item in data.Rows) 
            {
                Billinfor billinfor = new Billinfor(item);
                billinfors.Add(billinfor);
            }
            return billinfors;
        }
        public void InsertBillinfor(int billID, int foodID, int count)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_InsertBillInfo @idBill , @idFood , @count", new object[] { billID, foodID, count });
        }
    }
}
