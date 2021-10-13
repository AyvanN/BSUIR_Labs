using System;

namespace _4th_LR_2
{

   
    class Program
    {

        static void Main(string[] args)
        {
            double a = 13.2;
            double b = 22.7;
            int c = 4;

            Console.WriteLine($"{a} + {b} = {Linker.Sum(a,b)}");
            Console.WriteLine($"{a} - {b} = {Linker.Subtract(a, b)}");
            Console.WriteLine($"{a} * {b} = {Linker.Multiply(a, b)}");
            Console.WriteLine($"{a} / {b} = {Linker.Division(a, b)}");
            Console.WriteLine($"{a}^2 = {Linker.Square(a)}");
            Console.WriteLine($"{b}^2 = {Linker.Square(b)}");
            Console.WriteLine($"{c}! = {Linker.Factorial(c)}");
            Console.ReadKey();
        }
    }
}
