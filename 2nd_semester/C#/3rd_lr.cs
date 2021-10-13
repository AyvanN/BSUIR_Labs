using System;

namespace _3rd_LR
{
    class Program
    {
        static void Main(string[] args)
        {
            Human emptiness = new Human();
            Human man = new Human("Vanya", "Shabunia", 70, 185, 18);
            Console.WriteLine(man);
            double Fat;
            Fat = man.GetFatMass();
            Console.WriteLine("Fat mass = " + Fat);
            Fat = man.GetFatMass(100);
            Console.WriteLine("New Fat mass = " + Fat);
            Console.WriteLine(emptiness);
        }
    }
}
