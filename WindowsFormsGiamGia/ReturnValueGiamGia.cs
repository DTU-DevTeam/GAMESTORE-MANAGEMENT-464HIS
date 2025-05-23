using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsGiamGia
{
    public class ReturnValueGiamGia
    {
        DataRepository dataRepository;

        public ReturnValueGiamGia()
        {
            dataRepository = new DataRepository();
        }

        public int ReturnValueDiscount(int sotien, string maGiamGia)
        {
           object giamgiaobject = dataRepository.TimPhieuGiamGia(maGiamGia);

            DataRow row = giamgiaobject as DataRow;

            if (row != null)
            {
                int mucgiamapdung = int.Parse(row["MucGiamGiaApDung"].ToString());
                int soLuongApDung = int.Parse(row["SoLuongApDung"].ToString());
                int mucGiamGiaToiDa = int.Parse(row["MucGiamGiaToiDa"].ToString());
                int giamGia = int.Parse(row["GiamGia"].ToString());


                DateTime ngayKetThuc = Convert.ToDateTime(row["NgayKetThuc"]);

                if(sotien < mucgiamapdung)
                {
                    return 0;
                }

                if (ngayKetThuc <= DateTime.Now) return 0;

                if (soLuongApDung == 0) return 0;

                int giam =  (sotien * giamGia)/100;
                
                if(giam > mucGiamGiaToiDa)
                {
                    giam = mucGiamGiaToiDa;

                    return giam;
                }

                return giam;
            }
            else
            {
                return 0;
            }


        }
    }
}
