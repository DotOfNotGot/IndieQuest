using System;
using System.Collections.Generic;
namespace Simple_calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Set the price: ");
            string price = Console.ReadLine();
            string[] subs = price.Split(' ');
            List<string> modifiers = new List<string>(subs);
            modifiers.RemoveAt(0);
            modifiers.RemoveAt(modifiers.Count - 1);
            string multiWord = string.Join(" ", modifiers);
            decimal priceCalc;
            decimal operandA = Convert.ToDecimal(subs[0]);
            decimal operandB = Convert.ToDecimal(subs[^1]);
            
            switch (multiWord)
            {
                case "*":
                case "times":
                    priceCalc = operandA * operandB;

                    break;
                case "/":
                case "divided by":
                    priceCalc = operandA / operandB;

                    break;
                case "+":
                case "add":
                case "plus":
                    priceCalc = operandA + operandB;

                    break;
                case "-":
                case "subtract":
                case "minus":
                    priceCalc = operandA - operandB;
                    break;

                default:
                    Console.WriteLine("This operation is not supported");
                    return;
            }

            Console.WriteLine($"The price was set to {priceCalc}.");

        }
    }
}
