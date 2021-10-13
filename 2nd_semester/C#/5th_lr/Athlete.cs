using System;
using System.Collections.Generic;
using System.Text;

enum TypeOfRace
{
    UnknownDistance = 1,
    LongDistance,
    ShortDistance
}


namespace _5th_LR
{
    class Athlete : Sportsman
    {
        private string TypeOfSport { get; }
        public TypeOfRace Race { get; set; }

        public Athlete() : base()
        {
            TypeOfSport = "Athlete";
            Race = (TypeOfRace)1;
        }

        public Athlete(string name, string surName, int weight, int height, int age, double experience, 
                           string diet, string injury, string typeOfSport, int numberOfWins, Achievements achievement,TypeOfRace race)
                            : base(name, surName, weight, height, age, experience, diet, injury, numberOfWins, achievement)
        {
            TypeOfSport = "Athlete";
            Race = race;
        }

        public override void Movement()
        {
            Console.WriteLine("\nGoes to the race");
        }

        public override string ToString()
        {
            return base.ToString() + $"\nType Of Race: {Race}";
        }
    }
}
