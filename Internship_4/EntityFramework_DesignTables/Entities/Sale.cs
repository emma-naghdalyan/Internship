using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_DesignTables.Entities
{
    public class Sale
    {
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public DateTime DateSold { get; set; }
        public double Price { get; set; }
        public int AmountSold { get; set; }
    }
}
