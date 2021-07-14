using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_DesignTables.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public ProductList ProductList { get; set; }
        public int ProductListId { get; set; }
        public string ProductName { get; set; }
        public DateTime DateSold { get; set; }
        public string Description { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public Sale Sale { get; set; }
    }
}
