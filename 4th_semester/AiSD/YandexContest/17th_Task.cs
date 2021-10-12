using System;
using System.Collections.Generic;

namespace Seventeenth_Task
{
    class Program
    {
        private static int comp = 1031 * 1021 * 1033;
        private static int[] comparison = { 1021, 1031, 1033 };
        private static int[] _comparison = { 1052651, 1054693, 1065023 };
        public static bool Checker(List<int> lst)
        {
            foreach (var value in lst)
            {
                if (comp == value)
                {
                    return true;
                }
            }
            if (lst.IndexOf(comparison[0]) != -1 && lst.IndexOf(_comparison[2]) != -1)
            {
                return true;
            }
            if (lst.IndexOf(comparison[2]) != -1 && lst.IndexOf(_comparison[0]) != -1)
            {
                return true;
            }
            if (lst.IndexOf(comparison[1]) != -1 && lst.IndexOf(_comparison[1]) != -1)
            {
                return true;
            }
            if (lst.IndexOf(comparison[0]) != -1 && lst.IndexOf(comparison[1]) != -1 && lst.IndexOf(comparison[2]) != -1)
            {
                return true;
            }
            return false;
        }
        static void Main(string[] args)
        {
            string[] str;
            List<int> lst = new List<int>();
            int iterator = 0;
            int N = Convert.ToInt32(Console.ReadLine());
            while (iterator < N)
            {
                str = Console.ReadLine().Split(new char[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (Convert.ToInt32(str[0]) == comp)
                {
                    lst.Add(comp);
                }
                foreach (var t in comparison)
                {
                    if (Convert.ToInt32(str[0]) == t)
                    {
                        lst.Add(t);
                    }
                }
                foreach (var t in _comparison)
                {
                    if (Convert.ToInt32(str[0]) == t)
                    {
                        lst.Add(t);
                    }
                }
                iterator++;
            }
            if (Checker(lst))
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
