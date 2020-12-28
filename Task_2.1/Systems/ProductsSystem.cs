using System;
using System.Collections.Generic;
using System.Linq;
using Task_2._1.Entities;

namespace Task_2._1.Systems
{
    public class ProductsSystem : SystemEmulation
    {
        private void FindProduct()
        {
            Console.WriteLine("Enter search query");
            string query = Console.ReadLine();
            if (string.IsNullOrEmpty(query))
                return;
            
            query = query.ToLower().Trim();
            
            IEnumerable<Product> products = _fileReader.ReadProducts().ToList();
            if (!products.Any())
            {
                Console.WriteLine("\nNothing found");    
                return;
            }
            IEnumerable<Tag> tags = _fileReader.ReadTags().ToList();
            
            var productsWithId = products.Where(pr => pr.Id.Equals(query, StringComparison.OrdinalIgnoreCase)).ToList();
            var productsWithBrand = products.Where(pr => pr.Brand.ToLower().Contains(query)).ToList();
            var productsWithModel = products.Where(pr => pr.Model.ToLower().Contains(query)).ToList();
            
            var productsWithTags = tags.Where(t => t.Value.ToLower().Contains(query))
                                                .Select(tag => products.FirstOrDefault(p => p.Id == tag.ProdcutId))
                                                .ToList();
            
            var foundProducts = productsWithId.Union(productsWithBrand)
                                                            .Union(productsWithModel)
                                                            .Union(productsWithTags)
                                                            .ToList();

            if (foundProducts.Count == 0)
            {
                Console.WriteLine("\nNothing found");
            }
            else
            {
                var productInformation = GetProductsInformation(foundProducts).ToList();
                Console.WriteLine("\nSearch result");
                productInformation.ForEach(Console.WriteLine);
            }
        }

        private void ShowAllProductsAscendingPrice()
        {
            Console.WriteLine("\nProducts:");
            IEnumerable<Product> products = _fileReader.ReadProducts().OrderBy(pr => pr.Price).ToList();
            var productInformation = GetProductsInformation(products).ToList();
            productInformation.ForEach(Console.WriteLine);

        }
        
        private void ShowAllProductsDescendingPrice()
        {
            Console.WriteLine("\nProducts:");
            IEnumerable<Product> products = _fileReader.ReadProducts().OrderByDescending(pr => pr.Price).ToList();
            var productInformation = GetProductsInformation(products).ToList();
            productInformation.ForEach(Console.WriteLine);
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
                    FindProduct();
                    break;
                case 3: 
                    ShowAllProductsAscendingPrice();
                    break;
                case 4:
                    ShowAllProductsDescendingPrice();
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
            Console.WriteLine("2. Find product");
            Console.WriteLine("3. Show all product with ascending price"); // from lower to higher
            Console.WriteLine("4. Show all product with descending price"); // from higher to lower
        }

        
    }
}