using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_DesignTables.Entities
{
    public class ProductList
    {
        public int ProductListId { get; set; }
        public Inventory Inventory { get; set; }
        public int InventoryId { get; set; }
        public string SerialNumber { get; set; }
        public int Package { get; set; }
        public List<Product> Products { get; set; }
    }
}
