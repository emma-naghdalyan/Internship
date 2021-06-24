using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_DesignTables.Models
{
    public class CustomersFromAddress
    {
        public int CustomerId { get; set; }
        public string Address { get; set; }
        public double UnitSold { get; set; }
    }
}
