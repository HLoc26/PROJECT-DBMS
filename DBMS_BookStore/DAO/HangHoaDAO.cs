using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_BookStore.DAO
{
    internal class HangHoaDAO
    {


        // Hàm trả về một datarow của hàng hoá dựa vào mã hàng
        // dữ liệu trả về gồm mã hàng, tên hàng, đơn giá, số lượng còn lại.
        public DataRow GetHangHoa(string maHang)
        {
            string query = "SELECT * FROM dbo.FUNC_Get_HangHoa(@param)";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@param", maHang);

            DataTable dt = DBConnection.ExecuteQuery(cmd);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0];
            }
            return null;
        }

        // Hàm trả về toàn bộ thông tin sách
        public DataRow GetSach(string maSach)
        {
            string query = "SELECT * FROM dbo.FUNC_Get_TTSach(@param)";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@param", maSach);

            DataTable dt = DBConnection.ExecuteQuery(cmd);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0];
            }
            return null;
        }
        // Hàm trả về toàn bộ thông tin vpp
        public DataRow GetVPP(string maSach)
        {
            string query = "SELECT * FROM dbo.FUNC_Get_TTVPP(@param)";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@param", maSach);

            DataTable dt = DBConnection.ExecuteQuery(cmd);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0];
            }
            return null;
        }
    }
}
