using System;
using System.Collections.Generic;
namespace Olympic_games_quiz
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            IDictionary<int, string> hostCountries = new Dictionary<int, string>();
            hostCountries[2000] = "Australia";
            hostCountries[2002] = "USA";
            hostCountries[2004] = "Greece";
            hostCountries[2006] = "Italy";
            hostCountries[2008] = "China";
            hostCountries[2010] = "Canada";
            hostCountries[2012] = "United Kingdom";
            hostCountries[2014] = "Russia";
            hostCountries[2016] = "Brazil";
            hostCountries[2018] = "South Korea";
            hostCountries[2020] = "Japan";


            int summerWinter = random.Next(2);
            if (summerWinter == 0)
            {
                int yearSummer = 2000 + random.Next(6) * 4;
                Console.WriteLine($"Who hosted the Summer Olympic Games in {yearSummer}?");
                string country = Console.ReadLine();
                if (country == hostCountries[yearSummer])
                {
                    Console.WriteLine();
                    Console.WriteLine("Correct!");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"Incorrect. It was {hostCountries[yearSummer]}");
                }
            }
            else
            {
                int yearWinter = 2000 + random.Next(6) * 4 - 2;
                if (yearWinter < 2000)
                {
                    yearWinter += 4;
                }
                Console.WriteLine($"Who hosted the Winter Olympic Games in {yearWinter}?");
                string country = Console.ReadLine();
                if (country == hostCountries[yearWinter])
                {
                    Console.WriteLine();
                    Console.WriteLine("Correct!");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"Incorrect. It was {hostCountries[yearWinter]}");
                }
            }
            
            
            
        }
    }
}
