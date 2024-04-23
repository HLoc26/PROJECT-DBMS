using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS_BookStore
{
    public partial class FThemTTSach : Form
    {
        public FThemTTSach()
        {
            InitializeComponent();
        }

        private void txbTenSach_TextChanged(object sender, EventArgs e)
        {
            // Check tên sách với mỗi ký tự được nhập vào
        }

        private void txbTenTG_TextChanged(object sender, EventArgs e)
        {
            // Check tên TG với mỗi ký tự được nhập vào
        }

        private void txbTenNXB_TextChanged(object sender, EventArgs e)
        {
            // Check tên nxb với mỗi ký tự được nhập vào
        }
    }
}
