using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreInventoryRecorder
{
    public class InventoryItem : ProductBase
    {
        public int CurrentStock { get; set; }
        public int MinimumRequired { get; set; }

        public InventoryItem(string productName, int currentStock, int minimumRequired)
            : base(productName)
        {
            CurrentStock = currentStock;
            MinimumRequired = minimumRequired;
        }
    }
}
