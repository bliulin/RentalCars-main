using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCars.Store
{
    class ServiceCategory
    {
        public PriceCode PriceCode { get; set; }

        public RentalLocation Location { get; set; }

        public List<RentalPrice> Prices { get; set; } = new List<RentalPrice>();

        public int MinimumFrequentRenterPoints { get; set; }
    }
}
