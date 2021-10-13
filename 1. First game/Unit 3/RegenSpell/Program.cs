using System;

namespace RegenSpell
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
          
            int warriorHP = random.Next(1, 101);
            Console.WriteLine($"Warrior HP: {warriorHP}");
            Console.WriteLine("The regenerate spell is cast!");
            while (warriorHP < 50)
            {
                warriorHP += 10;
                Console.WriteLine(warriorHP);
            }
            Console.WriteLine("The Regenerate spell is complete");
        }
    }
}
