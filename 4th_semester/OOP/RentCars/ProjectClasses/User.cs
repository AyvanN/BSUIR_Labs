using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RentCar
{
    public class User
    {
        public string login { get; set; }
        public string password { get; set; }
        public int id { get; protected set; }

        private string fIO;
        private string birth;
        private string dateOfRegistration;
        private string license;
        private string pasportData;
        private string phoneNumber;

        public string License
        {
            get => license;

            set
            {
                if (Regex.Match(value, @"[0-9]{1}[A-Z]{2}\s+[0-9]{6}").Success == true)
                {
                    license = value;
                }
                else
                {
                    throw new Exception("Неправильный ввод лицензии");
                }
            }

        }

        public string PasportData
        {
            get => pasportData;

            set
            {
                if (Regex.Match(value, @"[A-Z]{2}[0-9]{7}").Success == true)
                {
                    pasportData = value;
                }
                else
                {
                    throw new Exception("Неправильный ввод паспортных данных");
                }
            }

        }

        public string PhoneNumber
        {
            get => phoneNumber;

            set
            {
                if (Regex.Match(value, @"\+[0-9]{12}").Success == true)
                {
                    phoneNumber = value;
                }
                else
                {
                    throw new Exception("Неправильный ввод телефонного номера");
                }
            }

        }

        public string FIO
        {
            get => fIO;

            set
            {
                if (int.TryParse(value, out var a) == false)
                {
                    fIO = value;
                }
                else
                {
                    throw new Exception("Неверный ввод FIO, попробуйте еще раз");
                }
            }
        }

        public string Birth
        {
            get => birth;
            set
            {
                if (Regex.Match(value, @"[0-9]{2}\.[0-9]{2}\.[0-9]{4}").Success == true)
                {
                    birth = value;
                }
                else
                {
                    throw new Exception("Неверно введена дата рождения");
                }
            }
        }

        public string DateOfRegistration
        {
            get => dateOfRegistration;
            set
            {
                if (Regex.Match(value, @"[0-9]{2}\.[0-9]{2}\.[0-9]{4}").Success == true)
                {
                    dateOfRegistration = value;
                }
                else
                {
                    throw new Exception("Неверно введена дата регистрации");
                }
            }
        }

        public User()
        {
            id = 0;
            FIO = "None";
            login = "None";
            password = "None";
            birth = "None";
            pasportData = "None";
            license = "None";
            phoneNumber = "None";
            dateOfRegistration = "None";

        }

    }
}
