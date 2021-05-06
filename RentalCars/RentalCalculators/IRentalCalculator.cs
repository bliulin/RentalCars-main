using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCars.RentalCalculators
{
    interface IRentalCalculator
    {
        RentalResult PerformRentalOperation(Customer customer, PriceCode priceCode, RentalLocation location, int rentalDays);
    }
}
