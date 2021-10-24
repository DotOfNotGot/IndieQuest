using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;
namespace Monster_data
{
    class Program
    {

        static void MonsterWrite(List<MonsterEntry> results, int indexChoice)
        {
            Console.WriteLine();
            Console.WriteLine($"Name: {results[indexChoice - 1].Name}");
            Console.WriteLine($"Description: {results[indexChoice - 1].Description}");
            Console.WriteLine($"Alignment: {results[indexChoice - 1].Alignment}");
            Console.WriteLine($"HP: {results[indexChoice - 1].HitPoints}");
            Console.WriteLine($"Armor class: {results[indexChoice - 1].Armor.Class}");
            if (results[indexChoice - 1].Armor.Type != ArmorType.Unspecified)
            {
                Console.WriteLine($"Armor type: {results[indexChoice - 1].Armor.Type}");
            }
        }


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
            ArmorType armorType = ArmorType.Unspecified;
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
                        Armor = new ArmorInformation { Class = armorClass, Type = armorType }
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
                    Console.WriteLine($"{i+1}. {armorTypeNames[i]}");
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

}
