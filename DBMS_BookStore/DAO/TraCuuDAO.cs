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
        public DataTable LoadTCSach()
        {
            string query = "SELECT * FROM dbo.VIEW_SACH";
            SqlCommand sql = new SqlCommand(query);
            DataTable dt = DBConnection.ExecuteQuery(sql);
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
            DataTable dt = DBConnection.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }
        public DataTable LoadTCNXB()
        {
            string query = "SELECT * FROM dbo.VIEW_SACHNXB";
            SqlCommand sqlCommand = new SqlCommand(query);
            DataTable dt = DBConnection.ExecuteQuery(sqlCommand);
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }
        public DataTable LoadTCTL()
        {
            string query = "SELECT * FROM dbo.VIEW_THELOAISACH";
            SqlCommand sqlCommand = new SqlCommand(query);
            DataTable dt = DBConnection.ExecuteQuery(sqlCommand);
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

            DataTable dt = DBConnection.ExecuteQuery(cmd);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0];
            }
            return null;
        }
        public DataTable LoadTCVPP()
        {
            string query = "SELECT * FROM dbo.VIEW_VPP";
            SqlCommand sql = new SqlCommand(query);
            DataTable dt = DBConnection.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }
        public DataTable SearchSACHByPartialMaSachOrTieuDe(string partialValue)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("PROC_SearchSACHByPartialMaSachOrTieuDe");
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@PartialValue", partialValue);
                return DBConnection.ExecuteQuery(sqlCommand);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return null;
            }
        }

        public DataTable SearchBooksByPartialAuthor(string partialAuthor)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("PROC_SearchBooksByPartialAuthor");
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@PartialAuthor", partialAuthor);
                return DBConnection.ExecuteQuery(sqlCommand);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return null;
            }
        }



        public DataTable SearchSachByPartialNXB(string PartialNXB)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("PROC_SearchSachByPartialNXB");
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@PartialNXB", PartialNXB);
                return DBConnection.ExecuteQuery(sqlCommand);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return null;
            }
        }
        public DataTable SearchSachByPartialTenLoai(string partialTenLoai)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("SearchSachByPartialTenLoai");
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@PartialTenLoai", partialTenLoai);
                return DBConnection.ExecuteQuery(sqlCommand);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return null;
            }
        }


        public DataTable SearchVPPByPartialTenHang(string partialTenHang)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("PROC_SearchVPPByPartialTenHang");
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@PartialTenHang", partialTenHang);
                return DBConnection.ExecuteQuery(sqlCommand);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return null;
            }
        }

    }
}