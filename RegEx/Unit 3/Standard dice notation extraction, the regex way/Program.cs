using System;
using System.Text.RegularExpressions;
namespace Standard_dice_notation_detection__the_regex_way
{
    class Program
    {
        static string diceNotationPattern = @"\b(\d+)?d(\d+)([+-]\d+)?\b";
        static void Main(string[] args)
        {
            DiceThrow("2d6+5");
            DiceThrow("2d4-1");
            DiceThrow("d12");
            DiceThrow("5d10");
            DiceThrow("34");

        }
        static int DiceRoll(int numberOfRolls, int diceSides, int fixedBonus = 0)
        {
            var random = new Random();
            int diceSum = fixedBonus;

            for (int i = 0; i < numberOfRolls; i++)
            {
                int diceThrow = random.Next(1, diceSides + 1);
                diceSum += diceThrow;

            }

            return diceSum;
        }
        static int DiceRoll(string diceNotation)
        {
            int numberOfRolls = 1;
            int diceSides;
            int fixedBonus = 0;
            Match result = Regex.Match(diceNotation, diceNotationPattern);

            if (result.Groups[1].Success)
            {
                numberOfRolls = Convert.ToInt32(result.Groups[1].Value);
            }
            diceSides = Convert.ToInt32(result.Groups[2].Value);
            if (result.Groups[3].Success)
            {
                fixedBonus = Convert.ToInt32(result.Groups[3].Value);
            }

            return DiceRoll(numberOfRolls, diceSides, fixedBonus);
        }
        static void DiceThrow(string diceNotation)
        {

            if (Regex.IsMatch(diceNotation, diceNotationPattern))
            {
                Console.Write($"Throwing {diceNotation} ...");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write($" {DiceRoll(diceNotation)}");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"Can't throw {diceNotation}, it is not in standard dice notation.");
            }

        }
    }
}
