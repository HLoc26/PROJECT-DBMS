using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_BookStore.DTO
{
    internal class Sach : HangHoa
    {
        string tacGia;
        string nxb;
        string theLoai;

        public Sach()
        {
            TacGia = string.Empty;
            Nxb = string.Empty;
            TheLoai = string.Empty;
        }
        public Sach(string maHang, string tenHang, int donGia, int soLuong, string tacGia, string nxb, string theLoai)
            : base(maHang, tenHang, donGia, soLuong)
        {
            TacGia = tacGia;
            Nxb = nxb;
            TheLoai = theLoai;
        }

        public Sach(DataRow dr) : base(dr)
        {
            TacGia = (string)dr[4];
            TheLoai = (string)dr[5];
            Nxb = (string)dr[6];
        }

        public string TacGia { get => tacGia; set => tacGia = value; }
        public string Nxb { get => nxb; set => nxb = value; }
        public string TheLoai { get => theLoai; set => theLoai = value; }
    }
}
