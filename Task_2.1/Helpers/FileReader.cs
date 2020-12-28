using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Task_2._1.Entities;

namespace Task_2._1.Helpers
{
    public class FileReader
    {
        public IEnumerable<Tag> ReadTags()
        {
            List<Tag> tags = File.ReadAllLines("Tags.csv")
                .ParseFile()
                .Select(characteristics => new Tag(characteristics[0], characteristics[1]))
                .ToList();
            return tags;
        }

        public IEnumerable<Product> ReadProducts()
        {
            List<Product> products = File.ReadAllLines("Products.csv")
                .ParseFile()
                .Select(cs => new Product(cs[0], cs[1], cs[2], decimal.Parse(cs[3].Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture)))
                .ToList();
            return products;
        }

        public IEnumerable<Leftover> ReadLeftovers()
        {
            List<Leftover> leftovers = File.ReadAllLines("Inventory.csv")
                .ParseFile()
                .Select(cs => new Leftover(cs[0], cs[1], int.Parse(cs[2])))
                .ToList();
            return leftovers;
        }


        
    }
}