using System;
using System.Collections.Generic;
namespace Country_capitals_quiz
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            SortedList<string, string> capitals = new SortedList<string, string>();
            capitals["Sweden"] = "Stockholm";
            capitals["Norway"] = "Oslo";
            capitals["Denmark"] = "Copenhagen";
            capitals["Russia"] = "Moscow";
           
            int randomCountry = random.Next(capitals.Keys.Count);
            Console.WriteLine($"What is the capital of {capitals.Keys[randomCountry]}?");
            Console.WriteLine();
            string answer = Console.ReadLine();

            if (answer == capitals.Values[randomCountry])
            {
                Console.WriteLine();
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"Incorrect. It is {capitals.Values[randomCountry]}.");
            }
        }
    }
}
