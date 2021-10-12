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
    public partial class Settings : Form
    {
        public Client client;
        private Label currentLabel;
        private Menu menu;

        public Settings(Client client, Menu menu)
        {
            this.menu = menu;
            InitializeComponent();
            this.client = client;
            if (client.CardId == "None")
            {
                changeCardId.Text = "Enter card Id";
            }
        }

        private void changeColor_MouseEnter(object sender, EventArgs e)
        {
            currentLabel = (Label)sender;
            currentLabel.ForeColor = Color.White;
        }

        private void changeColor_MouseLeave(object sender, EventArgs e)
        {
            currentLabel = (Label)sender;
            currentLabel.ForeColor = Color.DimGray;
        }

        private void changeLogin_Click(object sender, EventArgs e)
        {
            new CustomChangeMenu(menu, client, "enter new login", IconChar.UserCog, "login", 10);
        }

        private void changePasportData_Click(object sender, EventArgs e)
        {
            new CustomChangeMenu(menu, client, "enter new pasport data", IconChar.Passport, "pasportData", 9);
        }

        private void changeCardId_Click(object sender, EventArgs e)
        {
            if (client.CardId == "None")
            {
                new CustomChangeMenu(menu, client, "enter card Id", IconChar.CreditCard, "cardId", 19);
            }
            else
            {
                new CustomChangeMenu(menu, client, "enter new card Id", IconChar.CreditCard, "cardId", 19);
            }
        }

        private void changeDriveLicense_Click(object sender, EventArgs e)
        {
            new CustomChangeMenu(menu, client, "enter new license", IconChar.IdCard, "driveLicense", 10);
        }

        private void changePhoneNumber_Click(object sender, EventArgs e)
        {
            new CustomChangeMenu(menu, client, "enter new phone number", IconChar.Phone, "phoneNumber", 13);
        }

        private void changePass_Click(object sender, EventArgs e)
        {
            new ChangePassword(menu, client);
        }
    }
}
