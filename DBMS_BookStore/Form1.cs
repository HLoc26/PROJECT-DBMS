﻿using DBMS_BookStore.UC;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnlUCContainer.Controls.Clear();
            pnlUCContainer.Controls.Add(new UCTest1());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnlUCContainer.Controls.Clear();
            pnlUCContainer.Controls.Add(new UCTest2());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pnlUCContainer.Controls.Clear();
            pnlUCContainer.Controls.Add(new UCTest3());
        }
    }
}
