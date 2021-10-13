using System;
using System.Collections.Generic;


namespace Fifth_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] str;
            int N, M, start, end, iterator = 0;
            N = Convert.ToInt32(Console.ReadLine());
            M = Convert.ToInt32(Console.ReadLine());
            List<int[]>[] G = new List<int[]>[N];
            long[] node = new long[N];
            bool[] attendance = new bool[N];
            while (iterator < N)
            {
                G[iterator] = new List<int[]>();
                iterator++;
            }


            for (int i = 0; i < M; i++)
            {
                str = Console.ReadLine().Split(new char[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                G[Convert.ToInt32(str[0]) - 1].Add(new int[] { Convert.ToInt32(str[1]) - 1, Convert.ToInt32(str[2]) });
                G[Convert.ToInt32(str[1]) - 1].Add(new int[] { Convert.ToInt32(str[0]) - 1, Convert.ToInt32(str[2]) });
            }

            start = Convert.ToInt32(Console.ReadLine()) - 1;
            end = Convert.ToInt32(Console.ReadLine()) - 1;

            iterator = 0;
            while (iterator < N)
            {
                node[iterator] = long.MaxValue;
                iterator++;
            }
            node[start] = 0;

            for (int i = 0; i < N; i++)
            {
                int min = int.MinValue;
                for (int j = 0; j < N; j++)
                {
                    if (attendance[j] == false)
                    {
                        if (min == int.MinValue)
                            min = j;
                        else if (node[min] > node[j])
                            min = j;
                    }
                }
                if (node[min] == int.MaxValue)
                    break;
                else
                {
                    attendance[min] = true;
                    for (int j = 0; j < G[min].Count; j++)
                    {
                        long p = G[min][j][0];
                        long path = G[min][j][1];
                        if (node[min] + path < node[p])
                        {
                            node[p] = node[min] + path;
                        }
                    }
                }
            }

            Console.WriteLine(node[end]);
        }
    }
}