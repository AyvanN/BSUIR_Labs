
namespace RentCar
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.registration = new System.Windows.Forms.Panel();
            this.hiddenText = new System.Windows.Forms.TextBox();
            this.dateBirthPicker = new System.Windows.Forms.DateTimePicker();
            this.regDriveLicense = new System.Windows.Forms.TextBox();
            this.regFio = new System.Windows.Forms.TextBox();
            this.regPasportData = new System.Windows.Forms.TextBox();
            this.regPhoneNumber = new System.Windows.Forms.TextBox();
            this.confirmPas = new System.Windows.Forms.TextBox();
            this.passReg = new System.Windows.Forms.TextBox();
            this.back_registration = new System.Windows.Forms.Button();
            this.register = new System.Windows.Forms.Button();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.logReg = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.registration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // registration
            // 
            this.registration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.registration.Controls.Add(this.hiddenText);
            this.registration.Controls.Add(this.dateBirthPicker);
            this.registration.Controls.Add(this.regDriveLicense);
            this.registration.Controls.Add(this.regFio);
            this.registration.Controls.Add(this.regPasportData);
            this.registration.Controls.Add(this.regPhoneNumber);
            this.registration.Controls.Add(this.confirmPas);
            this.registration.Controls.Add(this.passReg);
            this.registration.Controls.Add(this.back_registration);
            this.registration.Controls.Add(this.register);
            this.registration.Controls.Add(this.pictureBox7);
            this.registration.Controls.Add(this.pictureBox6);
            this.registration.Controls.Add(this.pictureBox5);
            this.registration.Controls.Add(this.pictureBox4);
            this.registration.Controls.Add(this.pictureBox8);
            this.registration.Controls.Add(this.pictureBox3);
            this.registration.Controls.Add(this.pictureBox2);
            this.registration.Controls.Add(this.logReg);
            this.registration.Controls.Add(this.pictureBox1);
            this.registration.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.registration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.registration.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.registration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.registration.Location = new System.Drawing.Point(0, 0);
            this.registration.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.registration.Name = "registration";
            this.registration.Size = new System.Drawing.Size(600, 366);
            this.registration.TabIndex = 1;
            this.registration.MouseDown += new System.Windows.Forms.MouseEventHandler(this.registration_MouseDown);
            this.registration.MouseMove += new System.Windows.Forms.MouseEventHandler(this.registration_MouseMove);
            // 
            // hiddenText
            // 
            this.hiddenText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.hiddenText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hiddenText.ForeColor = System.Drawing.Color.DimGray;
            this.hiddenText.Location = new System.Drawing.Point(385, 234);
            this.hiddenText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.hiddenText.Name = "hiddenText";
            this.hiddenText.Size = new System.Drawing.Size(166, 26);
            this.hiddenText.TabIndex = 8;
            this.hiddenText.Text = " Enter date of birth";
            this.hiddenText.Click += new System.EventHandler(this.hiddenText_Click);
            // 
            // dateBirthPicker
            // 
            this.dateBirthPicker.CalendarMonthBackground = System.Drawing.Color.Black;
            this.dateBirthPicker.CalendarTitleBackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dateBirthPicker.CalendarTrailingForeColor = System.Drawing.SystemColors.ControlText;
            this.dateBirthPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateBirthPicker.Location = new System.Drawing.Point(385, 234);
            this.dateBirthPicker.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dateBirthPicker.MaxDate = new System.DateTime(2021, 12, 31, 0, 0, 0, 0);
            this.dateBirthPicker.Name = "dateBirthPicker";
            this.dateBirthPicker.Size = new System.Drawing.Size(166, 26);
            this.dateBirthPicker.TabIndex = 6;
            this.dateBirthPicker.Leave += new System.EventHandler(this.dateBirthPicker_Leave);
            // 
            // regDriveLicense
            // 
            this.regDriveLicense.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.regDriveLicense.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.regDriveLicense.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.regDriveLicense.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.regDriveLicense.ForeColor = System.Drawing.Color.DimGray;
            this.regDriveLicense.Location = new System.Drawing.Point(98, 234);
            this.regDriveLicense.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.regDriveLicense.MaxLength = 10;
            this.regDriveLicense.Name = "regDriveLicense";
            this.regDriveLicense.Size = new System.Drawing.Size(166, 24);
            this.regDriveLicense.TabIndex = 4;
            this.regDriveLicense.TabStop = false;
            this.regDriveLicense.Text = " Enter driver license";
            this.regDriveLicense.Click += new System.EventHandler(this.regDriveLicense_Click);
            this.regDriveLicense.Leave += new System.EventHandler(this.regDriveLicense_Leave);
            // 
            // regFio
            // 
            this.regFio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.regFio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.regFio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.regFio.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.regFio.ForeColor = System.Drawing.Color.DimGray;
            this.regFio.Location = new System.Drawing.Point(385, 162);
            this.regFio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.regFio.MaxLength = 100;
            this.regFio.Name = "regFio";
            this.regFio.Size = new System.Drawing.Size(166, 24);
            this.regFio.TabIndex = 4;
            this.regFio.TabStop = false;
            this.regFio.Text = " Enter FIO";
            this.regFio.Click += new System.EventHandler(this.regFio_Click);
            this.regFio.Leave += new System.EventHandler(this.regFio_Leave);
            // 
            // regPasportData
            // 
            this.regPasportData.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.regPasportData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.regPasportData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.regPasportData.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.regPasportData.ForeColor = System.Drawing.Color.DimGray;
            this.regPasportData.Location = new System.Drawing.Point(385, 33);
            this.regPasportData.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.regPasportData.MaxLength = 9;
            this.regPasportData.Name = "regPasportData";
            this.regPasportData.Size = new System.Drawing.Size(166, 24);
            this.regPasportData.TabIndex = 4;
            this.regPasportData.TabStop = false;
            this.regPasportData.Text = " Enter pasport data";
            this.regPasportData.Click += new System.EventHandler(this.regPasportData_Click);
            this.regPasportData.Leave += new System.EventHandler(this.regPasportData_Leave);
            // 
            // regPhoneNumber
            // 
            this.regPhoneNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.regPhoneNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.regPhoneNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.regPhoneNumber.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.regPhoneNumber.ForeColor = System.Drawing.Color.DimGray;
            this.regPhoneNumber.Location = new System.Drawing.Point(385, 95);
            this.regPhoneNumber.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.regPhoneNumber.MaxLength = 13;
            this.regPhoneNumber.Name = "regPhoneNumber";
            this.regPhoneNumber.Size = new System.Drawing.Size(166, 24);
            this.regPhoneNumber.TabIndex = 4;
            this.regPhoneNumber.TabStop = false;
            this.regPhoneNumber.Text = " Enter phone number";
            this.regPhoneNumber.Click += new System.EventHandler(this.regPhoneNumber_Click);
            this.regPhoneNumber.Leave += new System.EventHandler(this.regPhoneNumber_Leave);
            // 
            // confirmPas
            // 
            this.confirmPas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.confirmPas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.confirmPas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.confirmPas.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.confirmPas.ForeColor = System.Drawing.Color.DimGray;
            this.confirmPas.Location = new System.Drawing.Point(98, 161);
            this.confirmPas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.confirmPas.MaxLength = 32;
            this.confirmPas.Name = "confirmPas";
            this.confirmPas.Size = new System.Drawing.Size(166, 24);
            this.confirmPas.TabIndex = 4;
            this.confirmPas.TabStop = false;
            this.confirmPas.Text = " Confirm password";
            this.confirmPas.Click += new System.EventHandler(this.confirmPas_Click);
            this.confirmPas.Leave += new System.EventHandler(this.confirmPas_Leave);
            // 
            // passReg
            // 
            this.passReg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.passReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.passReg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passReg.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passReg.ForeColor = System.Drawing.Color.DimGray;
            this.passReg.Location = new System.Drawing.Point(98, 95);
            this.passReg.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.passReg.MaxLength = 32;
            this.passReg.Name = "passReg";
            this.passReg.Size = new System.Drawing.Size(166, 24);
            this.passReg.TabIndex = 4;
            this.passReg.TabStop = false;
            this.passReg.Text = " Create password";
            this.passReg.Click += new System.EventHandler(this.passReg_Click);
            this.passReg.Leave += new System.EventHandler(this.passReg_Leave);
            // 
            // back_registration
            // 
            this.back_registration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.back_registration.Cursor = System.Windows.Forms.Cursors.Hand;
            this.back_registration.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.back_registration.FlatAppearance.BorderSize = 0;
            this.back_registration.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.back_registration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back_registration.ForeColor = System.Drawing.SystemColors.Control;
            this.back_registration.Location = new System.Drawing.Point(9, 305);
            this.back_registration.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.back_registration.Name = "back_registration";
            this.back_registration.Size = new System.Drawing.Size(83, 29);
            this.back_registration.TabIndex = 3;
            this.back_registration.Text = "Back";
            this.back_registration.UseVisualStyleBackColor = false;
            this.back_registration.Click += new System.EventHandler(this.back_registration_Click);
            // 
            // register
            // 
            this.register.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.register.Cursor = System.Windows.Forms.Cursors.Hand;
            this.register.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.register.FlatAppearance.BorderSize = 0;
            this.register.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.register.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.register.ForeColor = System.Drawing.SystemColors.Control;
            this.register.Location = new System.Drawing.Point(508, 305);
            this.register.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.register.Name = "register";
            this.register.Size = new System.Drawing.Size(83, 29);
            this.register.TabIndex = 3;
            this.register.Text = "Register";
            this.register.UseVisualStyleBackColor = false;
            this.register.Click += new System.EventHandler(this.register_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::RentCar.Properties.Resources.phone;
            this.pictureBox7.Location = new System.Drawing.Point(335, 84);
            this.pictureBox7.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(45, 49);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 1;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::RentCar.Properties.Resources.Pencil;
            this.pictureBox6.Location = new System.Drawing.Point(335, 150);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(45, 49);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 1;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::RentCar.Properties.Resources.pasport;
            this.pictureBox5.Location = new System.Drawing.Point(49, 221);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(45, 49);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 1;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::RentCar.Properties.Resources.calendar;
            this.pictureBox4.Location = new System.Drawing.Point(335, 221);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(45, 49);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 1;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::RentCar.Properties.Resources.Lock_v1;
            this.pictureBox8.Location = new System.Drawing.Point(49, 150);
            this.pictureBox8.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(45, 49);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 1;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::RentCar.Properties.Resources.book;
            this.pictureBox3.Location = new System.Drawing.Point(335, 16);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(45, 49);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::RentCar.Properties.Resources.Lock_v1;
            this.pictureBox2.Location = new System.Drawing.Point(49, 84);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(45, 49);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // logReg
            // 
            this.logReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(49)))), ((int)(((byte)(49)))));
            this.logReg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logReg.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logReg.ForeColor = System.Drawing.Color.DimGray;
            this.logReg.Location = new System.Drawing.Point(98, 35);
            this.logReg.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.logReg.MaxLength = 10;
            this.logReg.Name = "logReg";
            this.logReg.Size = new System.Drawing.Size(166, 24);
            this.logReg.TabIndex = 2;
            this.logReg.TabStop = false;
            this.logReg.Text = " Create login";
            this.logReg.Click += new System.EventHandler(this.logReg_Click);
            this.logReg.Leave += new System.EventHandler(this.logReg_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RentCar.Properties.Resources.User_v1;
            this.pictureBox1.Location = new System.Drawing.Point(52, 24);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.registration);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegisterForm";
            this.registration.ResumeLayout(false);
            this.registration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel registration;
        private System.Windows.Forms.Button back_registration;
        private System.Windows.Forms.Button register;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox logReg;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox passReg;
        private System.Windows.Forms.TextBox regDriveLicense;
        private System.Windows.Forms.TextBox regFio;
        private System.Windows.Forms.TextBox regPasportData;
        private System.Windows.Forms.TextBox regPhoneNumber;
        private System.Windows.Forms.TextBox confirmPas;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.DateTimePicker dateBirthPicker;
        private System.Windows.Forms.TextBox hiddenText;
    }
}