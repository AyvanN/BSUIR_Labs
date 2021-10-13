using _6th_LR;
using System;
using System.Collections.Generic;

//Демонстрация классов + меню 
namespace _5th_LR
{
    public delegate bool CompareSimbols(string element1, string word1, string word2);
    public delegate bool CheckValue(int number, int LowV, int HighV);
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            int[] lastAmount = new int[4];
            int[] amount = new int[4];
            bool exit = false;

            List<Judoist> human1 = new List<Judoist>();
            List<Volleyballist> human2 = new List<Volleyballist>();
            List<Athlete> human3 = new List<Athlete>();
            List<AnotherSport> human4 = new List<AnotherSport>();
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine($"\n1)Add judoists \n2)Add volleyballists \n3)Add athletes \n4)Add Another sport \n5)Judo " +
                                  $"\n6)Volleyball \n7)Athlete \n8)Another sport \n0)Exit");
                choice = InputCheck(0, 8);
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Select the number of sportsman's you would like to add: ");
                        lastAmount[0] = amount[0];
                        amount[0] += InputCheck(1);
                        for (int i = lastAmount[0]; i < amount[0]; i++)
                        {
                            Console.Clear();
                            human1.Add(new Judoist());
                            HumanInput(human1[i]);
                            SportsmanInput(human1[i]);
                            JudoInput(human1[i]);
                        }
                        break;
                    case 2:
                        Console.WriteLine("Select the number of sportsman's you would like to add: ");
                        lastAmount[1] = amount[1];
                        amount[1] += InputCheck(1);
                        for (int i = lastAmount[1]; i < amount[1]; i++)
                        {
                            Console.Clear();
                            human2.Add(new Volleyballist());
                            HumanInput(human2[i]);
                            SportsmanInput(human2[i]);
                            VolleyballInput(human2[i]);
                        }
                        break;
                    case 3:
                        Console.WriteLine("Select the number of sportsman's you would like to add: ");
                        lastAmount[2] = amount[2];
                        amount[2] += InputCheck(1);
                        for (int i = lastAmount[2]; i < amount[2]; i++)
                        {
                            Console.Clear();
                            human3.Add(new Athlete());
                            HumanInput(human3[i]);
                            SportsmanInput(human3[i]);
                            AthleteInput(human3[i]);
                        }
                        break;
                    case 4:
                        Console.WriteLine("Select the number of sportsman's you would like to add: ");
                        lastAmount[3] = amount[3];
                        amount[3] += InputCheck(1);
                        for (int i = lastAmount[3]; i < amount[3]; i++)
                        {
                            Console.Clear();
                            human4.Add(new AnotherSport());
                            HumanInput(human4[i]);
                            SportsmanInput(human4[i]);
                            AnotherSportInput(human4[i]);
                        }
                        break;
                    case 5:
                        if (human1.Count > 0)
                        {
                            for (int i = 0; i < human1.Count; i++)
                            {
                                SelectionMenu(human1[i], i);
                            }
                            Console.Clear();
                            if (human1.Count > 1)
                            {
                                Competition(human1);
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nThere are no sportsmans in this category");
                            Expectation();
                        }
                        break;
                    case 6:
                        if (human2.Count > 0)
                        {
                            for (int i = 0; i < human2.Count; i++)
                            {
                                SelectionMenu(human2[i], i);
                            }
                            Console.Clear();
                            if (human2.Count > 1)
                            {
                                Competition(human2);
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nThere are no sportsmans in this category");
                            Expectation();
                        }
                        break;
                    case 7:
                        if (human3.Count > 0)
                        {
                            for (int i = 0; i < human3.Count; i++)
                            {
                                SelectionMenu(human3[i], i);
                            }
                            Console.Clear();
                            if (human3.Count > 1)
                            {
                                Competition(human3);
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nThere are no sportsmans in this category");
                            Expectation();
                        }
                        break;
                    case 8:
                        if (human4.Count > 0)
                        {
                            for (int i = 0; i < human4.Count; i++)
                            {
                                SelectionMenu(human4[i], i);
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nThere are no sportsmans in this category");
                            Expectation();
                        }
                        break;
                    case 0:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Error! Character entered incorrectly.");
                        break;
                }
            }
        }



        static void Competition<T>(List<T> sportsman) where T : Sportsman
        {
            int pick = 0;
            while (!(pick == 2))
            {
                Console.Clear();
                Console.WriteLine("Do you want to hold a competition between two sportsmans? \n1)Yes \n2)No");
                pick = InputCheck(1, 2);
                if (pick == 1)
                {
                    Console.WriteLine("Choose two athletes:");
                    for (int i = 0; i < sportsman.Count; i++)
                    {
                        Console.WriteLine($"\n№{i + 1} \n{sportsman[i]}");
                    }
                    int athlet1, athlet2;
                    bool check1, check2;
                    athlet1 = InputCheck(1, sportsman.Count);
                    athlet2 = InputCheck(1, sportsman.Count);
                    athlet1 = GetActualCount(athlet1);
                    athlet2 = GetActualCount(athlet2);
                    check1 = sportsman[athlet1].Admittance();
                    check2 = sportsman[athlet2].Admittance();
                    Console.Clear();
                    if (check1 == false)
                    {
                        Console.WriteLine($"Athlete №{athlet1 + 1} has an injury and cannot participate in the competition");
                        Expectation();
                    }
                    if (check2 == false)
                    {
                        Console.WriteLine($"Athlete №{athlet2 + 1} has an injury and cannot participate in the competition");
                        Expectation();
                    }
                    if (check1 == true && check2 == true)
                    {
                        bool win = sportsman[athlet1].Battle(sportsman[athlet2]);
                        if (win == true)
                        {
                            ShowWinner(athlet1);
                        }
                        else if (win == false)
                        {
                            ShowWinner(athlet2);
                        }

                    }
                }
            }

        }
        private static void Expectation()
        {
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }
        private static void ShowWinner(int athlet)
        {
            Console.WriteLine($"Sportsman №{athlet + 1} become the winner!!!");
            Expectation();
        }

        private static int GetActualCount(int athlet) => athlet - 1;

        static int InputCheck(int LowValue, int HighValue)
        {
            int check;
            bool res;
            CheckValue parameterCheck = (int number, int LowV, int HighV)=> (number >= LowV && number <= HighV);
            while (true)
            {
                while (!int.TryParse(Console.ReadLine(), out check))
                {
                    Console.WriteLine("Error! Character entered incorrectly. Try again.");
                }
                res = parameterCheck(check, LowValue, HighValue);
                if (res)
                {
                    break;
                }
                Console.WriteLine("Error! Character entered incorrectly. Try again.");
            }

            return check;
        }

        static int InputCheck(int LowValue)
        {
            int check;
            while (true)
            {
                while (!int.TryParse(Console.ReadLine(), out check))
                {
                    Console.WriteLine("Error! Character entered incorrectly. Try again.");
                }
                if (check >= LowValue)
                {
                    break;
                }
                Console.WriteLine("Error! Character entered incorrectly. Try again.");
            }

            return check;
        }

        static string SymbolCkeck()
        {
            string variety;
            bool result;
            CompareSimbols check = (string element, string word1, string word2) => (element == word1 || element == word2);
            while (true)
            {
                variety = Console.ReadLine();
                result = check(variety, "Yes", "No");
                if (result)
                {
                    break;
                }
                Console.WriteLine("Error! Character entered incorrectly. Try again.");
            }
            return variety;
        }

        static void HumanInput(Human human)
        {
            Console.WriteLine("Enter name: ");
            human.Name = Console.ReadLine();
            Console.WriteLine("\nEnter surname: ");
            human.Surname = Console.ReadLine();
            Console.WriteLine("\nEnter weight: ");
            human.Weight = InputCheck(0);
            Console.WriteLine("\nEnter heihgt: ");
            human.Height = InputCheck(0);
            Console.WriteLine("\nEnter age: ");
            human.Age = InputCheck(0);
        }
        static void SportsmanInput(Sportsman sportsman)
        {
            Console.WriteLine("\nEnter experience in sports(in years): ");
            sportsman.Experience = InputCheck(0, sportsman.Age);
            Console.WriteLine("\nEnter availability of a sports diet (Yes/No):");
            sportsman.Diet = SymbolCkeck();
            Console.WriteLine("\nEnter presence of injuries (Yes/No): ");
            sportsman.Injury = SymbolCkeck();
            Console.WriteLine("\nEnter number of wins in competitions: ");
            sportsman.NumberOfWins = InputCheck(0);
            Console.WriteLine($"\nEnter the athlete's achievements for the competition: \n1)No awards \n2)World champion " +
                                $"\n3)Olympic champion \n4)European champion \n5)Republican winner\n");
            sportsman.Achievement = (Achievements)InputCheck(1, 5);
        }

        static void AthleteInput(Athlete sportsman)
        {
            Console.WriteLine($"\nEnter the distance the athlete is running: \n1)Unknown distance \n2)Long distance \n3)Short distance");
            sportsman.Race = (TypeOfRace)InputCheck(1, 3);
        }

        static void JudoInput(Judoist sportsman)
        {
            Console.WriteLine($"\nEnter the athlete's belt:\n1)No info \n2)White \n3)Yellow \n4)Orange \n5)Green \n6)Blue \n7)Brown \n8)Black");
            sportsman.Belt = (Belts)InputCheck(1, 8);
        }

        static void VolleyballInput(Volleyballist sportsman)
        {
            Console.WriteLine($"\nEnter the type of volleyball: \n1)BeachVolleyball \n2)IndoorVolleyball \n3)SnowVolleyball");
            sportsman.Type = (TypeOfVolleyball)InputCheck(1, 3);
        }

        static void AnotherSportInput(AnotherSport sportsman)
        {
            Console.WriteLine("\nEnter the type of sport");
            sportsman.TypeOfSport = Console.ReadLine();
        }

        static void SelectionMenu(Sportsman sportsman, int number)
        {
            int selection;
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine($"\n№{number + 1}: \n1)Information about the sportsman \n2)The sportsman's action " +
                                  $"\n3)Check sportsman's health \n4)Back");
                selection = InputCheck(1, 4);
                switch (selection)
                {
                    case 1:
                        Console.WriteLine(sportsman);
                        Expectation();
                        break;
                    case 2:
                        sportsman.Movement();
                        Expectation();
                        break;
                    case 3:
                        sportsman.CheckDiet();
                        sportsman.CheckAge();
                        Expectation();
                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("ERROR!.Try again");
                        break;
                }
            }
        }
    }
}
