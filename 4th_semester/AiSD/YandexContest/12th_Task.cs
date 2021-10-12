using System;

namespace Twelfth_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string number;
            number = Console.ReadLine();
            if(number[number.Length-1]=='0')
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine(number[number.Length - 1]);
            }
        }
    }
}
