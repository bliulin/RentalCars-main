using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentalCars.Store
{
    class InMemoryPricesStore : IPricesStore
    {
        private List<ServiceCategory> _data;

        public InMemoryPricesStore()
        {
            if (_data != null)
            {
                return;
            }

            _data = new List<ServiceCategory>
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
                },

                new ServiceCategory
                {
                    PriceCode = PriceCode.Regular,
                    Location = RentalLocation.Bucharest,
                    Prices=new List<RentalPrice>
                    {
                        new RentalPrice { Amount=30, DaysApplied = 2 },
                        new RentalPrice { Amount=22.5M }
                    }
                },
                new ServiceCategory
                {
                    PriceCode = PriceCode.Premium,
                    Location = RentalLocation.Bucharest,
                    Prices=new List<RentalPrice>
                    {
                        new RentalPrice { Amount=45},
                    }
                },
                new ServiceCategory
                {
                    PriceCode = PriceCode.Mini,
                    Location = RentalLocation.Bucharest,
                    Prices=new List<RentalPrice>
                    {
                        new RentalPrice { Amount=22.5M, DaysApplied = 3 },
                        new RentalPrice { Amount=15 },
                    }
                },
                new ServiceCategory
                {
                    PriceCode = PriceCode.Luxury,
                    Location = RentalLocation.Bucharest,
                    Prices=new List<RentalPrice>
                    {
                        new RentalPrice { Amount=70 },
                    },
                    MinimumFrequentRenterPoints = 3
                },
                new ServiceCategory
                {
                    PriceCode = PriceCode.Luxury,
                    Location = RentalLocation.Iasi,
                    Prices=new List<RentalPrice>
                    {
                        new RentalPrice { Amount=70 },
                    },
                    MinimumFrequentRenterPoints = 3
                },
            };
        }

        public IEnumerable<ServiceCategory> GetServices(RentalLocation? location, PriceCode? priceCode)
        {
            IEnumerable<ServiceCategory> result = _data;

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
