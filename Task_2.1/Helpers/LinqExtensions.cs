using System.Collections.Generic;
using System.Linq;

namespace Task_2._1.Helpers
{
    public static class LinqExtensions
    {
        public static IEnumerable<string[]> ParseFile(this IEnumerable<string> source)
        {
            return source.Skip(1).Select(line => line.Split(';'));
        }
    }
}