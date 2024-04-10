using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_BookStore.DAO
{
    internal class DBConnection
    {
        SqlConnection db = new SqlConnection("Data Source=LAPTOP-LDCUFKEL;Initial Catalog=Proj_DBMS_BookStore;Integrated Security=True;Trust Server Certificate=True");
    }
}
