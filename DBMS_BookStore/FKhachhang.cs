using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBMS_BookStore.DAO;
using DBMS_BookStore.DTO;

namespace DBMS_BookStore
{
    public partial class FKhachhang : Form
    {
        KhachHangDAO dao = new KhachHangDAO();
        KhachHang kh;
        public FKhachhang()
        {
            InitializeComponent();
        }
        private void txtCustomerID_Leave(object sender, EventArgs e)
        {
            KhachHang check = dao.GetInforByCusID(txtCustomerID.Text);
            if (check == null)
            {
                //KhachHang kh = dao.ShowCustomer(txtCustomerID.Text);
                //txtCustomerName.Text = kh.Ho + " " + kh.TenLot + " " + kh.Ten;
                //txtCustomerDoB.Text = kh.NgaySinh.ToString();
                //txtCustomerGender.Text = kh.GioiTinh;
                //txtMembershipID.Text = kh.ThanhVien.MaThe;
                //txtCustomerLevel.Text = kh.ThanhVien.SoDiem.ToString();
            }

        }
        private void btnCustomerID_Click(object sender, EventArgs e)
        {
            KhachHang check = dao.GetInforByMemID(txtMembershipID.Text);
            if (check == null)
            {
                KhachHang kh = dao.ShowMembership(txtMembershipID.Text);
                txtCustomerID.Text = kh.MaKH;
                txtCustomerName.Text = kh.Ho + " " + kh.TenLot + " " + kh.Ten;
                txtCustomerDoB.Text = kh.NgaySinh.ToString();
                txtCustomerGender.Text = kh.GioiTinh;
                txtCustomerLevel.Text = kh.ThanhVien.SoDiem.ToString();
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string succeed = dao.createCustomer(txtCustomerID_2.Text, txtMembershipID_2.Text);
            if (succeed != null)
            {
                // Cập nhật lại nv hiện tại
                MessageBox.Show("Complete!");
            }
            return;
        }


    }
}
