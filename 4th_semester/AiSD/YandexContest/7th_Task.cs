using System;

namespace Seventh_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            int N, M, X1, X2, Y1, Y2;
            string[] str = Console.ReadLine().Split(new char[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            X1 = Convert.ToInt32(str[2]);
            X2 = Convert.ToInt32(str[4]);
            Y1 = Convert.ToInt32(str[3]);
            Y2 = Convert.ToInt32(str[5]);
            if (Math.Abs(X1 - X2) == Math.Abs(Y1 - Y2))
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}
