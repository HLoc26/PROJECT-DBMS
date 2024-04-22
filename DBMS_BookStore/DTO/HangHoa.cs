using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_BookStore.DTO
{
    internal class HangHoa
    {
        protected string maHang;
        protected string tenHang;
        protected int donGia;
        protected int soLuongNhap;
        private int soLuongCon;

        public HangHoa()
        {
            MaHang = string.Empty;
            tenHang = string.Empty;
            soLuongNhap = 0;
            DonGia = 0;
        }
        public HangHoa(string maHang, string tenHang, int donGia, int soLuongNhap)
        {
            MaHang = maHang;
            TenHang = tenHang;
            DonGia = donGia;
            SoLuongNhap = soLuongNhap;
        }
        public HangHoa(DataRow dr)
        {
            MaHang = (string)dr[0];
            TenHang = (string)dr[1];
            DonGia = (int)dr[2];
            SoLuongNhap = (int)dr[3];
        }
        public string MaHang { get => maHang; set => maHang = value; }
        public string TenHang { get => tenHang; set => tenHang = value; }
        public int DonGia { get => donGia; set => donGia = value; }
        public int SoLuongNhap { get => soLuongNhap; set => soLuongNhap = value; }
        protected int SoLuongCon { get => soLuongCon; set => soLuongCon = value; }
    }
}
