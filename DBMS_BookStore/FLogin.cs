using DBMS_BookStore.DAO;
using DBMS_BookStore.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_BookStore
{
    public partial class FLogin : Form
    {
        public FLogin()
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
                lblIncorrectUsername.Text = "Tên đăng nhập không được bỏ trống!";
                lblIncorrectUsername.Visible = true;
                txbUsername.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txbPassword.Text.Trim()))
            {
                lblIncorrectPassword.Text = "Mật khẩu không được bỏ trống!";
                lblIncorrectPassword.Visible = true;
                txbPassword.Focus();
                return;
            }
            DBConnection.username = txbUsername.Text;
            DBConnection.password = txbPassword.Text;
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
                lblIncorrectUsername.Text = "Sai tên đăng nhập hoặc mật khẩu";
                lblIncorrectUsername.Visible = true;
                lblIncorrectPassword.Text = "Sai tên đăng nhập hoặc mật khẩu";
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
