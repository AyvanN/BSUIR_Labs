using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RentCar
{
    public delegate void ShowInfo();

    public class Client : User, IFillFromDataBase
    {

        private uint wallet;
        private uint discounts;
        private string cardId;

        public uint Wallet
        {
            get => wallet;
            set => wallet = value;
        }

        public uint Discounts
        {
            get => discounts;

            set
            {
                if (value < 101)
                {
                    discounts = value;
                }
                else
                {
                    throw new Exception("Введена недопустимая скидка");
                }
            }
        }

        public string CardId
        {
            get => cardId;

            set
            {
                if (Regex.Match(value, @"[0-9]{4}\s{1}[0-9]{4}\s{1}[0-9]{4}\s{1}[0-9]{4}").Success == true)
                {
                    cardId = value;
                }
                else
                {
                    throw new Exception("Введены неверные данные карты\n Пример: **** **** **** ****");
                }
            }
        }

        public void ReplenishmentByCard(Client client, uint money)
        {
            if (client.CardId == null)
            {
                throw new Exception("Введите данные карты");
            }
            else
            {
                client.Wallet += money;
            }
        }

        public void ReplenishmentByCash(Client client, uint money)
        {
            client.Wallet += money;
        }

        public Client() : base()
        {
            cardId = "None";
            wallet = 0;
            discounts = 0;
        }

        public object FillFromDataBase(DataRow row)
        {
            id = Convert.ToInt32(row["id"]);
            login = row["login"].ToString();
            password = row["password"].ToString();
            FIO = row["FIO"].ToString();
            Birth = row["birth"].ToString();
            PasportData = row["pasportData"].ToString();
            License = row["license"].ToString();
            PhoneNumber = row["phoneNumber"].ToString();
            DateOfRegistration = row["dateOfRegistration"].ToString();
            cardId = row["cardId"].ToString();
            wallet = Convert.ToUInt32(row["wallet"]);
            discounts = Convert.ToUInt32(row["discounts"]);
            return new Client();
        }

        ShowInfo changeEvent = null;

        public event ShowInfo ChangeEvent
        {
            add { changeEvent += value; }
            remove { changeEvent -= value; }
        }


        public void InvokeChange()
        {
            changeEvent.Invoke();
        }

        public void PushNewUserInBase()
        {
            DataBase db = new DataBase();

            MySqlCommand users = new MySqlCommand("INSERT INTO `users` (`login`, `password`, `license`, `pasportData`, `phoneNumber`, `FIO`, `birth`, `dateOfRegistration`)" +
                " VALUES (@login, @password, @licence, @pasportdata, @phonenumber, @FIO, @birth, @dateOfRegistration)", db.GetConnection());

            users.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
            users.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
            users.Parameters.Add("@licence", MySqlDbType.VarChar).Value = License;
            users.Parameters.Add("@pasportdata", MySqlDbType.VarChar).Value = PasportData;
            users.Parameters.Add("@phonenumber", MySqlDbType.VarChar).Value = PhoneNumber;
            users.Parameters.Add("@FIO", MySqlDbType.VarChar).Value = FIO;
            users.Parameters.Add("@birth", MySqlDbType.VarChar).Value = Birth;
            users.Parameters.Add("@dateOfRegistration", MySqlDbType.VarChar).Value = DateOfRegistration;

            db.openConnection();
            if (users.ExecuteNonQuery() != 1)
            {
                throw new Exception("Ошибка регистрации данных");
            }
            db.closeConnection();
        }

        public void UpdateUserInBase()
        {
            DataBase db = new DataBase();

            MySqlCommand users = new MySqlCommand("Update `users` SET `login` = @login, `password`= @password, `license` = @licence," +
            " `pasportData`= @pasportdata, `phoneNumber` = @phonenumber, `FIO` = @FIO, `birth`= @birth, `dateOfRegistration` = @dateOfRegistration," +
            " `wallet` = @wallet, `cardId` = @cardId, `discounts` = @discounts  WHERE `id` = @id", db.GetConnection());

            users.Parameters.Add("id", MySqlDbType.Int32).Value = id;
            users.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
            users.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
            users.Parameters.Add("@licence", MySqlDbType.VarChar).Value = License;
            users.Parameters.Add("@pasportdata", MySqlDbType.VarChar).Value = PasportData;
            users.Parameters.Add("@phonenumber", MySqlDbType.VarChar).Value = PhoneNumber;
            users.Parameters.Add("@FIO", MySqlDbType.VarChar).Value = FIO;
            users.Parameters.Add("@birth", MySqlDbType.VarChar).Value = Birth;
            users.Parameters.Add("@dateOfRegistration", MySqlDbType.VarChar).Value = DateOfRegistration;
            users.Parameters.Add("@wallet", MySqlDbType.Int32).Value = Wallet;
            users.Parameters.Add("@cardId", MySqlDbType.VarChar).Value = CardId;
            users.Parameters.Add("@discounts", MySqlDbType.VarChar).Value = Discounts;

            db.openConnection();
            if (users.ExecuteNonQuery() != 1)
            {
                throw new Exception("Ошибка обновления данных");
            }
            db.closeConnection();
        }

        public void IsUserExists()
        {
            DataBase db = new DataBase();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL", db.GetConnection());

            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                throw new Exception("Login is busy, please enter another");
            }
        }
    }
}
