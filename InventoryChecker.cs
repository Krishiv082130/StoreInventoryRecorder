using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreInventoryRecorder
{
    internal class InventoryChecker
    {
        private const int BufferAmount = 20;

        public InventoryResult CheckInventory(InventoryItem item)
        {
            int targetStock = item.MinimumRequired + BufferAmount;

            if (item.CurrentStock < item.MinimumRequired)
            {
                int reorderAmount = targetStock - item.CurrentStock;

                return new InventoryResult(
                    targetStock,
                    reorderAmount,
                    true,
                    $"Reorder Needed! You should order {reorderAmount} units to reach safe stock level."
                );
            }
            else
            {
                return new InventoryResult(
                    targetStock,
                    0,
                    false,
                    "Stock level is sufficient. No reorder is needed."
                );
            }
        }
    }
}