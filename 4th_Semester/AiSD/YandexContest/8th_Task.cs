using System;

namespace Eighth_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            bool simSymb = false;
            string str;
            str = Console.ReadLine();
            for (int j = str.Length - 1, i = 0; j >= i; j--, i++)
            {
                if (simSymb == false && str[0] != str[i])
                {
                    simSymb = true;
                }
                if (str[i] != str[j])
                {
                    Console.WriteLine(str.Length);
                    System.Environment.Exit(0);
                }
            }
            if (simSymb == false)
            {
                Console.WriteLine("-1");
            }
            else
            {
                Console.WriteLine(str.Length - 1);
            }
        }
    }
}
