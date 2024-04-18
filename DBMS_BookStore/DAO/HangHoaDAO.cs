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
        DBConnection db = new DBConnection();


        // Hàm trả về một datarow của hàng hoá dựa vào mã hàng
        // dữ liệu trả về gồm mã hàng, tên hàng, đơn giá, số lượng còn lại.
        public DataRow GetHangHoa(string maHang)
        {
            string query = "SELECT * FROM dbo.FUNC_Get_HangHoa(@param)";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@param", maHang);

            DataTable dt = db.ExecuteQuery(cmd);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0];
            }
            return null;
        }
    }
}
