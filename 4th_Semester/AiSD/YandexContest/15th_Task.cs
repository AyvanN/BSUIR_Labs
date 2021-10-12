using System;

namespace Fifteenth_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            long size, answer = 0;
            size = Convert.ToInt32(Console.ReadLine());
            long[] mass = new long[size];
            string[] str = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < size; i++)
            {
                mass[i] = Convert.ToInt32(str[i]);
            }
            long maxNumber = mass[0];
            for (int i = 1; i < size; i++)
            {
                if (mass[i] > maxNumber)
                {
                    answer += mass[i] - maxNumber;
                    maxNumber = mass[i];
                }
                else
                {
                    if (mass[i] < mass[i - 1])
                    {
                        answer += mass[i - 1] - mass[i];
                    }
                }
            }
            Console.WriteLine(answer.ToString());
        }
    }
}
