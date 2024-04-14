﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_BookStore.DAO
{
    internal class DBConnection
    {
        SqlConnection SqlConn = new SqlConnection("Data Source=LAPTOP-LDCUFKEL;Initial Catalog=Proj_DBMS_BookStore;Integrated Security=True");

        public DataTable ExecuteQuery(SqlCommand sqlCommand)
        {
            DataTable dataTable = new DataTable();
            try
            {
                SqlConn.Open();

                sqlCommand.Connection = SqlConn;

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

                adapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " From ExecuteQuery");
            }
            finally { SqlConn.Close(); }
            return dataTable;
        }

        public int ExecuteNonQuery(SqlCommand sqlCommand)
        {
            int succeed = 0;
            try
            {
                SqlConn.Open();

                sqlCommand.Connection = SqlConn;

                succeed = sqlCommand.ExecuteNonQuery();
                if (succeed > 0)
                {
                    MessageBox.Show("Succeed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " From ExecuteNonQuery");
            }
            finally { SqlConn.Close(); }
            return succeed;
        }

    }
}
