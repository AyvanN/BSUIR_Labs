using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace _4th_LR_2
{
    class Linker
    {
        private const string link = "CustomDLL.dll";


        [DllImport(link, EntryPoint = "Multiply", CallingConvention = CallingConvention.StdCall)]
        public static extern double Multiply(double a, double b);

        [DllImport(link, EntryPoint = "Division", CallingConvention = CallingConvention.StdCall)]
        public static extern double Division(double a, double b);

        [DllImport(link, EntryPoint = "Sum", CallingConvention = CallingConvention.StdCall)]
        public static extern double Sum(double a, double b);

        [DllImport(link, EntryPoint = "Subtract", CallingConvention = CallingConvention.StdCall)]
        public static extern double Subtract(double a, double b);

        [DllImport(link, EntryPoint = "Square", CallingConvention = CallingConvention.StdCall)]
        public static extern double Square(double a);

        [DllImport(link, EntryPoint = "Factorial", CallingConvention = CallingConvention.StdCall)]
        public static extern double Factorial(int n);
    }
}
