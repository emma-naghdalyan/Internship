using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_DesignTables.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public int OrderHistoryId { get; set; }
        public OrderHistory OrderHistory { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Order> Orders { get; set; }
    }
}
