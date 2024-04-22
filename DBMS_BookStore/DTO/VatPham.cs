using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_BookStore.DTO
{
    internal class VatPham
    {
        string maHoaDon;
        string maNVBan;
        string maKH;
        string maHang;
        int soLuong;

        public VatPham(string maHoaDon, string maNVBan, string maKH, string maHang, int soLuong)
        {
            MaHoaDon = maHoaDon;
            MaNVBan = maNVBan;
            MaKH = maKH;
            MaHang = maHang;
            SoLuong = soLuong;
        }

        public string MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public string MaNVBan { get => maNVBan; set => maNVBan = value; }
        public string MaKH { get => maKH; set => maKH = value; }
        public string MaHang { get => maHang; set => maHang = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
    }
}
