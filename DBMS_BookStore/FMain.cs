using DBMS_BookStore.DAO;
using DBMS_BookStore.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_BookStore
{
    public partial class FMain : Form
    {
        // Thông tin của NV đăng nhập vào phiên hiện tại
        Employee nv;

        HangHoaDAO hanghoaDAO = new HangHoaDAO();
        EmployeeDAO employeeDAO = new EmployeeDAO();
        public FMain(Employee nv)
        {
            InitializeComponent();
            HideAllTabsOnTabControl();

            this.nv = nv;
        }

        private void HideAllTabsOnTabControl()
        {
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;
        }
        /* Thứ tự các tab:
         * 0. Giao dịch
         * 1. Tra cứu
         * 2. Cài đặt
         * 3. Báo cáo (thống kê)
         * 
         * 4. Giao dịch - Bán hàng
         * 5. Giao dịch - Bán hàng - Thanh toán
         * 7. Giao dịch - Bán hàng - Thanh toán - Tiền mặt 
         * 8. Giao dịch - Bán hàng - Thanh toán - Chuyển khoản
         * 
         * 9. Giao dịch - Nhập hàng (Chỉ admin)
         * 
         * 10. Giao dịch - Khách hàng
         * 11. Giao dịch - Khách hàng - Tìm thông tin
         * 12. Giao dịch - Khách hàng - Tạo thẻ TV
         * 
         * 13. Giao dịch - Hoá đơn bán hàng (tra cứu hoá đơn bán) 
         * 14. Giao dịch - Hoá đơn nhập hàng (tra cứu hoá đơn nhập)
         * 
         * 15. Tra cứu - Sách
         * 16. Tra cứu - Tác giả
         * 17. Tra cứu - NXB
         * 18. Tra cứu - Thể loại
         * 19. Tra cứu - VPP
         * 
         * 20. Cài đặt - Đổi MK (nv hiện tại đổi mk của mình)
         * 21. Cài đặt - Xem lịch làm việc
         * 22. Cài đặt - Xem thông tin NV (Chỉ admin mới sửa được)
         * 
         * 23. Báo cáo - Doanh thu
         * 24. Báo cáo - Lương NV
         */

        #region NAV
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnGiaoDich_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabControl.TabPages[0];
        }
        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabControl.TabPages[1];
        }
        private void btnCaiDat_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabControl.TabPages[2];
        }
        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabControl.TabPages[3];
        }
        #endregion

        #region 0. Giao Dịch
        private void btnBanHang_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabControl.TabPages[4];
        }
        #endregion

        #region 1. Tra cứu
        // Code here
        #endregion

        #region 2. Cài đặt
        private void btn_CD_DoiMK_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabControl.TabPages[20];
            lblHelloUser.Text = $"Hello, {nv.Ho} {nv.TenLot} {nv.Ten}";
        }
        private void btnCD_XemLich_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabControl.TabPages[21];
        }
        private void btnCD_XemNV_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabControl.TabPages[22];
        }
        #endregion

        #region 3. Báo cáo (thống kê)
        // Code here
        #endregion

        #region 4.Giao Dịch - Bán Hàng

        private void btnQuayLaiGiaoDich_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabControl.TabPages[0];
        }

        private void txbMaSP_TextChanged(object sender, EventArgs e)
        {
            DataRow hanghoa = hanghoaDAO.GetHangHoa(txbMaSP.Text);
            numSoLuongMua.Value = 1;
            if (hanghoa != null)
            {
                txbTenSP.Text = hanghoa["TenHang"].ToString();
                txbSoLuongCon.Text = hanghoa["SoLuong"].ToString();
                numSoLuongMua.Maximum = int.Parse(hanghoa["SoLuong"].ToString());
            }
            else
            {
                txbTenSP.Text = string.Empty;
                txbSoLuongCon.Text = string.Empty; 
            }
        }
        private void btnThemSP_Click(object sender, EventArgs e)
        {
            DataRow hanghoa = hanghoaDAO.GetHangHoa(txbMaSP.Text);
            if(hanghoa != null) { 
            hanghoa["SoLuong"] = numSoLuongMua.Value.ToString();
            int colNum = dtgvGioHang.ColumnCount;
                // Kiểm tra xem đã có sản phẩm đó chưa, nếu có rồi thì cộng thêm vào
                foreach (DataGridViewRow row in dtgvGioHang.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == txbMaSP.Text)
                    {
                        // Kiểm tra xem có đủ sản phẩm trong kho không
                        if (int.Parse(row.Cells[colNum - 1].Value.ToString()) + numSoLuongMua.Value <= int.Parse(txbSoLuongCon.Text))
                        {
                            row.Cells[colNum - 1].Value = (int.Parse(row.Cells[colNum - 1].Value.ToString()) + numSoLuongMua.Value).ToString();
                            txbTongTien.Text = CalculateTotal().ToString();
                        }
                        else
                        {
                            MessageBox.Show("Số lượng sản phẩm đạt giới hạn", "Không đủ sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        return;
                    }
                }
                // Nếu chưa có thì thêm vào giỏ hàng
                dtgvGioHang.Rows.Add(hanghoa.ItemArray);
                txbTongTien.Text = CalculateTotal().ToString();
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm", "Không tìm thấy sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private int CalculateTotal()
        {
            int total = 0;
            foreach (DataGridViewRow row in dtgvGioHang.Rows)
            {
                total += int.Parse(row.Cells[2].Value.ToString()) * int.Parse(row.Cells[3].Value.ToString());
            }
            return total;
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            string maHang = txbMaSP.Text;
            foreach (DataGridViewRow row in dtgvGioHang.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == maHang)
                {
                    dtgvGioHang.Rows.Remove(row);
                }
            }
            dtgvGioHang.Update();
            dtgvGioHang.Refresh();
        }

        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            int colNum = dtgvGioHang.ColumnCount;
            foreach (DataGridViewRow row in dtgvGioHang.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == txbMaSP.Text)
                {
                    row.Cells[colNum - 1].Value = numSoLuongMua.Text;
                }
            }
        }
        private void dtgvGioHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dtgvGioHang.SelectedRows[0];
            DataRow hanghoa = hanghoaDAO.GetHangHoa(selectedRow.Cells[0].Value.ToString());

            txbMaSP.Text = selectedRow.Cells[0].Value.ToString();
            txbTenSP.Text = selectedRow.Cells[1].Value.ToString();
            txbSoLuongCon.Text = hanghoa["SoLuong"].ToString();
            numSoLuongMua.Maximum = int.Parse(hanghoa["SoLuong"].ToString());
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabControl.TabPages[5];
        }
        #endregion

        #region 5. Giao dịch - Bán hàng - Thanh toán
        private void btnTienMat_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabControl.TabPages[7];
            dtgvXemLaiTienMat.DataSource = dtgvGioHang.DataSource;
        }

        private void btnChuyenKhoan_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabControl.TabPages[8];
        }
        private void btnQuayLaiBanHang_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabControl.TabPages[4];
        }
        #endregion

        #region 7. Giao dịch - Bán hàng - Thanh toán - Tiền mặt
        private void btnTMQuayLaiTT_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabControl.TabPages[5];
        }

        /*
         * Thêm vào bảng BAN_HANG(mã hoá đơn 
         */
        #endregion

        #region 8. Giao dịch - Bán hàng - Thanh toán - Chuyển khoản
        // Code here
        #endregion

        #region 9. Giao dịch - Nhập hàng (Chỉ admin)
        // Code here
        #endregion

        #region 10. Giao dịch - Khách hàng
        // Code here
        #endregion

        #region 11. Giao dịch - Khách hàng - Tìm thông tin
        // Code here
        #endregion

        #region 12. Giao dịch - Khách hàng - Tạo thẻ TV
        // Code here
        #endregion

        #region 13. Giao dịch - Hoá đơn bán hàng (tra cứu hoá đơn bán)
        // Code here
        #endregion

        #region 14. Giao dịch - Hoá đơn nhập hàng (tra cứu hoá đơn nhập)
        // Code here
        #endregion

        #region 15. Tra cứu - Sách
        // Code here
        #endregion

        #region 16. Tra cứu - Tác giả
        // Code here
        #endregion

        #region 17. Tra cứu - NXB
        // Code here
        #endregion

        #region 18. Tra cứu - Thể loại
        // Code here
        #endregion

        #region 19. Tra cứu - VPP
        // Code here
        #endregion

        #region 20. Cài đặt - Đổi MK (nv hiện tại đổi mk của mình)
        private bool isValidNewPass(string pass)
        {
            // Regex pattern to match at least 8 characters long and contain both letters and numbers
            string pattern = @"^(?=.*[a-zA-Z])(?=.*\d).{8,30}$";

            return Regex.IsMatch(pass, pattern);
        }
        private void btnSavePass_Click(object sender, EventArgs e)
        {
            // Kiểm tra pass có đúng không
            if (!string.Equals(txbMKCu.Text, nv.Mk))
            {
                MessageBox.Show("Mật khẩu không đúng!", "Sai mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Kiểm tra pass2 có đúng regex ko 
            if (!isValidNewPass(txbMKMoi.Text))
            {
                MessageBox.Show("Mật khẩu mới phải có 8-30 ký tự, có ít nhất một chữ cái và một số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Đổi mật khẩu
            bool succeed = employeeDAO.ChangePass(txbMKMoi.Text, nv.MaNV);
            // Nếu đã đổi thành công
            if (succeed)
            {
                // Cập nhật lại nv hiện tại
                nv = employeeDAO.GetInfoByUsername(nv.TenDN);
            }
            else
            {
                MessageBox.Show("ERROR CHANGE PASS!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return;
        }

        private void btnDoiMKQuayLaiCaiDat_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabControl.TabPages[2];
        }
        #endregion

        #region 21. Cài đặt - Xem lịch làm việc
        // Code here
        #endregion

        #region 22. Cài đặt - Xem thông tin NV (Chỉ admin mới sửa được)
        // Code here
        #endregion

        #region 23. Báo cáo - Doanh thu
        // Code here
        #endregion

        #region 24. Báo cáo - Lương NV
        // Code here
        #endregion
    }
}
