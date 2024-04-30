using DBMS_BookStore.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DBMS_BookStore.DTO
{
    public class Employee
    {
        string maNV;
        string cmnd;
        string ho;
        string tenLot;
        string ten;
        string gioiTinh;
        int luong;
        string tenDN;
        string mk;
        bool tinhTrangLamViec;
        List<DateTime> lsLamViec;

        public Employee(string cmnd, string ho, string tenLot, string ten, string gioiTinh, string tenDN, string mk)
        { 
            Cmnd = cmnd;
            Ho = ho;
            TenLot = tenLot;
            Ten = ten;
            GioiTinh = gioiTinh;
            TenDN = tenDN;
            Mk = mk;
            Luong = 0;
            TinhTrangLamViec = true;

            EmployeeDAO employeeDAO = new EmployeeDAO();
            LsLamViec = employeeDAO.GetLS(TenDN);
        }
        public Employee(DataRow dr)
        {
            MaNV = dr["MaNV"].ToString();
            Cmnd = dr["CMND"].ToString();
            Ho = dr["Ho"].ToString();
            TenLot = dr["TenLot"].ToString();
            Ten = dr["Ten"].ToString();
            GioiTinh = dr["GioiTinh"].ToString();
            TenDN = dr["TenDN"].ToString();
            Mk = dr["MK"].ToString();
            Luong = (int)dr["Luong"];
            TinhTrangLamViec = (bool)dr["TinhTrangLamViec"];

            EmployeeDAO employeeDAO = new EmployeeDAO();
            LsLamViec = employeeDAO.GetLS(TenDN);
        }
        public string MaNV { get => maNV; set => maNV = value; }
        public string Cmnd { get => cmnd; set => cmnd = value; }
        public string Ho { get => ho; set => ho = value; }
        public string TenLot { get => tenLot; set => tenLot = value; }
        public string Ten { get => ten; set => ten = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public int Luong { get => luong; set => luong = value; }
        public string TenDN { get => tenDN; set => tenDN = value; }
        public string Mk { get => mk; set => mk = value; }
        public bool TinhTrangLamViec { get => tinhTrangLamViec; set => tinhTrangLamViec = value; }
        public List<DateTime> LsLamViec { get => lsLamViec; set => lsLamViec = value; }
    }
}
