using System;
using System.Collections.Generic;

namespace Task_1._3
{
    class Program
    {
        private static string author = "Made by Mulish Vadym";
        private static string programDescription = "1.3 Dictionary with key";
        private static string programRules = "Enter number of elements you want to add to the dictionary\n" +
                                             "Then follow the instructions\n";
        
        static void Main(string[] args)
        {
            Console.WriteLine(programDescription);
            Console.WriteLine(author);
            Console.WriteLine(programRules);
            Console.WriteLine("Enter number of elements you want to add to the dictionary");
            int numberOfElements = int.Parse(Console.ReadLine());
            
            var dictionary = new Dictionary<Region, RegionSettings>();

            for (int i = 0; i < numberOfElements; i++)
            {
                Console.Write("Enter region brand: ");
                string brand = Console.ReadLine();
                Console.Write("Enter region country: ");
                string country = Console.ReadLine();
                Console.Write("Enter web-site: ");
                string webSite = Console.ReadLine();
                var region = new Region(brand, country);
                var regionSettings = new RegionSettings(webSite);
                try
                {
                    dictionary.Add(region, regionSettings);
                    Console.WriteLine("Successfully added\n");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("You entered key that already exists. Try again\n");
                    i--;
                }
                
                Console.WriteLine("Current dictionary:");
                PrintDictionary(dictionary);
                Console.WriteLine();
            }
            
        }

        private static void PrintDictionary(Dictionary<Region, RegionSettings> dict)
        {
            foreach (var regionSettings in dict)
                Console.WriteLine($"Key: [{regionSettings.Key}], Value: [{regionSettings.Value}]");
        }
        
    }
}