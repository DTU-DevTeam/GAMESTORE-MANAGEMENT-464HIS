using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsGiamGia
{
    public class DataRepository
    {
        private SqlConnection _Sqlconnection;

        public DataRepository()
        {
            _Sqlconnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\GAMESTORE-MANAGEMENT-464HIS\WindowsFormsGiamGia\QLTiemNet.mdf;Integrated Security=True");
        }

        public DataTable LoadDL(string sql)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(sql, _Sqlconnection);

            DataTable dt = new DataTable();

            _Sqlconnection.Open();

            adapter.Fill(dt);

            _Sqlconnection.Close();

            return dt;
        }

        public int ThemSuaXoa(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, _Sqlconnection);
            _Sqlconnection.Open();

            int kq = cmd.ExecuteNonQuery();

            _Sqlconnection.Close();

            return kq;
        }


        public DataRow TimPhieuGiamGia(string maGiamGia)
        {
            string sql = $"Select * from GiamGia Where MaKM = '{maGiamGia}'";

            //SqlCommand cmd = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, _Sqlconnection);

            DataTable dataTable = new DataTable();

            _Sqlconnection.Open();

            adapter.Fill(dataTable);

            _Sqlconnection.Close();

            return dataTable.Rows[0]; 


        }
       
    }
}
