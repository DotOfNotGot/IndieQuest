using System;

namespace Dice_score
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();

            int diceThrow1 = random.Next(1, 7);

            int diceThrow2 = random.Next(1, 7);

            int diceThrow3 = random.Next(1, 7);

            int dt3score = diceThrow3 * 3;

            int sum = diceThrow1 + diceThrow2 + dt3score;

            int result = sum * 2;

            Console.WriteLine($"You roll: {diceThrow1}, {diceThrow2}, {diceThrow3}");
            Console.WriteLine($"The total score is {result}");

        }
    }
}
