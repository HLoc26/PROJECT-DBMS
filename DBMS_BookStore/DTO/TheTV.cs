using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_BookStore.DTO
{
    public class TheTV
	{
        string maThe;
        int soDiem;
        string tenBacTV;
        string maKH;

        public TheTV(int soDiem, string tenBacTV, string maKH)
        {
            SoDiem = 0;
            TenBacTV = tenBacTV;
            MaKH = maKH;
        }
        public TheTV(DataRow dr)
        {
            MaThe = dr["MaThe"].ToString();
            SoDiem = (int)dr["SoDiem"];
            TenBacTV = dr["TenBacTV"].ToString();
            MaKH = dr["MaKH"].ToString();

        }
        public string MaThe { get => maThe; set => maThe = value; }
        public int SoDiem { get => soDiem; set => soDiem = value; }
        public string TenBacTV { get => tenBacTV; set => tenBacTV = value; }
        public string MaKH { get => maKH; set => maKH = value; }
    }

}
