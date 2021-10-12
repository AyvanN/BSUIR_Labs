
namespace RentCar
{
    partial class RentalDaysSetter
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
            this.changeBox = new System.Windows.Forms.TextBox();
            this.checkBtn = new System.Windows.Forms.Button();
            this.exitButton = new FontAwesome.Sharp.IconButton();
            this.hide = new FontAwesome.Sharp.IconButton();
            this.changePctr = new FontAwesome.Sharp.IconPictureBox();
            this.dateBirthPicker = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.changePctr)).BeginInit();
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
            this.panel1.TabIndex = 11;
            // 
            // changeBox
            // 
            this.changeBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.changeBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.changeBox.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changeBox.ForeColor = System.Drawing.Color.Gray;
            this.changeBox.Location = new System.Drawing.Point(103, 65);
            this.changeBox.Margin = new System.Windows.Forms.Padding(2);
            this.changeBox.MaxLength = 10;
            this.changeBox.Multiline = true;
            this.changeBox.Name = "changeBox";
            this.changeBox.Size = new System.Drawing.Size(166, 22);
            this.changeBox.TabIndex = 10;
            this.changeBox.TabStop = false;
            this.changeBox.Text = "chose ur ";
            // 
            // checkBtn
            // 
            this.checkBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.checkBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.checkBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.checkBtn.Location = new System.Drawing.Point(115, 139);
            this.checkBtn.Margin = new System.Windows.Forms.Padding(2);
            this.checkBtn.Name = "checkBtn";
            this.checkBtn.Size = new System.Drawing.Size(100, 24);
            this.checkBtn.TabIndex = 9;
            this.checkBtn.Text = "Oк";
            this.checkBtn.UseVisualStyleBackColor = false;
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
            // 
            // changePctr
            // 
            this.changePctr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.changePctr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.changePctr.IconChar = FontAwesome.Sharp.IconChar.CalendarAlt;
            this.changePctr.IconColor = System.Drawing.SystemColors.ControlText;
            this.changePctr.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.changePctr.IconSize = 47;
            this.changePctr.Location = new System.Drawing.Point(55, 52);
            this.changePctr.Name = "changePctr";
            this.changePctr.Size = new System.Drawing.Size(43, 46);
            this.changePctr.TabIndex = 8;
            this.changePctr.TabStop = false;
            this.changePctr.UseIconCache = true;
            // 
            // dateBirthPicker
            // 
            this.dateBirthPicker.CalendarMonthBackground = System.Drawing.Color.Black;
            this.dateBirthPicker.CalendarTitleBackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dateBirthPicker.CalendarTrailingForeColor = System.Drawing.SystemColors.ControlText;
            this.dateBirthPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateBirthPicker.Location = new System.Drawing.Point(103, 65);
            this.dateBirthPicker.Margin = new System.Windows.Forms.Padding(2);
            this.dateBirthPicker.MaxDate = new System.DateTime(2021, 12, 31, 0, 0, 0, 0);
            this.dateBirthPicker.Name = "dateBirthPicker";
            this.dateBirthPicker.Size = new System.Drawing.Size(166, 20);
            this.dateBirthPicker.TabIndex = 12;
            // 
            // RentalDaysSetter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(342, 168);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.changeBox);
            this.Controls.Add(this.checkBtn);
            this.Controls.Add(this.changePctr);
            this.Controls.Add(this.dateBirthPicker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RentalDaysSetter";
            this.Text = "RentalDaysSetter";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.changePctr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton exitButton;
        private FontAwesome.Sharp.IconButton hide;
        private System.Windows.Forms.TextBox changeBox;
        private System.Windows.Forms.Button checkBtn;
        public FontAwesome.Sharp.IconPictureBox changePctr;
        private System.Windows.Forms.DateTimePicker dateBirthPicker;
    }
}