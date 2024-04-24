using DBMS_BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DBMS_BookStore.DAO
{
    internal class ThemTTSachDAO
    {

        public NXB CheckMaNXB(string maNXB)
        {
            string query = "SELECT * FROM dbo.FUNC_GetTTNXB(@param)";
            SqlCommand cmd = new SqlCommand(query);

            cmd.Parameters.AddWithValue("@param", maNXB);
            DataTable dt = DBConnection.ExecuteQuery(cmd);
            if (dt.Rows.Count > 0)
            {
                return new NXB(dt.Rows[0]);
            }
            return null;
        }
        public TacGia CheckMaTG(string maTG)
        {
            string query = "SELECT * FROM dbo.FUNC_GetTTacGia(@param)";
            SqlCommand cmd = new SqlCommand(query);

            cmd.Parameters.AddWithValue("@param", maTG);
            DataTable dt = DBConnection.ExecuteQuery(cmd);
            if (dt.Rows.Count > 0)
            {
                return new TacGia(dt.Rows[0]);
            }
            return null;
        }

        public string GetMaNXB(string tenNXB)
        {
            string query = "SELECT dbo.FUNC_CreateMaNXB(@param)";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@param", tenNXB);

            string maNXB = (string)DBConnection.ExecuteScalar(cmd);
            return maNXB;
        }

        public string GetMaTG(string tenTacGia)
        {
            string query = "SELECT dbo.FUNC_CreateMaTG(@param)";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@param", tenTacGia);

            string maTG = (string)DBConnection.ExecuteScalar(cmd);
            return maTG;
        }

        public string GetMaSach(string tieuDe)
        {
            string query = "SELECT dbo.FUNC_CreateMaSach(@param)";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@param", tieuDe);

            string maSach = (string)DBConnection.ExecuteScalar(cmd);
            return maSach;
        }

        public string GetMaTheLoai(string tenLoai)
        {
            string query = $"SELECT MaLoai FROM dbo.THE_LOAI WHERE TenLoai = {tenLoai}";
            SqlCommand cmd = new SqlCommand(query);
            string maLoai = (string)DBConnection.ExecuteScalar(cmd);
            return maLoai;
        }

        public void InsertData(NXB nxb, TacGia tg, Sach sach, int namXB)
        {
            // Add sách vào hàng hoá
            string query = "EXEC PROC_AddBookInfo @MaNXB ,@TenNXB ,@DiaChi " +
                ",@SDT ,@MaHang ,@DonGia ,@SoLuongNhap ,@TieuDe ,@NamXB ,@MaTG ,@TenTG ,@TheLoai";
            SqlCommand command = new SqlCommand(query);
            command.Parameters.AddWithValue("@MaNXB", nxb.MaNXB);
            command.Parameters.AddWithValue("@TenNXB", nxb.TenNXB);
            command.Parameters.AddWithValue("@DiaChi", nxb.DiaChi);
            command.Parameters.AddWithValue("@SDT", nxb.Sdt);
            command.Parameters.AddWithValue("@MaHang", sach.MaHang);
            command.Parameters.AddWithValue("@DonGia", sach.DonGia);
            command.Parameters.AddWithValue("@SoLuongNhap", sach.SoLuongNhap);
            command.Parameters.AddWithValue("@TieuDe", sach.TenHang);
            command.Parameters.AddWithValue("@NamXB", namXB);
            command.Parameters.AddWithValue("@MaTG", tg.MaTG);
            command.Parameters.AddWithValue("@TenTG", tg.TenTG);
            command.Parameters.AddWithValue("@TheLoai", sach.TheLoai);

            DBConnection.ExecuteNonQuery(command);
        }
    }
}
