using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_1._1
{
    class Program
    {
        private static string author = "Made by Mulish Vadym";
        private static string programDescription = "1.1 LINQ Array Statistics";
        private static string programRules = "Enter a string with a set of comma separated integers";
        
        static void Main(string[] args)
        {
            Console.WriteLine(programDescription);
            Console.WriteLine(author);
            Console.WriteLine(programRules);
            int[] numbers;

            var statistics = new StatisticsCalculator();
            do
            {
                Console.WriteLine("Enter your numbers");
                string input = Console.ReadLine();
                numbers = GetIntegersList(input);
                
            } while (numbers == null);

            Console.WriteLine("Array statistics");
            Console.WriteLine($"Minimum: {statistics.GetMinimum(numbers)}");
            Console.WriteLine($"Maximum: {statistics.GetMaximum(numbers)}");
            Console.WriteLine($"Sum of elements: {statistics.GetSum(numbers)}");
            Console.WriteLine($"Average: {statistics.GetAverage(numbers)}");
            Console.WriteLine($"Standard deviation: {statistics.GetStandardDeviation(numbers)}");
            
            Console.Write("Sorted array without duplicates: ");
            
            PrintArray(statistics.SortDistinctElements(numbers));
        }
        
        private static int[] GetIntegersList(string input)
        {
            if (string.IsNullOrEmpty(input))
                return null;
            
            string[] splitedInput = input.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);
                
            try
            {
                return splitedInput.Select(number => number.Trim()).Select(int.Parse).ToArray();
            }
            catch (FormatException exception)
            {
                Console.WriteLine("Invalid input. Try again.");
                return null;
            }
        }

        private static void PrintArray(int[] array)
        {
            foreach (var element in array)
            {
                Console.Write($"{element} ");
            }
        }
    }
}