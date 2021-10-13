using System;
using System.Collections.Generic;
using System.Text;

namespace _5th_LR
{
    enum Belts
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
        private string TypeOfSport { get; }
        public Belts Belt { get; set; }
        public Judoist() : base()
        {
            TypeOfSport = "Judoist";
            Belt = (Belts)1;
        }

        public Judoist(string name, string surName, int weight, int height, int age, double experience, 
                           string diet, string injury, string typeOfSport, int numberOfWins, Achievements achievement,Belts belt)
                            : base(name, surName, weight, height, age, experience,  diet, injury, numberOfWins, achievement)
        {
            TypeOfSport = "Judoist";
            Belt = belt;
        }

        public override void Movement()
        {
            Console.WriteLine("\nOut on the tatami");
        }

        public override string ToString()
        {
            return base.ToString() + $"\nBelt: {Belt}";
        }
    }
}
