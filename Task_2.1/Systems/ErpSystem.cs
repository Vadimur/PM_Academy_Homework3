using System;

namespace Task_2._1.Systems
{
    public class ErpSystem : SystemEmulation
    {
        protected override bool ChooseCommand(int commandNumber)
        {
            bool correctCommand = true;
            switch (commandNumber)
            {
                case 1:
                    _keepProgramActive = false;
                    break;
                case 2:
                    StartProductsSystem();
                    break;
                case 3: 
                    StartLeftoversSystem();
                    break;
                default:
                    correctCommand = false;
                    break;
            }
            
            return correctCommand;
        }

        private void StartProductsSystem()
        {
            var prodSystem = new ProductsSystem();
            prodSystem.Start();
        }
        
        private void StartLeftoversSystem()
        {
            var remainingSystem = new LeftoversSystem();
            remainingSystem.Start();
        }
        
        protected override void PrintMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1. Exit");
            Console.WriteLine("2. Products");
            Console.WriteLine("3. Leftovers");
        }
    }
}