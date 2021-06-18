using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_DesignTables.Entities
{
    public class OrderHistory
    {
        public int OrderHistoryId { get; set; }
        public int CustomerId { get; set; }
        public double UnitSold { get; set; }
        public Customer Customer { get; set; }
    }
}
