using System;
using System.Collections.Generic;
namespace Travel_the_world_map
{
    class Program
    {
        static void Dijkstra(List<Location> graph, Location source)
        {

            List<Location> locations = new List<Location>();


            foreach (var vertex in graph)
            {

            }

            foreach (Location otherLocation in graph)
            {
                if (otherLocation == source) continue;

                var path = new Path { Location = otherLocation, Distance = dist[otherLocation] };
                source.ShortestPaths.Add(path);

                Location stop = prev[otherLocation];
                while (stop != source)
                {
                    path.StopNames.Insert(0, stop.Name);
                    stop = prev[stop];
                }
            }
        }

        static void Main(string[] args)
        {
            var locations = new List<Location>();
            var winterfell = new Location
            {
                Name = "Winterfell",
                Description = "the capital of the Kingdom of the North"
            };
            locations.Add(winterfell);
            var pyke = new Location
            {
                Name = "Pyke",
                Description = "the stronghold and seat of House Greyjoy"
            };
            locations.Add(pyke);
            var riverrun = new Location
            {
                Name = "Riverrun",
                Description = "a large castle located in the central-western part of the Riverlands"
            };
            locations.Add(riverrun);
            var thetrident = new Location
            {
                Name = "The Trident",
                Description = "one of the largest and most well-known rivers on the continent of Westeros"
            };
            locations.Add(thetrident);
            var kingslanding = new Location
            {
                Name = "King's Landing",
                Description = "the capital, and largest city, of the Seven Kingdoms"
            };
            locations.Add(kingslanding);
            var highgarden = new Location
            {
                Name = "Highgarden",
                Description = "the seat of House Tyrell and the regional capital of the Reach"
            };
            locations.Add(highgarden);
            ConnectLocations(winterfell, pyke, 18);
            ConnectLocations(winterfell, thetrident, 10);
            ConnectLocations(pyke, riverrun, 3);
            ConnectLocations(pyke, highgarden, 14);
            ConnectLocations(riverrun, thetrident, 2);
            ConnectLocations(riverrun, highgarden, 10);
            ConnectLocations(riverrun, kingslanding, 25);
            ConnectLocations(thetrident, kingslanding, 5);
            ConnectLocations(kingslanding, highgarden, 8);
            Location currentLocation = winterfell;
            while (true)
            {
                Console.WriteLine($"Welcome to {currentLocation.Name}, {currentLocation.Description}.");
                Console.WriteLine();
                Console.WriteLine("Continue or [q]uit?");
                char continueOrQuit = Convert.ToChar(Console.ReadLine());
                if (continueOrQuit == 'q')
                {
                    Console.WriteLine();
                    Console.WriteLine("Farewell");
                    break;
                }

                Console.WriteLine();
                Console.WriteLine($"Possible destinations are: ");
                for (int i = 0; i < currentLocation.Neighbors.Count; i++)
                {
                    var neighbor = currentLocation.Neighbors[i];
                    Console.WriteLine($"{i + 1}. {neighbor.Location.Name} ({neighbor.Distance})");
                }
                Console.WriteLine();
                Console.WriteLine("Where do you want to travel?");
                int destinationChoice = Convert.ToInt32(Console.ReadLine());
                currentLocation = currentLocation.Neighbors[destinationChoice - 1].Location;

               
                
            }
            
        }
        static void ConnectLocations(Location a, Location b, int distance)
        {
            var neighborA = new Neighbor { Location = a, Distance = distance };
            var neighborB = new Neighbor { Location = b, Distance = distance };
            
            a.Neighbors.Add(neighborB);
            b.Neighbors.Add(neighborA);

            
        }
    }
    
    class Location
    {
        public string Name;
        public string Description;
        public List<Neighbor> Neighbors = new List<Neighbor>();
    }
    class Neighbor
    {
        public Location Location;
        public int Distance;
    }
}
