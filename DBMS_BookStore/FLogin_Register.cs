using DBMS_BookStore.DAO;
using DBMS_BookStore.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_BookStore
{
    public partial class FLogin_Register : Form
    {
        public FLogin_Register()
        {
            InitializeComponent();
            HideAllTabsOnTabControl();
        }

        private void HideAllTabsOnTabControl()
        {
            tabControl_Login.Appearance = TabAppearance.FlatButtons;
            tabControl_Login.ItemSize = new Size(0, 1);
            tabControl_Login.SizeMode = TabSizeMode.Fixed;
        }

        #region Login
        private void btnCreateAcc_Click(object sender, EventArgs e)
        {
            tabControl_Login.SelectedIndex = 1;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            EmployeeDAO employeeDAO = new EmployeeDAO();
            Employee employee = employeeDAO.GetInfoByUsername(txbUsername.Text, txbPassword.Text);

            if (employee != null)
            {
                // Open main form here
                MessageBox.Show("Login Success\n" + employee.ToString(), "Login Success");
            }
            else
            {
                // Handle wrong password or username here (Show error text, not show messagebox)
                MessageBox.Show("Login Failed!", "Login Failed");
            }




            /* Some Login username (pass MK123456 for all):
             * nvv1353
             * hnqm3245
             * ntbn1521
             * ttn3241
             * nvnn7671
             */

        }

        #endregion

        #region Register
        private void btnBackLogin_Click(object sender, EventArgs e)
        {
            tabControl_Login.SelectedIndex = 0;
            txbUsername.Text = "";
            txbPassword.Text = "";
        }

        #endregion
    }
}
