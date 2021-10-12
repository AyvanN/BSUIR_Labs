using System;

namespace Ninth_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string st;
            st = Console.ReadLine();
            int Q, QL, QR;
            int[] mass = new int[st.Length];
            char[] answer = new char[st.Length];
            string[] str;
            for(int i=0;i<st.Length;i++)
            {
                answer[i] = st[i];
            }
            Q = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < Q; i++)
            {
                str = Console.ReadLine().Split(new char[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                QL = Convert.ToInt32(str[0]);
                QR = Convert.ToInt32(str[1]);
                mass[QL - 1] += 1;
                mass[QR] -= 1;
            }

            for (int i = 1; i < mass.Length; i++)
            {
                mass[i] += mass[i - 1];
            }


            for (int i = 0; i < st.Length; i++)
            {
                if (mass[i] % 2 == 1)
                {
                    if (Char.IsUpper(answer[i]))
                    {
                        answer[i] = Char.ToLower(answer[i]);
                    }
                    else
                    {
                        answer[i] = Char.ToUpper(answer[i]);
                    }
                }
            }
            Console.WriteLine(answer);
        }
    }
}
