using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentCar
{
    public partial class ChangePassword : Form
    {
        private Menu menu;
        private Client client;
        public ChangePassword(Menu menu, Client client)
        {
            this.menu = menu;
            this.client = client;
            InitializeComponent();
            this.Show();
        }

        private void currentPass_Click(object sender, EventArgs e)
        {
            if (currentPass.Text == "Enter current passwoed")
            {
                currentPass.Text = "";
                currentPass.ForeColor = Color.White;
            }
        }

        private void currentPass_Leave(object sender, EventArgs e)
        {
            if (currentPass.Text == "")
            {
                currentPass.Text = "Enter current passwoed";
                currentPass.ForeColor = Color.Gray;
            }
        }

        private void newPass_Click(object sender, EventArgs e)
        {
            if (newPass.Text == "Create new password")
            {
                newPass.Text = "";
                newPass.ForeColor = Color.White;
            }
        }

        private void newPass_Leave(object sender, EventArgs e)
        {
            if (currentPass.Text == "")
            {
                currentPass.Text = "Create new password";
                currentPass.ForeColor = Color.Gray;
            }
        }

        private void confirmPass_Click(object sender, EventArgs e)
        {
            if (confirmPass.Text == "Confirm new password")
            {
                confirmPass.Text = "";
                confirmPass.ForeColor = Color.White;
            }
        }

        private void confirmPass_Leave(object sender, EventArgs e)
        {
            if (confirmPass.Text == "")
            {
                confirmPass.Text = "Confirm new password";
                confirmPass.ForeColor = Color.Gray;
            }
        }

        private void checkBtn_Click(object sender, EventArgs e)
        {
            CustomMessage message = new CustomMessage();

            if (client.password.ToString() != currentPass.Text)
            {
                message.message.Text = "Неправильно введен текущий пароль";
                message.Show();
                return;
            }
            if (newPass == confirmPass)
            {
                message.message.Text = "Подтвержденный пароль не совпадает с паролем";
                message.Show();
                return;
            }
            try
            {
                client.ChangeEvent += new ShowInfo(ChangePass);
                client.ChangeEvent += new ShowInfo(client.UpdateUserInBase);
                client.InvokeChange();
                this.Close();
                message.message.Text = "Пароль успешно изменен";
                message.Show();
            }
            catch (Exception ex)
            {
                message.message.Text = ex.Message;
                message.Show();
                return;
            }

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hide_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void ChangePass()
        {
            client.password = newPass.Text;
        }

    }
}
