using System;
using System.IO;
namespace Detect_Kickstarter_backers
{
    class Program
    {
        static void Main(string[] args)
        {
            string playerNamePath = "player-name.txt";

            if (File.Exists(playerNamePath))
            {
                Console.WriteLine($"Welcome back, {File.ReadAllText(playerNamePath)}, let's continue!");
            }
            else
            {
                Console.WriteLine("Welcome to your biggest adventure yet!");
                Console.WriteLine();
                Console.WriteLine("What is your name, traveler?");
                Console.Write(">");
                File.WriteAllText("player-name.txt", Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine($"Nice to meet you, {File.ReadAllText(playerNamePath)}!");
            }
            bool isBacker = false;
            string backersPath = "backers.txt";
            string[] backers = File.ReadAllLines(backersPath);
            string playerName = File.ReadAllText(playerNamePath);
            for (int i = 0; i < backers.Length; i++)
            {
                if (playerName == backers[i])
                {
                    isBacker = true;
                    break;
                }
            }
            if (isBacker)
            {
                Console.WriteLine("You successfully enter Dr. Fred's secret laboratory and are greeted with a warm welcome for backing the game's Kickstarter!");
            }
            else
            {
                Console.WriteLine("Unfortunately I cannot let you into Dr. Fred's secret laboratory.");
            }

        }
    }
}
