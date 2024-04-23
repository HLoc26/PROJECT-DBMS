using DBMS_BookStore.DAO;
using DBMS_BookStore.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_BookStore
{
    public partial class FThemTTSach : Form
    {
        ThemTTSachDAO themTTSachDAO = new ThemTTSachDAO();
        public FThemTTSach()
        {
            InitializeComponent();
            numNamXB.Maximum = DateTime.Today.Year;
        }


        private void txbTenSach_Leave(object sender, EventArgs e)
        {
            // Check tên sách khi click ra ngoài
            string maSach = themTTSachDAO.GetMaSach(txbTenSach.Text);
            if (maSach == "FOUND")
            {
                DialogResult found = MessageBox.Show("Tên sách đã có trong kho!\n Quay lại trang nhập hàng?", "Đã có", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (found == DialogResult.OK)
                    Close();
            }
            else
            {
                txbMaSach.Text = maSach;
            }
        }

        private void txbTenTG_TextChanged(object sender, EventArgs e)
        {
            // Check tên TG với mỗi ký tự được nhập vào
            string maTG = themTTSachDAO.GetMaTG(txbTenTG.Text);
            txbMaTG.Text = maTG.Trim();
        }

        private void txbTenNXB_TextChanged(object sender, EventArgs e)
        {
            // Check tên nxb với mỗi ký tự được nhập vào
            string maNXB = themTTSachDAO.GetMaNXB(txbTenNXB.Text);
            txbMaNXB.Text = maNXB.Trim();
            // Điền thông tin của địa chỉ và sđt nếu mã có sẵn
            NXB nxb = themTTSachDAO.CheckMaNXB(txbMaNXB.Text);
            if (nxb != null) // Đã có thông tin, không cho sửa sđt và địa chỉ
            {
                txbDiaChiNXB.ReadOnly = true;
                txbDiaChiNXB.Text = nxb.DiaChi;
                txbSDTNXB.ReadOnly = true;
                txbSDTNXB.Text = nxb.Sdt;
            }
            else
            {
                txbDiaChiNXB.ReadOnly = false;
                txbDiaChiNXB.Text = string.Empty;
                txbSDTNXB.ReadOnly = false;
                txbSDTNXB.Text = string.Empty;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Gọi hàm thêm dữ liệu vào db
            // Kiểm tra xem đã có NXB chưa
            NXB nxb = new NXB(txbMaNXB.Text, txbTenNXB.Text, txbDiaChiNXB.Text, txbSDTNXB.Text);
            // Kiểm tra xem đã có TG chưa
            TacGia tg = new TacGia(txbMaTG.Text, txbTenTG.Text);

            Sach sach = new Sach(txbMaSach.Text, txbTenSach.Text, (int)numDonGia.Value, 0, txbTenTG.Text, txbTenNXB.Text, txbTheLoai.Text);

            themTTSachDAO.InsertData(nxb, tg, sach, (int)numNamXB.Value);
            MessageBox.Show("Thêm dữ liệu thành công!", "Thành công", MessageBoxButtons.OK);
            Close();
        }

        private void txbTheLoai_Leave(object sender, EventArgs e)
        {
            List<string> list = new List<string>() { "Tiểu thuyết", "Truyện tranh", "Kinh doanh", "Sách giáo khoa", "Ngoại ngữ"};
            if (!list.Contains(txbTheLoai.Text))
            {
                MessageBox.Show("Invalid Genre!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbTheLoai.Text = string.Empty;
                txbTheLoai.Focus();
                return;
            }
        }
        private void txbTheLoai_MouseDown(object sender, MouseEventArgs e)
        {
            SendKeys.Send(" ");
            SendKeys.Send("{BACKSPACE}");
        }
    }
}
