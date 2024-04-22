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
            InitErrorLabels();
        }

        private void InitErrorLabels()
        {   
            lblIncorrectUsername.Text = string.Empty;
            lblIncorrectUsername.Visible = false;
            lblIncorrectPassword.Text = string.Empty;
            lblIncorrectPassword.Visible = false;
        }

        #region Login
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbUsername.Text.Trim()))
            {
                lblIncorrectUsername.Text = "Username must not be empty!";
                lblIncorrectUsername.Visible = true;
                txbUsername.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txbPassword.Text.Trim()))
            {
                lblIncorrectPassword.Text = "Password must not be empty!";
                lblIncorrectPassword.Visible = true;
                txbPassword.Focus();
                return;
            }
            EmployeeDAO employeeDAO = new EmployeeDAO();
            Employee employee = employeeDAO.Login(txbUsername.Text, txbPassword.Text);

            if (employee != null)
            {
                // Open main form here
                // MessageBox.Show("Login Success\n" + employee.ToString(), "Login Success");
                FMain main = new FMain(employee);
                Hide();
                main.ShowDialog();
                txbUsername.Text = "";
                txbPassword.Text = "";
                txbUsername.Focus();
                Show();
            }
            else
            {
                // Handle wrong password or username here (Show error text, not show messagebox)
                lblIncorrectUsername.Text = "Wrong username or password";
                lblIncorrectUsername.Visible = true;
                lblIncorrectPassword.Text = "Wrong username or password";
                lblIncorrectPassword.Visible = true;
            }

            /* Some Login username (pass MK123456 for all):
             * nvv1353
             * hnqm3245
             * ntbn1521
             * ttn3241
             * nvnn7671
             */
        }
        private void txbUsername_TextChanged(object sender, EventArgs e)
        {
            lblIncorrectUsername.Visible = false;
        }

        private void txbPassword_TextChanged(object sender, EventArgs e)
        {
            lblIncorrectPassword.Visible = false;
        }
        #endregion
    }
}
