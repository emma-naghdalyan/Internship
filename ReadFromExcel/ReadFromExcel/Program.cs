using Ganss.Excel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReadFromExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            // ANother way that I try to do
            // Excel excel = new Excel(@"C:\Users\emman\Desktop\FinancialSample.cs");


            List<Finance> financeData = new List<Finance>();
            string path = @"C:\Users\emman\Desktop\FinancialSample.xlsx";
            List<Finance> data = new ExcelMapper(path).Fetch<Finance>().ToList();

            foreach (var item in data)
            {
                financeData.Add(
                    new Finance
                    {
                        Segment = item.Segment,
                        Country = item.Country,
                        Product = item.Product,
                        DiscountBand = item.DiscountBand,
                        UnitsSold = item.UnitsSold,
                        ManufacturingPrice = item.ManufacturingPrice,
                        SalePrice = item.SalePrice,
                        GrossSales = item.GrossSales,
                        Discounts = item.Discounts,
                        Sales = item.Sales,
                        COGS = item.COGS,
                        Profit = item.Profit,
                        Date = item.Date,
                        MonthNumber = item.MonthNumber,
                        MonthName = item.MonthName,
                        Year = item.Year
                    });
            }

            Console.WriteLine($"__________ Finance Data is ready __________");
            Console.WriteLine();

            for (int i = 0; i < financeData.Count(); i++)
            {
                Console.WriteLine($"{i + 1} - Segment : {financeData[i].Segment}, Country : {financeData[i].Country}");
            }

            var segmentsOfCanada = financeData.Where(f => f.Country == "Canada").GroupBy(f => f.Segment).Distinct().ToList();
            Console.WriteLine();
            Console.WriteLine($"__________ Segments of Canada __________");
            Console.WriteLine();
            for (int i = 0; i < segmentsOfCanada.Count(); i++)
            {
                Console.WriteLine($"{i + 1} - Segment : {segmentsOfCanada[i].Key}");
            }
        }
    }
}
