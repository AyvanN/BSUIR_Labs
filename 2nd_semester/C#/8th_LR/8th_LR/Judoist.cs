using System;
using System.Collections.Generic;
using System.Text;

namespace _5th_LR
{
    public enum Belts
    {
        NoInfo = 1,
        White,
        Yellow,
        Orange,
        Green,
        Blue,
        Brown,
        Black
    }
    class Judoist : Sportsman
    {
        private readonly string typeOfSport;

        private string GetTypeOfSport()
        {
            return typeOfSport;
        }

        public Belts Belt { get; set; }
        public Judoist() : base()
        {
            typeOfSport = "Judoist";
            Belt = (Belts)1;
        }

        public Judoist(string name, string surName, int weight, int height, int age, double experience,
                           string diet, string injury, string typeOfSport, int numberOfWins, Achievements achievement, Belts belt)
                            : base(name, surName, weight, height, age, experience, diet, injury, numberOfWins, achievement)
        {
            this.typeOfSport = "Judoist";
            Belt = belt;
        }

        public override void Movement() => Console.WriteLine("\nOut on the tatami");

        public override string ToString() => base.ToString() + $"\nType of sport {GetTypeOfSport()}\nBelt: {Belt}";
    }
}
