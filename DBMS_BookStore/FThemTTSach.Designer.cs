namespace DBMS_BookStore
{
    partial class FThemTTSach
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txbTenSach = new System.Windows.Forms.TextBox();
            this.txbTenNXB = new System.Windows.Forms.TextBox();
            this.txbMaNXB = new System.Windows.Forms.TextBox();
            this.tlplNXB = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tlplSach = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.txbMaSach = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbTenTG = new System.Windows.Forms.TextBox();
            this.txbMaTG = new System.Windows.Forms.TextBox();
            this.tlplTG = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tlplOther = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txbDiaChiNXB = new System.Windows.Forms.TextBox();
            this.txbSDTNXB = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txbTheLoai = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.numDonGia = new System.Windows.Forms.NumericUpDown();
            this.numNamXB = new System.Windows.Forms.NumericUpDown();
            this.tlplNXB.SuspendLayout();
            this.tlplSach.SuspendLayout();
            this.tlplTG.SuspendLayout();
            this.tlplOther.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDonGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNamXB)).BeginInit();
            this.SuspendLayout();
            // 
            // txbTenSach
            // 
            this.txbTenSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbTenSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txbTenSach.Location = new System.Drawing.Point(3, 56);
            this.txbTenSach.Name = "txbTenSach";
            this.txbTenSach.Size = new System.Drawing.Size(291, 30);
            this.txbTenSach.TabIndex = 0;
            this.txbTenSach.Leave += new System.EventHandler(this.txbTenSach_Leave);
            // 
            // txbTenNXB
            // 
            this.txbTenNXB.AutoCompleteCustomSource.AddRange(new string[] {
            "Nhà xuất bản Giáo dục Việt Nam",
            "Nhà xuất bản Kim Đồng",
            "Nhà xuất bản Trẻ",
            "Nhà xuất bản Thanh Niên",
            "Nhà xuất bản Đại Học Kinh Tế Quốc Dân",
            "Nhà xuất bản Hà Nội",
            "Cambridge University Press & Assessment"});
            this.txbTenNXB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txbTenNXB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txbTenNXB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbTenNXB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txbTenNXB.Location = new System.Drawing.Point(3, 46);
            this.txbTenNXB.Name = "txbTenNXB";
            this.txbTenNXB.Size = new System.Drawing.Size(350, 30);
            this.txbTenNXB.TabIndex = 2;
            this.txbTenNXB.TextChanged += new System.EventHandler(this.txbTenNXB_TextChanged);
            // 
            // txbMaNXB
            // 
            this.txbMaNXB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbMaNXB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txbMaNXB.Location = new System.Drawing.Point(359, 46);
            this.txbMaNXB.Name = "txbMaNXB";
            this.txbMaNXB.ReadOnly = true;
            this.txbMaNXB.Size = new System.Drawing.Size(232, 30);
            this.txbMaNXB.TabIndex = 3;
            this.txbMaNXB.TabStop = false;
            // 
            // tlplNXB
            // 
            this.tlplNXB.ColumnCount = 2;
            this.tlplNXB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlplNXB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlplNXB.Controls.Add(this.txbTenNXB, 0, 1);
            this.tlplNXB.Controls.Add(this.txbMaNXB, 1, 1);
            this.tlplNXB.Controls.Add(this.label9, 1, 4);
            this.tlplNXB.Controls.Add(this.label8, 1, 0);
            this.tlplNXB.Controls.Add(this.label6, 0, 0);
            this.tlplNXB.Controls.Add(this.txbDiaChiNXB, 0, 3);
            this.tlplNXB.Controls.Add(this.txbSDTNXB, 0, 5);
            this.tlplNXB.Controls.Add(this.label10, 0, 4);
            this.tlplNXB.Controls.Add(this.label11, 0, 2);
            this.tlplNXB.Controls.Add(this.numNamXB, 1, 5);
            this.tlplNXB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlplNXB.Location = new System.Drawing.Point(8, 309);
            this.tlplNXB.Name = "tlplNXB";
            this.tlplNXB.RowCount = 6;
            this.tlplNXB.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66666F));
            this.tlplNXB.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66666F));
            this.tlplNXB.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66666F));
            this.tlplNXB.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66666F));
            this.tlplNXB.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66666F));
            this.tlplNXB.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66666F));
            this.tlplNXB.Size = new System.Drawing.Size(594, 259);
            this.tlplNXB.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label8.Location = new System.Drawing.Point(359, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(173, 26);
            this.label8.TabIndex = 7;
            this.label8.Text = "Mã nhà xuất bản";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label6.Location = new System.Drawing.Point(3, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 26);
            this.label6.TabIndex = 7;
            this.label6.Text = "Tên nhà xuất bản";
            // 
            // tlplSach
            // 
            this.tlplSach.ColumnCount = 2;
            this.tlplSach.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlplSach.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlplSach.Controls.Add(this.label2, 0, 0);
            this.tlplSach.Controls.Add(this.txbTenSach, 0, 1);
            this.tlplSach.Controls.Add(this.txbMaSach, 1, 1);
            this.tlplSach.Controls.Add(this.label3, 1, 0);
            this.tlplSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlplSach.Location = new System.Drawing.Point(8, 83);
            this.tlplSach.Name = "tlplSach";
            this.tlplSach.RowCount = 2;
            this.tlplSach.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlplSach.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlplSach.Size = new System.Drawing.Size(594, 107);
            this.tlplSach.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label2.Location = new System.Drawing.Point(3, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 26);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tên sách";
            // 
            // txbMaSach
            // 
            this.txbMaSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbMaSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txbMaSach.Location = new System.Drawing.Point(300, 56);
            this.txbMaSach.Name = "txbMaSach";
            this.txbMaSach.ReadOnly = true;
            this.txbMaSach.Size = new System.Drawing.Size(291, 30);
            this.txbMaSach.TabIndex = 1;
            this.txbMaSach.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label3.Location = new System.Drawing.Point(300, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "Mã sách";
            // 
            // txbTenTG
            // 
            this.txbTenTG.AutoCompleteCustomSource.AddRange(new string[] {
            "J. K. Rowling",
            "Edmondo De Amicis",
            "Jenny Nimmo",
            "Mai Lan Hương",
            "Hà Thanh Uyên",
            "The Windy",
            "Lê Thu Hà",
            "Ban biên tập MIS",
            "Nhiều tác giả",
            "Gosho Aoyama",
            "Akira Toriyama",
            "Inagaki Riichiro",
            "Eiichiro Oda",
            "Paulo Coelho",
            "Nguyễn Nhật Ánh"});
            this.txbTenTG.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txbTenTG.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txbTenTG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbTenTG.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txbTenTG.Location = new System.Drawing.Point(3, 56);
            this.txbTenTG.Name = "txbTenTG";
            this.txbTenTG.Size = new System.Drawing.Size(291, 30);
            this.txbTenTG.TabIndex = 6;
            this.txbTenTG.TextChanged += new System.EventHandler(this.txbTenTG_TextChanged);
            // 
            // txbMaTG
            // 
            this.txbMaTG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbMaTG.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txbMaTG.Location = new System.Drawing.Point(300, 56);
            this.txbMaTG.Name = "txbMaTG";
            this.txbMaTG.ReadOnly = true;
            this.txbMaTG.Size = new System.Drawing.Size(291, 30);
            this.txbMaTG.TabIndex = 7;
            this.txbMaTG.TabStop = false;
            // 
            // tlplTG
            // 
            this.tlplTG.ColumnCount = 2;
            this.tlplTG.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlplTG.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlplTG.Controls.Add(this.txbTenTG, 0, 1);
            this.tlplTG.Controls.Add(this.txbMaTG, 1, 1);
            this.tlplTG.Controls.Add(this.label4, 0, 0);
            this.tlplTG.Controls.Add(this.label5, 1, 0);
            this.tlplTG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlplTG.Location = new System.Drawing.Point(8, 196);
            this.tlplTG.Name = "tlplTG";
            this.tlplTG.RowCount = 2;
            this.tlplTG.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlplTG.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlplTG.Size = new System.Drawing.Size(594, 107);
            this.tlplTG.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label4.Location = new System.Drawing.Point(3, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 26);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tên tác giả";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label5.Location = new System.Drawing.Point(300, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 26);
            this.label5.TabIndex = 7;
            this.label5.Text = "Mã tác giả";
            // 
            // tlplOther
            // 
            this.tlplOther.ColumnCount = 2;
            this.tlplOther.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlplOther.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlplOther.Controls.Add(this.label12, 1, 0);
            this.tlplOther.Controls.Add(this.label7, 0, 0);
            this.tlplOther.Controls.Add(this.txbTheLoai, 1, 1);
            this.tlplOther.Controls.Add(this.numDonGia, 0, 1);
            this.tlplOther.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlplOther.Location = new System.Drawing.Point(8, 574);
            this.tlplOther.Name = "tlplOther";
            this.tlplOther.RowCount = 2;
            this.tlplOther.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlplOther.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlplOther.Size = new System.Drawing.Size(594, 107);
            this.tlplOther.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label9.Location = new System.Drawing.Point(359, 189);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(148, 26);
            this.label9.TabIndex = 7;
            this.label9.Text = "Năm xuất bản";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label7.Location = new System.Drawing.Point(3, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 26);
            this.label7.TabIndex = 7;
            this.label7.Text = "Đơn giá";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tlplSach, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tlplOther, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tlplTG, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tlplNXB, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(610, 768);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnOK, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnCancel, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(8, 687);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(594, 73);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnOK.Location = new System.Drawing.Point(390, 14);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(111, 45);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "Xác nhận";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnCancel.Location = new System.Drawing.Point(93, 14);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(111, 45);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Huỷ";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label1.Location = new System.Drawing.Point(143, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 39);
            this.label1.TabIndex = 6;
            this.label1.Text = "Thêm thông tin sách";
            // 
            // txbDiaChiNXB
            // 
            this.tlplNXB.SetColumnSpan(this.txbDiaChiNXB, 2);
            this.txbDiaChiNXB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbDiaChiNXB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txbDiaChiNXB.Location = new System.Drawing.Point(3, 132);
            this.txbDiaChiNXB.Name = "txbDiaChiNXB";
            this.txbDiaChiNXB.Size = new System.Drawing.Size(588, 30);
            this.txbDiaChiNXB.TabIndex = 8;
            // 
            // txbSDTNXB
            // 
            this.txbSDTNXB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbSDTNXB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txbSDTNXB.Location = new System.Drawing.Point(3, 218);
            this.txbSDTNXB.Name = "txbSDTNXB";
            this.txbSDTNXB.Size = new System.Drawing.Size(350, 30);
            this.txbSDTNXB.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label10.Location = new System.Drawing.Point(3, 189);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(190, 26);
            this.label10.TabIndex = 10;
            this.label10.Text = "SĐT Nhà xuất bản";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label11.Location = new System.Drawing.Point(3, 103);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(168, 26);
            this.label11.TabIndex = 11;
            this.label11.Text = "Địa chỉ xuất bản";
            // 
            // txbTheLoai
            // 
            this.txbTheLoai.AutoCompleteCustomSource.AddRange(new string[] {
            "Tiểu thuyết",
            "Truyện tranh",
            "Kinh doanh",
            "Sách giáo khoa",
            "Ngoại ngữ"});
            this.txbTheLoai.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txbTheLoai.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txbTheLoai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbTheLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txbTheLoai.Location = new System.Drawing.Point(300, 56);
            this.txbTheLoai.Name = "txbTheLoai";
            this.txbTheLoai.Size = new System.Drawing.Size(291, 30);
            this.txbTheLoai.TabIndex = 8;
            this.txbTheLoai.Leave += new System.EventHandler(this.txbTheLoai_Leave);
            this.txbTheLoai.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txbTheLoai_MouseDown);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label12.Location = new System.Drawing.Point(300, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 26);
            this.label12.TabIndex = 9;
            this.label12.Text = "Thể loại";
            // 
            // numDonGia
            // 
            this.numDonGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numDonGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.numDonGia.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numDonGia.Location = new System.Drawing.Point(3, 56);
            this.numDonGia.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numDonGia.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numDonGia.Name = "numDonGia";
            this.numDonGia.Size = new System.Drawing.Size(291, 30);
            this.numDonGia.TabIndex = 10;
            this.numDonGia.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // numNamXB
            // 
            this.numNamXB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numNamXB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.numNamXB.Location = new System.Drawing.Point(359, 218);
            this.numNamXB.Maximum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.numNamXB.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.numNamXB.Name = "numNamXB";
            this.numNamXB.Size = new System.Drawing.Size(232, 30);
            this.numNamXB.TabIndex = 12;
            this.numNamXB.Value = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            // 
            // FThemTTSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 768);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FThemTTSach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm thông tin";
            this.tlplNXB.ResumeLayout(false);
            this.tlplNXB.PerformLayout();
            this.tlplSach.ResumeLayout(false);
            this.tlplSach.PerformLayout();
            this.tlplTG.ResumeLayout(false);
            this.tlplTG.PerformLayout();
            this.tlplOther.ResumeLayout(false);
            this.tlplOther.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numDonGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNamXB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txbTenSach;
        private System.Windows.Forms.TextBox txbTenNXB;
        private System.Windows.Forms.TextBox txbMaNXB;
        private System.Windows.Forms.TableLayoutPanel tlplNXB;
        private System.Windows.Forms.TableLayoutPanel tlplSach;
        private System.Windows.Forms.TextBox txbMaSach;
        private System.Windows.Forms.TextBox txbTenTG;
        private System.Windows.Forms.TextBox txbMaTG;
        private System.Windows.Forms.TableLayoutPanel tlplTG;
        private System.Windows.Forms.TableLayoutPanel tlplOther;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbDiaChiNXB;
        private System.Windows.Forms.TextBox txbSDTNXB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txbTheLoai;
        private System.Windows.Forms.NumericUpDown numDonGia;
        private System.Windows.Forms.NumericUpDown numNamXB;
    }
}