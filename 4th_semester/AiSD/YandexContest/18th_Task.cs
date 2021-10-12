using System;

namespace Eighteenth
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.Clear();
            int y;
            y = Convert.ToInt32(Console.ReadLine());
            if (y % 4 == 0 && (y % 400 == 0 || y % 100 != 0))
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }

        }
    }
}
