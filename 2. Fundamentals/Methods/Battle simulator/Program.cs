using System;
using System.Collections.Generic;
namespace Battle_simulator
{

    class Program
    {



        static int DiceRoll(int numberOfRolls, int diceSides, int fixedBonus = 0)
        {
            var random = new Random();
            int diceSum = fixedBonus;
            
            for (int i = 0; i < numberOfRolls; i++)
            {
                int diceThrow = random.Next(1, diceSides + 1);
                diceSum += diceThrow;
                
            }

            return diceSum;
        }




        static void SimulateBattle(List<string> heroes, string monster, int monsterHP, int savingThrowDC)
        {

            var random = new Random();



            Console.WriteLine($"A {monster} with {monsterHP} hp appears!");
            Console.WriteLine();

            while (monsterHP > 0)
            {
                if (heroes.Count == 0)
                {
                    Console.WriteLine($"The party has failed and the {monster} continues to attack unsuspecting adventurers.");
                    break;
                }

                for (int i = 0; i < heroes.Count; i++)
                {
                    string name = heroes[i];

                    for (int e = 0; e < heroes.Count; e++)
                    {
                        name = heroes[e];


                        int damage = DiceRoll(2, 6);
                        monsterHP = monsterHP - damage;
                        if (monsterHP <= 0)
                        {
                            monsterHP = 0;
                            Console.WriteLine($"{name} hits the {monster} for {damage} damage. {monster} has {monsterHP} hp left");
                            Console.WriteLine($"The {monster} collapses and the heroes celebrate their victory!\n");
                            break;
                        }
                        Console.WriteLine($"{name} hits the {monster} for {damage} damage. {monster} has {monsterHP} hp left.\n");


                    }
                    if (monsterHP <= 0)
                    {

                        break;
                    }
                    Console.WriteLine($"The {monster} attacks {name}!");
                    int diceRoll = DiceRoll(1, 20);
                    if (diceRoll >= savingThrowDC)
                    {
                        Console.WriteLine($"{name} rolls a {diceRoll} and is saved from the attack.\n");
                    }
                    else
                    {
                        Console.WriteLine($"{name} rolls a {diceRoll} and fails to be saved. {name} is killed.\n");
                        heroes.Remove(name);

                    }

                }
            }

        }


        static void Main(string[] args)
        {


            var heroes = new List<string> { "Jazlyn", "Theron", "Dayana", "Rolando" };



            Console.WriteLine($"A party of warriors ({heroes[0]}, {heroes[1]}, {heroes[2]}, {heroes[3]}) descends into the dungeon.");
            Console.WriteLine();
            
            
            SimulateBattle(heroes, "orc", DiceRoll(2, 8, 6), 7);
            if (heroes.Count > 0)
            {
                
                SimulateBattle(heroes, "mage", DiceRoll(9, 8), 15);
            }
            if (heroes.Count > 0)
            {
                
                SimulateBattle(heroes, "troll", DiceRoll(8, 10, 40), 13);
            }
            if (heroes.Count > 0 && heroes.Count < 4)
            {
                Console.WriteLine($"After three grueling battles, {string.Join(", ", heroes)} returns from the dungeons. Unfortunately, none of the other party members survived.");
            }
            if (heroes.Count == 4)
            {
                Console.WriteLine($"After three grueling battles, { string.Join(", ", heroes)} returns from the dungeons. Fortunately, all the party members survived!");

            }

        }
    }
}
