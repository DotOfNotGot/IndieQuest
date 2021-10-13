using System;
using System.Collections.Generic;
namespace Loops_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose from shapes: Line, Square, Right triangle, Parallelogram, Isosceles triangle, BlankHSquare");

            string shape = "BlankHSquare";//Console.ReadLine();
            Console.Write("Enter number for size: ");
            Console.WriteLine();
            int n = 5;//Convert.ToInt32(Console.ReadLine());


            if (shape == "Line")
            {


                for (int i = 0; i < n; i++)
                {
                    Console.Write("#");
                }
            }
            else if (shape == "Square")
            {



                for (int e = 0; e < n; e++)
                {
                    for (int i = 0; i < n; i++)
                    {
                        Console.Write("#");

                    }
                    for (int a = 0; a < 1; a++)
                    {
                        Console.WriteLine("");
                    }
                }

            }
            else if (shape == "Right triangle")
            {

                List<string> triangleParts = new List<string>();
                for (int i = 0; i < n; i++)
                {
                    triangleParts.Add("#");
                    Console.WriteLine(String.Join("", triangleParts));
                }
            }
            else if (shape == "Parallelogram")
            {

                for (int i = 0; i < n; i++)
                {


                    int spaces = n - i - 1;
                    for (int j = 0; j < spaces; j++)
                    {
                        Console.Write(" ");
                    }

                    for (int b = 0; b < n; b++)
                    {
                        Console.Write("#");
                    }
                    Console.WriteLine();


                }
            }
            else if (shape == "Isosceles triangle")
            {
                int space = 1;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n - i; j++)
                    {
                        Console.Write(" ");
                    }
                
                for (int k = 0; k < space; k++)
                {
                    Console.Write("#");

                }
                    Console.WriteLine();
                    for (int l = 0; l < 2; l++)
                {
                    space++;
                        
                }
                    
                }
            }
            else if (shape == "BlankHSquare")
            {

            }

        }
    }
}
