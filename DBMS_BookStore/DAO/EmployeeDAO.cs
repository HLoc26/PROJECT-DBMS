using DBMS_BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_BookStore.DAO
{
    internal class EmployeeDAO
    {
        DBConnection db = new DBConnection();

        public Employee GetInfoByCityZID(string cmnd)
        {
            string query = "EXEC PROC_GetNV_ByCityZID @CMND = @param";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@param", cmnd);

            DataTable dt = db.ExecuteQuery(cmd);
            if (dt.Rows.Count > 0)
                return new Employee(dt.Rows[0]);
            else return null;
        }

        public Employee GetInfoByEmpID(string maNV)
        {
            string query = "EXEC PROC_GetNV_ByEmpID @MaNV = @param";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@param", maNV);

            DataTable dt = db.ExecuteQuery(cmd);
            if(dt.Rows.Count > 0)
                return new Employee(dt.Rows[0]);
            else return null;
        }

        public Employee GetInfoByUsername(string username, string password)
        {
            string query = "EXEC PROC_Login @TenDN = @param1, @MK = @param2";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@param1", username);
            cmd.Parameters.AddWithValue("@param2", password);

            DataTable dt = db.ExecuteQuery(cmd);
            if (dt.Rows.Count > 0)
                return new Employee(dt.Rows[0]);
            else return null;
        }
    }
}
