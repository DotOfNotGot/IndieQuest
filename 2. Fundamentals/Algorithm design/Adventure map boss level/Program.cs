using System;

namespace Algorithm_boss_Adventure_map
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 100;
            int height = 50;

            //Generates and draws the map.
            DrawMap(width, height);
        }
        //Method for generating structures like the wall or river, we call them curves.
        static void GenerateCurve(char[,] map, ConsoleColor[,] mapColor, ConsoleColor curveColor, int curveWidth, int curveChance, int startPosQuarters)
        {
            int width = map.GetLength(0);
            int height = map.GetLength(1);
            var random = new Random();
            int curveX = (width / 4) * startPosQuarters;
            for (int curveY = 1; curveY < height - 1; curveY++)
            {
                
                int curveChange = random.Next(curveChance);
                if (curveChange == 0 && curveX < width - 2)
                {
                    for (int curveWidthIndex = 0; curveWidthIndex < curveWidth; curveWidthIndex++)
                    {
                        map[curveX + curveWidthIndex, curveY] = '\\';
                        mapColor[curveX + curveWidthIndex, curveY] = curveColor;
                    }
                    curveX++;
                }
                else if (curveChange == 1 && curveX > 1)
                {
                    for (int curveWidthIndex = 0; curveWidthIndex < curveWidth; curveWidthIndex++)
                    {
                        map[curveX + curveWidthIndex, curveY] = '/';
                        mapColor[curveX + curveWidthIndex, curveY] = curveColor;
                    }

                    curveX--;
                }
                else
                {
                    for (int curveWidthIndex = 0; curveWidthIndex < curveWidth; curveWidthIndex++)
                    {
                        map[curveX + curveWidthIndex, curveY] = '|';
                        mapColor[curveX + curveWidthIndex, curveY] = curveColor;
                    }
                }
            }
        }
        //Method for creating what should happen when the curve crosses the road.
        static void GenerateCurveIntersection(char[,] map, ConsoleColor[,] mapColor, int intersectionLength, string edgeSymbols, ref int roadX, int roadY, ConsoleColor roadColor, ConsoleColor edgeColor)
        {

            int width = map.GetLength(0);
            int symbolIndex = 0;

            
            for (int curveIntersection = 0; curveIntersection < intersectionLength; curveIntersection++)
            {
                char edgeSymbol = edgeSymbols[symbolIndex];
                symbolIndex = (symbolIndex + 1) % edgeSymbols.Length;
                map[roadX, roadY] = '#';
                map[roadX, roadY - 1] = edgeSymbol;
                map[roadX, roadY + 1] = edgeSymbol;
                mapColor[roadX, roadY] = roadColor;
                mapColor[roadX, roadY - 1] = edgeColor;
                mapColor[roadX, roadY + 1] = edgeColor;
                roadX++;
                if (roadX == width - 1)
                {
                    break;
                }
            }

        }

        //Method for generating and drawing the map.
        static void DrawMap(int width, int height)
        {
            var map = new char[width, height];
            var mapColor = new ConsoleColor[width, height];
            var forestColor = ConsoleColor.Green;
            var borderColor = ConsoleColor.Yellow;
            var riverColor = ConsoleColor.Blue;
            var lakeColor = ConsoleColor.Blue;
            var wallColor = ConsoleColor.DarkGray;
            var roadColor = ConsoleColor.White;
            var bridgeColor = ConsoleColor.DarkGray;
            var random = new Random();

            int quarter2 = width / 2;
            int tophalf = height / 2 - 3;
            //Preps map array with spaces.
            for (int prepY = 0; prepY < height; prepY++)
            {
                for (int prepX = 0; prepX < width; prepX++)
                {
                    map[prepX, prepY] = ' ';
                }
            }
            int randomYPos = random.Next(1, height - 5);
            //Generate border and trees
            for (int y = 0; y < height; y++)
            {

                for (int x = 0; x < width; x++)
                {
                    

                    //GenerateBorder
                    //Top left corner
                    if (x == 0 && y == 0)
                    {
                        map[x, y] = '+';
                        mapColor[x, y] = borderColor;
                    }
                    //Top row
                    else if (x < width - 1 && y == 0)
                    {
                        map[x, y] = '-';
                        mapColor[x, y] = borderColor;
                    }
                    //Top right corner
                    else if (x == width - 1 && y == 0)
                    {
                        map[x, y] = '+';
                        mapColor[x, y] = borderColor;
                    }
                    //Left row
                    else if (x == 0 && y > 0 && y < height - 1)
                    {
                        map[x, y] = '|';
                        mapColor[x, y] = borderColor;
                    }
                    //Bottom left corner
                    else if (x == 0 && y == height - 1)
                    {
                        map[x, y] = '+';
                        mapColor[x, y] = borderColor;
                    }
                    //Bottom row
                    else if (x > 0 && x < width - 1 && y == height - 1)
                    {
                        map[x, y] = '-';
                        mapColor[x, y] = borderColor;
                    }
                    //Bottom right corner
                    else if (x == width - 1 && y == height - 1)
                    {
                        map[x, y] = '+';
                        mapColor[x, y] = borderColor;
                    }
                    //Right row
                    else if (x == width - 1 && y > 0 && y < height - 1)
                    {
                        map[x, y] = '|';
                        mapColor[x, y] = borderColor;
                    }
                    //GenerateTrees (Decreasing density over x amount width)
                    else if (x > 0 && x < width / 4 && y > 0 && y < height - 1)
                    {
                        int treeType = random.Next(6);
                        int rng = random.Next(width / 4 + 1);
                        if (rng >= x)
                        {
                            //Character for tree depending on treetype roll
                            string treeTypes = "T@%()A";
                            map[x, y] = treeTypes[treeType];

                            //Forest color
                            mapColor[x, y] = forestColor;
                        }
                    }

                    
                    int quarter1 = width / 4;
                    int quarter4 = (width / 4) * 3 - 5;
                    //Has a chance to spawn a rectangular wheat field in the x middle of the map, random y.
                    if (x > quarter1 && x < quarter4 && y > 1 && y < height - 1 && y < randomYPos)
                    {
                        map[x, y] = '#';
                        mapColor[x, y] = ConsoleColor.DarkYellow;
                    }

                    //random used for making the lake assymetric
                    int beach = random.Next(0, 7);
                    //Generating lake.
                    if (x <= quarter2 && y >= 1 && x >= 1 && y < tophalf && x - beach >= 1)
                    {
                        map[x, y] = ' ';
                        map[x - beach, y ] = '~';
                        mapColor[x - beach, y] = lakeColor;
                    }
                }

                //Adventure map title generation
                for (int titleX = 0; titleX < width; titleX++)
                {
                    string title = "ADVENTURE MAP";
                    if (titleX == width / 2 - 6 && y == 1)
                    {
                        for (int titleIndex = 0; titleIndex < title.Length; titleIndex++)
                        {
                            map[titleX, y] = title[titleIndex];
                            mapColor[titleX, y] = borderColor;
                            titleX++;
                        }
                    }
                }
            }
            //Generating the river.
            GenerateCurve(map, mapColor, riverColor, 3, 3, 3);
            //Generating the wall.
            GenerateCurve(map, mapColor, wallColor, 2, 25, 1);
            //Local method to check if something is a curve.
            bool IsCurve(int x, int y)
            {
                return map[x, y] == '|' || map[x, y] == '\\' || map[x, y] == '/';
            }

            //Prepare for riverRoad generation
            void GenerateRiverRoad(int x, int startY)
            {
                for (int riverRoad = startY; riverRoad < height - 1; riverRoad++)
                {
                    int riverGap = 4;
                    if (x < width - riverGap && IsCurve(x + riverGap, riverRoad) && map[x + riverGap - 1, riverRoad] == ' ' && mapColor[x + riverGap, riverRoad] == riverColor)
                    {
                        map[x, riverRoad] = '#';
                        mapColor[x, riverRoad] = roadColor;
                    }
                }
            }
            //Generate roads
            int roadY = height / 2;
            for (int roadX = 1; roadX < width - 1; roadX++)
            {
                //Road up or down
                int roadChange = random.Next(11);
                if (roadChange == 0 && roadY > 1)
                {
                    roadY--;
                }
                else if (roadChange == 1 && roadY < height - 2)
                {
                    roadY++;
                }
                //Generating the river road
                GenerateRiverRoad(roadX, roadY);
                //Generating the bridge
                int bridgeGap = 2;
                if (roadX < width - bridgeGap && IsCurve(roadX + bridgeGap, roadY) && mapColor[roadX + bridgeGap, roadY] == riverColor)
                {
                    int bridgeLength = 7;
                    for (int bridgeX = 0; bridgeX < bridgeLength; bridgeX++)
                    {
                        GenerateRiverRoad(roadX + bridgeX, roadY);
                    }
                    //Generating the bridge
                    GenerateCurveIntersection(map, mapColor, bridgeLength, "=", ref roadX, roadY, roadColor, bridgeColor);
                }
                //Generating the towers
                int towerGap = 0;
                if (roadX < width - towerGap && IsCurve(roadX + towerGap, roadY) && mapColor[roadX + towerGap, roadY] == wallColor)
                {
                    int towerLength = 2;
                    GenerateCurveIntersection(map, mapColor, towerLength, "[]", ref roadX, roadY, roadColor, wallColor);
                }
                map[roadX, roadY] = '#';
                mapColor[roadX, roadY] = roadColor;
            }


            //Map Drawing! (Draws the generated map to the console)
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

