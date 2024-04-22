using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_BookStore.DTO
{
    public class KhachHang
    {
        string maKH;
        string ho;
        string tenLot;
        string ten;
        DateTime ngaySinh;
        string gioiTinh;
        TheTV thanhVien;

        public KhachHang(string maKH, string ho, string tenLot, string ten, DateTime ngaySinh, string gioiTinh, TheTV thanhVien)
        {
            MaKH = maKH;
            Ho = ho;
            TenLot = tenLot;
            Ten = ten;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            ThanhVien = thanhVien;
        }

        public KhachHang(DataRow dr)
        {
            MaKH = dr["MaKH"].ToString();
            Ho = dr["Ho"].ToString();
            TenLot = dr["TenLot"].ToString();
            Ten = dr["Ten"].ToString();
            NgaySinh = (DateTime)dr["ngaySinh"];
            GioiTinh = dr["GioiTinh"].ToString();

        }
        public string MaKH { get => maKH; set => maKH = value; }
        public string Ho { get => ho; set => ho = value; }
        public string TenLot { get => tenLot; set => tenLot = value; }
        public string Ten { get => ten; set => ten = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public TheTV ThanhVien { get => thanhVien; set => thanhVien = value; }
    }
}