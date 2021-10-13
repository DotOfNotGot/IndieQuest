using System;

namespace Operation_system_detection
{
    class Program
    {
        static void Main(string[] args)
        {
            string OS = System.Environment.OSVersion.VersionString;
            Console.Write("You are running the game on Windows: ");
            Console.Write(OS.Contains("Windows"));
        }
    }
}
