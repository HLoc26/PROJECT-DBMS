using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_BookStore.DTO
{
    internal class HoaDonBan
    {
        string maHoaDon;
        string maNVBan;
        string maKH;
        string maHang;
        DateTime thoiGian;
        int soLuong;
        double khuyenMai;


        public string MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public string MaNVBan { get => maNVBan; set => maNVBan = value; }
        public string MaKH { get => maKH; set => maKH = value; }
        public string MaHang { get => maHang; set => maHang = value; }
        public int SoLuong { get => SoLuong1; set => SoLuong1 = value; }
        public DateTime ThoiGian { get => thoiGian; set => thoiGian = value; }
        public int SoLuong1 { get => soLuong; set => soLuong = value; }
        public double KhuyenMai { get => khuyenMai; set => khuyenMai = value; }
    }
}
