using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;

namespace DBMS_BookStore.DAO
{
    internal class TraCuuDAO
    {
        DBConnection dbConnection;
        DBConnection db = new DBConnection();
        public TraCuuDAO()
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
        public DataTable LoadTCTG()
        {
            string query = "SELECT MaSach, tenTG, TieuDe, DonGia, TenLoai FROM dbo.VIEW_SACH";
            SqlCommand sql = new SqlCommand(query);
            DataTable dt = dbConnection.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }
        public DataTable LoadTCVPP()
        {
            string query = "SELECT * FROM dbo.VIEW_VPP";
            SqlCommand sql = new SqlCommand(query);
            DataTable dt = dbConnection.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }
        public DataRow GetTCTG(string tenTG)
        {
            string query = "SELECT * FROM dbo.PROC_TCTG(@param)";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@param", tenTG);

            DataTable dt = db.ExecuteQuery(cmd);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0];
            }
            return null;
        }
        public DataTable SearchBooksByAuthor(string authorName)
        {
            // Create SqlCommand for the stored procedure
            SqlCommand sqlCommand = new SqlCommand("SearchBooksByAuthor");
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@tenTG", authorName);

            // Execute the query using DBConnection and return the result
            return dbConnection.ExecuteQuery(sqlCommand);
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
        public DataTable SearchVPPByMaHang(string maHang)
        {
            SqlCommand sqlCommand = new SqlCommand("SearchVPPByMaHang");
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@MaHang", maHang);

            return dbConnection.ExecuteQuery(sqlCommand);
        }

    }
}