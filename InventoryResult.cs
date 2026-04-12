using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreInventoryRecorder
{
    internal class InventoryResult
    {
        public int TargetStock { get; set; }
        public int ReorderAmount { get; set; }
        public bool NeedsReorder { get; set; }
        public string Message { get; set; }

        public InventoryResult(int targetStock, int reorderAmount, bool needsReorder, string message)
        {
            TargetStock = targetStock;
            ReorderAmount = reorderAmount;
            NeedsReorder = needsReorder;
            Message = message;
        }
    }
}
