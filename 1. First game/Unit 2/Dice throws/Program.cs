using System;

namespace Dice_throws
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            int diceThrow1 = random.Next(1, 7);
            int diceThrow2 = random.Next(1, 7);
            int diceThrow3 = random.Next(1, 7);
            Console.WriteLine($"First dice throw is {diceThrow1}");
            Console.WriteLine($"Second dice throw is {diceThrow2}");
            Console.WriteLine($"Third dice throw is {diceThrow3}");
        }
    }
}
