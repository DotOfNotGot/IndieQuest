using System;
using System.Collections.Generic;
namespace Party_dilemma
{
    class Program
    {
        static void WriteAllPermutations(List<string> items)
        {

            var decidedItems = new List<string>();
            WriteAllPermutationsRecursive(decidedItems, items);
        }

        static void WriteAllPermutationsRecursive(List<string> decidedItems, List<string> remainingItems)
        {
            if (remainingItems.Count == 0)
            {
                Console.WriteLine(string.Join(", ", decidedItems));
            }
            else
            {
                foreach (var chosenItem in remainingItems)
                {
                    var remainingItems2 = new List<string>(remainingItems);
                    remainingItems2.Remove(chosenItem);
                    var decidedItems2 = new List<string>(decidedItems);
                    decidedItems2.Add(chosenItem);
                    WriteAllPermutationsRecursive(decidedItems2, remainingItems2);
                }
            }
            

        }

        static int Factorial(int n)
        {
            if (n <= 0)
            {
                return 1; 
            }
            else
            {
                Console.WriteLine(n);
                return Factorial(n - 1) * n;
                
            }
        }
        static void Main(string[] args)
        {
            List<string> items = new List<string>();
            items.Add("Allie");
            items.Add("Ben");
            items.Add("Claire");
            items.Add("Dipshit");
            items.Add(":D");
            items.Add("Max");
            items.Add("Matej");
            items.Add("Marnix");
            items.Add("Gustaf");
            items.Add("oops");

            WriteAllPermutations(items);
            
            
        }
    }
}
