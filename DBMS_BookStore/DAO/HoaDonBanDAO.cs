using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_BookStore.DAO
{
    internal class HoaDonBanDAO
    {
        DBConnection db = new DBConnection();

        //public int InsertBanHang(VatPham vatpham)
        //{
        //    string query = "EXEC dbo.PROC_AddGioHangVaoHoaDon @param1 , @param2 , @param3 , @param4 , @param5";
        //    SqlCommand cmd = new SqlCommand(query);
        //    cmd.Parameters.AddWithValue("@param1", vatpham.MaHoaDon);
        //    cmd.Parameters.AddWithValue("@param2", vatpham.MaKH);
        //    cmd.Parameters.AddWithValue("@param3", vatpham.MaNVBan);
        //    cmd.Parameters.AddWithValue("@param4", vatpham.MaHang);
        //    cmd.Parameters.AddWithValue("@param5", vatpham.SoLuong);

        //    int succeed = db.ExecuteNonQuery(cmd);
        //    return succeed;
        //}

        public string GetMaHoaDon()
        {
            string query = "SELECT dbo.FUNC_Create_MaHoaDonBan()";
            SqlCommand cmd = new SqlCommand(query);

            return (string)db.ExecuteScalar(cmd);
        }

        public DataTable GetListSaleReceipt(DateTime start, DateTime end)
        {
            string query = "EXEC PROC_GetListSaleReceiptByDate @NgayBatDau = @param1, @NgayKetThuc = @param2";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@param1", start);
            cmd.Parameters.AddWithValue("@param2", end);
        
            DataTable dt = db.ExecuteQuery(cmd);
            return dt;
        }
    }
}
