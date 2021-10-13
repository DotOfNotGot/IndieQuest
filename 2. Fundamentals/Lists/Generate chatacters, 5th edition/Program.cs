using System;
using System.Collections.Generic;
namespace Generate_chatacters__5th_edition
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            int d6;
            int stat;
            var abilityScores = new List<int>();
            for (int i = 0; i < 6; i++)
            {
                var rolls = new List<int>();
                
                for (int e = 0; e < 4; e++)
                {
                    d6 = random.Next(1, 7);
                    rolls.Add(d6);

                }
                Console.Write($"You roll {String.Join(", ", rolls)}.");
                rolls.Sort();
                stat = rolls[1] + rolls[2] + rolls[3];
                Console.WriteLine($" The ability score is {stat}.");
                
                abilityScores.Add(stat);
               
                
            }

            abilityScores.Sort();
            Console.WriteLine($"Your available ability scores are {String.Join(", ", abilityScores)}.");

        }
    }
}
