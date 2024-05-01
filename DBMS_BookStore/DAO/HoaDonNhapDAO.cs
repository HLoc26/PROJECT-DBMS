using DBMS_BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_BookStore.DAO
{
    internal class HoaDonNhapDAO
    {

        public int InsertNhapHang(string maDonNhap, string maNVNhap, HangHoa hang)
        {
            string query = "EXEC dbo.PROC_NhapHang @param1 , @param2 , @param3 , @param4 ";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@param1", maDonNhap);
            cmd.Parameters.AddWithValue("@param2", maNVNhap);
            cmd.Parameters.AddWithValue("@param3", hang.MaHang);
            cmd.Parameters.AddWithValue("@param4", hang.SoLuongNhap);

            int succeed = DBConnection.ExecuteNonQuery(cmd);
            return succeed;
        }

        public string GetMaDonNhap()
        {
            string query = "SELECT dbo.FUNC_Create_MaHoaDonNhap()";
            SqlCommand cmd = new SqlCommand(query);

            return (string)DBConnection.ExecuteScalar(cmd);
        }

        public DataTable GetListGoodReceipt(DateTime start, DateTime end)
        {
            string query = "EXEC PROC_GetListGoodReceiptByDate @NgayBatDau = @param1, @NgayKetThuc = @param2";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@param1", start);
            cmd.Parameters.AddWithValue("@param2", end);

            DataTable dt = DBConnection.ExecuteQuery(cmd);
            return dt;
        }

        public int GetTongTienNhap(DateTime date)
        {
            string query = "SELECT dbo.FUNC_TOTAL_EXPENSES (@param)";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@param", date);

            return (int)DBConnection.ExecuteScalar(cmd);
        }
    }
}
