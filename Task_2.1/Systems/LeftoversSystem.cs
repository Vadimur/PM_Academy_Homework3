using System;
using System.Collections.Generic;
using System.Linq;
using Task_2._1.Entities;

namespace Task_2._1.Systems
{
    public class LeftoversSystem : SystemEmulation
    {
        private void ShowUnavailableProducts()
        {
            var unavailableProducts = GetUnavailableProducts().ToList();
            if (unavailableProducts.Count == 0)
            {
                Console.WriteLine("\nThere are no unavailable products");   
                return;
            }
            
            var unavailableProductsInformation = GetProductsInformation(unavailableProducts).ToList();
            Console.WriteLine("\nUnavailable products");
            unavailableProductsInformation.ForEach(Console.WriteLine);
        }

        private IEnumerable<Product> GetUnavailableProducts()
        {
            var products = _fileReader.ReadProducts().ToList();
            var leftovers = _fileReader.ReadLeftovers().ToList();
            
            
            var unavailableProducts = (from product in products
                join leftover in leftovers on product.Id equals leftover.ProductId into ps
                from leftover in ps.DefaultIfEmpty()
                group leftover by product.Id
                into g
                select new
                {
                    Product = (from product in products where product.Id.Equals(g.Key) select product).FirstOrDefault(),
                    Amount = g.Sum(e => e?.Amount)
                }).Where(e => e.Amount == 0).Select(e => e.Product).OrderBy(p => p.Id);
            
            return unavailableProducts.ToList();
        }
        
        private void ShowAllLeftoversAscendingSum()
        {
            var products = _fileReader.ReadProducts().ToList();
            var leftovers = _fileReader.ReadLeftovers().ToList();
            
            var productLeftoversQuery = from product in products
                join leftover in leftovers on product.Id equals leftover.ProductId into ps
                from leftover in ps.DefaultIfEmpty()
                group leftover by product.Id
                into g
                select new
                {
                    Product = (from product in products where product.Id.Equals(g.Key) select product).FirstOrDefault(),
                    Amount = g.Sum(e => e?.Amount)
                };
            var productLeftovers = productLeftoversQuery.OrderBy(g => g.Amount).ToList();
            if (productLeftovers.Count == 0)
            {
                Console.WriteLine("\nThere are no leftovers");   
                return;
            }
            var productLeftoversInfo = GetProductsInformation(productLeftovers.Select(pl => pl.Product)).ToList();
            
            for (int i = 0; i < productLeftoversInfo.Count; i++)
            {
                Console.WriteLine($"{productLeftoversInfo[i]}. This product has {productLeftovers[i].Amount} units of leftovers");
            }
            
        }
        
        private void ShowAllLeftoversDescendingSum()
        {
            var products = _fileReader.ReadProducts().ToList();
            var leftovers = _fileReader.ReadLeftovers().ToList();
            
            var productLeftoversQuery = from product in products
                join leftover in leftovers on product.Id equals leftover.ProductId into ps
                from leftover in ps.DefaultIfEmpty()
                group leftover by product.Id
                into g
                select new
                {
                    Product = (from product in products where product.Id.Equals(g.Key) select product).FirstOrDefault(),
                    Amount = g.Sum(e => e?.Amount)
                };
            var productLeftovers = productLeftoversQuery.OrderByDescending(g => g.Amount).ToList();
            if (productLeftovers.Count == 0)
            {
                Console.WriteLine("\nThere are no leftovers");   
                return;
            }
            var productLeftoversInfo = GetProductsInformation(productLeftovers.Select(pl => pl.Product)).ToList();
            
            for (int i = 0; i < productLeftoversInfo.Count; i++)
            {
                Console.WriteLine($"{productLeftoversInfo[i]}. This product has {productLeftovers[i].Amount} units of leftovers");
            }

        }

        private void ShowLeftoversById()
        {
            Console.WriteLine("Enter product id");
            string productId = Console.ReadLine();
            var leftovers = _fileReader.ReadLeftovers().ToList();

            var leftoverInfo = leftovers
                .Where(l => l.ProductId.Equals(productId, StringComparison.CurrentCultureIgnoreCase) && l.Amount > 0)
                .OrderByDescending(l => l.Amount)
                .ToList();
            
            if (leftoverInfo.Count == 0)
            {
                Console.WriteLine($"\nThere are no leftovers of product with id '{productId}'");   
                return;
            }
            
            leftoverInfo.ForEach(Console.WriteLine);
        }
       
        protected override bool ChooseCommand(int commandNumber)
        {
            bool correctCommand = true;
            switch (commandNumber)
            {
                case 1:
                    _keepProgramActive = false;
                    break;
                case 2:
                    ShowUnavailableProducts();
                    break;
                case 3: 
                    ShowAllLeftoversAscendingSum();
                    break;
                case 4:
                    ShowAllLeftoversDescendingSum();
                    break;
                case 5:
                    ShowLeftoversById();
                    break;
                default:
                    correctCommand = false;
                    break;
            }
            return correctCommand;
        }
        
        protected override void PrintMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1. Back");
            Console.WriteLine("2. Unavailable products");
            Console.WriteLine("3. Show all leftovers with ascending sum"); // from lower to higher
            Console.WriteLine("4. Show all leftovers with descending sum"); // from higher to lower
            Console.WriteLine("5. Get leftovers by ID");
        }
    }
}