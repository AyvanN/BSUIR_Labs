using System;
using System.Collections.Generic;
using System.Text;

namespace _5th_LR
{
    class Human
    {
        //Task№1 - HUMAN->SPORTSMAN->KindOfSport
        public string Name { get; set; }
        public string Surname { get; set; }

        private int height;
        private int weight;
        private int age;

        private static double fatPercentage = 12;


        public int Height
        {
            get => height;
            set
            {
                if (value > 0)
                {
                    height = value;
                }
            }
        }

        public int Weight
        {
            get => weight;
            set
            {
                if (value > 0)
                {
                    weight = value;
                }
            }
        }

        public int Age
        {
            get => age;
            set
            {
                if (value > 0)
                {
                    age = value;
                }
            }
        }

        public Human()
        {
            Name = "No Name";
            Surname = "No Surname";
            Height = 0;
            Weight = 0;
            Age = 0;
        }

        public Human(string name, string surName, int weight, int height, int age)
        {
            Name = name;
            Surname = surName;
            Weight = weight;
            Height = height;
            Age = age;
        }


        public double GetFatMass()
        {
            if (weight != 0)
            {
                return (fatPercentage / 100) * weight;
            }
            else return 0;
        }

        public double GetFatMass(int nWeight)
        {
            if (nWeight != 0)
            {
                return (fatPercentage / 100) * nWeight;
            }
            else return 0;
        }

        public override string ToString() => $"\nName: {Name} \nSurname: {Surname} \nWeight:  {Weight}  \nHeight: { Height}  \nAge: { Age}";

    }
}
