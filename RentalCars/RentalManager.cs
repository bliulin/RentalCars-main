using RentalCars.RentalCalculators;
using RentalCars.Store;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCars
{
    class RentalManager
    {
        private IRentalCalculator rentalCalculator = new RentalCalculator(new InMemoryPricesStore()); //TODO ctor inject

        public RentalManager()
        {

        }

        public IEnumerable<RentalResult> ProcessRentalEvents(IEnumerable<Rental> rentalEvents)
        {
            List<RentalResult> results = new List<RentalResult>();

            foreach (var rentalEvent in rentalEvents)
            {
                try
                {
                    var result = rentalCalculator.PerformRentalOperation(rentalEvent);
                    rentalEvent.Customer.FrequentRenterPoints += result.FrequentRenterPointsAwarded;
                    results.Add(result);
                }
                catch (Exception e)
                {
                    var errorResult = new RentalResult();
                    errorResult.Errors.Add(e);
                    results.Add(errorResult);
                }
            }

            return results;
        }
    }
}
