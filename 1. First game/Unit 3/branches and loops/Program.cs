using System;

//ExploreIf();
//DumbRemShenanigans();

class BranchesAndLoops
{
    static void Main(string[] args)
    {
        void DumbRemShenanigans()
        {
            int sum = 0;
            for (int counter = 1; counter < 21; counter++)
            {

                if (counter % 3 == 0)
                {
                    sum = sum + counter;
                }
                Console.WriteLine(sum);
            }
        }

        void ExploreIf()
        {
            int a = 5;
            int b = 3;
            if (a + b > 10)
            {
                Console.WriteLine("The answer is greater than 10");
            }
            else
            {
                Console.WriteLine("The answer is not greater than 10");
            }

            int c = 4;
            if ((a + b + c > 10) && (a > b))
            {
                Console.WriteLine("The answer is greater than 10");
                Console.WriteLine("And the first number is greater than the second");
            }
            else
            {
                Console.WriteLine("The answer is not greater than 10");
                Console.WriteLine("Or the first number is not greater than the second");
            }

            if ((a + b + c > 10) || (a > b))
            {
                Console.WriteLine("The answer is greater than 10");
                Console.WriteLine("Or the first number is greater than the second");
            }
            else
            {
                Console.WriteLine("The answer is not greater than 10");
                Console.WriteLine("And the first number is not greater than the second");
            }
        }
    }
}