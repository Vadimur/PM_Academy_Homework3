using System;
using System.Collections.Generic;
using System.Linq;
using Task_2._1.Entities;
using Task_2._1.Helpers;

namespace Task_2._1.Systems
{
    public abstract class SystemEmulation
    {
        protected bool _keepProgramActive = true;
        protected readonly FileReader _fileReader;

        protected SystemEmulation()
        {
            _fileReader = new FileReader();
        }
        public void Start()
        {
            do
            {
                PrintMenu();
                Console.Write("Enter command: ");
                string userInput = Console.ReadLine();

                if (string.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("Empty input. Try again\n");
                    continue;
                }

                userInput = userInput.Trim();
                if (int.TryParse(userInput, out int commandId) == false)
                {
                    Console.WriteLine("Unknown command id. Try again\n");
                    continue;
                }

                bool isCommandValid = ChooseCommand(commandId);
                if (isCommandValid == false)
                {
                    Console.WriteLine("Unknown command id. Try again\n");
                }
            } while (_keepProgramActive);
        }


        protected abstract void PrintMenu();

        protected abstract bool ChooseCommand(int commandId);
        
        protected IEnumerable<string> GetProductsInformation(IEnumerable<Product> products)
        {
            IEnumerable<Tag> tags = _fileReader.ReadTags().ToList();

            return products.Select(p => tags.Where(t => t.ProdcutId == p.Id)
                    .Aggregate(p + " [",(str, obj) => str +  obj.Value + ", ")
                    .TrimEnd(' ', ',') + "]")
                .ToList();
        }
    }
}