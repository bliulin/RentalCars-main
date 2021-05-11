using RentalCars.RentalCalculators;
using RentalCars.Statements;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCars
{
    class RentalStatement : IStatement
    {
        public RentalStatement(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public string GetStatement(List<RentalResult> results)
        {
            var r = "Rental Record for " + Name + "\n";
            r += "------------------------------\n";

            StringBuilder sb = new StringBuilder(r);

            decimal total = 0;
            foreach (var result in results)
            {
                total += result.Amount;
                //r += each.Customer.Name + "\t" + each.Car.Model + "\t" + each.DaysRented + "d \t" + thisAmount + " EUR\n";
                sb.AppendLine($"{result.Rental.Customer.Name}\t{result.Rental.Car.Model}\t{result.Rental.Location.ToString()}\t{result.Rental.DaysRented}d \t{result.Amount} EUR");
            }

            //r += "------------------------------\n";
            //r += "Total revenue " + totalAmount + " EUR\n";
            sb.AppendLine("------------------------------");
            sb.AppendLine($"Total revenue {total} EUR");
            return sb.ToString();
        }
    }
}