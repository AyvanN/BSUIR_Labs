using System;

namespace Second_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            int N;
            long answer;
            N = Convert.ToInt32(Console.ReadLine());
            long[] mass = new long[N];
            string[] str = Console.ReadLine().Split(new char[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < N; i++)
            {
                mass[i] = Convert.ToInt32(str[i]);
            }
            if (N == 2)
            {
                answer = mass[0] * mass[1];
            }
            else
            {
                Array.Sort(mass);
                answer = Math.Max(mass[0] * mass[1], mass[N - 2] * mass[N - 1]);
            }
            Console.WriteLine(answer.ToString());
        }
    }
}
