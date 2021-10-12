
namespace RentCar
{
    partial class CustomChangeMenu
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
            this.checkBtn = new System.Windows.Forms.Button();
            this.changeBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.exitButton = new FontAwesome.Sharp.IconButton();
            this.hide = new FontAwesome.Sharp.IconButton();
            this.changePctr = new FontAwesome.Sharp.IconPictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.changePctr)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBtn
            // 
            this.checkBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.checkBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.checkBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.checkBtn.Location = new System.Drawing.Point(115, 133);
            this.checkBtn.Margin = new System.Windows.Forms.Padding(2);
            this.checkBtn.Name = "checkBtn";
            this.checkBtn.Size = new System.Drawing.Size(100, 24);
            this.checkBtn.TabIndex = 5;
            this.checkBtn.Text = "Oк";
            this.checkBtn.UseVisualStyleBackColor = false;
            this.checkBtn.Click += new System.EventHandler(this.checkBtn_Click);
            // 
            // changeBox
            // 
            this.changeBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.changeBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.changeBox.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changeBox.ForeColor = System.Drawing.Color.Gray;
            this.changeBox.Location = new System.Drawing.Point(103, 56);
            this.changeBox.Margin = new System.Windows.Forms.Padding(2);
            this.changeBox.MaxLength = 10;
            this.changeBox.Multiline = true;
            this.changeBox.Name = "changeBox";
            this.changeBox.Size = new System.Drawing.Size(166, 22);
            this.changeBox.TabIndex = 6;
            this.changeBox.TabStop = false;
            this.changeBox.Text = "change something";
            this.changeBox.Click += new System.EventHandler(this.changeBox_Click);
            this.changeBox.Leave += new System.EventHandler(this.changeBox_Leave);
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
            this.panel1.TabIndex = 7;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.customChangeMenu_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.customChangeMenu_MouseMove);
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
            // changePctr
            // 
            this.changePctr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.changePctr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.changePctr.IconChar = FontAwesome.Sharp.IconChar.None;
            this.changePctr.IconColor = System.Drawing.SystemColors.ControlText;
            this.changePctr.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.changePctr.IconSize = 43;
            this.changePctr.Location = new System.Drawing.Point(55, 46);
            this.changePctr.Name = "changePctr";
            this.changePctr.Size = new System.Drawing.Size(43, 46);
            this.changePctr.TabIndex = 4;
            this.changePctr.TabStop = false;
            // 
            // CustomChangeMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(342, 168);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.changeBox);
            this.Controls.Add(this.checkBtn);
            this.Controls.Add(this.changePctr);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomChangeMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomChangeMenu";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.customChangeMenu_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.customChangeMenu_MouseMove);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.changePctr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public FontAwesome.Sharp.IconPictureBox changePctr;
        private System.Windows.Forms.Button checkBtn;
        private System.Windows.Forms.TextBox changeBox;
        private FontAwesome.Sharp.IconButton hide;
        private FontAwesome.Sharp.IconButton exitButton;
        private System.Windows.Forms.Panel panel1;
    }
}