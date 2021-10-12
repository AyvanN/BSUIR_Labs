
namespace RentCar
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.accountInfo = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.logout = new FontAwesome.Sharp.IconButton();
            this.settings = new FontAwesome.Sharp.IconButton();
            this.boockingList = new FontAwesome.Sharp.IconButton();
            this.home = new FontAwesome.Sharp.IconButton();
            this.catalog = new FontAwesome.Sharp.IconButton();
            this.UpperPanel = new System.Windows.Forms.Panel();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.wallet = new System.Windows.Forms.Label();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.hide = new FontAwesome.Sharp.IconButton();
            this.maximize = new FontAwesome.Sharp.IconButton();
            this.currentFormIcon = new FontAwesome.Sharp.IconPictureBox();
            this.formTitle = new System.Windows.Forms.Label();
            this.panelShadow = new System.Windows.Forms.Panel();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.UpperPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentFormIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.panelMenu.Controls.Add(this.panel1);
            this.panelMenu.Controls.Add(this.logout);
            this.panelMenu.Controls.Add(this.settings);
            this.panelMenu.Controls.Add(this.boockingList);
            this.panelMenu.Controls.Add(this.home);
            this.panelMenu.Controls.Add(this.catalog);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(2);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(183, 643);
            this.panelMenu.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.panel1.Controls.Add(this.accountInfo);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(183, 115);
            this.panel1.TabIndex = 8;
            // 
            // accountInfo
            // 
            this.accountInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.accountInfo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.accountInfo.FlatAppearance.BorderSize = 0;
            this.accountInfo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.accountInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.accountInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.accountInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.accountInfo.ForeColor = System.Drawing.Color.White;
            this.accountInfo.Location = new System.Drawing.Point(0, 70);
            this.accountInfo.Name = "accountInfo";
            this.accountInfo.Size = new System.Drawing.Size(183, 29);
            this.accountInfo.TabIndex = 0;
            this.accountInfo.Text = "Username";
            this.accountInfo.UseVisualStyleBackColor = true;
            this.accountInfo.Click += new System.EventHandler(this.accountInfo_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::RentCar.Properties.Resources.User_v11;
            this.pictureBox1.Location = new System.Drawing.Point(49, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(86, 76);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.accountInfo_Click);
            // 
            // logout
            // 
            this.logout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.logout.FlatAppearance.BorderSize = 0;
            this.logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logout.ForeColor = System.Drawing.Color.DarkGray;
            this.logout.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.logout.IconColor = System.Drawing.Color.Black;
            this.logout.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.logout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logout.Location = new System.Drawing.Point(0, 594);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(183, 49);
            this.logout.TabIndex = 7;
            this.logout.Text = "Logout";
            this.logout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.logout.UseVisualStyleBackColor = true;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // settings
            // 
            this.settings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settings.FlatAppearance.BorderSize = 0;
            this.settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.settings.ForeColor = System.Drawing.Color.DarkGray;
            this.settings.IconChar = FontAwesome.Sharp.IconChar.Cogs;
            this.settings.IconColor = System.Drawing.Color.Black;
            this.settings.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.settings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.settings.Location = new System.Drawing.Point(0, 287);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(185, 49);
            this.settings.TabIndex = 7;
            this.settings.Text = "Settings";
            this.settings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.settings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.settings.UseVisualStyleBackColor = true;
            this.settings.Click += new System.EventHandler(this.settings_Click);
            // 
            // boockingList
            // 
            this.boockingList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.boockingList.FlatAppearance.BorderSize = 0;
            this.boockingList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.boockingList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.boockingList.ForeColor = System.Drawing.Color.DarkGray;
            this.boockingList.IconChar = FontAwesome.Sharp.IconChar.Car;
            this.boockingList.IconColor = System.Drawing.Color.Black;
            this.boockingList.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.boockingList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.boockingList.Location = new System.Drawing.Point(0, 232);
            this.boockingList.Name = "boockingList";
            this.boockingList.Size = new System.Drawing.Size(185, 49);
            this.boockingList.TabIndex = 7;
            this.boockingList.Text = "Booking List";
            this.boockingList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.boockingList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.boockingList.UseVisualStyleBackColor = true;
            this.boockingList.Click += new System.EventHandler(this.bookingList_Click);
            // 
            // home
            // 
            this.home.Cursor = System.Windows.Forms.Cursors.Hand;
            this.home.FlatAppearance.BorderSize = 0;
            this.home.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.home.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.home.ForeColor = System.Drawing.Color.DarkGray;
            this.home.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.home.IconColor = System.Drawing.Color.Black;
            this.home.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.home.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.home.Location = new System.Drawing.Point(0, 122);
            this.home.Name = "home";
            this.home.Size = new System.Drawing.Size(185, 49);
            this.home.TabIndex = 7;
            this.home.Text = "Home";
            this.home.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.home.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.home.UseVisualStyleBackColor = true;
            this.home.Click += new System.EventHandler(this.home_Click);
            // 
            // catalog
            // 
            this.catalog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.catalog.FlatAppearance.BorderSize = 0;
            this.catalog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.catalog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.catalog.ForeColor = System.Drawing.Color.DarkGray;
            this.catalog.IconChar = FontAwesome.Sharp.IconChar.ShoppingCart;
            this.catalog.IconColor = System.Drawing.Color.Black;
            this.catalog.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.catalog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.catalog.Location = new System.Drawing.Point(0, 177);
            this.catalog.Name = "catalog";
            this.catalog.Size = new System.Drawing.Size(185, 49);
            this.catalog.TabIndex = 7;
            this.catalog.Text = "Catalog";
            this.catalog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.catalog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.catalog.UseVisualStyleBackColor = true;
            this.catalog.Click += new System.EventHandler(this.catalog_Click);
            // 
            // UpperPanel
            // 
            this.UpperPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.UpperPanel.Controls.Add(this.iconPictureBox1);
            this.UpperPanel.Controls.Add(this.wallet);
            this.UpperPanel.Controls.Add(this.iconButton1);
            this.UpperPanel.Controls.Add(this.hide);
            this.UpperPanel.Controls.Add(this.maximize);
            this.UpperPanel.Controls.Add(this.currentFormIcon);
            this.UpperPanel.Controls.Add(this.formTitle);
            this.UpperPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.UpperPanel.Location = new System.Drawing.Point(183, 0);
            this.UpperPanel.Name = "UpperPanel";
            this.UpperPanel.Size = new System.Drawing.Size(1273, 55);
            this.UpperPanel.TabIndex = 7;
            this.UpperPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UpperPanel_MouseDown);
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Wallet;
            this.iconPictureBox1.IconColor = System.Drawing.Color.White;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 23;
            this.iconPictureBox1.Location = new System.Drawing.Point(1117, 3);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(28, 23);
            this.iconPictureBox1.TabIndex = 10;
            this.iconPictureBox1.TabStop = false;
            // 
            // wallet
            // 
            this.wallet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.wallet.AutoSize = true;
            this.wallet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.wallet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.wallet.ForeColor = System.Drawing.Color.White;
            this.wallet.Location = new System.Drawing.Point(1141, 5);
            this.wallet.Name = "wallet";
            this.wallet.Size = new System.Drawing.Size(54, 16);
            this.wallet.TabIndex = 9;
            this.wallet.Text = "Money";
            // 
            // iconButton1
            // 
            this.iconButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.iconButton1.IconColor = System.Drawing.Color.White;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 15;
            this.iconButton1.Location = new System.Drawing.Point(1251, 6);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(10, 16);
            this.iconButton1.TabIndex = 0;
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // hide
            // 
            this.hide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hide.FlatAppearance.BorderSize = 0;
            this.hide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hide.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.hide.IconColor = System.Drawing.Color.White;
            this.hide.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.hide.IconSize = 15;
            this.hide.Location = new System.Drawing.Point(1215, 6);
            this.hide.Name = "hide";
            this.hide.Size = new System.Drawing.Size(20, 15);
            this.hide.TabIndex = 0;
            this.hide.UseVisualStyleBackColor = true;
            this.hide.Click += new System.EventHandler(this.hide_Click);
            // 
            // maximize
            // 
            this.maximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.maximize.FlatAppearance.BorderSize = 0;
            this.maximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maximize.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            this.maximize.IconColor = System.Drawing.Color.White;
            this.maximize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.maximize.IconSize = 15;
            this.maximize.Location = new System.Drawing.Point(1232, 3);
            this.maximize.Name = "maximize";
            this.maximize.Size = new System.Drawing.Size(18, 25);
            this.maximize.TabIndex = 0;
            this.maximize.UseVisualStyleBackColor = true;
            this.maximize.Click += new System.EventHandler(this.maximize_Click);
            // 
            // currentFormIcon
            // 
            this.currentFormIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.currentFormIcon.ForeColor = System.Drawing.Color.Black;
            this.currentFormIcon.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.currentFormIcon.IconColor = System.Drawing.Color.Black;
            this.currentFormIcon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.currentFormIcon.IconSize = 46;
            this.currentFormIcon.Location = new System.Drawing.Point(5, 12);
            this.currentFormIcon.Name = "currentFormIcon";
            this.currentFormIcon.Size = new System.Drawing.Size(46, 49);
            this.currentFormIcon.TabIndex = 8;
            this.currentFormIcon.TabStop = false;
            // 
            // formTitle
            // 
            this.formTitle.AutoSize = true;
            this.formTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.formTitle.ForeColor = System.Drawing.Color.White;
            this.formTitle.Location = new System.Drawing.Point(55, 20);
            this.formTitle.Name = "formTitle";
            this.formTitle.Size = new System.Drawing.Size(56, 20);
            this.formTitle.TabIndex = 8;
            this.formTitle.Text = "Home";
            // 
            // panelShadow
            // 
            this.panelShadow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.panelShadow.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelShadow.Location = new System.Drawing.Point(183, 55);
            this.panelShadow.Name = "panelShadow";
            this.panelShadow.Size = new System.Drawing.Size(1273, 11);
            this.panelShadow.TabIndex = 9;
            // 
            // panelDesktop
            // 
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(183, 55);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(1273, 588);
            this.panelDesktop.TabIndex = 9;
            this.panelDesktop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UpperPanel_MouseDown);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1456, 643);
            this.Controls.Add(this.panelShadow);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.UpperPanel);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panelMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.UpperPanel.ResumeLayout(false);
            this.UpperPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentFormIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelMenu;
        private FontAwesome.Sharp.IconButton settings;
        private FontAwesome.Sharp.IconButton logout;
        private FontAwesome.Sharp.IconButton boockingList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel UpperPanel;
        private FontAwesome.Sharp.IconPictureBox currentFormIcon;
        private System.Windows.Forms.Label formTitle;
        private System.Windows.Forms.Panel panelShadow;
        private FontAwesome.Sharp.IconButton home;
        private System.Windows.Forms.Panel panelDesktop;
        private FontAwesome.Sharp.IconButton maximize;
        private FontAwesome.Sharp.IconButton hide;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        public FontAwesome.Sharp.IconButton catalog;
        public System.Windows.Forms.Button accountInfo;
        public System.Windows.Forms.Label wallet;
    }
}