using System;

namespace GenerateCharsAndMonsters
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();

            
            int strength = 0;
            
            


            for (int d6Counter = 0; d6Counter < 3; d6Counter++)
            {
               int diceRoll = random.Next(1, 7);
                strength += diceRoll;
            }

            Console.WriteLine($"A character with strength {strength} was created");

            int cubeHealthCalc = 0;

            for (int d10Counter = 0; d10Counter < 8; d10Counter++)
            {
                int diceRoll = random.Next(1, 11);
                cubeHealthCalc += diceRoll;
            }
            int cubeHealth = cubeHealthCalc + 40;
            Console.WriteLine($"A gelatinous cube with {cubeHealth} HP appears!");

            int cubeArmyHealth = 0;

            for (int i = 0; i < 100; i++)
            {
               cubeHealthCalc = 0;

                for (int d10Counter = 0; d10Counter < 8; d10Counter++)
                {
                    int diceRoll = random.Next(1, 11);
                    cubeHealthCalc += diceRoll;
                }
               cubeHealth = cubeHealthCalc + 40;
               cubeArmyHealth += cubeHealth;
            }
            
            Console.WriteLine($"Dear gods, an army of 100 cubes descends upon us with a total of {cubeArmyHealth} HP. We are doomed!");



        }
    }
}
