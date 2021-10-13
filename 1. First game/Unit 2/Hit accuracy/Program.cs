using System;

namespace Hit_accuracy
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();

            double totalShots = random.Next(10, 21);
            double hitsMade = random.Next(0, (int)totalShots);
            double hitAcc = hitsMade / totalShots;
            double percAcc = hitAcc * 100;
            Console.WriteLine($"Total shots: {totalShots}");
            Console.WriteLine($"Hits made: {hitsMade}");
            Console.WriteLine($"Hit accuracy: {percAcc}%");
        }
    }
}
