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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_BookStore
{
    public partial class FMain : Form
    {
        // Thông tin của NV đăng nhập vào phiên hiện tại
        Employee nv;

        HangHoaDAO hanghoaDAO = new HangHoaDAO();
        TraCuuDAO traCuuDAO = new TraCuuDAO();
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
        // Code here
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
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm", "Không tìm thấy sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
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

        #endregion

        #region 4. Giao dịch - Bán hàng
        // Code here
        #endregion

        #region 5. Giao dịch - Bán hàng - Thanh toán
        // Code here
        #endregion

        #region 7. Giao dịch - Bán hàng - Thanh toán - Tiền mặt
        // Code here
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
        // Code here
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
