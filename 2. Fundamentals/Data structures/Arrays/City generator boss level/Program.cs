using System;

namespace City_generator_boss_level
{
    class Program
    {

        /*static void temp(int fuckyoiu)
        {
            roads[startX, startY] = true;
            
            int width = roads.GetLength(0);
            int height = roads.GetLength(1);


            for (int y = 0; y < height; y++)
            {
                
                if (startY == y && direction == 2)
                {


                    for (int i = 0; i < startX; i++)
                    {
                        Console.Write("#");
                    }
                    for (int x = 0; x < width; x++) 
                    {
                        if (roads[x, y])
                        {
                            Console.Write("#");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                        
                }
                else if (startY != y)
                {

                    for (int i = 0; i < width; i++)
                    {
                        Console.Write(" ");
                    }
                    
                }
                
            }
        }
        */
        static void GenerateRoad(bool[,] roads, int startX, int startY, int direction)
        {
            roads[startX, startY] = true;

            int width = roads.GetLength(0);
            int height = roads.GetLength(1);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (roads[x, y])
                    {
                        Console.Write("#");
                        if (direction == 0)
                        {
                            while (startX < width)
                            {
                                startX++;
                                Console.Write("#");
                            }
                        }
                        else if (direction == 1)
                        {
                            int rem = height - startY;
                            while (startY > 0)
                            {
                                for (int i = startY; i < height - rem; i++)
                                {
                                    startY--;
                                    int newY = startY;

                                    if (startY == newY - 1)
                                    {
                                        Console.Write("#");
                                    }
                                    else
                                    {
                                        Console.Write(" ");
                                    }
                                }

                                
                            }
                        }
                        else if (direction == 2)
                        {
                            Console.Write("#");
                            for (int i = 0; i < startX; i++)
                            {
                                Console.Write("#");
                            }
                        }

                        break;
                    }
                    else
                    {
                        Console.Write(" ");
                    }

                }
                Console.WriteLine();
            }
            
            
            


            



        }
        static void Main(string[] args)
        {
            var random = new Random();
            int width = 80;
            int height = 20;
            var roads = new bool [width, height];
            int startX = random.Next(width);
            int startY = random.Next(height);
            int direction = 1;


            GenerateRoad(roads, startX, startY, direction);

            
        }
    }
}
