using DBMS_BookStore.DAO;
using DBMS_BookStore.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.SqlClient;
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
        EmployeeDAO employeeDAO= new EmployeeDAO();

        HangHoaDAO hanghoaDAO = new HangHoaDAO();
        TraCuuDAO traCuuDAO = new TraCuuDAO();
        HoaDonBanDAO hoaDonBanDAO = new HoaDonBanDAO();
        public FMain(Employee nv)
        {
            InitializeComponent();
            HideAllTabsOnTabControl();
            this.nv = nv;
            DateComboBoxes_Load();
            SetDTGVStyles();
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
        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabControl.TabPages[9];
            cbbLoaiHangNhap.SelectedIndex = 0;
        }
        #endregion

        #region 1. Tra cứu
        private void btnTTSach_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabControl.TabPages[15];
            DataTable dt = traCuuDAO.LoadTCSach();
            foreach (DataRow row in dt.Rows)
            {
                dtgvTCSACH.Rows.Add(row.ItemArray);
            }
            dtgvTCSACH.Refresh();
            dtgvTCSACH.Update();
        }

        private void btnTTTacGia_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabControl.TabPages[16];
            DataTable dt = traCuuDAO.LoadTCTG();
            foreach (DataRow row in dt.Rows)
            {
                dtgvTCTG.Rows.Add(row.ItemArray);
            }
            dtgvTCTG.Refresh();
            dtgvTCTG.Update();
        }
        private void btnTTNXB_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabControl.TabPages[17];
        }
        private void btnTTTheLoai_Click(object sender, EventArgs e)
        {

            tabControl.SelectedTab = tabControl.TabPages[18];

        }
        private void btnTTVPP_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabControl.TabPages[19];
            DataTable dt = traCuuDAO.LoadTCVPP();
            foreach (DataRow row in dt.Rows)
            {
                dtgvTCVPP.Rows.Add(row.ItemArray);
            }
            dtgvTCVPP.Refresh();
            dtgvTCVPP.Update();
            
        }
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
        private void btnBaoCaoNhanVien_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabControl.TabPages[24];
        }
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
            txbTongTien.Text = CalculateTotal().ToString();
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
            DataGridViewRow row = new DataGridViewRow();

            // Copy dữ liệu từ giỏ hàng 
            for (int i = 0; i < dtgvGioHang.Rows.Count; i++)
            {
                row = (DataGridViewRow)dtgvGioHang.Rows[i].Clone();
                int intColIndex = 0;
                foreach (DataGridViewCell cell in dtgvGioHang.Rows[i].Cells)
                {
                    row.Cells[intColIndex].Value = cell.Value;
                    intColIndex++;
                }
                dtgvXemLaiTienMat.Rows.Add(row);
            }
            dtgvXemLaiTienMat.AllowUserToAddRows = false;
            dtgvXemLaiTienMat.Refresh();

            // Copy tổng tiền
            txbTongTienMat.Text = (double.Parse(txbTongTien.Text) * (1 - double.Parse(txbGiamGia.Text))).ToString();
        }

        private void btnChuyenKhoan_Click(object sender, EventArgs e)
        {
            btnTienMat_Click(sender, e); // hihi
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
            dtgvXemLaiTienMat.Rows.Clear();
        }
        private void btnTienMatThanhToan_Click(object sender, EventArgs e)
        {
            string maHoaDonBan = hoaDonBanDAO.GetMaHoaDon();
            string maKH = "0000000000";

            // Nếu nhập mã khách hàng thì lấy mã đó, còn không thì lấy mã mặc định "0000000000"
            if (!string.IsNullOrEmpty(txbMaKH.Text))
            {
                maKH = txbMaKH.Text;
            }
            int succeed = 0;
            foreach(DataGridViewRow row in dtgvXemLaiTienMat.Rows)
            {
                VatPham vatpham = new VatPham(maHoaDonBan, nv.MaNV, maKH, row.Cells[0].Value.ToString(), (int)row.Cells[3].Value);

                succeed += hoaDonBanDAO.InsertBanHang(vatpham);
            }

            MessageBox.Show($"Đã thêm {succeed} hàng vào BAN_HANG");
        }

        #endregion

        #region 8. Giao dịch - Bán hàng - Thanh toán - Chuyển khoản
        // Code here
        #endregion

        #region 9. Giao dịch - Nhập hàng (Chỉ admin)

        // Nhập hàng
        List<HangHoa> dsHangNhap = new List<HangHoa>();
        // 1. Chọn loại hàng: ComboBox chọn sách hoặc vpp
        private void cbbLoaiHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbbLoaiHangNhap.SelectedIndex)
            {
                case 0:
                    tlplGD_NHContainer4.Visible = true;
                    tlplGD_NHContainer7.Visible = true;
                    tlplGD_NHContainer5.Visible = true;

                    break;
                case 1:
                    tlplGD_NHContainer4.Visible = false;
                    tlplGD_NHContainer7.Visible = false;
                    tlplGD_NHContainer5.Visible = false;
                    break;
            }
        }
        private void txbMaHangNhap_TextChanged(object sender, EventArgs e)
        {
            numSoLuongNhap.Value = 1;
            DataRow drSach = hanghoaDAO.GetSach(txbMaHangNhap.Text);
            DataRow drVPP = hanghoaDAO.GetVPP(txbMaHangNhap.Text);

            if (cbbLoaiHangNhap.SelectedIndex == 0 && drSach != null)
            {
                Sach sach = new Sach(drSach);
                txbTenHangNhap.Text = sach.TenHang;
                txbDonGiaNhap.Text = sach.DonGia.ToString();
                txbTacGiaNhap.Text = sach.TacGia;
                txbTheLoaiNhap.Text = sach.TheLoai;
                txbNXBNhap.Text = sach.Nxb;
                txbSoLuongCon_Nhap.Text = drSach["SoLuong"].ToString();
            }
            else if (cbbLoaiHangNhap.SelectedIndex == 1 && drVPP != null)
            {
                HangHoa vpp = new HangHoa(drVPP);
                txbTenHangNhap.Text = vpp.TenHang;
                txbDonGiaNhap.Text = vpp.DonGia.ToString();
                txbSoLuongCon_Nhap.Text = drVPP["SoLuong"].ToString();

            }
            else
            {
                txbTenHangNhap.Text = string.Empty;
                txbDonGiaNhap.Text = string.Empty;
                txbTacGiaNhap.Text = string.Empty;
                txbTheLoaiNhap.Text = string.Empty;
                txbNXBNhap.Text = string.Empty;
            }
        }

        private void btnThemHangNhap_Click(object sender, EventArgs e)
        {
            if (cbbLoaiHangNhap.SelectedIndex == 0)
            {
                // Sach nhap
                Sach sach = new Sach(txbMaHangNhap.Text, txbTenHangNhap.Text, int.Parse(txbDonGiaNhap.Text),
                                     (int)numSoLuongNhap.Value,
                                     txbTacGiaNhap.Text, txbNXBNhap.Text, txbTheLoaiNhap.Text
                                     );
                dsHangNhap.Add(sach);
            }
            else if(cbbLoaiHangNhap.SelectedIndex == 1)
            {
                // VPP nhap
                HangHoa vpp = new HangHoa(txbMaHangNhap.Text, txbTenHangNhap.Text, int.Parse(txbDonGiaNhap.Text), (int)numSoLuongNhap.Value);
                dsHangNhap.Add(vpp);
            }
            LoadDTGVNhap();
        }

        private void LoadDTGVNhap()
        {
        }

        private void btnNhapHangQuayLaiGiaoDich_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabControl.TabPages[0];
        }

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



        private void btnTCSACHID_Click(object sender, EventArgs e)
        {
            string maHang = txtb_TCSACH.Text;


            // Call SearchSACHByMaHang method to retrieve books by maHang
            DataTable booksByMaHang = traCuuDAO.SearchSACHByMaHang(maHang);

            // Clear existing rows in the DataGridView
            dtgvTCSACH.Rows.Clear();

            // Add rows to the DataGridView based on the DataTable
            foreach (DataRow row in booksByMaHang.Rows)
            {
                dtgvTCSACH.Rows.Add(row["MaSach"], row["TieuDe"], row["DonGia"], row["SoLuong"], row["TenTG"], row["TenLoai"], row["TenNXB"]);
            }
        }




        #endregion

        #region 16. Tra cứu - Tác giả

        private void btnTCTG_Click(object sender, EventArgs e)
        {
            string authorName = txtbTCTG.Text;

            // Call SearchBooksByAuthor method to retrieve books by author
            DataTable booksByAuthor = traCuuDAO.SearchBooksByAuthor(authorName);

            // Clear existing rows in the DataGridView
            dtgvTCTG.Rows.Clear();

            // Add rows to the DataGridView based on the DataTable
            foreach (DataRow row in booksByAuthor.Rows)
            {
                dtgvTCTG.Rows.Add(row["MaSach"], row["tenTG"], row["TieuDe"], row["DonGia"], row["TenLoai"]);
            }
        }
        #endregion

        #region 17. Tra cứu - NXB
        private void btnTCNXB_Click(object sender, EventArgs e)
        {
            string TenNXB = txtbTCNXB.Text;
            TraCuuDAO traCuuDAO = new TraCuuDAO();

            DataTable sachNXBData = traCuuDAO.SearchSachByNXB(TenNXB);

            dtgvTCNXB.Rows.Clear();

            foreach (DataRow row in sachNXBData.Rows)
            {
                dtgvTCNXB.Rows.Add(row["MaSach"], row["TieuDe"], row["TenLoai"], row["TenNXB"], row["DiaChi"], row["SDT"]);
            }
        }

        #endregion

        #region 18. Tra cứu - Thể loại
        private void btnTCTL_Click(object sender, EventArgs e)
        {
            string tenLoai = txtbTCTL.Text; 
            TraCuuDAO traCuuDAO = new TraCuuDAO();
            DataTable sachByTenLoaiData = traCuuDAO.SearchSachByTenLoai(tenLoai);
            dtgvTCTL.Rows.Clear();
            foreach (DataRow row in sachByTenLoaiData.Rows)
            {
                dtgvTCTL.Rows.Add(row["MaSach"], row["TieuDe"], row["TenLoai"], row["TenTG"], row["TenNXB"]);
            }
        }
        #endregion

        #region 19. Tra cứu - VPP
        private void btnTCVPP_Click(object sender, EventArgs e)
        {
            string maHang = txtbTCVPP.Text; 



            // Call SearchVPPByMaHang method to retrieve VPP items by MaHang
            DataTable vppByMaHang = traCuuDAO.SearchVPPByMaHang(maHang);

            // Clear existing rows in the DataGridView
            dtgvTCVPP.Rows.Clear();

            // Add rows to the DataGridView based on the DataTable
            foreach (DataRow row in vppByMaHang.Rows)
            {
                dtgvTCVPP.Rows.Add(row["MaHang"], row["TenHang"], row["DonGia"], row["SoLuong"]);
            }
        }


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
        private void btnTCNV_Click(object sender, EventArgs e)
        {
            string input = txtbTCNV.Text; // Assuming txtInput is the TextBox for input

            // Call SearchNhanVienByMaNVOrTen method to retrieve data of employees
            DataTable nhanVienData = employeeDAO.SearchNhanVienByMaNVOrTen(input);

            // Clear existing rows in the DataGridView
            dtgvTCNV.Rows.Clear();

            // Add rows to the DataGridView based on the DataTable
            foreach (DataRow row in nhanVienData.Rows)
            {
                dtgvTCNV.Rows.Add(row["MaNV"], row["CMND"], row["Ho"], row["TenLot"], row["Ten"], row["GioiTinh"], row["Luong"], row["TinhTrangLamViec"]);
            }
        }

        #endregion

        #region 23. Báo cáo - Doanh thu
        // Code here
        #endregion

        #region 24. Báo cáo - Lương NV
        // Code here
        #endregion

        // Set style cho dtgv
        private void SetDTGVStyles()
        {
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                BackColor = SystemColors.Control,
                Font = new Font("Microsoft Sans Serif", 18F),
                ForeColor = SystemColors.WindowText,
                SelectionBackColor = SystemColors.Highlight,
                SelectionForeColor = SystemColors.HighlightText,
                WrapMode = DataGridViewTriState.True
            };

            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                BackColor = SystemColors.Window,
                Font = new Font("Microsoft Sans Serif", 15.75F),
                ForeColor = SystemColors.ControlText,
                SelectionBackColor = SystemColors.Highlight,
                SelectionForeColor = SystemColors.HighlightText,
                WrapMode = DataGridViewTriState.False
            };

            SetDataGridViewStyles(dtgvGioHang, columnHeaderStyle, cellStyle);
            SetDataGridViewStyles(dtgvXemLaiTienMat, columnHeaderStyle, cellStyle);
            SetDataGridViewStyles(dtgvNhapHang, columnHeaderStyle, cellStyle);
            SetDataGridViewStyles(dtgvTCSACH, columnHeaderStyle, cellStyle);
        }

        private void SetDataGridViewStyles(DataGridView dataGridView, DataGridViewCellStyle columnHeaderStyle, DataGridViewCellStyle cellStyle)
        {
            dataGridView.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            dataGridView.DefaultCellStyle = cellStyle;
        }
    }
}
