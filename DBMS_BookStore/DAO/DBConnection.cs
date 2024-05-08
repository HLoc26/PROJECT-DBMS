using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_BookStore.DAO
{
    public static class DBConnection
    {
        public static string username;
        public static string password;
        static string connString = $"Data Source= (localdb)\\mssqllocaldb;Initial Catalog=Proj_DBMS_BookStore;User ID={username}; Password={password}";
        static SqlConnection SqlConn = new SqlConnection();

        public static DataTable ExecuteQuery(SqlCommand sqlCommand)
        {
            connString = $"Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Proj_DBMS_BookStore;User ID={username}; Password={password}";
            SqlConn.ConnectionString = connString;
            DataTable dataTable = new DataTable();
            try
            {
                SqlConn.Open();

                sqlCommand.Connection = SqlConn;

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " From ExecuteQuery");
            }
            finally { SqlConn.Close(); }
            return dataTable;
        }

        public static int ExecuteNonQuery(SqlCommand sqlCommand)
        {
            connString = $"Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Proj_DBMS_BookStore;User ID={username}; Password={password}";
            SqlConn.ConnectionString = connString;
            int succeed = 0;
            try
            {
                SqlConn.Open();

                sqlCommand.Connection = SqlConn;

                succeed = sqlCommand.ExecuteNonQuery();
                if (succeed > 0)
                {
                    MessageBox.Show("Succeed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " From ExecuteNonQuery");
            }
            finally { SqlConn.Close(); }
            return succeed;
        }

        // Trả về dòng cột đầu tiên của bảng trả về, những dòng, cột khác kệ
        public static object ExecuteScalar(SqlCommand sqlCommand)
        {
            connString = $"Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Proj_DBMS_BookStore;User ID={username}; Password={password}";
            SqlConn.ConnectionString = connString;
            object obj = new object();
            try
            {
                SqlConn.Open();     

                sqlCommand.Connection = SqlConn;

                obj = sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " From ExecuteNonQuery");
            }
            finally { SqlConn.Close(); }
            return obj;
        }
    }
}
