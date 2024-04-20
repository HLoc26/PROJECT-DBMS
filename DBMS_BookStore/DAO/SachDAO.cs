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
    internal class SachDAO
    {
        DBConnection dbConnection;
        DBConnection db = new DBConnection();
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
        //public DataTable LoadTCTG()
        //{
        //    string query = "SELECT * FROM dbo.VIEW_SACH";
        //    SqlCommand sql = new SqlCommand(query);
        //    DataTable dt = dbConnection.ExecuteQuery(sql);
        //    if (dt.Rows.Count > 0)
        //    {
        //        return dt;
        //    }
        //    return null;
        //}
        public static DataTable LoadTCTG(string tenTG, DBConnection dbConnection)
        {
            string query = "SELECT * FROM PROC_TCTG(@tenTG)";
            SqlCommand sql = new SqlCommand(query);
            sql.Parameters.AddWithValue("@tenTG", tenTG);
            DataTable dt = dbConnection.ExecuteQuery(sql);
            return dt;
        }

        public DataRow GetTCTG(string tenTG)
        {
            string query = "SELECT * FROM dbo.FUNC_TCTG(@param)";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@param", tenTG);

            DataTable dt = db.ExecuteQuery(cmd);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0];
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