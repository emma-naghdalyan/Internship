using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_DesignTables.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public int TrackingNumber { get; set; }
        public List<Product> Products { get; set; }
    }
}
