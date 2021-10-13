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

    public delegate bool CompareDelegate(double element1, double element2);
    public delegate void Diet(string massage);

    class Sportsman : Human, ICompetition, IHealth
    {
        public event Diet DietChange;

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
            DietChange += (string message) => Console.WriteLine(message);

        }

        public Sportsman(string name, string surName, int weight, int height, int age, double experience, string diet, string injury, int numberOfWins, Achievements achievement)
                        : base(name, surName, weight, height, age)
        {
            Experience = experience;
            Diet = diet;
            Injury = injury;
            NumberOfWins = numberOfWins;
            Achievement = achievement;
            DietChange += (string message) => Console.WriteLine(message);
        }

        public virtual void Movement() => Console.WriteLine("something doing");

        public override string ToString() => base.ToString() + $"\nExperience: {Experience}\nDiet: {Diet}\nInjury: {Injury}\nNumber of wins: {NumberOfWins}\nAchievement: {Achievement}";

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
                DietChange?.Invoke("Diet change");
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

        public bool Battle(Sportsman sportsman2)
        {
            bool result;
            int human1 = 0, human2 = 0;
            CompareDelegate compare = (element1, element2) => element1 > element2;
            result = compare(Age, sportsman2.Age);
            if (!result)
            {
                human2++;
            }
            else
            {
                human1++;

            }
            result = compare(Experience, sportsman2.Experience);
            if (!result)
            {
                human2++;
            }
            else
            {
                human1++;
            }
            result = compare(NumberOfWins, sportsman2.NumberOfWins);
            if (!result)
            {
                human2++;
            }
            else
            {
                human1++;
            }
            return compare(human1, human2);
        }

    }
}
