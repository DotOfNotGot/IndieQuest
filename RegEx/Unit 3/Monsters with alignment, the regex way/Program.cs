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
            int monsterLineIndex = 0;
            string currentMonsterName = "";
            var namesByAlignment = new List<string>[3, 3];
            var namesOfUnaligned = new List<string>();
            var namesOfAnyAlignment = new List<string>();
            var namesOfSpecialCases = new List<string>();
            for (int axis1 = 0; axis1 < 3; axis1++)
                for (int axis2 = 0; axis2 < 3; axis2++)
                    namesByAlignment[axis1, axis2] = new List<string>();

            foreach (string dataLine in dataLines)
            {
                
                if (monsterLineIndex == 0)
                {
                    currentMonsterName = dataLine;
                }

                if (monsterLineIndex == 1)
                {
                    Match result = Regex.Match(dataLine, @", ([^,]*)$");
                    string allignmentText = result.Groups[1].Value;
                    
                    result = Regex.Match(allignmentText, "(lawful|neutral|chaotic) (good|neutral|evil)");

                    if (result.Success)
                    {
                        string axis1 = result.Groups[1].Value;
                        string axis2 = result.Groups[2].Value;
                        int axis1Index = 0;
                        int axis2Index = 0;
                        switch (axis1)
                        {
                            case "lawful":
                                axis1Index = 0;
                                break;
                            case "neutral":
                                axis1Index = 1;
                                break;
                            case "chaotic":
                                axis1Index = 2;
                                break;
                        }
                        switch (axis2)
                        {
                            case "good":
                                axis2Index = 0;
                                break;
                            case "neutral":
                                axis2Index = 1;
                                break;
                            case "evil":
                                axis2Index = 2;
                                break;
                        }
                        namesByAlignment[axis1Index, axis2Index].Add(currentMonsterName);
                    }
                    else if (allignmentText == "unaligned")
                    {
                        namesOfUnaligned.Add(currentMonsterName);
                    }
                    else if (allignmentText == "any alignment")
                    {
                        namesOfAnyAlignment.Add(currentMonsterName);
                    }
                    else if (allignmentText == "neutral")
                    {
                        namesByAlignment[1, 1].Add(currentMonsterName);
                    }
                    else
                    {
                        namesOfSpecialCases.Add(currentMonsterName);
                    }
                }
                monsterLineIndex++;
                if (dataLine == "")
                {
                    monsterLineIndex = 0;
                }
                
            }

            OutputMonsters("Monsters with alignment lawful good are:", namesByAlignment[0, 0]);
            OutputMonsters("Monsters with alignment lawful neutral are:", namesByAlignment[0, 1]);
            OutputMonsters("Monsters with alignment lawful evil are:", namesByAlignment[0, 2]);
            OutputMonsters("Monsters with alignment neutral good are:", namesByAlignment[1, 0]);
            OutputMonsters("Monsters with alignment true neutral are:", namesByAlignment[1, 1]);
            OutputMonsters("Monsters with alignment neutral evil are:", namesByAlignment[1, 2]);
            OutputMonsters("Monsters with alignment chaotic good are:", namesByAlignment[2, 0]);
            OutputMonsters("Monsters with alignment chaotic neutral are:", namesByAlignment[2, 1]);
            OutputMonsters("Monsters with alignment chaotic evil are:", namesByAlignment[2, 2]);
            OutputMonsters("Unaligned monsters are:", namesOfUnaligned);
            OutputMonsters("Monsters which can be of any alignment are:", namesOfAnyAlignment);
            OutputMonsters("Monsters with special cases are:", namesOfSpecialCases);
        }
        static void OutputMonsters(string description, List<string> monsters)
        {
            Console.WriteLine(description);
            
            foreach (string monster in monsters)
            {
                Console.WriteLine(monster);
            }
            Console.WriteLine();
        }
    }
}
