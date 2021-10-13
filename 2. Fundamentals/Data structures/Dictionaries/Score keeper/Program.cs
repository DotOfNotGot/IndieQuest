using System;
using System.Collections.Generic;
namespace Score_keeper
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList<string, int> scoreKeep = new SortedList<string, int>();

            while (true)
            {
                Console.Write("Who won this round? ");

                string winner = Console.ReadLine();

                if (scoreKeep.ContainsKey(winner))
                {
                    int score = scoreKeep[winner] + 1;
                    scoreKeep[winner] = score;
                }
                else
                {
                    scoreKeep.Add(winner, 1);
                }
                var names = new List<string>(scoreKeep.Keys);
                names.Sort((name1, name2) => scoreKeep[name2].CompareTo(scoreKeep[name1]));
                
                foreach (string name in names)
                {
                    int score = scoreKeep[name];
                    Console.WriteLine($"{name} {score}");
                    
                }
            }
            
        }
    }
}
