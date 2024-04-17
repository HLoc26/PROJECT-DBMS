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
            InitErrorLabels();
        }

        private void HideAllTabsOnTabControl()
        {
            tabControl_Login.Appearance = TabAppearance.FlatButtons;
            tabControl_Login.ItemSize = new Size(0, 1);
            tabControl_Login.SizeMode = TabSizeMode.Fixed;
        }

        private void InitErrorLabels()
        {   
            lblIncorrectUsername.Text = string.Empty;
            lblIncorrectUsername.Visible = false;
            lblIncorrectPassword.Text = string.Empty;
            lblIncorrectPassword.Visible = false;
        }

        #region Login
        private void btnCreateAcc_Click(object sender, EventArgs e)
        {
            tabControl_Login.SelectedIndex = 1;
        }

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
                MessageBox.Show("Login Success\n" + employee.ToString(), "Login Success");
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

        #region Register
        private void btnBackLogin_Click(object sender, EventArgs e)
        {
            tabControl_Login.SelectedIndex = 0;
            txbUsername.Text = "";
            txbPassword.Text = "";
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Check if any textbox is empty
            if (string.IsNullOrEmpty(txbCityzID.Text.Trim()) ||
                string.IsNullOrEmpty(txbLastname.Text.Trim()) ||
                string.IsNullOrEmpty(txbSurname.Text.Trim()) ||
                string.IsNullOrEmpty(txbFirstname.Text.Trim()) ||
                string.IsNullOrEmpty(txbRegUsername.Text.Trim()) ||
                string.IsNullOrEmpty(txbRegPass.Text.Trim()) ||
                string.IsNullOrEmpty(txbRegPass2.Text.Trim()))
            {
                MessageBox.Show("All field must be input!", "Empty field");
                return;
            }
                // Call function check valid pass
                if (!isSimilarPass())
            {
                txbRegPass2.Focus();
                return;
            }
            // Call function check valid id, username
            if(!isValidCityZID())
            {
                txbCityzID.Focus();
                return;
            }

            if (!isValidUsername())
            {
                txbRegUsername.Focus();
                return;
            }

            EmployeeDAO employeeDAO = new EmployeeDAO();

            string sex = rbtnSexFemale.Checked ? "Nữ" : (rbtnSexOther.Checked ? "Khác" : "Nam");

            Employee employee = new Employee("", txbCityzID.Text.Trim(), txbLastname.Text.Trim(),
                txbSurname.Text.Trim(), txbFirstname.Text.Trim(), sex, txbRegUsername.Text.Trim(), txbRegPass.Text.Trim());

            employee.MaNV = employeeDAO.Register(employee);

            MessageBox.Show($"Đăng ký thành công, mã NV của bạn là {employee.MaNV}", "Đăng ký thành công");

            btnBackLogin_Click(sender, e);
            txbCityzID.Text = "";
            txbLastname.Text = "";
            txbSurname.Text = "";
            txbFirstname.Text = "";
            txbRegUsername.Text = "";
            txbRegPass.Text = "";
            txbRegPass2.Text = "";
        }

        // Function check if password and retype password match
        private bool isSimilarPass()
        {
            return txbRegPass.Text.Trim() == txbRegPass2.Text.Trim();
        }


        // Function check valid Cityzen ID
        private bool isValidCityZID()
        {
            EmployeeDAO employeeDAO = new EmployeeDAO();
            Employee emp = employeeDAO.GetInfoByCityZID(txbCityzID.Text.Trim());
            return emp == null;
        }
        // Function check valid Username
        private bool isValidUsername()
        {
            EmployeeDAO employeeDAO = new EmployeeDAO();
            Employee emp = employeeDAO.GetInfoByUsername(txbRegUsername.Text.Trim());
            return emp == null;
        }

        #endregion
    }
}
