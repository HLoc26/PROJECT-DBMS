using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        KhachHangDAO KhDAO = new KhachHangDAO();
        KhachHang kh;
        public FKhachhang()
        {
            InitializeComponent();
        }
        private void txtCustomerID_Leave(object sender, EventArgs e)
        {
            KhachHang check = KhDAO.GetInforByCusID(txtCustomerID.Text);
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
            KhachHang check = KhDAO.GetInforByMemID(txtMembershipID.Text);
            if (check == null)
            {
                KhachHang kh = KhDAO.ShowMembership(txtMembershipID.Text);
                txtCustomerID.Text = kh.MaKH;
                txtCustomerName.Text = kh.Ho + " " + kh.TenLot + " " + kh.Ten;
                txtCustomerDoB.Text = kh.NgaySinh.ToString();
                txtCustomerGender.Text = kh.GioiTinh;
                txtCustomerLevel.Text = kh.ThanhVien.SoDiem.ToString();
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!checkTxb())
            {
                return;
            }
            //customer ID
            string cusID = txtCustomerID_2.Text;
            // Ho, TenLot, Ten
            string[] HoTen = txtCustomerName.Text.Split();

            // Ho
            string ho = HoTen.First();

            // Ten
            string ten = HoTen.Last();

            // TenLot
            string tenLot = HoTen.Length > 2 ? string.Join(" ", HoTen.Skip(1).Take(HoTen.Length - 2)) : "";

            //Bac
            string bac = txtCustomerLevel_2.Text;

            //NgaySinh
            DateTime ngaySinh = DateTime.ParseExact(txtCustomerDoB_2.Text, "dd,MM,yyyy", CultureInfo.InvariantCulture);

            //Diem Tich Luy
            int soDiem = 0;

            // Gioi Tinh
            string gender = rbtnMale.Checked ? rbtnMale.Text : rbtnFemale.Text;

            TheTV tv = new TheTV(soDiem, bac, cusID);
            KhachHang kh = new KhachHang(cusID, ho, tenLot, ten, ngaySinh, gender, tv);

            string maKH = KhDAO.createCustomer(kh, tv);
            if (maKH != null)
            {
                MessageBox.Show($"Đăng ký thành công!\n\rMã khách hàng vừa mới tạo là {maKH}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Đăng ký thất bại!", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool checkTxb ()
        {
            if(txtCustomerID_2.Text.Length < 10)
            {
                return false;
            }
            if(txtCustomerName_2.Text.Length < 5) 
            {
                return false;
            }
            return true;
        }

        private void btnReturn_2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
