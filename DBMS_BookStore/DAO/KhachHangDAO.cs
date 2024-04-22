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
    internal class KhachHangDAO
    {
        DBConnection db = new DBConnection();

        //Tạo khách hàng mới
        public string createCustomer(KhachHang khachHang, TheTV theTV)
        {
            string query = "EXEC dbo.PROC_Create_Customer @MaKH = @param1 , @Ho = @param2 , @TenLot = @param3 ," +
                "@Ten = @param4 , @NgaySinh = @param5 , @GioiTinh = @param6 ,@MaThe = @param7, @SoDiem = @param8 ";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@param1", khachHang.MaKH);
            cmd.Parameters.AddWithValue("@param2", khachHang.Ho);
            cmd.Parameters.AddWithValue("@param3", khachHang.TenLot);
            cmd.Parameters.AddWithValue("@param4", khachHang.Ten);
            cmd.Parameters.AddWithValue("@param5", khachHang.NgaySinh);
            cmd.Parameters.AddWithValue("@param6", khachHang.GioiTinh);
            cmd.Parameters.AddWithValue("@param7", theTV.MaThe);
            cmd.Parameters.AddWithValue("@param7", theTV.SoDiem);

            string maNV = (string)db.ExecuteScalar(cmd);
            return maNV;
        }

        //Tìm kiếm khách hàng theo mã khách hàng
        public KhachHang GetInforByCusID(string MaKH)
        {
            string query = "EXEC PROC_GetKH_ByCusID @MaKH = @param";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@param", MaKH);

            DataTable dt = db.ExecuteQuery(cmd);
            if (dt.Rows.Count > 0)
                return new KhachHang(dt.Rows[0]);
            else return null;
        }

        //Tìm kiém khách hàng theo mã thẻ thành viên
        public KhachHang GetInforByMemID(string MaThe)
        {
            string query = "EXEC PROC_GetKH_ByMemID @Mathe = @param";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@param", MaThe);

            DataTable dt = db.ExecuteQuery(cmd);
            if (dt.Rows.Count > 0)
                return new KhachHang(dt.Rows[0]);
            else return null;
        }

        //Show thông tin thẻ thành viên
        public KhachHang ShowMembership(string MaKH)
        {
            string query = "SELECT * FROM dbo.FUNC_GetKH (@param)";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@param", MaKH);
            DataTable dt = db.ExecuteQuery(cmd);
            if (dt.Rows.Count > 0)
                return new KhachHang(dt.Rows[0]);
            else return null;
        }
    }
}