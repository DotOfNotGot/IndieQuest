using System;

namespace Seasons
{
    class Program
    {
        static string OrdinalNumber(int number)
        {

            int numberMod = number % 10;
            int numberDiv = number / 10;
            int numberDivMod = numberDiv % 10;
            if (numberDivMod == 1)
            {
                return number + "th";
            }
            else if (numberMod == 1)
            {
                return number + "st";
            }
            else if (numberMod == 2)
            {
                return number + "nd";
            }
            else if (numberMod == 3)
            {
                return number + "rd";
            }
            else
            {
                return number + "th";
            }
        }
        static string CreateDayDescription(int day, int season, int year)
        {
            string[] Seasons = { "Spring", "Summer", "Autumn", "Winter" };
            return $"{OrdinalNumber(day)} day of {Seasons[season]} in the year {year}";
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine(CreateDayDescription(3, 0, 1601)); 
        }
    }
}
