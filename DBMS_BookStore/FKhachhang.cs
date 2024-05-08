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
            SetDTGVStyles();
            LoadTTKH();
        }
        private void LoadTTKH()
        {
            dtgvTTKH.Rows.Clear();
            DataTable khachHangData = KhDAO.GetDSKH();
            foreach (DataRow row in khachHangData.Rows)
            {
                dtgvTTKH.Rows.Add(row["MaKH"], row["MaThe"], row["Ho"], row["TenLot"], row["Ten"], row["NgaySinh"], row["GioiTinh"], row["SoDiem"], row["TenBacTV"]);
            }
            dtgvTTKH.ClearSelection();
        }
        private void txtCustomerID_TextChanged(object sender, EventArgs e)
        {
            dtgvTTKH.ClearSelection();
            if (string.IsNullOrEmpty(txtCustomerID.Text))
            {
                foreach (DataGridViewRow row in dtgvTTKH.Rows)
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
                return;
            }
            DataTable dsnv = KhDAO.GetInforByCusID(txtCustomerID.Text);
            InputFieldChanged(dsnv);
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            //MaKH
            string MaKH = txtCustomerID.Text;

            // Ho, TenLot, Ten
            string[] HoTen = txtCustomerName.Text.Split();

            // Ho
            string ho = HoTen.First();

            // Ten
            string ten = HoTen.Last();

            // TenLot
            string tenLot = HoTen.Length > 2 ? string.Join(" ", HoTen.Skip(1).Take(HoTen.Length - 2)) : "";

            // Ten Bac
            string bac = txtCustomerLevel.Text;

            // Ngay Sinh
            DateTime ngaysinh = DateTime.Parse(txtCustomerDoB.Text);

            //Diem Tich luy
            int diem = int.Parse(txtCustomerScore.Text);

            // Gioi Tinh
            string sex = txtCustomerGender.Text;

            KhachHang kh = new KhachHang(MaKH, ho, tenLot, ten, ngaysinh, sex, diem, bac);
            string maKH = KhDAO.createCustomer(kh);
            if (maKH != null)
            {
                MessageBox.Show($"Đăng ký thành công!\n\rMã khách hàng vừa mới tạo là {maKH}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Đăng ký thất bại!", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadTTKH();
        }
        private void InputFieldChanged(DataTable dsnv)
        {
            List<string> dsMaKH = new List<string>();

            for (int i = 0; i < dsnv.Rows.Count; i++)
            {
                dsMaKH.Add(dsnv.Rows[i][0].ToString());
            }

            foreach (DataGridViewRow row in dtgvTTKH.Rows)
            {
                if (row.Cells[0].Value != null && dsMaKH.Contains(row.Cells[0].Value.ToString()))
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;

                }
            }
        }

        private void btnReturn_2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SetDTGVStyles()
        {
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                BackColor = Color.FromArgb(0, 80, 131),
                Font = new Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold),
                ForeColor = Color.White,
                SelectionBackColor = Color.FromArgb(0, 80, 131),
                SelectionForeColor = Color.White,
                WrapMode = DataGridViewTriState.True
            };

            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                BackColor = SystemColors.Window,
                Font = new Font("Segoe UI", 12F),
                ForeColor = SystemColors.ControlText,
                SelectionBackColor = Color.FromArgb(173, 232, 244),
                SelectionForeColor = Color.Black,
                WrapMode = DataGridViewTriState.False
            };

            SetDataGridViewStyles(dtgvTTKH, columnHeaderStyle, cellStyle);

        }
        private void SetDataGridViewStyles(DataGridView dataGridView, DataGridViewCellStyle columnHeaderStyle, DataGridViewCellStyle cellStyle)
        {
            dataGridView.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            dataGridView.DefaultCellStyle = cellStyle;
        }

        private void dtgvTTKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dtgvTTKH.SelectedRows[0];
            KhachHang kh = KhDAO.ShowMembership(selectedRow.Cells[0].Value.ToString());
            if (kh != null)
            {
                txtCustomerID.Text = kh.MaKH;
                txtMembershipID.Text = kh.MaThe;
                txtCustomerName.Text = kh.Ho + " " + kh.TenLot + " " + kh.Ten;
                txtCustomerLevel.Text = kh.TenBacTV;
                txtCustomerDoB.Text = kh.NgaySinh.ToString();
                txtCustomerScore.Text = kh.SoDiem.ToString();
                txtCustomerGender.Text = kh.GioiTinh;
            }
            else
            {
                txtCustomerID.Text = selectedRow.Cells[0].Value.ToString();
                txtMembershipID.Text = selectedRow.Cells[1].Value.ToString();
                txtCustomerName.Text = selectedRow.Cells[2].Value.ToString()
                    + " " + selectedRow.Cells[3].Value.ToString()
                    + " " + selectedRow.Cells[4].Value.ToString();
                txtCustomerDoB.Text = selectedRow.Cells[5].Value.ToString();
                txtCustomerGender.Text = selectedRow.Cells[6].Value.ToString();
                txtCustomerLevel.Text = selectedRow.Cells[8].Value.ToString();
                txtCustomerScore.Text = selectedRow.Cells[7].Value.ToString();
            }
        }
    }
}
