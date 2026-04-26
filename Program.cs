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
            List<InventoryResult> results = new List<InventoryResult>();
            InventoryChecker checker = new InventoryChecker();

            Console.WriteLine("================================");
            Console.WriteLine("STORE INVENTORY RECORDER");
            Console.WriteLine("================================");
            Console.WriteLine("This program helps you determine if you need to reorder products based on current stock levels.");
            Console.WriteLine();

            Console.WriteLine("--------------------------------");
            Console.WriteLine("Enter product details below:");
            Console.WriteLine("--------------------------------");
            bool continueProgram = true;

            while (continueProgram)
            {
                string productName = ReadProductName("Enter product name: ");
                int currentStock = ReadInteger("Enter current stock: ");
                int minimumRequired = ReadInteger("Enter minimum required stock: ");

                InventoryItem item = new InventoryItem(productName, currentStock, minimumRequired);
                InventoryResult result = checker.CheckInventory(item);
                results.Add(result);

                Console.WriteLine();
                Console.WriteLine("\n----- RESULT -----");
                Console.WriteLine(result.Message);
                Console.WriteLine("------------------\n");
                Console.WriteLine();

                continueProgram = AskToContinue();
                Console.WriteLine();
            }

            DisplaySummary(results);

            Console.WriteLine();
            Console.WriteLine("Program Complete. Press any key to exit...");
            Console.ReadKey();
        }

        static string ReadProductName(string prompt)
        {
            string productName;

            do
            {
                Console.Write(prompt);
                productName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(productName))
                {
                    Console.WriteLine("Product name cannot be blank. Please enter a product name.");
                }

            } while (string.IsNullOrWhiteSpace(productName));

            return productName;
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

        static bool AskToContinue()
        {
            string answer;

            do
            {
                Console.Write("Do you want to check another product? (Y/N): ");
                answer = Console.ReadLine().Trim().ToUpper();

                if (answer == "Y")
                {
                    return true;
                }

                if (answer == "N")
                {
                    return false;
                }

                Console.WriteLine("Invalid choice. Please enter Y or N.");

            } while (true);
        }

        static void DisplaySummary(List<InventoryResult> results)
        {
            int reorderCount = 0;
            int okCount = 0;

            foreach (InventoryResult result in results)
            {
                if (result.NeedsReorder)
                {
                    reorderCount++;
                }
                else
                {
                    okCount++;
                }
            }

            Console.WriteLine("\n======================================");
            Console.WriteLine("         INVENTORY SUMMARY");
            Console.WriteLine("======================================");
            Console.WriteLine($"Total Products Checked : {results.Count}");
            Console.WriteLine($"Need Reorder           : {reorderCount}");
            Console.WriteLine($"Stock OK               : {okCount}");
            Console.WriteLine("======================================\n");
        }
    }
}
