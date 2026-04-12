using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreInventoryRecorder
{
    internal class InventoryItem
    {
        public string ProductName { get; set; }
        public int CurrentStock { get; set; }
        public int MinimumRequired { get; set; }

        public InventoryItem(string productName, int currentStock, int minimumRequired)
        {
            ProductName = productName;
            CurrentStock = currentStock;
            MinimumRequired = minimumRequired;
        }
    }
}
