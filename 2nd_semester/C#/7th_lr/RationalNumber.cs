using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Text.RegularExpressions;

namespace _7th_LR
{
    class RationalNumber : IComparable<RationalNumber>, IEquatable<RationalNumber>
    {
        private int integer;
        private int natural;

        public int Integer
        {
            get => integer;
            set
            {
                if (value > 0)
                {
                    integer = value;
                }
            }
        }

        public int Natural
        {
            get
            {
                return natural;
            }
            set 
            {
                if(value > 0)
                {
                    natural = value;
                }
                else if(value<0)
                {
                    natural = -value;
                }
                else
                {
                    Console.WriteLine("Знаменатель не может быть равен нулю!");
                    natural = 1;
                }
            }
        }



        public RationalNumber(int numerator, int denominator)
        {
            Integer = numerator;
            Natural = denominator;
        }

        //Overloading mathematical operators:
        public static RationalNumber operator +(RationalNumber number1, RationalNumber number2)
        {
            if (number1.natural == number2.natural)
                return new RationalNumber(number1.Integer + number2.Integer, number1.natural);
            else
                return new RationalNumber((number1.Integer * number2.natural) + (number2.Integer * number1.natural), number1.natural * number2.natural);
        }

        public static RationalNumber operator -(RationalNumber number1, RationalNumber number2)
        {
            if (number1.natural == number2.natural)
                return new RationalNumber(number1.Integer - number2.Integer, number1.natural);
            else
                return new RationalNumber((number1.Integer * number2.natural) - (number2.Integer * number1.natural), number1.natural * number2.natural);
        }

        public static RationalNumber operator *(RationalNumber number1, RationalNumber number2)
        {
            return new RationalNumber(number1.Integer * number2.Integer, number1.natural * number2.natural);
        }

        public static RationalNumber operator /(RationalNumber number1, RationalNumber number2)
        {
            return new RationalNumber(number1.Integer * number2.natural, number1.natural * number2.Integer);
        }

        public static RationalNumber operator +(RationalNumber number1, int integer)
        {
            RationalNumber number2 = new RationalNumber(integer, 1);
            return number1 + number2;
        }

        public static RationalNumber operator -(RationalNumber number1, int integer)
        {
            RationalNumber number2 = new RationalNumber(integer, 1);
            return number1 - number2;
        }

        public static RationalNumber operator *(RationalNumber number1, int integer)
        {
            RationalNumber number2 = new RationalNumber(integer, 1);
            return number1 * number2;
        }

        public static RationalNumber operator /(RationalNumber number1, int integer)
        {
            RationalNumber number2 = new RationalNumber(integer, 1);
            return number1 / number2;
        }

        //Overloading comparison operators:
        public static bool operator >(RationalNumber number1, RationalNumber number2)
        {
            if (number1.Integer == number2.Integer && number1.natural == number2.natural)
                return false;
            else if (number1.natural == number2.natural && number1.Integer > number2.Integer)
                return true;
            else if (number1.Integer == number2.Integer && number1.natural < number2.natural)
                return true;
            else if (number1.Integer != number2.Integer && number1.natural != number2.natural)
            {
                RationalNumber resultOne = new RationalNumber(number1.Integer * number2.natural, number1.natural * number2.natural);
                RationalNumber resultTwo = new RationalNumber(number2.Integer * number1.natural, number1.natural * number2.natural);
                if (resultOne.Integer > resultTwo.Integer)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public static bool operator <(RationalNumber number1, RationalNumber number2)
        {
            if (number1.Integer == number2.Integer && number1.natural == number2.natural)
                return false;
            else if (number1.natural == number2.natural && number1.Integer < number2.Integer)
                return true;
            else if (number1.Integer == number2.Integer && number1.natural > number2.natural)
                return true;
            else if (number1.Integer != number2.Integer && number1.natural != number2.natural)
            {
                RationalNumber resultOne = new RationalNumber(number1.Integer * number2.natural, number1.natural * number2.natural);
                RationalNumber resultTwo = new RationalNumber(number2.Integer * number1.natural, number1.natural * number2.natural);
                if (resultOne.Integer < resultTwo.Integer)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public static bool operator ==(RationalNumber n1, RationalNumber n2)
        {
            if (n1.Equals(n2))
                return true;
            else
                return false;
        }

        public static bool operator !=(RationalNumber n1, RationalNumber n2)
        {
            if (n1.Equals(n2))
                return false;
            else
                return true;
        }

        //Methods:
        public int CompareTo(RationalNumber other)
        {
            if (other is RationalNumber)
            {
                double r1 = Integer / (double)natural;
                double r2 = other.Integer / (double)other.natural; 
                return r1.CompareTo(r2);
            }
            else
            {
                throw new ArgumentException("Unable to compare objects!");
            }
        }

        public bool Equals(RationalNumber other)
        {
            if (other is RationalNumber)
            {
                double r1 = this.Integer / (double)this.natural;
                double r2 = other.Integer / (double)other.natural;
                return r1.Equals(r2);
            }
            else
            {
                throw new ArgumentException("Unable to compare objects!");
            }
        }

        public static RationalNumber Create(string str)
        {
            int numerator;
            int denominator;
            string[] s = str.Split('/');
            if (s.Length == 2 && Int32.TryParse(s[0], out numerator) && Int32.TryParse(s[1], out denominator))
            {
                return new RationalNumber(numerator, denominator);
            }
            else
            {
                return null;
            }
        }

        public override string ToString()
        {
            return $"{Integer}/{natural}";
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        //Overloading type conversion operations:
        public static implicit operator RationalNumber(string str)
        {
            return RationalNumber.Create(str);
        }

        public static implicit operator string(RationalNumber number)
        {
            return number.ToString();
        }

        public static explicit operator double(RationalNumber number)
        {
            return number.Integer / (double)number.natural;
        }
    }

}
