using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar
{
    class RentalInfo : CarInfo, IFillFromDataBase
    {
       public uint rentalDays { get; set; }
        public bool isRented { get; set; }
        public uint rentalPrice { get; private set; }

        public RentalInfo() : base()
        {
            rentalPrice = 0;
            isRented = false;
            rentalDays = 0;
        }

        public object FillFromDataBase(DataRow row)
        {
            id = Convert.ToInt32(row["id"]);
            carName = row["carName"].ToString();
            carBrand = row["carBrand"].ToString();
            typeOfCar = row["typeOfCar"].ToString();
            color = row["color"].ToString();
            Age = Convert.ToUInt32(row["age"]);
            HorsePower = Convert.ToUInt32(row["horsePower"]);
            Weight = Convert.ToUInt32(row["weight"]);
            FuelCapacity = Convert.ToUInt32(row["fuelCapacity"]);
            EngineCapacity = float.Parse(row["engineCapacity"].ToString());
            MaxSpeed = Convert.ToUInt32(row["maxSpeed"]);
            rentalPrice = Convert.ToUInt32(row["rentalPrice"]);
            rentalDays = Convert.ToUInt32(row["rentalDays"]);
            isRented = Convert.ToBoolean(row["isRented"]);
            return new RentalInfo();
        }

    }
}
