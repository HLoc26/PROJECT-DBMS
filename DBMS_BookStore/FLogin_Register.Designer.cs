namespace DBMS_BookStore
{
    partial class FLogin_Register
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tblpPassword = new System.Windows.Forms.TableLayoutPanel();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.lblIncorrectPassword = new System.Windows.Forms.Label();
            this.tblpUsername = new System.Windows.Forms.TableLayoutPanel();
            this.txbUsername = new System.Windows.Forms.TextBox();
            this.lblIncorrectUsername = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tblpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tblpPassword.SuspendLayout();
            this.tblpUsername.SuspendLayout();
            this.tblpButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(541, 432);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.Controls.Add(this.tblpPassword, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tblpUsername, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tblpButtons, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(57, 111);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(426, 210);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tblpPassword
            // 
            this.tblpPassword.ColumnCount = 1;
            this.tblpPassword.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblpPassword.Controls.Add(this.txbPassword, 0, 0);
            this.tblpPassword.Controls.Add(this.lblIncorrectPassword, 0, 1);
            this.tblpPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblpPassword.Location = new System.Drawing.Point(109, 81);
            this.tblpPassword.Name = "tblpPassword";
            this.tblpPassword.RowCount = 2;
            this.tblpPassword.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblpPassword.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblpPassword.Size = new System.Drawing.Size(314, 72);
            this.tblpPassword.TabIndex = 2;
            // 
            // txbPassword
            // 
            this.txbPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPassword.Location = new System.Drawing.Point(3, 3);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.Size = new System.Drawing.Size(308, 29);
            this.txbPassword.TabIndex = 1;
            this.txbPassword.TextChanged += new System.EventHandler(this.txbPassword_TextChanged);
            // 
            // lblIncorrectPassword
            // 
            this.lblIncorrectPassword.AutoSize = true;
            this.lblIncorrectPassword.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblIncorrectPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIncorrectPassword.ForeColor = System.Drawing.Color.Red;
            this.lblIncorrectPassword.Location = new System.Drawing.Point(3, 36);
            this.lblIncorrectPassword.Name = "lblIncorrectPassword";
            this.lblIncorrectPassword.Size = new System.Drawing.Size(308, 16);
            this.lblIncorrectPassword.TabIndex = 2;
            this.lblIncorrectPassword.Text = "Incorrect Username or Password";
            // 
            // tblpUsername
            // 
            this.tblpUsername.ColumnCount = 1;
            this.tblpUsername.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblpUsername.Controls.Add(this.txbUsername, 0, 0);
            this.tblpUsername.Controls.Add(this.lblIncorrectUsername, 0, 1);
            this.tblpUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblpUsername.Location = new System.Drawing.Point(109, 3);
            this.tblpUsername.Name = "tblpUsername";
            this.tblpUsername.RowCount = 2;
            this.tblpUsername.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblpUsername.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblpUsername.Size = new System.Drawing.Size(314, 72);
            this.tblpUsername.TabIndex = 0;
            // 
            // txbUsername
            // 
            this.txbUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbUsername.Location = new System.Drawing.Point(3, 3);
            this.txbUsername.Name = "txbUsername";
            this.txbUsername.Size = new System.Drawing.Size(300, 29);
            this.txbUsername.TabIndex = 0;
            this.txbUsername.TextChanged += new System.EventHandler(this.txbUsername_TextChanged);
            // 
            // lblIncorrectUsername
            // 
            this.lblIncorrectUsername.AutoSize = true;
            this.lblIncorrectUsername.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblIncorrectUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIncorrectUsername.ForeColor = System.Drawing.Color.Red;
            this.lblIncorrectUsername.Location = new System.Drawing.Point(3, 36);
            this.lblIncorrectUsername.Name = "lblIncorrectUsername";
            this.lblIncorrectUsername.Size = new System.Drawing.Size(308, 16);
            this.lblIncorrectUsername.TabIndex = 1;
            this.lblIncorrectUsername.Text = "Incorrect Username or password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 78);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 78);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // tblpButtons
            // 
            this.tblpButtons.ColumnCount = 2;
            this.tblpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblpButtons.Controls.Add(this.btnLogin, 1, 0);
            this.tblpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblpButtons.Location = new System.Drawing.Point(109, 159);
            this.tblpButtons.Name = "tblpButtons";
            this.tblpButtons.RowCount = 1;
            this.tblpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tblpButtons.Size = new System.Drawing.Size(314, 48);
            this.tblpButtons.TabIndex = 4;
            // 
            // btnLogin
            // 
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogin.Location = new System.Drawing.Point(160, 3);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(151, 42);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // FLogin_Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(541, 432);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "FLogin_Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FLogin_Register";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tblpPassword.ResumeLayout(false);
            this.tblpPassword.PerformLayout();
            this.tblpUsername.ResumeLayout(false);
            this.tblpUsername.PerformLayout();
            this.tblpButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txbUsername;
        private System.Windows.Forms.TextBox txbPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tblpButtons;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tblpPassword;
        private System.Windows.Forms.Label lblIncorrectPassword;
        private System.Windows.Forms.TableLayoutPanel tblpUsername;
        private System.Windows.Forms.Label lblIncorrectUsername;
    }
}