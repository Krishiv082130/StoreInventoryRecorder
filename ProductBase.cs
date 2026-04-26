using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreInventoryRecorder
{
    public class ProductBase
    {
        public string ProductName { get; set; }

        public ProductBase(string productName)
        {
            ProductName = productName;
        }
    }
}
