using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCars.RentalCalculators
{
    class RentalResult
    {
        public decimal Amount { get; set; }

        public int FrequentRenterPointsAwarded { get; set; }

        public decimal Discount { get; set; }

        public Rental Rental { get; set; }
    }
}
