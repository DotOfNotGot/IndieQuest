using System;

namespace Ace_of
{
    class Program
    {
        enum Suits
        {
            Hearts,
            Spades,
            Diamonds,
            Clubs
        }

        static void DrawAce(Suits suit)
        {

            string symbol = "";

            switch (suit)
            {
                case Suits.Hearts:
                    symbol = "♥";
                    break;
                case Suits.Spades:
                    symbol = "♠";
                    break;
                case Suits.Diamonds:
                    symbol = "♦";
                    break;
                case Suits.Clubs:
                    symbol = "♣";
                    break;
                default:
                    symbol = "?";
                    break;
            }
            Console.WriteLine("╭─────────╮");
            Console.WriteLine($"│A        │");
            Console.WriteLine($"│{symbol}        │");
            Console.WriteLine("│         │");
            Console.WriteLine($"│    {symbol}    │");
            Console.WriteLine("│         │");
            Console.WriteLine($"│        {symbol}│");
            Console.WriteLine($"│        A│");
            Console.WriteLine("╰─────────╯");

        }

        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            DrawAce(Suits.Hearts);
            DrawAce(Suits.Spades);
            DrawAce(Suits.Diamonds);
            DrawAce(Suits.Clubs);

        }
    }
}
