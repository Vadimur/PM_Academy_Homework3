using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_1._1
{
    public class StatisticsCalculator
    {
        public int GetMinimum(int[]  numbers) => numbers.Min();
        public int GetMaximum(int[]  numbers) => numbers.Max();
        public int GetSum(int[]  numbers) => numbers.Sum();
        public double GetAverage(int[]  numbers) => numbers.Average();
        public double GetStandardDeviation(int[]  numbers)
        {
            double avg = numbers.Average();
            double sum = numbers.Sum(number => Math.Pow(number - avg, 2));
            return Math.Sqrt(sum / numbers.Length);
        }
        public int[] SortDistinctElements(int[]  numbers)
        {
            return numbers.Distinct().OrderBy(number => number).ToArray();
        }
    }
}