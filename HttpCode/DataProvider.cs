using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace FoodDoAn.HttpCode
{
    public class DataProvider
    {
        public static SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-SB4FNSQ\SQLEXPRESS;Initial Catalog=Food_Sale;Integrated Security=True");
        public static void Connect()
        {
            if (ConnectionState.Broken == conn.State || ConnectionState.Closed == conn.State)
            {
                conn.Open();
            }
        }

        public static bool executeNonQuery(string sQuery, SqlParameter[] sParams)
        {
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sQuery, conn);
                cmd.Parameters.AddRange(sParams);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        //lấy về id tang tụ đông

        public static int executeScalar(string sQuery, SqlParameter[] sParams)
        {
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sQuery, conn);
                cmd.Parameters.AddRange(sParams);
                cmd.ExecuteNonQuery();
                sQuery = "Select * @@identity";
                cmd = new SqlCommand(sQuery, conn);
                int id = (int)cmd.ExecuteScalar();
                conn.Close();
                return id;
            }
            catch (Exception err)
            {

                throw;
            }

        }

        public static DataTable getDataTable(string sQuery, SqlParameter[] sParams)
        {
            try
            {
                Connect();
                SqlDataAdapter da = new SqlDataAdapter(sQuery, conn);
                //cmd.Parameters.AddRange(sParams);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
            catch (Exception err)
            {

                throw;
            }

        }

        // Lấy username tồn tại 
        public static bool executeQuey(string sQuery, SqlParameter sParams)
        {
            bool flag = false;
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sQuery, conn);
                cmd.Parameters.Add(sParams);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    flag = true;
                }
                conn.Close();

            }
            catch (Exception)
            {

                return false;
            }
            return flag;
        }

        // laasys rows theo username
       public static DataTable getUserName(string sQuery)
        {
            try
            {
                Connect();
                SqlDataAdapter da = new SqlDataAdapter(sQuery, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
            catch (Exception err)
            {

                throw;
            }
        }
        public static bool deleteUsername(string sQuery)
        {
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sQuery,conn);
               // cmd.Parameters.Add(sParams);

                SqlDataReader raeder = cmd.ExecuteReader();
                conn.Close();
                return true;
            }
            catch (Exception err)
            {

                return false;
            }
        }




    }
}