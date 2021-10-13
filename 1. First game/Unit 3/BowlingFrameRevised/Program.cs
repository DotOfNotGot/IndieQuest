using System;

namespace BowlingFrameRevised
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            int firstBowl = random.Next(0, 11);
            int pins = 10 - firstBowl;
            int secondBowl = random.Next(0, pins + 1);
            int spareCheck = pins - secondBowl;
            int knockedPins = firstBowl + secondBowl;
            
            if(firstBowl == 10)    
            {
                Console.WriteLine("First roll: X");
                
            }
           else if (firstBowl == 0)
            {
                
                Console.WriteLine("First roll: -");
                   
            }
            else
            {
                Console.WriteLine($"First roll: {firstBowl}");
            }

            if (firstBowl == 10)
            {
                //This is meant to be empty
            }
            else if (secondBowl == 0)
            {
                Console.WriteLine("Second roll: -");
            }
            else if (spareCheck == 0)
            {
                Console.WriteLine("Second roll: /");
            }
            else 
            {
                Console.WriteLine($"Second roll: {secondBowl}");
            }

            Console.WriteLine($"Knocked pins: {knockedPins}");
        }
    }
}
