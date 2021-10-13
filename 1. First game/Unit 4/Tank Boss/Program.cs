using System;

namespace Tank_Boss
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            int tankDistance = random.Next(40, 71);


            Console.WriteLine("DANGER! A tank is approaching our position. Your artilery unit is our only hope!");
            Console.WriteLine("\nWhat is your name, commander?");
            
            Console.Write("\nEnter name: " );
            string playerName = Console.ReadLine();
            Console.Clear();






            int Shot;




            bool miss;
           do
            {
                Console.WriteLine("\nHere is the map of the battlefield:");
                Console.Write("\n_/");
                for (int i = 0; i < 78; i++)
                {
                    if (tankDistance == i)
                    {
                        Console.Write("T");
                    }
                    else
                    {
                        Console.Write("_");
                    }
                }


                int tankMove = random.Next(1, 16);
                Console.WriteLine($"\nAim your shot, " + playerName);
                Console.Write("Enter distance: ");
                Shot = Convert.ToInt32(Console.ReadLine());
                
                
                for (int i = 0; i < 78; i++)
                {
                    if (Shot == i)
                    {
                        Console.Write("  *");
                    }
                    else
                    {
                        Console.Write(" ");
                    }

                }
                
                if (tankDistance == Shot)
                {
                    Console.WriteLine("\nBOOM! Your aim is legendary and the tank is destroyed");
                    miss = false;
                }
                else if (tankDistance < Shot)
                {
                    Console.WriteLine("\nAlas, the shell flies past the tank.");
                    miss = true;
                }
                else
                {
                    Console.WriteLine("\nOh no, your shot was too short.");
                    miss = true;
                }
                if (miss)
                {
                    
                    Console.WriteLine("The tank advances!");
                    tankDistance = tankDistance - tankMove;
                    Console.WriteLine("Press enter to see the new battlefield.");
                }

                Console.ReadKey();
                Console.Clear();

                if (tankDistance <= 0)
                {
                    Console.WriteLine("You suck.");
                }
            } while (tankDistance > 0 && miss);

        }
}
}
