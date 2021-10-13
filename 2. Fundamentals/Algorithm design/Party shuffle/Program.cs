using System;
using System.Collections.Generic;
namespace Party_shuffle
{
    class Program
    {
       
        static void Main(string[] args)
        {
            List<string> items = new List<string>();
            items.Add("Max");
            items.Add("Matej");
            items.Add("Arthur");
            items.Add("Gustaf");
            items.Add("Andjela");
            items.Add("Marnix");
            Console.WriteLine($"The list of participants: {String.Join(", ", items)}\n");
            Console.Write("Generating starting order");
            for (int i = 0; i < 3; i++)
            {
                System.Threading.Thread.Sleep(333);
                Console.Write(".");
            }
            Console.WriteLine();
            ShuffleList3(items);
            Console.WriteLine($"Starting order: {String.Join(", ", items)}"); 
        }
        static void ShuffleList(List<string> items)
        {
            var random = new Random();
            List<string> itemsNewOrder = new List<string>();
            while(items.Count > 0)
            {
                int randomIndex = random.Next(0, items.Count);
                itemsNewOrder.Add(items[randomIndex]);
                items.RemoveAt(randomIndex);  
            }
            
            items.AddRange(itemsNewOrder);
        }
        static void ShuffleList2(List<string> items)
        {

            var random = new Random();
            int n = items.Count;
            
            for (int i = n - 1; i >= 1; i--)
            {
                int j = random.Next(0, i+1);
                string temp = items[i];
                items[i] = items[j];
                items[j] = temp;

            }
        }
        static void ShuffleList3(List<string> items)
        {
            var random = new Random();
            int n = items.Count;
            for (int i = 0; i <= n- 2; i++)
            {
                int j = random.Next(i, n);
                (items[j], items[i]) = (items[i], items[j]);
            }
        }
    }
}
