
namespace RentCar
{
    partial class AccountInfo
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
            this.home = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // home
            // 
            this.home.Cursor = System.Windows.Forms.Cursors.Hand;
            this.home.FlatAppearance.BorderSize = 0;
            this.home.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.home.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.home.ForeColor = System.Drawing.Color.Gray;
            this.home.IconChar = FontAwesome.Sharp.IconChar.MoneyBillAlt;
            this.home.IconColor = System.Drawing.Color.Black;
            this.home.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.home.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.home.Location = new System.Drawing.Point(250, 129);
            this.home.Name = "home";
            this.home.Size = new System.Drawing.Size(196, 49);
            this.home.TabIndex = 8;
            this.home.Text = "Top up balance";
            this.home.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.home.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.home.UseVisualStyleBackColor = true;
            this.home.Click += new System.EventHandler(this.home_Click);
            this.home.MouseEnter += new System.EventHandler(this.changeColor_MouseEnter);
            this.home.MouseLeave += new System.EventHandler(this.changeColor_MouseLeave);
            // 
            // AccountInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1273, 588);
            this.Controls.Add(this.home);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AccountInfo";
            this.Text = "Account Info";
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton home;
    }
}