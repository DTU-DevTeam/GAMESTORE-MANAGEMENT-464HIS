using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanNet.DTO
{
    public class Bill
    {
        public Bill(int id, DateTime? dateCheckin, DateTime? dateCheckout, int status, int discount=0)
        {
            this.ID = id;
            this.DateCheckIn = dateCheckin;
            this.DateCheckOut = dateCheckout;
            this.Status = status;
            this.Discount = discount;
   
        }
        public Bill(DataRow row)
        {
            this.iD = (int)row["ID"];
            this.dateCheckIn = (DateTime?)row["DateCheckIn"];
            var dateCheckOutTemp = row["DataCheckOut"];
            if (dateCheckOutTemp.ToString() != "")
            {
                this.dateCheckOut = (DateTime?)dateCheckOutTemp;
            }
            else
            {
                this.dateCheckOut = null;
            }
            this.Status = (int)row["Status"];
            this.Discount = (int)row["Discount"];
        }
        private int discount;
        public int Discount
        {
            get { return discount; }
            set { discount = value; }
        }
        private int status;
        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        private DateTime? dateCheckOut;
        public DateTime? DateCheckOut
        {
            get { return dateCheckOut; }
            set { dateCheckOut = value; }
        }
        private DateTime? dateCheckIn;
        public DateTime? DateCheckIn
        {
            get { return dateCheckIn; }
            set { dateCheckIn = value; }
        }
        private int iD;
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
    }
}
