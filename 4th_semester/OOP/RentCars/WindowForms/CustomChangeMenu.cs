using FontAwesome.Sharp;
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
    public partial class CustomChangeMenu : Form
    {
        private Client client;
        private string text, type;
        private Menu menu;
        public CustomChangeMenu(Menu menu, Client client, string text, IconChar iconChar, string type, int length)
        {
            InitializeComponent();
            this.menu = menu;
            this.type = type;
            this.client = client;
            this.text = text;
            changePctr.IconChar = iconChar;
            changeBox.Text = text;
            changeBox.MaxLength = length;
            changeBox.Multiline = true;
            this.Show();
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
            CustomMessage customMessage = new CustomMessage();
            if (changeBox.Text == "" || changeBox.Text == text)
            {
                customMessage.message.Text = "Некорректно введены данные";
                customMessage.Show();
                return;
            }
            else
            {
                if (type == "login")
                {
                    client.login = changeBox.Text;
                    try
                    {
                        client.IsUserExists();
                    }
                    catch (Exception ex)
                    {
                        customMessage.message.Text = ex.Message;
                        customMessage.Show();
                        return;
                    }
                }
                else if (type == "pasportData")
                {
                    try
                    {
                        client.PasportData = changeBox.Text;
                    }
                    catch (Exception ex)
                    {
                        customMessage.message.Text = ex.Message;
                        customMessage.Show();
                        return;
                    }
                }
                else if (type == "phoneNumber")
                {
                    try
                    {
                        client.PhoneNumber = changeBox.Text;
                    }
                    catch (Exception ex)
                    {
                        customMessage.message.Text = ex.Message;
                        customMessage.Show();
                        return;
                    }
                }
                else if (type == "driveLicense")
                {
                    try
                    {
                        client.License = changeBox.Text;
                    }
                    catch (Exception ex)
                    {
                        customMessage.message.Text = ex.Message;
                        customMessage.Show();
                        return;
                    }
                }
                else if (type == "cardId")
                {
                    try
                    {
                        client.CardId = changeBox.Text;
                    }
                    catch (Exception ex)
                    {
                        customMessage.message.Text = ex.Message;
                        customMessage.Show();
                        return;
                    }
                }
                try
                {
                    client.ChangeEvent += new ShowInfo(UpdateInfo);
                    client.ChangeEvent += new ShowInfo(client.UpdateUserInBase);
                    client.InvokeChange();
                    this.Close();
                    customMessage.message.Text = "Успешно";
                    customMessage.Show();
                }
                catch (Exception ex)
                {
                    customMessage.message.Text = ex.Message;
                    customMessage.Show();
                    return;
                }
            }
        }

        private void changeBox_Click(object sender, EventArgs e)
        {
            if (changeBox.Text == text)
            {
                changeBox.Text = "";
                changeBox.ForeColor = Color.White;
            }
        }

        private void changeBox_Leave(object sender, EventArgs e)
        {
            if (changeBox.Text == "")
            {
                changeBox.Text = text;
                changeBox.ForeColor = Color.Gray;
            }
        }

        Point lastPoint;
        private void customChangeMenu_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void customChangeMenu_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void UpdateInfo()
        {
            menu.accountInfo.Text = client.login.ToString();
        }

    }
}
