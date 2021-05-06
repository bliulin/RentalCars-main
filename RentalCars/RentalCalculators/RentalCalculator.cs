using RentalCars.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentalCars.RentalCalculators
{
    class RentalCalculator : IRentalCalculator
    {
        private IPricesStore pricesStore;

        public RentalCalculator(IPricesStore pricesStore)
        {
            this.pricesStore = pricesStore;
        }

        public RentalResult PerformRentalOperation(Customer customer, PriceCode priceCode, RentalLocation location, int rentalDays)
        {
            var applicableCategory = this.pricesStore.GetServices(location, priceCode).FirstOrDefault();

            if (applicableCategory == null)
            {
                throw new Exception("Could not find a suitable service for your request.");
            }

            if (customer.FrequentRenterPoints < applicableCategory.MinimumFrequentRenterPoints)
            {
                throw new Exception("Unsufficient frequent renter points for this service.");
            }

            int index = 0;
            decimal amount = 0;
            while (rentalDays > 0)
            {
                var price = applicableCategory.Prices[index++];
                if (price.DaysApplied == 0 || price.DaysApplied >= rentalDays)
                {
                    amount += price.Amount * rentalDays;
                    rentalDays = 0;
                }
                else
                {
                    amount += price.Amount * price.DaysApplied;
                    rentalDays -= price.DaysApplied;
                }
            }

            if (customer.FrequentRenterPoints >= 5 && priceCode != PriceCode.Luxury)
            {
                amount -= amount * 5 / 100;
            }

            int freqRenterPointsAwarded = 1;
            if (rentalDays >= 2 && priceCode == PriceCode.Premium)
            {
                freqRenterPointsAwarded = 2;
            }

            return new RentalResult
            {
                Amount = amount,
                FrequentRenterPointsAwarded = freqRenterPointsAwarded
            };
        }
    }
}
