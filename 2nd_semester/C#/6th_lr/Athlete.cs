using System;
using System.Collections.Generic;
using System.Text;

namespace _5th_LR
{
    public enum TypeOfRace
    {
        UnknownDistance = 1,
        LongDistance,
        ShortDistance
    }
    class Athlete : Sportsman
    {
        private readonly string typeOfSport;

        private string GetTypeOfSport()
        {
            return typeOfSport;
        }

        public TypeOfRace Race { get; set; }

        public Athlete() : base()
        {
            typeOfSport = "Athlete";
            Race = (TypeOfRace)1;
        }

        public Athlete(string name, string surName, int weight, int height, int age, double experience,
                           string diet, string injury, string typeOfSport, int numberOfWins, Achievements achievement, TypeOfRace race)
                            : base(name, surName, weight, height, age, experience, diet, injury, numberOfWins, achievement)
        {
            this.typeOfSport = "Athlete";
            Race = race;
        }

        public override void Movement() => Console.WriteLine("\nGoes to the race");

        public override string ToString() => base.ToString() + $"\nType of sport: {GetTypeOfSport()} \nType Of Race: {Race}";
    }
}
