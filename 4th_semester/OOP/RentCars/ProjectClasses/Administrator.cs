using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar
{
    class Administrator : User
    {

        private bool adminPermissions;
        private bool mainAdministrator;
        public bool Permissions
        {
            get => adminPermissions;
        }

        public void SetPermissions(Administrator admin)
        {
            if (admin.MainAdministrator == true)
            {
                adminPermissions = true;
            }
            else
            {
                throw new Exception("Недостаточно прав");
            }
        }

        public bool MainAdministrator
        {
            get => mainAdministrator;
        }

        public Administrator() : base()
        {
            adminPermissions = false;
            mainAdministrator = false;
        }

        public void MakeAdmin(DataRow row)
        {
            try
            {
                login = row["login"].ToString();
                password = row["password"].ToString();
                FIO = row["FIO"].ToString();
                Birth = row["birth"].ToString();
                PasportData = row["pasportData"].ToString();
                License = row["license"].ToString();
                PhoneNumber = row["phoneNumber"].ToString();
                DateOfRegistration = row["dateOfRegistration"].ToString();
                adminPermissions = (bool)row["adminPermissions"];
                mainAdministrator = (bool)row["mainAdministrator"];
            }
            catch(Exception ex)
            {
                CustomMessage message = new CustomMessage();
                message.message.Text = ex.Message;
                message.Show();
            }
           

        }
    }
}
