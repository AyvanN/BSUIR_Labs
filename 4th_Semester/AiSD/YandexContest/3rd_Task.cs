using System;
using System.Collections.Generic;

namespace Third_Task
{
    class Program
    {
        private const double module = 1e9 + 7;
        static void Main(string[] args)
        {
            long N, K;
            string[] str = Console.ReadLine().Split(new char[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            N = Convert.ToInt32(str[0]);
            K = Convert.ToInt32(str[1]);
            long[] mass = new long[N];
            double answer = 1;
            long iterator = 0, start = 0, end = N - 1;
            str = Console.ReadLine().Split(new char[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            while (iterator < N)
            {
                mass[iterator] = Convert.ToInt32(str[iterator]);
                iterator++;
            }
            Array.Sort(mass);
            if (mass[0] >= 0 && mass[N - 1] > 0)
            {
                for (long i = N - 1; i > N - K - 1; i--)
                {
                    answer = (answer % module * mass[i] % module) % module;
                }
            }
            else if (mass[0] < 0 && mass[N - 1] < 0)
            {
                if (K % 2 == 0)
                {
                    for (long i = 0; i < K; i++)
                    {
                        answer = (answer % module * mass[i] % module) % module;
                    }
                }
                else
                {
                    for (long i = N - 1; i > N - K - 1; i--)
                    {
                        answer = (answer % module * mass[i] % module) % module;
                    }
                }
            }
            else
            {
                if (K % 2 == 1)
                {
                    answer = (answer % module * mass[end] % module) % module;
                    end--;
                    K--;
                }
                while (K > 0)
                {
                    if ((mass[start] % module * mass[start + 1] % module) > (mass[end] % module * mass[end - 1] % module))
                    {
                        answer = (answer % module * (mass[start] % module * mass[start + 1] % module) % module) % module;
                        start += 2;
                        K -= 2;
                    }
                    else
                    {
                        answer = (answer % module * (mass[end] % module * mass[end - 1] % module) % module) % module;
                        end -= 2;
                        K -= 2;
                    }
                }
            }
            if (answer < 0)
            {
                answer += module;
                Console.WriteLine(answer);
            }
            else
            {
                Console.WriteLine(answer);
            }
        }
    }
}

