using System.Collections.Generic;

namespace RentalCars
{
    class Customer
    {
        public Customer(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public int FrequentRenterPoints { get; set; }
    }
}