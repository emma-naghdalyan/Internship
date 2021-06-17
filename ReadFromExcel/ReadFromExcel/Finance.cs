using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFromExcel
{
    public sealed class Finance
    {
        public string Segment { get; set; }
        public string Country { get; set; }
        public string Product { get; set; }
        public string DiscountBand { get; set; }
        public decimal UnitsSold { get; set; }
        public decimal ManufacturingPrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal GrossSales { get; set; }
        public decimal Discounts { get; set; }
        public decimal Sales { get; set; }
        public decimal COGS { get; set; }
        public decimal Profit { get; set; }
        public DateTime Date { get; set; }
        public int MonthNumber { get; set; }
        public string MonthName { get; set; }
        public long Year { get; set; }
    }
}
