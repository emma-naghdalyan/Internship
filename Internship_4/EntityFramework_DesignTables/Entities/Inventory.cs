using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_DesignTables.Entities
{
    public class Inventory
    {
        public int InventoryId { get; set; }
        public string Type { get; set; }
        public string SerialNumber { get; set; }
        public List<ProductList> ProductLists { get; set; }
    }
}
