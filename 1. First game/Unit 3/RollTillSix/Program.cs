using System;

namespace RollTillSix
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            int diceRoll;
            int sum = 0;
            do
            {
                
                diceRoll = random.Next(1, 7);
                sum += diceRoll;
                
                
                Console.WriteLine($"The player rolls: {diceRoll}");

                
                

            } while (diceRoll <= 5);
            Console.WriteLine($"Total score: {sum}");
        }
    }
}
