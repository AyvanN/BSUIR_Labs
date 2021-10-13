using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace _2nd_LR
{
    class Program
    {
        static void Main(string[] args)
        {
            Tasks task = new Tasks();
            int choice = 10;
            int a, b;
            bool stop = true;
            while (stop)
            {
                Console.WriteLine("\nSelect the tasks that you want to view:\n1)Task №1 \n2)Task №4 \n3)Task №5 \n0)Exit");
                choice = InputCheck(0, 3);
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Task №1: ");
                        task.GettingCurrentTimeAndDate();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Task №4: ");
                        Console.Write("Write interval [a,b]\na=");
                        a = InputCheck();
                        Console.Write("b=");
                        b = InputCheck();
                        task.CalculationOfTheDegree(a, b);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Task №5: ");
                        Console.WriteLine("Enter the string: ");
                        char[] letters = task.FindNotEnglishUpperLetters(Console.ReadLine());
                        Console.WriteLine("All uppercase letters that are not part of the English alphabet:");
                        foreach (char letter in letters)
                        {
                            Console.Write(letter);
                        }
                        break;
                    default:
                        stop = false;
                        break;
                }
            }
        }

        static int InputCheck(int LowValue, int HighValue)
        {
            int check;
            while (true)
            {
                while (!int.TryParse(Console.ReadLine(), out check))
                {
                    Console.WriteLine("Error! Character entered incorrectly. Try again.");
                }
                if (check >= LowValue && check <= HighValue)
                {
                    break;
                }
                Console.WriteLine("Error! Character entered incorrectly. Try again.");
            }

            return check;
        }


        static int InputCheck()
        {
            int check;
            while (true)
            {
                while (!int.TryParse(Console.ReadLine(), out check))
                {
                    Console.WriteLine("Error! Character entered incorrectly. Try again.");
                }

                break;
            }

            return check;
        }

    }
}
