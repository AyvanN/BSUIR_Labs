using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace RentCar
{
    public partial class Menu : Form
    {
        private IconPictureBox currentPicrure;
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        private Client client;

        public Menu(Client _client)
        {
            client = new Client();
            this.client = _client;
            InitializeComponent();
            OpenChildForm(new Home(client, this));
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 0);
            panelMenu.Controls.Add(leftBorderBtn);
            accountInfo.Text = client.login.ToString();
            wallet.Text = client.Wallet.ToString() + " BYN";

            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }


        public void ActiveButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();

                if (senderBtn is IconButton)
                {
                    currentBtn = senderBtn as IconButton;
                    currentBtn.BackColor = Color.FromArgb(49, 49, 49);
                    currentBtn.ForeColor = Color.White;
                    currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                    currentBtn.IconColor = color;
                    currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                    currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                    leftBorderBtn.BackColor = color;
                    leftBorderBtn.Location = new Point(currentBtn.Location.Y);
                    leftBorderBtn.Visible = true;
                    leftBorderBtn.BringToFront();

                    currentFormIcon.IconChar = currentBtn.IconChar;
                    currentFormIcon.IconColor = color;
                }
            }
        }

        public void ActiveButton(IconPictureBox picture, Color color)
        {
            if (picture != null)
            {
                DisableButton();

                currentPicrure = picture;
                currentPicrure.BackColor = Color.FromArgb(49, 49, 49);
                currentPicrure.ForeColor = Color.White;
                currentPicrure.IconColor = color;


                currentFormIcon.IconChar = currentPicrure.IconChar;
                currentFormIcon.IconColor = color;
            }
        }

        public void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(49, 49, 49);
                currentBtn.ForeColor = Color.DarkGray;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = Color.Black;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        public void OpenChildForm(Form ChildForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(ChildForm);
            panelDesktop.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
            formTitle.Text = ChildForm.Text;
            ChildForm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UpperPanel_MouseDown);
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void catalog_Click(object sender, EventArgs e)
        {
            currentChildForm.Close();
            ActiveButton(sender, Color.Black);
            OpenChildForm(new Catalog(client));
        }

        private void bookingList_Click(object sender, EventArgs e)
        {
            currentChildForm.Close();
            ActiveButton(sender, Color.Black);
            OpenChildForm(new BookingList());
        }

        private void settings_Click(object sender, EventArgs e)
        {
            currentChildForm.Close();
            ActiveButton(sender, Color.Black);
            OpenChildForm(new Settings(client, this));
        }

        private void home_Click(object sender, EventArgs e)
        {
            currentChildForm.Close();
            ActiveButton(sender, Color.Black);
            OpenChildForm(new Home(client, this));
        }

        private void accountInfo_Click(object sender, EventArgs e)
        {
            IconPictureBox picture = new IconPictureBox();
            picture.IconChar = IconChar.UserAlt;
            currentChildForm.Close();
            ActiveButton(picture, Color.Black);
            OpenChildForm(new AccountInfo(client,this));
        }

        private void logout_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, Color.Black);
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void UpperPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void maximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void hide_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

    }
}
