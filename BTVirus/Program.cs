using System;

namespace BTVirus
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Do you want to trigger the BTVirus? (yes/no): ");
            var trigger = Console.ReadLine()?.Trim();
            if (string.Equals(trigger, "yes", StringComparison.OrdinalIgnoreCase))
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