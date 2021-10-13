using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace _5th_LR
{

    class AnotherSport : Sportsman
    {
        public string TypeOfSport { get; set; }

        public AnotherSport()
        {
            TypeOfSport = "No sport";
        }

        public AnotherSport(string name, string surName, int weight, int height, int age, double experience,
                           string diet, string injury, string typeOfSport, int numberOfWins, Achievements achievement)
                            : base(name, surName, weight, height, age, experience, diet, injury, numberOfWins, achievement)
        {
            TypeOfSport = typeOfSport;
        }

        public override void Movement()
        {
            Console.WriteLine("\nDoes warm-up");
        }

        public override string ToString()
        {
            return base.ToString() + $"\nTypeOfSport: {TypeOfSport}";
        }
    }
}
