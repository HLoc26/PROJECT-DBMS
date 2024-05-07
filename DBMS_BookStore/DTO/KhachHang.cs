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
        string maThe;
        int soDiem;
        string tenBacTV;

        public KhachHang(string maKH, string ho, string tenLot, string ten, DateTime ngaySinh, string gioiTinh, int soDiem, string tenBacTV)
        {
            MaKH = maKH;
            Ho = ho;
            TenLot = tenLot;
            Ten = ten;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            SoDiem = 0;
            TenBacTV = tenBacTV;
        }

        public KhachHang(DataRow dr)
        {
            MaKH = dr["MaKH"].ToString();
            Ho = dr["Ho"].ToString();
            TenLot = dr["TenLot"].ToString();
            Ten = dr["Ten"].ToString();
            NgaySinh = (DateTime)dr["ngaySinh"];
            GioiTinh = dr["GioiTinh"].ToString();
            MaThe = dr["MaThe"].ToString();
            SoDiem = (int)dr["SoDiem"];
            TenBacTV = dr["TenBacTV"].ToString();

        }
        public string MaKH { get => maKH; set => maKH = value; }
        public string Ho { get => ho; set => ho = value; }
        public string TenLot { get => tenLot; set => tenLot = value; }
        public string Ten { get => ten; set => ten = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string MaThe { get => maThe; set => maThe = value; }
        public int SoDiem { get => soDiem; set => soDiem = value; }
        public string TenBacTV { get => tenBacTV; set => tenBacTV = value; }
    }
}