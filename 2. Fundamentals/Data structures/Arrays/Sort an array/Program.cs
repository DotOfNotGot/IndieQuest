using System;

namespace Sort_an_array
{
    class Program
    {
        
        
        static void Main(string[] args)
        {
            var random = new Random();
            int[] monsters;
            monsters = new int[100];

            for (int i = 0; i < 100; i++)
            {
                monsters[i] = (random.Next(1, 51));
            }

            Array.Sort(monsters);
            Console.WriteLine($"Number of monsters in levels: {String.Join(", ", monsters)}");
        }
    }
}
