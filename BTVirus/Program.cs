using System;

namespace BTVirus
{
    class Program
    {
        static void Main(string[] args)
        {
            public string trigger = Console.ReadLine("Do you want to trigger the BTVirus? (yes/no): ");
            if (trigger.ToLower() == "yes")
            {
                Console.WriteLine("BTVirus triggered!");
            }
            else
            {
                Console.WriteLine("BTVirus not triggered.");
            }
        }
    }
}