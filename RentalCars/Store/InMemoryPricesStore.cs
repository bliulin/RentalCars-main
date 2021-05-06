using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentalCars.Store
{
    class InMemoryPricesStore : IPricesStore
    {
        public IEnumerable<ServiceCategory> GetServices(RentalLocation? location, PriceCode? priceCode)
        {
            var data = new List<ServiceCategory>
            {
                new ServiceCategory
                {
                    PriceCode = PriceCode.Regular,
                    Location = RentalLocation.Iasi,
                    Prices=new List<RentalPrice>
                    {
                        new RentalPrice { Amount=20, DaysApplied = 2 },
                        new RentalPrice { Amount=15 }
                    }
                },
                new ServiceCategory
                {
                    PriceCode = PriceCode.Premium,
                    Location = RentalLocation.Iasi,
                    Prices=new List<RentalPrice>
                    {
                        new RentalPrice { Amount=30 },
                    }
                },
                new ServiceCategory
                {
                    PriceCode = PriceCode.Mini,
                    Location = RentalLocation.Iasi,
                    Prices=new List<RentalPrice>
                    {
                        new RentalPrice { Amount=15, DaysApplied = 3 },
                        new RentalPrice { Amount=10 },
                    }
                }
            };

            IEnumerable<ServiceCategory> result = data;

            if (location != null)
            {
                result = result.Where(s => s.Location == location);
            }
            if (priceCode != null)
            {
                result = result.Where(s => s.PriceCode == priceCode);
            }

            return result;
        }
    }
}
