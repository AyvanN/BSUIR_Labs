using System;

namespace Nineteenth_Task
{
    class Program
    {
        static public long answer = 0;

        static void MergeSort(long[] mass, long startIndex, long endIndex)
        {
            if (startIndex < endIndex)
            {
                long middleIndex = (startIndex + endIndex) / 2;
                MergeSort(mass, startIndex, middleIndex);
                MergeSort(mass, middleIndex + 1, endIndex);
                Merge(mass, startIndex, middleIndex, endIndex);
            }
        }
        static void Main(string[] args)
        {
            long N;
            N = Convert.ToInt32(Console.ReadLine());
            long[] A = new long[N];
            string[] str = Console.ReadLine().Split(new char[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            for (long i = 0; i < N; i++)
            {
                A[i] = Convert.ToInt32(str[i]);
            }
            MergeSort(A, 0, A.Length - 1);
            Console.WriteLine(answer.ToString());
        }

        static void Merge(long[] mass, long startIndex, long middleIndex, long endIndex)
        {
            long left = startIndex;
            long right = middleIndex + 1;
            long[] arr = new long[endIndex - startIndex + 1];
            long iterator = 0;

            while ((left <= middleIndex) && (right <= endIndex))
            {
                arr[iterator] = Math.Min(mass[left], mass[right]);
                if (arr[iterator] == mass[left])
                {
                    left++;
                }
                else
                {
                    right++;
                    answer += (middleIndex - left + 1);
                }
                iterator++;
            }
            if (left > middleIndex)
            {
                while (right <= endIndex)
                {
                    arr[iterator] = mass[right];
                    right++;
                    iterator++;
                }
            }
            else
            {
                while (left <= middleIndex)
                {
                    arr[iterator] = mass[left];
                    left++;
                    iterator++;
                }
            }
            for (long i = startIndex, j = 0; i <= endIndex; j++, i++)
            {
                mass[i] = arr[j];
            }
        }
    }
}
