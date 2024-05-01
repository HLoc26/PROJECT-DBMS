using DBMS_BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_BookStore.DAO
{
    internal class EmployeeDAO
    {
        public Employee GetInfoByCityZID(string cmnd)
        {
            string query = "EXEC PROC_GetNV_ByCityZID @CMND = @param";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@param", cmnd);

            DataTable dt = DBConnection.ExecuteQuery(cmd);
            if (dt.Rows.Count > 0)
                return new Employee(dt.Rows[0]);
            else return null;
        }

        public Employee GetInfoByUsername(string username)
        {
            string query = "EXEC PROC_GetNV_ByUsername @TenDN = @param";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@param", username);

            DataTable dt = DBConnection.ExecuteQuery(cmd);
            if(dt.Rows.Count > 0)
                return new Employee(dt.Rows[0]);
            else return null;
        }

        public Employee Login(string username, string password)
        {
            string query = "EXEC PROC_Login @TenDN = @param1, @MK = @param2";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@param1", username);
            cmd.Parameters.AddWithValue("@param2", password);

            DataTable dt = DBConnection.ExecuteQuery(cmd);
            if (dt.Rows.Count > 0)
            {
                Employee nv = new Employee(dt.Rows[0]);
                return nv;
            }
            else return null;
        }

        // Đăng ký thông tin và nhận về một mã NV
        public string Register(Employee emp)
        {
            string query = "EXEC dbo.PROC_Register @CMND = @param1 , @Ho = @param2 , @TenLot = @param3 ," +
                "@Ten = @param4 , @GioiTinh = @param5 , @TenDN = @param6 ,@MK = @param7 ";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@param1", emp.Cmnd);
            cmd.Parameters.AddWithValue("@param2", emp.Ho);
            cmd.Parameters.AddWithValue("@param3", emp.TenLot);
            cmd.Parameters.AddWithValue("@param4", emp.Ten);
            cmd.Parameters.AddWithValue("@param5", emp.GioiTinh);
            cmd.Parameters.AddWithValue("@param6", emp.TenDN);
            cmd.Parameters.AddWithValue("@param7", emp.Mk);
            
            string maNV = (string)DBConnection.ExecuteScalar(cmd);
            return maNV;
        }

        // Đổi MK
        public bool ChangePass(string newPass, string MaNV)
        {
            string query = "EXEC dbo.PROC_ChangePass @MaNV = @param1, @NewPass = @param2";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@param1", MaNV);
            cmd.Parameters.AddWithValue("@param2", newPass);

            int succeed = DBConnection.ExecuteNonQuery(cmd);
            return succeed == 1;
        }

        // Lấy lịch sử làm việc dựa vài tên ĐN
        public List<DateTime> GetLS(string tenDN)
        {
            string query = "SELECT * FROM FUNC_GetLoginHistory(@param)";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@param", tenDN);

            DataTable dt = DBConnection.ExecuteQuery(cmd);

            List<DateTime> ls = new List<DateTime>();
            foreach (DataRow dr in dt.Rows)
            {
                ls.Add((DateTime)dr[1]);
            }
            return ls;
        }
        //Tìm kiếm gần đúng bằng mã nv
        public DataTable GetInfoByMaNV(string tenNV)
        {
            string query = "EXEC dbo.PROC_GetNV_ByEmpID @MaNV = @param";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@param", tenNV);
            return DBConnection.ExecuteQuery(cmd);
        }

        //Tìm kiếm gần đúng bằng tên NV
        public DataTable GetInfoByTen(string tenNV)
        {
            string query = "EXEC dbo.PROC_GetNV_ByName @HoVaTen = @param";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@param", tenNV);
            return DBConnection.ExecuteQuery(cmd);
        }

        // Lấy thông tin liên quan đến nv
        public Employee GetNV(string MaNV)
        {
            string query = $"SELECT * FROM dbo.VIEW_NV_TK WHERE MaNV = '{MaNV}'";
            SqlCommand cmd = new SqlCommand(query);
            DataTable dt = DBConnection.ExecuteQuery(cmd);
            if (dt.Rows.Count > 0)
            {
                return new Employee(dt.Rows[0]);
            }
            return null;
        }

        public DataTable GetDSNV()
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM dbo.VIEW_NV");

            return DBConnection.ExecuteQuery(sqlCommand);
        }

        // Xoá thông tin nhân viên (cho nghỉ việc, set tình trạng làm việc thành nghỉ việc)
        public int XoaNV(string MaNV)
        {
            string query = "EXEC PROC_Delete_NV @MaNV = @param";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@param", MaNV);

            return DBConnection.ExecuteNonQuery(cmd);
        }

    }
}
