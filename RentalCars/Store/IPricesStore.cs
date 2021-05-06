using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCars.Store
{
    interface IPricesStore
    {
        IEnumerable<ServiceCategory> GetServices(RentalLocation? location, PriceCode? priceCode);
    }
}
