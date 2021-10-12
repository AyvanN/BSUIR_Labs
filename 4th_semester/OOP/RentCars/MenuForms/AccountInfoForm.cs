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
    public partial class AccountInfo : Form
    {
        private Client client;
        private Menu menu;
        private IconButton currentButton;
        public AccountInfo(Client client, Menu menu)
        {
            this.client = client;
            this.menu = menu;
            InitializeComponent();
        }

        private void home_Click(object sender, EventArgs e)
        {
            PaymentByCard payment = new PaymentByCard(menu, client);
            if (client.CardId == "None")
            {
                new CustomChangeMenu(menu, client, "enter card Id", IconChar.CreditCard, "cardId", 19);
            }
            else
            {
                payment.Show();
            }
        }


        private void changeColor_MouseEnter(object sender, EventArgs e)
        {
            currentButton = (IconButton)sender;
            currentButton.ForeColor = Color.White;
        }

        private void changeColor_MouseLeave(object sender, EventArgs e)
        {
            currentButton = (IconButton)sender;
            currentButton.ForeColor = Color.DimGray;
        }
    }
}
