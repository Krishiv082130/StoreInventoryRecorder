using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreInventoryRecorder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("STORE INVENTORY RECORDER");
            Console.WriteLine();

            Console.Write("Enter product name: ");
            string productName = Console.ReadLine();

            int currentStock = ReadInteger("Enter current stock: ");
            int minimumRequired = ReadInteger("Enter minimum required stock: ");

            InventoryItem item = new InventoryItem(productName, currentStock, minimumRequired);
            InventoryChecker checker = new InventoryChecker();
            InventoryResult result = checker.CheckInventory(item);

            Console.WriteLine();
            Console.WriteLine("Checking inventory...");
            Console.WriteLine();
            Console.WriteLine(result.Message);

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            Console.WriteLine("Testing the Github Connection");
        }

        static int ReadInteger(string prompt)
        {
            int value;
            bool validInput;

            do
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                validInput = int.TryParse(input, out value);

                if (!validInput || value < 0)
                {
                    Console.WriteLine("Invalid input. Please enter a whole number 0 or greater.");
                    validInput = false;
                }

            } while (!validInput);

            return value;
        }
    }
}
