using System;
using System.IO;
using System.Text.RegularExpressions;
namespace Monster_names
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "MonsterManual.txt";


            string[] dataLines = File.ReadAllLines(filePath);
            bool isFirstMonsterLine = true;
            Console.WriteLine("Monsters in the manual are:");
            string currentMonsterName = "";
            foreach (string dataLine in dataLines)
            {
                if (isFirstMonsterLine)
                {
                    currentMonsterName = dataLine;
                }

                isFirstMonsterLine = dataLine == "";

                if (Regex.IsMatch(dataLine, "^Speed"))
                {
                    Console.Write($"{currentMonsterName} - Can fly: ");

                    Console.WriteLine(Regex.IsMatch(dataLine, "fly"));
                    
                    if (Regex.IsMatch(dataLine, @"y [1-4]\d "))
                    {
                        Console.WriteLine(currentMonsterName);
                    }
                    Console.WriteLine();
                }
                if (Regex.IsMatch(dataLine, "^Hit"))
                {
                    Console.Write($"{currentMonsterName} - 10+ dice rolls: ");

                    Console.WriteLine(Regex.IsMatch(dataLine, @"\(\d{2}"));

                }
            }
            Console.WriteLine("Monsters that can fly 10-40 feet per turn:");
            foreach (string dataLine in dataLines)
            {
                if (isFirstMonsterLine)
                {
                    currentMonsterName = dataLine;
                }

                isFirstMonsterLine = dataLine == "";

                if (Regex.IsMatch(dataLine, "^Speed"))
                {
                    
                    if (Regex.IsMatch(dataLine, @"y [1-4]\d "))
                    {
                        Console.WriteLine(currentMonsterName);
                    }
                }
            }

        }
    }
}
