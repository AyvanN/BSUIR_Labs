using System;

namespace _7th_LR
{
    class Program
    {
        static void Main()
        {
            RationalNumber a = new RationalNumber(9, 3);
            RationalNumber b = RationalNumber.Create("8/19");
            RationalNumber c = "2/3";

            Console.WriteLine($"{a}");
            Console.WriteLine($"{b}");
            Console.WriteLine($"{(double)c}\n");

            Console.WriteLine($"{a} + {b} = {a + b}");
            Console.WriteLine($"{a} / {c} = {a / c}");
            Console.WriteLine($"{b} + 3 = {b + 3}\n");

            if (b > c)
                Console.WriteLine($"{b} > {c}\n");
            if (a != c)
                Console.WriteLine($"{(double)a} != {(double)c}\n");

            var number1 = new RationalNumber(10, 22);
            var number2 = new RationalNumber(5, 11);

            Console.WriteLine($"{ number1.CompareTo(number2) }");
            Console.WriteLine($"{ number1.Equals(number2) }");
            if (number1 == number2)
                Console.WriteLine("number1 = number2");
        }

    }
}
