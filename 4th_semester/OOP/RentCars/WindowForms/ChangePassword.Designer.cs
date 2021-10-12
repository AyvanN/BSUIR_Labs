
namespace RentCar
{
    partial class ChangePassword
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.exitButton = new FontAwesome.Sharp.IconButton();
            this.hide = new FontAwesome.Sharp.IconButton();
            this.confirmPass = new System.Windows.Forms.TextBox();
            this.newPass = new System.Windows.Forms.TextBox();
            this.currentPass = new System.Windows.Forms.TextBox();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.checkBtn = new System.Windows.Forms.Button();
            this.changePctr = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.changePctr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.panel1.Controls.Add(this.exitButton);
            this.panel1.Controls.Add(this.hide);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 22);
            this.panel1.TabIndex = 19;
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.exitButton.IconColor = System.Drawing.Color.White;
            this.exitButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.exitButton.IconSize = 15;
            this.exitButton.Location = new System.Drawing.Point(332, 0);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(10, 16);
            this.exitButton.TabIndex = 8;
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
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
            this.hide.Location = new System.Drawing.Point(310, 0);
            this.hide.Name = "hide";
            this.hide.Size = new System.Drawing.Size(20, 15);
            this.hide.TabIndex = 9;
            this.hide.UseVisualStyleBackColor = true;
            this.hide.Click += new System.EventHandler(this.hide_Click);
            // 
            // confirmPass
            // 
            this.confirmPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.confirmPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.confirmPass.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.confirmPass.ForeColor = System.Drawing.Color.Gray;
            this.confirmPass.Location = new System.Drawing.Point(102, 183);
            this.confirmPass.Margin = new System.Windows.Forms.Padding(2);
            this.confirmPass.MaxLength = 100;
            this.confirmPass.Multiline = true;
            this.confirmPass.Name = "confirmPass";
            this.confirmPass.Size = new System.Drawing.Size(166, 22);
            this.confirmPass.TabIndex = 16;
            this.confirmPass.TabStop = false;
            this.confirmPass.Text = "Confirm new password";
            this.confirmPass.Click += new System.EventHandler(this.confirmPass_Click);
            this.confirmPass.Leave += new System.EventHandler(this.confirmPass_Leave);
            // 
            // newPass
            // 
            this.newPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.newPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.newPass.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newPass.ForeColor = System.Drawing.Color.Gray;
            this.newPass.Location = new System.Drawing.Point(102, 119);
            this.newPass.Margin = new System.Windows.Forms.Padding(2);
            this.newPass.MaxLength = 32;
            this.newPass.Multiline = true;
            this.newPass.Name = "newPass";
            this.newPass.Size = new System.Drawing.Size(166, 22);
            this.newPass.TabIndex = 17;
            this.newPass.TabStop = false;
            this.newPass.Text = "Create new password";
            this.newPass.UseSystemPasswordChar = true;
            this.newPass.Click += new System.EventHandler(this.newPass_Click);
            this.newPass.Leave += new System.EventHandler(this.newPass_Leave);
            // 
            // currentPass
            // 
            this.currentPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.currentPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.currentPass.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentPass.ForeColor = System.Drawing.Color.Gray;
            this.currentPass.Location = new System.Drawing.Point(102, 55);
            this.currentPass.Margin = new System.Windows.Forms.Padding(2);
            this.currentPass.MaxLength = 19;
            this.currentPass.Multiline = true;
            this.currentPass.Name = "currentPass";
            this.currentPass.Size = new System.Drawing.Size(166, 22);
            this.currentPass.TabIndex = 18;
            this.currentPass.TabStop = false;
            this.currentPass.Text = "Enter current passwoed";
            this.currentPass.Click += new System.EventHandler(this.currentPass_Click);
            this.currentPass.Leave += new System.EventHandler(this.currentPass_Leave);
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.iconPictureBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Lock;
            this.iconPictureBox1.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 43;
            this.iconPictureBox1.Location = new System.Drawing.Point(54, 41);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(43, 46);
            this.iconPictureBox1.TabIndex = 13;
            this.iconPictureBox1.TabStop = false;
            this.iconPictureBox1.UseGdi = true;
            // 
            // checkBtn
            // 
            this.checkBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.checkBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.checkBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.checkBtn.Location = new System.Drawing.Point(115, 240);
            this.checkBtn.Margin = new System.Windows.Forms.Padding(2);
            this.checkBtn.Name = "checkBtn";
            this.checkBtn.Size = new System.Drawing.Size(100, 24);
            this.checkBtn.TabIndex = 15;
            this.checkBtn.Text = "Oк";
            this.checkBtn.UseVisualStyleBackColor = false;
            this.checkBtn.Click += new System.EventHandler(this.checkBtn_Click);
            // 
            // changePctr
            // 
            this.changePctr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.changePctr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.changePctr.IconChar = FontAwesome.Sharp.IconChar.Key;
            this.changePctr.IconColor = System.Drawing.SystemColors.ControlText;
            this.changePctr.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.changePctr.IconSize = 43;
            this.changePctr.Location = new System.Drawing.Point(54, 105);
            this.changePctr.Name = "changePctr";
            this.changePctr.Size = new System.Drawing.Size(43, 46);
            this.changePctr.TabIndex = 14;
            this.changePctr.TabStop = false;
            this.changePctr.UseGdi = true;
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.iconPictureBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Key;
            this.iconPictureBox2.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 43;
            this.iconPictureBox2.Location = new System.Drawing.Point(54, 170);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(43, 46);
            this.iconPictureBox2.TabIndex = 14;
            this.iconPictureBox2.TabStop = false;
            this.iconPictureBox2.UseGdi = true;
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(342, 275);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.confirmPass);
            this.Controls.Add(this.newPass);
            this.Controls.Add(this.currentPass);
            this.Controls.Add(this.iconPictureBox1);
            this.Controls.Add(this.checkBtn);
            this.Controls.Add(this.iconPictureBox2);
            this.Controls.Add(this.changePctr);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangePassword";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.changePctr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton exitButton;
        private FontAwesome.Sharp.IconButton hide;
        private System.Windows.Forms.TextBox confirmPass;
        private System.Windows.Forms.TextBox newPass;
        private System.Windows.Forms.TextBox currentPass;
        public FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.Button checkBtn;
        public FontAwesome.Sharp.IconPictureBox changePctr;
        public FontAwesome.Sharp.IconPictureBox iconPictureBox2;
    }
}