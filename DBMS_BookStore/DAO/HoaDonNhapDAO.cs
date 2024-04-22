﻿using System;
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
        DBConnection db = new DBConnection();

        public DataTable GetListGoodReceipt(DateTime start, DateTime end)
        {
            string query = "EXEC PROC_GetListGoodReceiptByDate @NgayBatDau = @param1, @NgayKetThuc = @param2";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@param1", start);
            cmd.Parameters.AddWithValue("@param2", end);

            DataTable dt = db.ExecuteQuery(cmd);
            return dt;
        }
        public int GetTongTienNhap(DateTime start, DateTime end)
        {
            string query = "SELECT dbo.FUNC_TOTAL_SALE_AMOUNT (@param1, @param2)";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@param1", start);
            cmd.Parameters.AddWithValue("@param2", end);

            return (int)db.ExecuteScalar(cmd);
        }
    }
}
