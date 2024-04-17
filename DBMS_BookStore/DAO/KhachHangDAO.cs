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
        public TheTV GetInforByCustomerID(string maKH)
        {
            string query = "EXEC PROC_ShowKH_ByCusID @MaKH = @param";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@param", maKH);

            DataTable dt = db.ExecuteQuery(cmd);
            if (dt.Rows.Count > 0)
                return new TheTV(dt.Rows[0]);
            else return null;
        }
    }
}