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
    public partial class Home : Form
    {
        private Client client;
        private Menu menu;
        public Home(Client client, Menu menu)
        {
            this.menu = menu;
            this.client = client;
            InitializeComponent();
            userLabel.Text = "Hi " + client.login.ToString() + "!";
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            menu.ActiveButton(menu.catalog, Color.Black);
            this.Close();
            menu.OpenChildForm(new Catalog(client));

        }
    }
}
