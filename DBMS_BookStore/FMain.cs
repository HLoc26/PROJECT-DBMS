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
        const int MAX_DAYS_ROW = 6;
        const int MAX_DAYS_COL = 7;
        // Thông tin của NV đăng nhập vào phiên hiện tại
        Employee nv;

        HangHoaDAO hanghoaDAO = new HangHoaDAO();
        EmployeeDAO employeeDAO = new EmployeeDAO();
        public FMain(Employee nv)
        {
            InitializeComponent();
            HideAllTabsOnTabControl();
            this.nv = nv;
            DateComboBoxes_Load();
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
            Days_Load();
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

        #region 21. Cài đặt - Xem lịch sử làm việc
        int year = DateTime.Now.Year;
        int month = DateTime.Now.Month;
        private void Days_Load()
        {
            int btnWidth = (flpnlDays.Size.Width - 8 * (MAX_DAYS_COL - 1)) / MAX_DAYS_COL;
            int btnHeight = (flpnlDays.Size.Height - 10 * (MAX_DAYS_ROW - 1)) / MAX_DAYS_ROW;

            flpnlDays.Controls.Clear();
            List<int> valid = GetWorkDates();


            DateTime startDate = new DateTime(year, month, 1);
            // Day count of month
            int days = DateTime.DaysInMonth(year, month);
            // Convert startDate to int
            int dayOfWeek = Convert.ToInt32(startDate.DayOfWeek.ToString("d"));

            // Add blank days
            for (int i = 0; i < dayOfWeek; i++)
            {
                int lastMonth = month - 1;
                if (lastMonth == 0) lastMonth = 12;
                int lastMonthDayCount = DateTime.DaysInMonth(year, lastMonth);

                Button btn = new Button();
                btn.Text = (lastMonthDayCount - dayOfWeek + i + 1).ToString();
                btn.Size = new Size(btnWidth, btnHeight);
                btn.Font = new Font(btn.Font.FontFamily, 20);
                btn.Enabled = false;

                flpnlDays.Controls.Add(btn);
            }

            int countTongNgayLam = 0;

            // Fill days of current month
            for (int i = 0; i < days; i++)
            {
                Button btn = new Button();
                btn.Text = (i + 1).ToString();
                btn.Size = new Size(btnWidth, btnHeight);
                btn.Font = new Font(btn.Font.FontFamily, 20);
                btn.Enabled = true;
                
                if (valid.Contains(i + 1))
                {
                    btn.BackColor = Color.Green;
                    countTongNgayLam += 1;
                }
                else
                {
                    btn.BackColor = Color.Red;
                }
                flpnlDays.Controls.Add(btn);
            }

            txbTongNgayLam.Text = countTongNgayLam.ToString();

            // Fill the rest with blank
            for (int i = 0; i < 42 - days - dayOfWeek; i++)
            {
                Button btn = new Button();
                btn.Text = (i + 1).ToString();
                btn.Size = new Size(btnWidth, btnHeight);
                btn.Font = new Font(btn.Font.FontFamily, 20);
                btn.Enabled = false;

                flpnlDays.Controls.Add(btn);
            }
        }

        private List<int> GetWorkDates()
        {
            List<int> days = new List<int>();
            foreach(DateTime day in nv.LsLamViec)
            {
                if (day.Month == month)
                {
                    days.Add(day.Day);
                }
            }
            return days;
        }

        private void DateComboBoxes_Load()
        {
            string[] monthNames = new string[]
            {
                "January", "February", "March", "April", "May", "June",
                "July", "August", "September", "October", "November", "December"
            };
            cbbMonth.Items.AddRange(monthNames);

            for (int i = DateTime.Now.Year - 5; i <= DateTime.Now.Year + 5; i++)
            {
                cbbYear.Items.Add(i.ToString());
            }
            cbbMonth.SelectedIndex = month - 1;
            cbbYear.SelectedIndex = 0;
        }

        private void btnNextMonth_Click(object sender, EventArgs e)
        {
            month += 1;
            if (month > 12)
            {
                month = 1;
                year += 1;
                cbbYear.SelectedIndex = year - DateTime.Now.Year;
            }
            cbbMonth.SelectedIndex = month - 1;
        }

        private void btnPrevMonth_Click(object sender, EventArgs e)
        {
            month -= 1;
            if (month < 1)
            {
                month = 12;
                year -= 1;
                cbbYear.SelectedIndex = year - DateTime.Now.Year;
            }
            cbbMonth.SelectedIndex = month - 1;
        }

        private void cbbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            month = cbbMonth.SelectedIndex + 1;
            Days_Load();
        }

        private void cbbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            year = cbbYear.SelectedIndex + DateTime.Now.Year;
            Days_Load();
        }
        private void btnLSQuayLaiCaiDat_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabControl.TabPages[2];
        }
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
