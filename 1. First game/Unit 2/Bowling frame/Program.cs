using System;

namespace Bowling_frame
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();

            int firstRoll = random.Next(0, 11);
            int secondRoll = random.Next(0, 11 - firstRoll);
            Console.WriteLine($"First roll: {firstRoll}");
            Console.WriteLine($"Second roll: {secondRoll}");
        }
    }
}
