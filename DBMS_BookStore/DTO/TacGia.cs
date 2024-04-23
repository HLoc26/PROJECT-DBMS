using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_BookStore.DTO
{
    internal class TacGia
    {
        string maTG;
        string tenTG;

        public TacGia (string maTG, string tenTG)
        {
            MaTG = maTG;
            TenTG = tenTG;
        }
        
        public TacGia(DataRow dr)
        {
            MaTG = (string)dr[0];
            TenTG= (string)dr[1];
        }
        public string MaTG { get => maTG; set => maTG = value; }
        public string TenTG { get => tenTG; set => tenTG = value; }

        
    }
}
