using System;
using System.Collections.Generic;

namespace Sixteenth_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            int numb;
            List<int> lst = new List<int>();
            List<int> answer = new List<int>();
            string str = Console.ReadLine();
            int number = Convert.ToInt32(str);
            str = "";
            numb = number % 10;
            lst.Add(numb);
            number /= 10;
            while (number != 0)
            {
                numb = number % 10;
                number /= 10;
                if (numb < lst[lst.Count - 1])
                {
                    if (number != 0)
                    {
                        answer.Add(number);
                    }
                    lst.Add(numb);
                    lst.Sort();
                    foreach (var value in lst)
                    {
                        if (value > numb)
                        {
                            answer.Add(value);
                            lst.Remove(value);
                            break;
                        }
                    }
                    foreach (var value in lst)
                    {
                        answer.Add(value);
                    }
                    foreach (var value in answer)
                    {
                        str += value.ToString();
                    }
                    Console.WriteLine(str);
                    System.Environment.Exit(0);
                }
                else
                {
                    lst.Add(numb);
                }
            }
            Console.WriteLine("-1");
        }
    }
}
