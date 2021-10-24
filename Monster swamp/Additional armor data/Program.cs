using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;
namespace Monster_data
{
    class Program
    {
        static Dictionary<ArmorType, ArmorTypeEntry> armorTypeEntries = new Dictionary<ArmorType, ArmorTypeEntry>();
        static void MonsterWrite(List<MonsterEntry> results, int indexChoice)
        {

            MonsterEntry monster = results[indexChoice - 1];

            Console.WriteLine();
            Console.WriteLine($"Name: {monster.Name}");
            Console.WriteLine($"Description: {monster.Description}");
            Console.WriteLine($"Alignment: {monster.Alignment}");
            Console.WriteLine($"HP: {monster.HitPoints}");
            Console.WriteLine($"Armor class: {monster.Armor.Class}");
            if (monster.Armor.Type == ArmorType.Other)
            {
                Console.WriteLine($"Armor type: {monster.Armor.Name}");
            }
            else if (monster.Armor.Type != ArmorType.Unspecified)
            {
                ArmorTypeEntry armor = armorTypeEntries[monster.Armor.Type];
                Console.WriteLine($"Armor type: {armor.Name}");
                Console.WriteLine($"Armor category: {armor.Category}");
                Console.WriteLine($"Armor weight: {armor.Weight} lb.");
            }
        }
        static void Main(string[] args)
        {
            //Read title data.
            string titleFilePath = "Title.txt";
            string[] titleLines = File.ReadAllLines(titleFilePath);

            //Read armor data.
            string armorTypesFilePath = "ArmorTypes.txt";
            
            string[] armorTypesLines = File.ReadAllLines(armorTypesFilePath);

            foreach  (string armorTypesLine in armorTypesLines)
            {
                string[] splitLines = armorTypesLine.Split(",");

                ArmorType type = Enum.Parse<ArmorType>(splitLines[0]);

                armorTypeEntries[type] = new ArmorTypeEntry
                {
                    Name = splitLines[1],
                    Category = Enum.Parse<ArmorCategory>(splitLines[2]),
                    Weight = Convert.ToInt32(splitLines[3])
                };
            }

            //Read monster data.
            string monsterFilePath = "MonsterManual.txt";
            string[] monsterLines = File.ReadAllLines(monsterFilePath);
            var monsters = new List<MonsterEntry>();

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
            ArmorType armorType = ArmorType.Unspecified;
            string armorName = "";
            string speed = "";
            string challengeRating = "";
            string xp = "";



            foreach (string monsterLine in monsterLines)
            {
                if (monsterLineIndex == 0)
                {
                    currentMonsterName = monsterLine;
                }

                Match result = Regex.Match(monsterLine, findMonsterDescriptionAndAlignment);
                if (result.Success)
                {
                    monsterDescription = result.Groups[1].Value;
                    monsterAlignment = result.Groups[2].Value;
                }

                result = Regex.Match(monsterLine, findHP);
                if (result.Success)
                {
                    hitPointsRoll = result.Value;
                }
                result = Regex.Match(monsterLine, findArmorClassAndType);

                if (result.Success)
                {
                    string armorTypeText = result.Groups[3].Value.ToLowerInvariant();
                    if (armorTypeText == "")
                    {
                        armorType = ArmorType.Unspecified;
                    }
                    else if (armorTypeText.Contains("natural"))
                    {
                        armorType = ArmorType.Natural;
                    }
                    else if (armorTypeText.Contains("leather armor"))
                    {
                        armorType = ArmorType.Leather;
                    }
                    else if (armorTypeText.Contains("studded"))
                    {
                        armorType = ArmorType.StuddedLeather;
                    }
                    else if (armorTypeText.Contains("hide"))
                    {
                        armorType = ArmorType.Hide;
                    }
                    else if (armorTypeText.Contains("chain shirt"))
                    {
                        armorType = ArmorType.ChainShirt;
                    }
                    else if (armorTypeText.Contains("chain mail"))
                    {
                        armorType = ArmorType.ChainMail;
                    }
                    else if (armorTypeText.Contains("scale mail"))
                    {
                        armorType = ArmorType.ScaleMail;
                    }
                    else if (armorTypeText.Contains("plate"))
                    {
                        armorType = ArmorType.Plate;
                    }
                    else
                    {
                        armorType = ArmorType.Other;
                        
                    }
                    armorClass = Convert.ToInt32(result.Groups[1].Value);
                    armorName = result.Groups[3].Value;
                }

                monsterLineIndex++;
                if (monsterLine == "")
                {
                    var monster = new MonsterEntry
                    {
                        Name = currentMonsterName,
                        Description = monsterDescription,
                        Alignment = monsterAlignment,
                        HitPoints = hitPointsRoll,
                        Armor = new ArmorInformation { Class = armorClass, Type = armorType, Name = armorName }
                    };
                    monsters.Add(monster);
                    monsterLineIndex = 0;
                }
            }

            foreach (string titleLine in titleLines)
            {
                Console.WriteLine(titleLine);
            }
            string[] armorTypeNames = Enum.GetNames(typeof(ArmorType));
            ArmorType[] armorTypeValues = (ArmorType[])Enum.GetValues(typeof(ArmorType));
            //Choosing what to search by.
            Console.WriteLine("Do you want to search by (n)ame or (a)rmor type?");
            string searchChoice = Console.ReadLine();
            //Searching by name.
            if (searchChoice == "n")
            {
                Console.WriteLine();
                Console.WriteLine("Enter a query to seach for monsters by name or RegEx: ");
                string search = Console.ReadLine();
                var results = new List<MonsterEntry>();
                //Scroll through every monster in the manual and compare their name to the search query. If it matches then add it to the list.
                for (int monsterIndex = 0; monsterIndex < monsters.Count; monsterIndex++)
                {
                    Match monsterSearch = Regex.Match(monsters[monsterIndex].Name, search, RegexOptions.IgnoreCase);
                    if (monsterSearch.Success)
                    {
                        results.Add(monsters[monsterIndex]);
                    }
                }
                ChooseBetweenResults(results);
            }
            //Search by armor type.
            else if (searchChoice == "a")
            {
                Console.WriteLine();
                Console.WriteLine("Which armor type do you want to display?");
                for (int i = 0; i < armorTypeNames.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {armorTypeNames[i]}");
                }
                int armorIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                var results = new List<MonsterEntry>();
                foreach (MonsterEntry monster in monsters)
                {
                    if (monster.Armor.Type == armorTypeValues[armorIndex])
                    {
                        results.Add(monster);
                    }
                }

                ChooseBetweenResults(results);
            }
        }

        private static void ChooseBetweenResults(List<MonsterEntry> results)
        {
            //If there is only one result then skip the list indexing choice.
            if (results.Count == 1)
            {
                MonsterWrite(results, 0);
            }
            //If there are more than 1 monster match then display a list where you can choose by index.
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
                    MonsterWrite(results, indexChoice);

                }
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
        public ArmorType Type;
        § string Name;
    }
    enum ArmorType
    {
        Unspecified,
        Natural,
        Leather,
        StuddedLeather,
        Hide,
        ChainShirt,
        ChainMail,
        ScaleMail,
        Plate,
        Other
    }
    enum ArmorCategory
    {
        Light,
        Medium,
        Heavy
    }


    class ArmorTypeEntry
    {
        public string Name;
        public ArmorCategory Category;
        public int Weight;
    }


}
