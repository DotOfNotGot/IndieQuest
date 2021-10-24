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

                }
            }

        }
    }
}
