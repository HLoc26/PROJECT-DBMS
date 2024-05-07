using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBMS_BookStore.DTO;
using System.Windows.Forms;

namespace DBMS_BookStore.DAO
{
 
    public class KhachHangDAO
    {
        //Tạo khách hàng mới
        public string createCustomer(KhachHang kh)
        {
            string query = "EXEC dbo.PROC_Create_Customer @MaKH = @param1 , @Ho = @param2 , @TenLot = @param3 ," +
                "@Ten = @param4 , @NgaySinh = @param5 , @GioiTinh = @param6, @SoDiem = @param7 ";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@param1", kh.MaKH);
            cmd.Parameters.AddWithValue("@param2", kh.Ho);
            cmd.Parameters.AddWithValue("@param3", kh.TenLot);
            cmd.Parameters.AddWithValue("@param4", kh.Ten);
            cmd.Parameters.AddWithValue("@param5", kh.NgaySinh);
            cmd.Parameters.AddWithValue("@param6", kh.GioiTinh);
            cmd.Parameters.AddWithValue("@param7", kh.SoDiem);

            string MaThe = (string)DBConnection.ExecuteScalar(cmd);
            return MaThe;
        }

        //Tìm kiếm khách hàng theo mã khách hàng
        public DataTable GetInforByCusID(string MaKH)
        {
            string query = "EXEC PROC_GetKH_ByCusID @MaKH = @param";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@param", MaKH);
            return DBConnection.ExecuteQuery(cmd);
        }
        //Show thông tin thẻ thành viên
        public KhachHang ShowMembership(string MaKH)
        {
            string query = $"SELECT * FROM dbo.FUNC_GetKH WHERE MaNV = '{MaKH}'";
            SqlCommand cmd = new SqlCommand(query);
            DataTable dt = DBConnection.ExecuteQuery(cmd);
            if (dt.Rows.Count > 0)
                return new KhachHang(dt.Rows[0]);
            else return null;
        }
        public int GetSoLuongKH()
        {
            string query = "SELECT dbo.FUNC_SoLuongKH ()";
            SqlCommand cmd = new SqlCommand(query);

            return (int)DBConnection.ExecuteScalar(cmd);
        }
        public DataTable GetDSKH()
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM dbo.VIEW_KH");

            return DBConnection.ExecuteQuery(sqlCommand);
        }

        public float GetDiscountValue(string MaKH)
        {
            string query = "SELECT dbo.FUNC_GetDiscount(@param)";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@param", MaKH);
            return (float)DBConnection.ExecuteScalar(cmd);
        }
    }
}