using System;
using System.Collections.Generic;
namespace Methods_practice
{
    class Program
    {

        static int Add(int x, int y)
        {
            return x + y;
        }

        static int SafeDivision(int dividend, int divisor)
        {

            if (divisor == 0)
            {
                return dividend;
            }
            else
            {
                return dividend / divisor;
            }

        }

        static double AreaOfCircle(double radius)
        {
            return Math.PI * radius * radius;
        }

        static int MaximumInteger(int a, int b)
        {
            int biggest;
            
            if (a > b)
            {
                biggest = a;
            }
            else
            {
                biggest = b;
            }
            return biggest;
        }

        
            
        static void Main(string[] args)
        {
            //Console.WriteLine(Add(5, 5));
            //Console.WriteLine(SafeDivision(10, 2));
            //Console.WriteLine(AreaOfCircle(5));
            //Console.WriteLine(MaximumInteger(10, 4));
            
        }
    }
}
