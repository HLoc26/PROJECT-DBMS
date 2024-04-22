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
        public FKhachhang()
        {
            InitializeComponent();
        }
        private void txtCustomerID_Leave(object sender, EventArgs e)
        {
            KhachHangDAO dao = new KhachHangDAO();

            KhachHang kh = dao.ShowMembership(txtCustomerID.Text);
            
            txtCustomerName.Text = kh.Ho + " " + kh.TenLot + " " + kh.Ten;
            txtCustomerDoB.Text = kh.NgaySinh.ToString();
            txtCustomerGender.Text = kh.GioiTinh;
            txtMembershipID.Text = kh.ThanhVien.MaThe;
            txtCustomerLevel.Text = kh.ThanhVien.SoDiem.ToString;

        }
        private void btnCustomerID_Click(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

        }


    }
}
