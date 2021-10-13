using _6th_LR;
using System;
using System.Collections.Generic;
using System.Text;

namespace _5th_LR
{
    public enum Achievements
    {
        NoAwards = 1,
        WorldChampion,
        OlympicChampion,
        EuropeanСhampion,
        RepublicanWinner
    }
    class Sportsman : Human, ICompetition, IHealth
    {
        private double experience;
        public string Diet { get; set; }
        public string Injury { get; set; }
        public Achievements Achievement { get; set; }

        private int numberOfWins;

        public int NumberOfWins
        {
            get => numberOfWins;
            set
            {
                if (value < 0)
                {
                    numberOfWins = value;
                }
            }
        }

        public double Experience
        {
            get => experience;
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

        public Sportsman(string name, string surName, int weight, int height, int age, double experience, string diet, string injury, int numberOfWins, Achievements achievement)
                        : base(name, surName, weight, height, age)
        {
            Experience = experience;
            Diet = diet;
            Injury = injury;
            NumberOfWins = numberOfWins;
            Achievement = achievement;
        }

        public virtual void Movement() => Console.WriteLine("something doing");

        public override string ToString() => base.ToString() + $"\nExperience: {Experience}\nDiet: {Diet}\nInjury: {Injury}\nNumber of wins: {NumberOfWins}\nAchievement: {Achievement}";


        public bool Battle(Sportsman sportsman2)
        {
            int human1 = 0, human2 = 0;
            if (Age > sportsman2.Age)
            {
                human1 += 40;
                human2 -= 40;
            }
            else
            {
                human1 -= 40;
                human2 += 40;
            }
            if (Experience > sportsman2.Experience)
            {
                human1 += 45;
                human2 -= 45;
            }
            else
            {
                human1 -= 45;
                human2 += 45;
            }
            if (NumberOfWins > sportsman2.NumberOfWins)
            {
                human1 += 15;
                human2 -= 15;
            }
            else
            {
                human1 -= 15;
                human2 += 15;
            }
            return human1 > human2;
        }

        public bool Admittance()
        {
            if (Injury == "Yes")
            {
                Console.WriteLine("Cannot participate in competitions");
                return false;
            }
            Console.WriteLine("Allowed to compete");
            return true;
        }

        public void CheckDiet()
        {
            int check = Height - 100;
            if (check < Weight && Diet == "No")
            {
                Console.WriteLine("You need a diet");
                Diet = "Yes";
            }
            else if (check > Weight && Diet == "Yes")
            {
                Console.WriteLine("Your weight is normal.You do not need to diet");
                Diet = "No";
            }
            else if (check < Weight && Diet == "Yes")
            {
                Console.WriteLine("Continue to keep to a diet");

            }
            else if (check > Weight && Diet == "No")
            {
                Console.WriteLine("Your weight is normal");
            }
        }

        public void CheckAge()
        {
            if (Age > 40)
            {
                Console.WriteLine("Advice.Finish your professional career in sports");
            }
            else
            {
                Console.WriteLine("Continue your career as an sportsman");
            }
        }

    }
}
