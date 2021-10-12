using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentCar
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();

        }

        private void back_registration_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }


        Point lastPoint;
        private void registration_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void registration_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void logReg_Click(object sender, EventArgs e)
        {
            if (logReg.Text == " Create login")
            {
                logReg.Text = "";
                logReg.ForeColor = Color.White;
            }
            DateNowCheck();
        }

        private void passReg_Click(object sender, EventArgs e)
        {
            if (passReg.Text == " Create password")
            {
                passReg.Text = "";
                passReg.ForeColor = Color.White;
            }
            DateNowCheck();
        }

        private void logReg_Leave(object sender, EventArgs e)
        {
            if (logReg.Text == "")
            {
                logReg.Text = " Create login";
                logReg.ForeColor = Color.Gray;
            }
        }

        private void passReg_Leave(object sender, EventArgs e)
        {
            if (passReg.Text == "")
            {
                passReg.Text = " Create password";
                passReg.ForeColor = Color.Gray;
            }
        }

        private void confirmPas_Leave(object sender, EventArgs e)
        {
            if (confirmPas.Text == "")
            {
                confirmPas.Text = " Confirm password";
                confirmPas.ForeColor = Color.Gray;
            }
        }

        private void confirmPas_Click(object sender, EventArgs e)
        {
            if (confirmPas.Text == " Confirm password")
            {
                confirmPas.Text = "";
                confirmPas.ForeColor = Color.White;
            }
            DateNowCheck();
        }

        private void regDriveLicense_Leave(object sender, EventArgs e)
        {
            if (regDriveLicense.Text == "")
            {
                regDriveLicense.Text = " Enter driver license";
                regDriveLicense.ForeColor = Color.Gray;
            }
        }

        private void regDriveLicense_Click(object sender, EventArgs e)
        {
            if (regDriveLicense.Text == " Enter driver license")
            {
                regDriveLicense.Text = "";
                regDriveLicense.ForeColor = Color.White;
            }
            DateNowCheck();
        }

        private void DateNowCheck()
        {
            if (dateBirthPicker.Text == DateTime.Now.ToString("d"))
            {
                hiddenText.Show();
                hiddenText.Text = " Enter date of birth";
                hiddenText.ForeColor = Color.Gray;
            }
        }

        private void regPasportData_Leave(object sender, EventArgs e)
        {
            if (regPasportData.Text == "")
            {
                regPasportData.Text = " Enter pasport data";
                regPasportData.ForeColor = Color.Gray;
            }
        }

        private void regPasportData_Click(object sender, EventArgs e)
        {
            if (regPasportData.Text == " Enter pasport data")
            {
                regPasportData.Text = "";
                regPasportData.ForeColor = Color.White;
            }
            if (dateBirthPicker.Text == DateTime.Now.ToString("d"))
            {
                hiddenText.Show();
                hiddenText.Text = " Enter date of birth";
                hiddenText.ForeColor = Color.Gray;
            }
        }

        private void regPhoneNumber_Click(object sender, EventArgs e)
        {
            if (regPhoneNumber.Text == " Enter phone number")
            {
                regPhoneNumber.Text = "";
                regPhoneNumber.ForeColor = Color.White;
            }
            if (dateBirthPicker.Text == DateTime.Now.ToString("d"))
            {
                hiddenText.Show();
                hiddenText.Text = " Enter date of birth";
                hiddenText.ForeColor = Color.Gray;
            }
        }

        private void regPhoneNumber_Leave(object sender, EventArgs e)
        {
            if (regPhoneNumber.Text == "")
            {
                regPhoneNumber.Text = " Enter phone number";
                regPhoneNumber.ForeColor = Color.Gray;
            }

        }

        private void regFio_Leave(object sender, EventArgs e)
        {
            if (regFio.Text == "")
            {
                regFio.Text = " Enter FIO";
                regFio.ForeColor = Color.Gray;
            }
        }

        private void regFio_Click(object sender, EventArgs e)
        {
            if (regFio.Text == " Enter FIO")
            {
                regFio.Text = "";
                regFio.ForeColor = Color.White;
            }
            if (dateBirthPicker.Text == DateTime.Now.ToString("d"))
            {
                hiddenText.Show();
                hiddenText.Text = " Enter date of birth";
                hiddenText.ForeColor = Color.Gray;
            }
        }

        private void hiddenText_Click(object sender, EventArgs e)
        {
            hiddenText.Hide();
        }

        private void dateBirthPicker_Leave(object sender, EventArgs e)
        {
            if (dateBirthPicker.Text == DateTime.Now.ToString("d"))
            {
                hiddenText.Show();
                hiddenText.Text = " Enter date of birth";
                hiddenText.ForeColor = Color.Gray;
            }
        }

        private void birth_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void register_Click(object sender, EventArgs e)
        {
            Client client = new Client();

            CustomMessage message = new CustomMessage();

            if (logReg.Text == " Create login" || logReg.Text == " ")
            {
                message.message.Text = "Пожалуйста, введите логин";
                message.Show();
                return;
            }
            else
            {
                client.login = logReg.Text;
            }

            if (passReg.Text == " Create password" || passReg.Text == " ")
            {
                message.message.Text = "Пожалуйста, введите пароль";
                message.Show();
                return;
            }
            else
            {
                client.password = passReg.Text;
            }

            if (passReg.Text != confirmPas.Text)
            {
                message.message.Text = "Пароли не совпадают";
                message.Show();
                return;
            }

            try
            {
                client.PhoneNumber = regPhoneNumber.Text;
            }
            catch (Exception ex)
            {
                message.message.Text = ex.Message;
                message.Show();
                return;
            }

            try
            {
                client.PasportData = regPasportData.Text;
            }
            catch (Exception ex)
            {
                message.message.Text = ex.Message;
                message.Show();
                return;
            }

            try
            {
                client.FIO = regFio.Text;
            }
            catch (Exception ex)
            {
                message.message.Text = ex.Message;
                message.Show();
                return;
            }

            try
            {
                client.Birth = dateBirthPicker.Text;
            }
            catch (Exception ex)
            {
                message.message.Text = ex.Message;
                message.Show();
                return;
            }

            try
            {
                client.License = regDriveLicense.Text;
            }
            catch (Exception ex)
            {
                message.message.Text = ex.Message;
                message.Show();
                return;
            }

            try
            {
                client.DateOfRegistration = DateTime.Now.ToString("d");
            }
            catch (Exception ex)
            {
                message.message.Text = ex.Message;
                message.Show();
                return;
            }

            try
            {
                client.IsUserExists();
                client.ChangeEvent += new ShowInfo(client.PushNewUserInBase);
                client.InvokeChange();
                LoginForm loginForm = new LoginForm();
                this.Hide();
                loginForm.Show();
                message.message.Text = "Account created successfully";
                message.Show();
            }
            catch (Exception ex)
            {
                message.message.Text = ex.Message;
                message.Show();
                return;
            }
        }


       
    }
}
