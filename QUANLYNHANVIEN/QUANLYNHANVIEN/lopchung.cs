using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLYNHANVIEN
{
    class lopchung
    {
        SqlConnection conn;

        public lopchung()
        {
            conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\GAMESTORE-MANAGEMENT-464HIS\QUANLYNHANVIEN\QUANLYNHANVIEN\QLNV.mdf;Integrated Security=True");
        }

        public int Themsuaxoa(string SqlString)
        {
            SqlCommand comn = new SqlCommand(SqlString, conn);

            conn.Open();
            int kq = comn.ExecuteNonQuery();

            conn.Close();

            return kq;
        }


        public DataTable LoadDl(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, conn); 
            DataTable dt = new DataTable();
            
            da.Fill(dt);

            return dt;
          
        }
    }
}
