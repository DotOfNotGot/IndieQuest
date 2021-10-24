using System;
using System.IO;
namespace Remember_the_players_name
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
            }

        }
    }
}
