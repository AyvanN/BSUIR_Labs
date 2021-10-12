using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentCar
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void rigistrarion_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }

        private void login_Click(object sender, EventArgs e)
        {
            if (login.Text == " Login")
            {
                this.login.Text = "";
            }
            login.ForeColor = Color.White;
        }

        private void password_Click(object sender, EventArgs e)
        {
            if (password.Text == " Password")
            {
                this.password.Text = "";
            }
            password.ForeColor = Color.White;
        }

        Point lastPoint;
        private void log_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void log_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void enter_Click(object sender, EventArgs e)
        {
            String userLogin = "kusodu01";
            String userPassword = "kusodu020228";

            CustomMessage customMessage = new CustomMessage();
            DataTable table = new DataTable();
            DataBase db = new DataBase();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            CustomMessage message = new CustomMessage();


            MySqlCommand users = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL AND `password` = @uP", db.GetConnection());
            users.Parameters.Add("@uL", MySqlDbType.VarChar).Value = userLogin;
            users.Parameters.Add("@uP", MySqlDbType.VarChar).Value = userPassword;


            adapter.SelectCommand = users;
            adapter.Fill(table);


            if (table.Rows.Count == 0)
            {
                customMessage.message.Text = "wrong login or password";
                customMessage.Show();
            }
            else
            {
                foreach (DataRow row in table.Rows)
                {
                    if ((bool)row["adminPermissions"] == true)
                    {
                        Administrator admin = new Administrator();
                        Enter(admin, table);
                    }
                    else
                    {

                        Client client = new Client();
                        Enter(client, table);
                    }
                }
            }
        }

        private new void Enter(Administrator admin, DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                admin.MakeAdmin(row);
            }
        }

        private new void Enter(Client client, DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                client.FillFromDataBase(row);
            }
            this.Hide();
            Menu menu = new Menu(client);
            menu.Show();
        }

        private void login_Leave(object sender, EventArgs e)
        {
            if (login.Text == "")
            {
                this.login.Text = " Login";
                login.ForeColor = Color.Gray;
            }
        }

        private void password_Leave(object sender, EventArgs e)
        {
            if (password.Text == "")
            {
                this.password.Text = " Password";
                password.ForeColor = Color.Gray;
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
