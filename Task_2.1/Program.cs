using System;
using System.IO;
using Task_2._1.Systems;

namespace Task_2._1
{
    class Program
    {
        private static string author = "Made by Mulish Vadym";
        private static string programDescription = "2.1 ERP Reports Bot";
        private static string programRules = "ERP reports bot for creating various reports about products and their availability\n" +
                                             "(lists of products, tags, leftovers in warehouses)";
        
        static int Main(string[] args)
        {
            Console.WriteLine(programDescription);
            Console.WriteLine(author);
            Console.WriteLine(programRules);
            
            var mainSystem = new ErpSystem();
            try
            {
                mainSystem.Start();
                return 0;
            }
            catch (IOException e)
            {
                return -1;
            }
            
        }
    }
}