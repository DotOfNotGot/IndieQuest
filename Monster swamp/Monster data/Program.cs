using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;
namespace Monster_data
{
    class Program
    {

        static void Main(string[] args)
        {
            string filePath = "MonsterManual.txt";
            string titleFilePath = "Title.txt";

            string[] titleLines = File.ReadAllLines(titleFilePath);

            var monsters = new List<MonsterEntry>();
            
            string[] dataLines = File.ReadAllLines(filePath);
            int monsterLineIndex = 0;
            string currentMonsterName = "";
            string findArmorClassAndType = @"Armor\sClass:\s(\d+)\s(\((.+)\))?";
            string findMonsterDescriptionAndAlignment = @"^(.*), ([^,]\D*?)$";
            string findHP = @"\b(\d+)?d(\d+)([+-]\d+)?\b";
            string monsterDescription = "";
            string monsterAlignment = "";
            string hitPointsDefault = "";
            string hitPointsRoll = "";
            int armorClass = 0;
            string armorType = "";
            string speed = "";
            string challengeRating = "";
            string xp = "";



            foreach (string dataLine in dataLines)
            {
                if (monsterLineIndex == 0)
                {
                    currentMonsterName = dataLine;
                }

                Match result = Regex.Match(dataLine, findMonsterDescriptionAndAlignment);
                if (result.Success)
                {
                    monsterDescription = result.Groups[1].Value;
                    monsterAlignment = result.Groups[2].Value;
                }

                result = Regex.Match(dataLine, findHP);
                if (result.Success)
                {
                    hitPointsRoll = result.Value;
                }
                result = Regex.Match(dataLine, findArmorClassAndType);
                if (result.Success)
                {
                    armorClass = Convert.ToInt32(result.Groups[1].Value);
                    armorType = result.Groups[3].Value;
                }

                monsterLineIndex++;
                if (dataLine == "")
                {
                    var monster = new MonsterEntry
                    {
                        Name = currentMonsterName,
                        Description = monsterDescription,
                        Alignment = monsterAlignment,
                        HitPoints = hitPointsRoll,
                        Armor = new ArmorInformation {Class = armorClass, Type = armorType}
                    };
                    monsters.Add(monster);
                    monsterLineIndex = 0;
                }
            }

            foreach (string titleLine in titleLines)
            {
                Console.WriteLine(titleLine);
            }

            Console.WriteLine("Do you want to search by (n)ame or (a)rmor type?");
            string searchChoice = Console.ReadLine();
            if (searchChoice == "n")
            {
                Console.WriteLine();
                Console.WriteLine("Enter a query to seach for monsters by name or RegEx: ");
                string search = Console.ReadLine();
                var results = new List<MonsterEntry>();
                for (int monsterIndex = 0; monsterIndex < monsters.Count; monsterIndex++)
                {
                    Match monsterSearch = Regex.Match(monsters[monsterIndex].Name, search, RegexOptions.IgnoreCase);
                    if (monsterSearch.Success)
                    {
                        results.Add(monsters[monsterIndex]);
                    }
                }

                if (results.Count == 1)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Name: {results[0].Name}");
                    Console.WriteLine($"Description: {results[0].Description}");
                    Console.WriteLine($"Alignment: {results[0].Alignment}");
                    Console.WriteLine($"HP: {results[0].HitPoints}");
                    Console.WriteLine($"Armor class: {results[0].Armor.Class}");
                    if (results[0].Armor.Type != "")
                    {
                        Console.WriteLine($"Armor type: {results[0].Armor.Type}");
                    }

                }
                else
                {

                    for (int i = 0; i < results.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {results[i].Name}");
                    }
                    int indexChoice = Convert.ToInt32(Console.ReadLine());
                    if (indexChoice <= -1)
                    {
                        Console.WriteLine("That is not a valid input choice");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Name: {results[indexChoice - 1].Name}");
                        Console.WriteLine($"Description: {results[indexChoice - 1].Description}");
                        Console.WriteLine($"Alignment: {results[indexChoice - 1].Alignment}");
                        Console.WriteLine($"HP: {results[indexChoice - 1].HitPoints}");
                        Console.WriteLine($"Armor class: {results[indexChoice - 1].Armor.Class}");
                        if (results[indexChoice - 1].Armor.Type != "")
                        {
                            Console.WriteLine($"Armor type: {results[indexChoice - 1].Armor.Type}");
                        }

                    }
                }
            }
            else if (searchChoice == "a")
            {
                Console.WriteLine();
                Console.WriteLine("Which armor type do you want to display?");
               
            }
            
            

        }
    }

    class MonsterEntry
    {
        public string Name;
        public string Description;
        public string Alignment;
        public string HitPoints;
        public ArmorInformation Armor;        
    }
    class ArmorInformation
    {
        public int Class;
        public string Type;
    }

}
