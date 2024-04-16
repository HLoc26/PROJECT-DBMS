using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_BookStore.DTO
{
    internal class TheTV
	{
        string maThe;
        int soDiem;
        string tenBacTV;
        DateTime ngayBatDau;
        DateTime ngayKetThuc;
        string maKH;

        public TheTV(string maThe, int soDiem, string tenBacTV, DateTime ngayBatDau, DateTime ngayKetThuc, string maKH)
        {
            MaThe = maThe;
            SoDiem = 0;
            TenBacTV = tenBacTV;
            NgayBatDau = ngayBatDau;
            NgayKetThuc = ngayKetThuc;
            MaKH = maKH;
        }
        public TheTV(DataRow dr)
        {
            MaThe = dr["MaThe"].ToString();
            SoDiem = (int)dr["SoDiem"];
            TenBacTV = dr["TenBacTV"].ToString();
            NgayBatDau = (DateTime)dr["NgayBatDau"];
            NgayKetThuc = (DateTime)dr["NgayKetThuc"];
            MaKH = dr["MaKH"].ToString();

        }
        public string MaThe { get => maThe; set => maThe = value; }
        public int SoDiem { get => soDiem; set => soDiem = value; }
        public string TenBacTV { get => tenBacTV; set => tenBacTV = value; }
        public DateTime NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        public DateTime NgayKetThuc { get => ngayKetThuc; set => ngayKetThuc = value; }
        public string MaKH { get => maKH; set => maKH = value; }
    }

}
