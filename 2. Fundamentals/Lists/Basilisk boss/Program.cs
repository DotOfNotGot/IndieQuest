using System;
using System.Collections.Generic;
namespace Basilisk_boss
{
    class Program
    {
        static void Main(string[] args)
        {

            var random = new Random();
            var names = new List<string> {"Jazlyn", "Theron", "Dayana", "Rolando" };
            Console.WriteLine($"A party of warriors ({names[0]}, {names[1]}, {names[2]}, {names[3]}) descends into the dungeon.");
            Console.WriteLine();

            int sum = 0;
            int diceRoll;
            
            for (int i = 0; i < 8; i++)
            {
                diceRoll = random.Next(1, 9);
                
                sum += diceRoll;
                
                
            }
            int basiliskHP = sum + 16;            
            Console.WriteLine($"A basilisk with {basiliskHP} appears!");
            Console.WriteLine();
            int damage = 0;


            while (basiliskHP > 0)
            {
                if (names.Count == 0)
                {
                    Console.WriteLine("The party has failed and the basilisk continues to turn unsuspecting adventurers to stone");
                    break;
                }

                for (int i = 0; i < names.Count; i++)
                {
                    string name = names[i];

                        for (int e = 0;  e < names.Count; e++)
                        {
                            name = names[e];
                            diceRoll = random.Next(1, 5);

                            damage += diceRoll;
                            basiliskHP = basiliskHP - damage;
                            if (basiliskHP <= 0)
                            {
                                basiliskHP = 0;
                                Console.WriteLine($"{name} hits the basilisk for {damage} damage. Basilisk has {basiliskHP} hp left");
                                Console.WriteLine("The basilisk collapses and the heroes celebrate their victory!");
                                break;
                            }
                            Console.WriteLine($"{name} hits the basilisk for {damage} damage. Basilisk has {basiliskHP} hp left\n");
                            
                            damage = 0;
                        }
                    if (basiliskHP <= 0)
                    {
                        
                        break;
                    }
                    Console.WriteLine($"The basilisk uses petrifying gaze on {name}");
                        diceRoll = random.Next(1, 21);
                        if (diceRoll >= 7)
                        {
                            Console.WriteLine($"{name} rolls a {diceRoll} and is saved from the attack\n");
                        }
                        else
                        {
                            Console.WriteLine($"{name} rolls a {diceRoll} and fails to be saved. {name} is turned into stone.\n");
                            names.Remove(name);
                            
                        }
                        
                }            
            }
        }
    }
}
