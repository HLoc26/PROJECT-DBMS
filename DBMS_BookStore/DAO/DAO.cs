using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_BookStore.DAO
{
    internal class DAO
    {
        SqlConnection db = new SqlConnection(Properties.Settings.Default.ConnectionString);
    }
}
