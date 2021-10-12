using FontAwesome.Sharp;
using MySql.Data.MySqlClient;
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
    public delegate void UpdateInfo();
    public partial class Catalog : Form
    {
        private Client client;
        private IconButton currentButton;
        private List<RentalInfo> cars;
        private CustomMessage message;
        private ToolTip help;
        public List<int> rentalCars;
        private int lastSelected = -1;
        private DataTable table;
        public Catalog(Client client)
        {
            currentButton = new IconButton();
            cars = new List<RentalInfo>();
            table = new DataTable();
            rentalCars = new List<int>();
            help = new ToolTip();
            message = new CustomMessage();
            this.client = client;
            InitializeComponent();
            DataBase db = new DataBase();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand users = new MySqlCommand("SELECT * FROM carinfo", db.GetConnection());


            adapter.SelectCommand = users;
            adapter.Fill(table);


            if (table.Rows.Count == 0)
            {
                message.message.Text = "Нет машин в базе данных";
                message.Show();
            }
            else
            {
                FillRentalCars();
            }

            lastSelected++;
            ShowCars(rentalCars[lastSelected]);
        }

        private void FillRentalCars()
        {
            rentalCars.Clear();
            int size = 0;
            foreach (DataRow row in table.Rows)
            {
                RentalInfo car = new RentalInfo();
                car.FillFromDataBase(row);
                cars.Add(car);
                rentalCars.Add(size);
                size++;
            }
        }

        private void changeColor_MouseEnter(object sender, EventArgs e)
        {
            if (sender != null)
            {
                if (sender is IconButton)
                {
                    currentButton = sender as IconButton;
                    currentButton.ForeColor = Color.White;
                }
            }
        }

        private void changeColor_MouseLeave(object sender, EventArgs e)
        {
            if (sender != null)
            {
                if (sender is IconButton)
                {
                    currentButton = sender as IconButton;
                    currentButton.ForeColor = Color.Gray;
                }
            }
        }

        private void ShowCars(int switchCar)
        {
            if (switchCar <= cars.Count || switchCar >= 0)
            {
                carName.Text = cars[switchCar].carName;
                carBrand.Text = cars[switchCar].carBrand;
                typeOfCar.Text = cars[switchCar].typeOfCar;
                color.Text = cars[switchCar].color;
                age.Text = cars[switchCar].Age.ToString();
                horsePower.Text = cars[switchCar].HorsePower.ToString();
                weight.Text = cars[switchCar].Weight.ToString();
                fuelCapacity.Text = cars[switchCar].FuelCapacity.ToString();
                engineCapacity.Text = cars[switchCar].EngineCapacity.ToString();
                maxSpeed.Text = cars[switchCar].MaxSpeed.ToString();
                rentalPrice.Text = cars[switchCar].rentalPrice.ToString();
            }
            else
            {
                lastSelected--;
            }

        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            lastSelected++;
            if (SelectNextCheck()) { ShowCars(rentalCars[lastSelected]); }
        }

        private void previous_Click(object sender, EventArgs e)
        {
            lastSelected--;
            if (SelectPrevCheck()) { ShowCars(rentalCars[lastSelected]); }
        }

        private bool SelectPrevCheck()
        {
            if (lastSelected < 0)
            {
                lastSelected++;
                return false;
            }
            else { return true; }
        }

        private bool SelectNextCheck()
        {
            if (lastSelected >= rentalCars.Count)
            {
                lastSelected--;
                return false;
            }
            else { return true; }
        }

        private void FilturesCheck()
        {
            List<int> filtredCars = new List<int>();
            if (int.TryParse(lowerPrice.Text, out var lowerMoney) == true && int.TryParse(upperPrice.Text, out var upperMoney) == true)
            {
                int checker = 0;
                foreach (RentalInfo info in cars)
                {
                    if (info.rentalPrice >= lowerMoney && info.rentalPrice <= upperMoney)
                    {
                        filtredCars.Add(checker);
                    }
                    checker++;
                }
            }
            else if (int.TryParse(lowerPrice.Text, out var _lowerMoney) == true)
            {
                int checker = 0;
                foreach (RentalInfo info in cars)
                {
                    if (info.rentalPrice >= _lowerMoney)
                    {
                        filtredCars.Add(checker);
                    }
                    checker++;
                }
            }
            else if (int.TryParse(upperPrice.Text, out var _upperMoney) == true)
            {
                int checker = 0;
                foreach (RentalInfo info in cars)
                {
                    if (info.rentalPrice <= _upperMoney)
                    {
                        filtredCars.Add(checker);
                    }
                    checker++;
                }
            }
            if (int.TryParse(lowerAge.Text, out var lowerYear) == true && int.TryParse(upperAge.Text, out var upperYear) == true)
            {
                int checker = 0;
                foreach (RentalInfo info in cars)
                {
                    if (info.Age >= lowerYear && info.Age <= upperYear)
                    {
                        filtredCars.Add(checker);
                    }
                    checker++;
                }
            }
            else if (int.TryParse(lowerAge.Text, out var _lowerYear) == true)
            {
                int checker = 0;
                foreach (RentalInfo info in cars)
                {
                    if (info.Age >= _lowerYear)
                    {
                        filtredCars.Add(checker);
                    }
                    checker++;
                }
            }
            else if (int.TryParse(upperAge.Text, out var _upperYear) == true)
            {
                int checker = 0;
                foreach (RentalInfo info in cars)
                {
                    if (info.Age <= _upperYear)
                    {
                        filtredCars.Add(checker);
                    }
                    checker++;
                }
            }
            for (int it = 0; it < filtredCars.Count; it++)
            {
                for (int iterator = it + 1; iterator < filtredCars.Count; iterator++)
                {
                    if (filtredCars[it] == filtredCars[iterator])
                    {
                        filtredCars.RemoveAt(it);
                        it--;
                        break;
                    }
                }
            }
            if (filtredCars.Count > 0)
            {
                lastSelected = 0;
                rentalCars.Clear();
                for (int iterator = 0; iterator < filtredCars.Count; iterator++)
                {
                    rentalCars.Add(filtredCars[iterator]);
                }
                ShowCars(rentalCars[lastSelected]);
            }
        }
        private void Help_MouseEnter(object sender, EventArgs e)
        {
            currentButton = (IconButton)sender;
            if (currentButton is IconButton)
            {
                help.SetToolTip(currentButton, currentButton.Name);
            }
        }

        private void upperAge_Click(object sender, EventArgs e)
        {
            if (upperAge.Text == "Age to")
            {
                upperAge.Text = "";
                upperAge.ForeColor = Color.White;
            }
        }

        private void upperAge_Leave(object sender, EventArgs e)
        {
            if (upperAge.Text == "")
            {
                upperAge.Text = "Age to";
                upperAge.ForeColor = Color.Gray;
            }
        }

        private void lowerAge_Leave(object sender, EventArgs e)
        {
            if (lowerAge.Text == "")
            {
                lowerAge.Text = "Age from";
                lowerAge.ForeColor = Color.Gray;
            }
        }

        private void lowerAge_Click(object sender, EventArgs e)
        {
            if (lowerAge.Text == "Age from")
            {
                lowerAge.Text = "";
                lowerAge.ForeColor = Color.White;
            }
        }

        private void lowerPerice_Click(object sender, EventArgs e)
        {
            if (lowerPrice.Text == "Price from")
            {
                lowerPrice.Text = "";
                lowerPrice.ForeColor = Color.White;
            }
        }

        private void lowerPrice_Leave(object sender, EventArgs e)
        {

            if (lowerPrice.Text == "")
            {
                lowerPrice.Text = "Price from";
                lowerPrice.ForeColor = Color.Gray;
            }
        }

        private void upperPrice_Click(object sender, EventArgs e)
        {
            if (upperPrice.Text == "Price to")
            {
                upperPrice.Text = "";
                upperPrice.ForeColor = Color.White;
            }
        }


        private void upperPrice_Leave(object sender, EventArgs e)
        {
            if (upperPrice.Text == "")
            {
                upperPrice.Text = "Price to";
                upperPrice.ForeColor = Color.Gray;
            }
        }


        private void serch_Click(object sender, EventArgs e)
        {
            FilturesCheck();
        }

        private void resetOptions_Click(object sender, EventArgs e)
        {
            lastSelected = 0;
            FillRentalCars();
            upperPrice.Text = "Price to";
            upperPrice.ForeColor = Color.Gray;
            lowerPrice.Text = "Price from";
            lowerPrice.ForeColor = Color.Gray;
            lowerAge.Text = "Age from";
            lowerAge.ForeColor = Color.Gray;
            upperAge.Text = "Age to";
            upperAge.ForeColor = Color.Gray;
            ShowCars(rentalCars[lastSelected]);
        }
    }
}
