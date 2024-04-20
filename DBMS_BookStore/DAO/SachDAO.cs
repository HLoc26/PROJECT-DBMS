using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DBMS_BookStore.DAO
{
    internal class SachDAO
    {
        DBConnection dbConnection;

        public SachDAO()
        {
            dbConnection = new DBConnection();
        }

        public DataTable LoadTCSach()
        {
            string query = "SELECT * FROM dbo.VIEW_SACH";
            SqlCommand sql = new SqlCommand(query);
            DataTable dt = dbConnection.ExecuteQuery(sql);
            if(dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }


        public DataTable SearchSACHByMaHang(string maHang)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("SearchSACHByMaHang");
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@MaHang", maHang);
                return dbConnection.ExecuteQuery(sqlCommand);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return null;
            }
        }
}}