using DBMS_BookStore.DTO;
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
    public partial class TenDN : Form
    {
        public TenDN()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Employee nv = new Employee("000", txtbCMND.Text, txtbHo.Text, TenLot.Text, Ten.Text, textBox6.Text, MK);
        }
    }
}
