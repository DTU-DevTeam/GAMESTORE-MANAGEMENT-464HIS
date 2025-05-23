using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanNet.DTO
{
    public class Billinfor
    {
        public Billinfor(int id, int count, int foodID, int billID)
        {
            this.ID = id;
            this.Count = count;
            this.FoodID = foodID;
            this.BillID = billID;
        }
        public Billinfor(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.Count = (int)row["Count"];
            this.FoodID = (int)row["idFood"];
            this.BillID = (int)row["idBill"];
        }
        private int count;
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        private int foodID;
        public int FoodID
        {
            get { return foodID; }
            set { foodID = value; }
        }
        private int billID;
        public int BillID
        {
            get { return billID; }
            set { billID = value; }
        }
        private int iD;
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

    }
}
