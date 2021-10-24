using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;
namespace Monsters_with_alignment
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
                List<string> allignmentSplit;

                if (Regex.IsMatch(dataLine, "^(Large|Medium|Huge|Gargantuan|Tiny|Small)"))
                {
                    if (Regex.IsMatch(dataLine, "(lawful|neutral|chaotic) (good|neutral|evil)$"))
                    {
                        if (Regex.IsMatch(dataLine, @"\([a-z]+,"))
                        {
                            string[] allignment = dataLine.Split(", ");
                            allignmentSplit = new List<string>(allignment);
                            allignmentSplit.RemoveAt(0);
                        }
                        else
                        {
                            string[] allignment = dataLine.Split(", ");
                            allignmentSplit = new List<string>(allignment);
                            
                        }
                        allignmentSplit.RemoveAt(0);
                        
                        Console.WriteLine($"{currentMonsterName} ({allignmentSplit[0]})");
                    }
                }

                
            }

        }
    }
}
