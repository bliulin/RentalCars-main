using RentalCars.RentalCalculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentalCars.Statements
{
    class CategoryStatement : IStatement
    {
        public string GetStatement(List<RentalResult> results)
        {
            var items = results.ToList()
                .GroupBy(r => r.Rental.Car.PriceCode)
                .Select(x => new
                {
                    PriceCode = x.Key,
                    Total = x.Sum(x => x.Amount)
                });

            var sb = new StringBuilder();
            foreach (var item in items)
            {
                sb.AppendLine($"{item.PriceCode}\t{item.Total} EUR");
            }

            return sb.ToString();
        }
    }
}
