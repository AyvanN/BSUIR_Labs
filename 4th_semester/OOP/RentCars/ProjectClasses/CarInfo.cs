using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar
{
    class CarInfo
    {
        public int id { get;protected set; }
        public string carBrand { get; set; }
        public string typeOfCar { get; set; }
        public string color { get; set; }

        public string carName { get; set; }

        private uint age;
        private uint horsePower;
        private uint weight;
        private uint fuelCapacity;
        private float engineCapacity;
        private uint maxSpeed;


        public uint Age
        {
            get => age;

            set
            {
                if (value > 10)
                {
                    throw new ArgumentException("Введен недопустимый возраст");
                }
                else
                {
                    age = value;
                }
            }
        }

        public uint HorsePower
        {
            get => horsePower;

            set
            {
                if (value > 3000)
                {
                    throw new ArgumentException("Введен недопустимое значение лошадиных сил");
                }
                else
                {
                    horsePower = value;
                }
            }
        }

        public uint Weight
        {
            get => weight;

            set
            {
                if (weight > 10000)
                {
                    throw new ArgumentException("Введен недопустимый вес");
                }
                else
                {
                    weight = value;
                }
            }
        }

        public uint FuelCapacity
        {
            get => fuelCapacity;

            set
            {
                if (fuelCapacity > 150)
                {
                    throw new ArgumentException("Введен недопустимый возраст");
                }
                else
                {
                    fuelCapacity = value;
                }
            }
        }

        public float EngineCapacity
        {
            get => engineCapacity;

            set
            {
                if (value > 8.4 || value < 0)
                {
                    throw new ArgumentException("Введен недопустимый объем двигателя");
                }
                else
                {
                    engineCapacity = value;
                }
            }
        }

        public uint MaxSpeed
        {
            get => maxSpeed;

            set
            {
                if (value > 400)
                {
                    throw new ArgumentException("Введен недопустимая скорость");
                }
                else
                {
                    maxSpeed = value;
                }
            }
        }

        public CarInfo()
        {
            carName = "None";
            carBrand = "None";
            color = "None";
            age = 0;
            horsePower = 0;
            weight = 0;
            fuelCapacity = 0;
            engineCapacity = 0;
            maxSpeed = 0;
        }




    }
}
