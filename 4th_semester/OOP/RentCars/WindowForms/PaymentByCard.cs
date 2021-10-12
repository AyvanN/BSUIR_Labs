using FontAwesome.Sharp;
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
    public partial class PaymentByCard : Form
    {
        private Client client;
        private Menu menu;
        public PaymentByCard(Menu menu, Client client)
        {
            this.client = client;
            this.menu = menu;
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hide_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void checkBtn_Click(object sender, EventArgs e)
        {
            CustomMessage message = new CustomMessage();

            if (Regex.Match(cardId.Text, @"[0-9]{4}\s{1}[0-9]{4}\s{1}[0-9]{4}\s{1}[0-9]{4}").Success == false)
            {
                message.message.Text = "Неправильно введены данные вашей карты";
                message.Show();
                return;
            }
            if (client.password.ToString() != password.Text)
            {
                message.message.Text = "Неправильно введен пароль";
                message.Show();
                return;
            }
            if (Regex.Match(money.Text, @"[0-9]").Success == false)
            {
                message.message.Text = "Неправильно введены денежные средства";
                message.Show();
                return;
            }
            if (client.password.ToString() == password.Text && client.CardId == cardId.Text)
            {
                try
                {
                    client.ChangeEvent += new ShowInfo(ChangeWallet);
                    client.ChangeEvent += new ShowInfo(client.UpdateUserInBase);
                    client.InvokeChange();
                    this.Hide();
                    message.message.Text = "Транзакция проведена успешно";
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

        private void cardId_Click(object sender, EventArgs e)
        {
            if (cardId.Text == "Enter your card Id")
            {
                cardId.Text = "";
                cardId.ForeColor = Color.White;
            }
        }

        private void cardId_Leave(object sender, EventArgs e)
        {
            if (cardId.Text == "")
            {
                cardId.Text = "Enter your card Id";
                cardId.ForeColor = Color.Gray;
            }
        }

        private void password_Click(object sender, EventArgs e)
        {
            if (password.Text == "Enter your password")
            {
                password.Text = "";
                password.ForeColor = Color.White;
            }
        }

        private void password_Leave(object sender, EventArgs e)
        {
            if (password.Text == "")
            {
                password.Text = "Enter your password";
                password.ForeColor = Color.Gray;
            }
        }

        private void money_Click(object sender, EventArgs e)
        {
            if (money.Text == "Enter the money")
            {
                money.Text = "";
                money.ForeColor = Color.White;
            }
        }

        private void money_Leave(object sender, EventArgs e)
        {
            if (cardId.Text == "")
            {
                cardId.Text = "Enter the money";
                cardId.ForeColor = Color.Gray;
            }
        }

        private void ChangeWallet()
        {
            client.Wallet += Convert.ToUInt32(money.Text);
            menu.wallet.Text = client.Wallet.ToString() + " BYN";
        }
    }
}
