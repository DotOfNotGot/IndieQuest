using System;

namespace Character_dialouge
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string warriorName = "Skeep the warrior";
            string mageName = "Skoop the mage";
            string Dialouge = "The party stared down the stone stairs into darkness. \"We should've brought some torches with us,\" remarked WARRIOR. MAGE turned around and replied, \"Worry not dear WARRIOR, let me shine some light for you,\" as she cast a Continual light spell.";

            Dialouge = Dialouge.Replace("WARRIOR", warriorName);
            Dialouge = Dialouge.Replace("MAGE", mageName);
            Console.WriteLine(Dialouge);
        }
    }
}
