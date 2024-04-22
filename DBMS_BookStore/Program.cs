using DBMS_BookStore.DAO;
using DBMS_BookStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_BookStore
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            EmployeeDAO dao = new EmployeeDAO();
            Employee emp = dao.Login("nvv1353", "MK123456");
            Application.Run(new FMain(emp));

            //Application.Run(new FLogin_Register());
        }
    }
}
