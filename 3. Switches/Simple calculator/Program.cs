using System;

namespace Simple_calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Set the price: ");
            string price = Console.ReadLine();
            string[] subs = price.Split(' ');
            decimal priceCalc;
            decimal operandA = Convert.ToDecimal(subs[0]);
            decimal operandB = Convert.ToDecimal(subs[2]);
            switch (subs[1])
            {
                case "*":
                    priceCalc = operandA * operandB;

                    break;
                case "/":
                    priceCalc = operandA / operandB;

                    break;
                case "+":
                    priceCalc = operandA + operandB;
                    
                    break;
                case "-":
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
