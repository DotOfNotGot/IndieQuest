using System;
using System.IO;
using System.Collections.Generic;
namespace Minotaur_s_lair
{
    class Program
    {

        static int width;
        static int height;
        static char[,] map;
        static ConsoleColor[,] mapColor;
        static int playerX = 0;
        static int playerY = 0;

        static void Main(string[] args)
        {
            string mapFilePath = "MazeLevel.txt";
            List<string> lines = new List<string>(File.ReadAllLines(mapFilePath));
            string levelName = lines[0];
            string[] subs = lines[1].Split('x');
            bool win = false;
            var playerColor = ConsoleColor.Yellow;
            for (int i = 0; i < 2; i++)
            {
                lines.RemoveAt(0);
            }
            width = Convert.ToInt32(subs[0]);
            height = Convert.ToInt32(subs[1]);

            var random = new Random();
            map = new char[width, height];
            mapColor = new ConsoleColor[width, height];
            Console.WriteLine($"Get ready for: {levelName}");
            Console.WriteLine();
            Console.WriteLine("Press any key to start ...");
            Console.ReadKey();
            Console.Clear();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    map[x, y] = lines[y][x];
                    if (map[x, y] == 'S')
                    {
                        playerX = x;
                        playerY = y;
                        map[x, y] = '☺';
                    }
                    else if ((map[x, y] == ' ') && (y < 3))
                    {
                        int randomTree = random.Next(4);
                        if (randomTree == 0)
                        {
                            map[x, y] = '♠';
                        }
                    }
                    if (map[x, y] == 'M')
                    {
                        mapColor[x, y] = ConsoleColor.Red;
                    }
                    else if (map[x, y] == '☺')
                    {
                        mapColor[x, y] = ConsoleColor.Yellow;
                    }
                    else if (map[x, y] == '♠')
                    {
                        mapColor[x, y] = ConsoleColor.Green;
                    }
                    else
                    {
                        mapColor[x, y] = ConsoleColor.White;
                    }
                }

            }

            DrawMap();
            while (true)
            {
                Console.ForegroundColor = mapColor[playerX, playerY];
                var keyPress = Console.ReadKey();
                switch (keyPress.Key)
                {

                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                    case ConsoleKey.LeftArrow:

                        if (map[playerX - 1, playerY] == ' ')
                        {
                            map[playerX, playerY] = ' ';
                            Console.SetCursorPosition(playerX, playerY);
                            Console.Write(map[playerX, playerY]);
                            playerX--;
                        }
                        else if (map[playerX - 1, playerY] == 'M')
                        {
                            map[playerX, playerY] = ' ';
                            Console.SetCursorPosition(playerX, playerY);
                            Console.Write(map[playerX, playerY]);
                            playerX--;


                            win = true;
                        }
                        else
                        {
                            
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (map[playerX, playerY - 1] == ' ')
                        {
                            map[playerX, playerY] = ' ';
                            Console.SetCursorPosition(playerX, playerY);
                            Console.Write(map[playerX, playerY]);
                            playerY--;
                        }
                        else
                        {
                           
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (map[playerX + 1, playerY] == ' ')
                        {
                            map[playerX, playerY] = ' ';
                            Console.SetCursorPosition(playerX, playerY);
                            Console.Write(map[playerX, playerY]);
                            playerX++;
                        }
                        else
                        {
                            
                        }

                        break;
                    case ConsoleKey.DownArrow:
                        if (map[playerX, playerY + 1] == ' ')
                        {
                            map[playerX, playerY] = ' ';
                            Console.SetCursorPosition(playerX, playerY);
                            Console.Write(map[playerX, playerY]);

                            playerY++;
                        }
                        else
                        {
                            
                        }
                        break;
                }
                map[playerX, playerY] = '☺';
                mapColor[playerX, playerY] = playerColor;
                Console.SetCursorPosition(playerX, playerY);
                Console.Write(map[playerX, playerY]);
                Console.SetCursorPosition(0, lines.Count);
                if (win)
                {
                    Console.WriteLine("You reached the minotaur! Congratulations you won!");
                    Console.Beep();
                    Environment.Exit(0);
                }
            }

        }
        static void DrawMap()
        {
            Console.SetCursorPosition(0, 0);
            Console.Clear();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {

                    Console.ForegroundColor = mapColor[x, y];
                    Console.Write(map[x, y]);
                }
                Console.WriteLine();
            }
        }
    }
}
