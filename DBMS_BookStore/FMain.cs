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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_BookStore
{
    public partial class FMain : Form
    {
        // Thông tin của NV đăng nhập vào phiên hiện tại
        Employee nv;

        HangHoaDAO hanghoaDAO = new HangHoaDAO();

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

        #region Giao Dịch
        private void btnBanHang_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabControl.TabPages[4];
        }
        #endregion

        #region Giao Dịch - Bán Hàng

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
                        MessageBox.Show("Số lượng sản phẩm đạt giới hạn", "Không đủ sản phẩm",  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                }
            }
            // Nếu chưa có thì thêm vào giỏ hàng
            dtgvGioHang.Rows.Add(hanghoa.ItemArray);
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

    }
}
