using System;
using System.Collections.Generic;
using System.Text;

namespace _5th_LR
{
    enum Achievements
    {
        NoAwards = 1,
        WorldChampion,
        OlympicChampion,
        EuropeanСhampion,
        RepublicanWinner
    }
    class Sportsman : Human
    {
        private double experience;
        public string Diet { get; set; }
        public string Injury { get; set; }
        public Achievements Achievement { get; set; }

        private int numberOfWins;

        public int NumberOfWins
        {
            get
            {
                return numberOfWins;
            }
            set
            {
                if (value > 0)
                {
                    numberOfWins = value;
                }
            }
        }

        public double Experience
        {
            get
            {
                return experience;
            }
            set
            {
                if (value > 0)
                {
                    experience = value;
                }
            }
        }

        public Sportsman() : base()
        {

            Experience = 0;
            Diet = "No info";
            Injury = "No info";
            NumberOfWins = 0;
            Achievement = (Achievements)1;
        }

        public Sportsman(string name, string surName, int weight, int height, int age, double experience, string diet, string injury,int numberOfWins, Achievements achievement)
                        : base(name, surName, weight, height, age)
        {
            Experience = experience;
            Diet = diet;
            Injury = injury;
            NumberOfWins = numberOfWins;
            Achievement = achievement;
        }

        public virtual void Movement()
        {
            Console.WriteLine("something doing");
        }

        public override string ToString()
        {
            return base.ToString() + $"\nExperience: {Experience}\nDiet: {Diet}\nInjury: {Injury}\nNumber of wins: {NumberOfWins}\nAchievement: {Achievement}";
        }

    }
}
