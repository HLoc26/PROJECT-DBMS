using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_BookStore.DTO
{
    internal class NXB
    {
        string maNXB;
        string tenNXB;
        string diaChi;
        string sdt;

        public NXB(string maNXB, string tenNXB, string diaChi, string sdt)
        {
            MaNXB = maNXB;
            TenNXB = tenNXB;
            DiaChi = diaChi;
            Sdt = sdt;
        }
        public NXB(DataRow dr)
        {
            MaNXB = (string)dr["MaNXB"];
            TenNXB = (string)dr["TenNXB"];
            DiaChi = (string)dr["DiaChi"];
            Sdt = (string)dr["SDT"];
        }

        public string MaNXB { get => maNXB; set => maNXB = value; }
        public string TenNXB { get => tenNXB; set => tenNXB = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Sdt { get => sdt; set => sdt = value; }
    }
}
