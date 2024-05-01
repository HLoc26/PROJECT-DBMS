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
    public partial class FRegis : Form
    {
        EmployeeDAO empDAO = new EmployeeDAO();
        public FRegis()
        {
            InitializeComponent();
        }

        private void btnDK_Click(object sender, EventArgs e)
        {
            if (!checkTxb())
            {
                return;
            }
            // CMND
            string cmnd = txbCMND.Text;

            // Ho, TenLot, Ten
            string[] HoTen = txbHoTen.Text.Split();

            // Ho
            string ho = HoTen.First();

            // Ten
            string ten = HoTen.Last();

            // TenLot
            string tenLot = HoTen.Length > 2 ? string.Join(" ", HoTen.Skip(1).Take(HoTen.Length - 2)) : "";


            // Gioi Tinh
            string sex = rbtnNam.Checked ? rbtnNam.Text : rbtnNu.Text;

            // TenDN
            string tenDN = txbTenDN.Text;

            // MK
            string mk = txbMK.Text;

            Employee emp = new Employee(cmnd, ho, tenLot, ten, sex, tenDN, mk);

            string maNV = empDAO.Register(emp);
            if(maNV != null)
            {
                MessageBox.Show($"Đăng ký thành công!\n\rMã nhân viên vừa mới tạo là {maNV}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Đăng ký thất bại!", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Kiem tra cac txb co dung yeu cau khong:
        /*
         * CMND: Phai co it nhat 8 so, khong duoc chua chu cai
         * Ho Ten: Khong duoc chua so
         * ten DN: Dai vua du
         * MK: It nhat 8 ky tu
         * confirm: giong MK
         */

        private bool checkTxb()
        {
            if(txbCMND.Text.Length < 8 && !(int.TryParse(txbCMND.Text, out _)))
            {
                return false;
            }
            if(txbHoTen.Text.Length < 5)
            {
                return false;
            }
            if(txbTenDN.Text.Length < 5)
            {
                return false;
            }
            if(txbMK.Text.Length < 8)
            {
                return false;
            }
            if(!string.Equals(txbMK.Text, txbConfirmMK.Text))
            { 
                return false;
            }
            return true;
        }

    }
}
