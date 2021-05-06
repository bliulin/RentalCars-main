using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCars.Store
{
    class RentalPrice
    {
        public decimal Amount { get; set; }

        public int DaysApplied { get; set; } = 0; // A value of 0 means that it is applied indefinitely
    }
}
