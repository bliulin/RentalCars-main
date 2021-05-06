using RentalCars.RentalCalculators;
using RentalCars.Store;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCars.Statements
{
    class UserRentalStatement : IStatement
    {
        private IRentalCalculator rentalCalculator = new RentalCalculator(new InMemoryPricesStore()); //TODO ctor inject

        public string GetStatement(IEnumerable<Rental> rentalEvents)
        {
            StringBuilder sb = new StringBuilder();

            decimal total = 0;
            foreach (var rentalEvent in rentalEvents)
            {
                try
                {
                    var result = rentalCalculator.PerformRentalOperation(rentalEvent);
                    rentalEvent.Customer.FrequentRenterPoints += result.FrequentRenterPointsAwarded;
                    total += result.Amount;
                    //r += each.Customer.Name + "\t" + each.Car.Model + "\t" + each.DaysRented + "d \t" + thisAmount + " EUR\n";
                    sb.AppendLine($"{rentalEvent.Customer.Name}\t{rentalEvent.Car.Model}\t{rentalEvent.DaysRented}d \t{result.Amount} EUR");
                }
                catch (Exception)
                {
                    //TODO: append error
                }
            }

            //r += "------------------------------\n";
            //r += "Total revenue " + totalAmount + " EUR\n";
            sb.AppendLine("------------------------------");
            sb.AppendLine($"Total revenue {total} EUR");
            return sb.ToString();
        }
    }
}
