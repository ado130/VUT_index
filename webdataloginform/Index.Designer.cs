namespace VUT_index
{
    partial class Index
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Index));
            this.btn_login = new System.Windows.Forms.Button();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lb_login = new System.Windows.Forms.Label();
            this.lb_pass = new System.Windows.Forms.Label();
            this.tb_login = new System.Windows.Forms.TextBox();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.DGV_index = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_logout = new System.Windows.Forms.Button();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.lb_copyright = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.lb_version = new System.Windows.Forms.Label();
            this.gb_menu = new System.Windows.Forms.GroupBox();
            this.btn_credits = new System.Windows.Forms.Button();
            this.chb_mailRemember = new System.Windows.Forms.CheckBox();
            this.chb_mail = new System.Windows.Forms.CheckBox();
            this.tb_mail = new System.Windows.Forms.TextBox();
            this.lb_mail = new System.Windows.Forms.Label();
            this.chb_loginRemember = new System.Windows.Forms.CheckBox();
            this.cb_Year = new System.Windows.Forms.ComboBox();
            this.cb_refresh = new System.Windows.Forms.ComboBox();
            this.show = new System.Windows.Forms.ToolStripMenuItem();
            this.exit = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Menu_show = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_logout = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.lb_status = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_index)).BeginInit();
            this.gb_menu.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(607, 11);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(126, 32);
            this.btn_login.TabIndex = 0;
            this.btn_login.Text = "Prihlásiť sa";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.button_login);
            // 
            // webBrowser
            // 
            this.webBrowser.Location = new System.Drawing.Point(12, 447);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(1326, 243);
            this.webBrowser.TabIndex = 1;
            this.webBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser1_Navigated);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 60000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lb_login
            // 
            this.lb_login.AutoSize = true;
            this.lb_login.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_login.Location = new System.Drawing.Point(6, 16);
            this.lb_login.Name = "lb_login";
            this.lb_login.Size = new System.Drawing.Size(45, 20);
            this.lb_login.TabIndex = 2;
            this.lb_login.Text = "Login";
            // 
            // lb_pass
            // 
            this.lb_pass.AutoSize = true;
            this.lb_pass.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_pass.Location = new System.Drawing.Point(234, 16);
            this.lb_pass.Name = "lb_pass";
            this.lb_pass.Size = new System.Drawing.Size(73, 20);
            this.lb_pass.TabIndex = 3;
            this.lb_pass.Text = "VUT heslo";
            // 
            // tb_login
            // 
            this.tb_login.Location = new System.Drawing.Point(57, 16);
            this.tb_login.Name = "tb_login";
            this.tb_login.Size = new System.Drawing.Size(171, 20);
            this.tb_login.TabIndex = 4;
            // 
            // tb_password
            // 
            this.tb_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_password.Location = new System.Drawing.Point(313, 16);
            this.tb_password.Name = "tb_password";
            this.tb_password.PasswordChar = '*';
            this.tb_password.Size = new System.Drawing.Size(171, 22);
            this.tb_password.TabIndex = 5;
            // 
            // DGV_index
            // 
            this.DGV_index.AllowUserToAddRows = false;
            this.DGV_index.AllowUserToDeleteRows = false;
            this.DGV_index.AllowUserToResizeColumns = false;
            this.DGV_index.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DGV_index.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DGV_index.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_index.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DGV_index.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_index.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DGV_index.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_index.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column9,
            this.Column10,
            this.Column12});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_index.DefaultCellStyle = dataGridViewCellStyle7;
            this.DGV_index.Location = new System.Drawing.Point(12, 97);
            this.DGV_index.Name = "DGV_index";
            this.DGV_index.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_index.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.DGV_index.RowHeadersVisible = false;
            this.DGV_index.Size = new System.Drawing.Size(1309, 344);
            this.DGV_index.TabIndex = 8;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column1.HeaderText = "zkr.";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 49;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column2.HeaderText = "názov predmetu";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 99;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column3.HeaderText = "jazyk";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 56;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column4.HeaderText = "typ";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 46;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column5.HeaderText = "kr.";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 44;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column6.HeaderText = "uk.";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 47;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column7.HeaderText = "záp.";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 52;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column9.HeaderText = "body";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 55;
            // 
            // Column10
            // 
            this.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column10.HeaderText = "zn.";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 46;
            // 
            // Column12
            // 
            this.Column12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column12.HeaderText = "absl.";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Width = 54;
            // 
            // btn_logout
            // 
            this.btn_logout.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_logout.Location = new System.Drawing.Point(739, 11);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(126, 32);
            this.btn_logout.TabIndex = 9;
            this.btn_logout.Text = "Odhlásiť sa";
            this.btn_logout.UseVisualStyleBackColor = true;
            this.btn_logout.Click += new System.EventHandler(this.button_logout);
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(871, 11);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(126, 32);
            this.btn_refresh.TabIndex = 10;
            this.btn_refresh.Text = "Obnoviť";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.button_refresh);
            // 
            // lb_copyright
            // 
            this.lb_copyright.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lb_copyright.AutoSize = true;
            this.lb_copyright.Location = new System.Drawing.Point(640, 707);
            this.lb_copyright.Name = "lb_copyright";
            this.lb_copyright.Size = new System.Drawing.Size(160, 13);
            this.lb_copyright.TabIndex = 11;
            this.lb_copyright.Text = "Copyright © 2017 Andrej Vlasatý";
            this.lb_copyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "VUT index";
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // lb_version
            // 
            this.lb_version.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_version.AutoSize = true;
            this.lb_version.Location = new System.Drawing.Point(1293, 707);
            this.lb_version.Name = "lb_version";
            this.lb_version.Size = new System.Drawing.Size(28, 13);
            this.lb_version.TabIndex = 12;
            this.lb_version.Text = "v7.0";
            // 
            // gb_menu
            // 
            this.gb_menu.Controls.Add(this.btn_credits);
            this.gb_menu.Controls.Add(this.chb_mailRemember);
            this.gb_menu.Controls.Add(this.chb_mail);
            this.gb_menu.Controls.Add(this.tb_mail);
            this.gb_menu.Controls.Add(this.lb_mail);
            this.gb_menu.Controls.Add(this.chb_loginRemember);
            this.gb_menu.Controls.Add(this.cb_Year);
            this.gb_menu.Controls.Add(this.cb_refresh);
            this.gb_menu.Controls.Add(this.lb_login);
            this.gb_menu.Controls.Add(this.tb_login);
            this.gb_menu.Controls.Add(this.lb_pass);
            this.gb_menu.Controls.Add(this.tb_password);
            this.gb_menu.Controls.Add(this.btn_refresh);
            this.gb_menu.Controls.Add(this.btn_login);
            this.gb_menu.Controls.Add(this.btn_logout);
            this.gb_menu.Location = new System.Drawing.Point(12, 12);
            this.gb_menu.Name = "gb_menu";
            this.gb_menu.Size = new System.Drawing.Size(1309, 79);
            this.gb_menu.TabIndex = 14;
            this.gb_menu.TabStop = false;
            this.gb_menu.Text = "Menu";
            // 
            // btn_credits
            // 
            this.btn_credits.Location = new System.Drawing.Point(1003, 11);
            this.btn_credits.Name = "btn_credits";
            this.btn_credits.Size = new System.Drawing.Size(126, 32);
            this.btn_credits.TabIndex = 21;
            this.btn_credits.Text = "Predmety";
            this.btn_credits.UseVisualStyleBackColor = true;
            this.btn_credits.Click += new System.EventHandler(this.btn_credits_Click);
            // 
            // chb_mailRemember
            // 
            this.chb_mailRemember.AutoSize = true;
            this.chb_mailRemember.Enabled = false;
            this.chb_mailRemember.Location = new System.Drawing.Point(303, 45);
            this.chb_mailRemember.Name = "chb_mailRemember";
            this.chb_mailRemember.Size = new System.Drawing.Size(78, 17);
            this.chb_mailRemember.TabIndex = 20;
            this.chb_mailRemember.Text = "Zapamätať";
            this.chb_mailRemember.UseVisualStyleBackColor = true;
            // 
            // chb_mail
            // 
            this.chb_mail.AutoSize = true;
            this.chb_mail.Enabled = false;
            this.chb_mail.Location = new System.Drawing.Point(234, 45);
            this.chb_mail.Name = "chb_mail";
            this.chb_mail.Size = new System.Drawing.Size(63, 17);
            this.chb_mail.TabIndex = 19;
            this.chb_mail.Text = "Odoslať";
            this.chb_mail.UseVisualStyleBackColor = true;
            // 
            // tb_mail
            // 
            this.tb_mail.Enabled = false;
            this.tb_mail.Location = new System.Drawing.Point(57, 42);
            this.tb_mail.Name = "tb_mail";
            this.tb_mail.Size = new System.Drawing.Size(171, 20);
            this.tb_mail.TabIndex = 18;
            // 
            // lb_mail
            // 
            this.lb_mail.AutoSize = true;
            this.lb_mail.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_mail.Location = new System.Drawing.Point(6, 40);
            this.lb_mail.Name = "lb_mail";
            this.lb_mail.Size = new System.Drawing.Size(35, 20);
            this.lb_mail.TabIndex = 17;
            this.lb_mail.Text = "Mail";
            // 
            // chb_loginRemember
            // 
            this.chb_loginRemember.AutoSize = true;
            this.chb_loginRemember.Location = new System.Drawing.Point(491, 20);
            this.chb_loginRemember.Name = "chb_loginRemember";
            this.chb_loginRemember.Size = new System.Drawing.Size(78, 17);
            this.chb_loginRemember.TabIndex = 16;
            this.chb_loginRemember.Text = "Zapamätať";
            this.chb_loginRemember.UseVisualStyleBackColor = true;
            // 
            // cb_Year
            // 
            this.cb_Year.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Year.FormattingEnabled = true;
            this.cb_Year.Location = new System.Drawing.Point(1211, 11);
            this.cb_Year.Name = "cb_Year";
            this.cb_Year.Size = new System.Drawing.Size(90, 21);
            this.cb_Year.TabIndex = 12;
            this.cb_Year.SelectedIndexChanged += new System.EventHandler(this.cb_Year_SelectedIndexChanged_1);
            // 
            // cb_refresh
            // 
            this.cb_refresh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_refresh.FormattingEnabled = true;
            this.cb_refresh.Items.AddRange(new object[] {
            "30sec",
            "1min",
            "5min",
            "10min",
            "30min",
            "59min"});
            this.cb_refresh.Location = new System.Drawing.Point(1211, 36);
            this.cb_refresh.Name = "cb_refresh";
            this.cb_refresh.Size = new System.Drawing.Size(90, 21);
            this.cb_refresh.TabIndex = 11;
            this.cb_refresh.SelectedIndexChanged += new System.EventHandler(this.cb_refresh_SelectedIndexChanged);
            // 
            // show
            // 
            this.show.Name = "show";
            this.show.Size = new System.Drawing.Size(152, 22);
            this.show.Text = "Zobraziť";
            // 
            // exit
            // 
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(152, 22);
            this.exit.Text = "Ukončiť";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_show,
            this.Menu_logout,
            this.Menu_exit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(113, 70);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // Menu_show
            // 
            this.Menu_show.Name = "Menu_show";
            this.Menu_show.Size = new System.Drawing.Size(112, 22);
            this.Menu_show.Text = "Show";
            // 
            // Menu_logout
            // 
            this.Menu_logout.Name = "Menu_logout";
            this.Menu_logout.Size = new System.Drawing.Size(112, 22);
            this.Menu_logout.Text = "Logout";
            // 
            // Menu_exit
            // 
            this.Menu_exit.Name = "Menu_exit";
            this.Menu_exit.Size = new System.Drawing.Size(112, 22);
            this.Menu_exit.Text = "Exit";
            // 
            // lb_status
            // 
            this.lb_status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_status.AutoSize = true;
            this.lb_status.Location = new System.Drawing.Point(1250, 707);
            this.lb_status.Name = "lb_status";
            this.lb_status.Size = new System.Drawing.Size(10, 13);
            this.lb_status.TabIndex = 15;
            this.lb_status.Text = " ";
            // 
            // Index
            // 
            this.AcceptButton = this.btn_login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.lb_status);
            this.Controls.Add(this.gb_menu);
            this.Controls.Add(this.lb_version);
            this.Controls.Add(this.lb_copyright);
            this.Controls.Add(this.DGV_index);
            this.Controls.Add(this.webBrowser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Index";
            this.Text = "VUT index";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_index)).EndInit();
            this.gb_menu.ResumeLayout(false);
            this.gb_menu.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lb_login;
        private System.Windows.Forms.Label lb_pass;
        private System.Windows.Forms.TextBox tb_login;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.DataGridView DGV_index;
        private System.Windows.Forms.Button btn_logout;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Label lb_copyright;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Label lb_version;
        private System.Windows.Forms.GroupBox gb_menu;
        private System.Windows.Forms.ComboBox cb_refresh;
        private System.Windows.Forms.ToolStripMenuItem show;
        private System.Windows.Forms.ToolStripMenuItem exit;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Menu_show;
        private System.Windows.Forms.ToolStripMenuItem Menu_exit;
        private System.Windows.Forms.ToolStripMenuItem Menu_logout;
        private System.Windows.Forms.Label lb_status;
        private System.Windows.Forms.ComboBox cb_Year;
        private System.Windows.Forms.CheckBox chb_loginRemember;
        private System.Windows.Forms.CheckBox chb_mail;
        private System.Windows.Forms.TextBox tb_mail;
        private System.Windows.Forms.Label lb_mail;
        private System.Windows.Forms.CheckBox chb_mailRemember;
        private System.Windows.Forms.Button btn_credits;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
    }
}

