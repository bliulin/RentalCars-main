using RentalCars.Statements;
using System;
using System.Collections.Generic;

namespace RentalCars
{
    class RentalCarsStore
    {
        private readonly List<Rental> _rentals = new List<Rental>();

        public RentalCarsStore(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public void AddRental(Rental rental)
        {
            _rentals.Add(rental);
        }

        public string Statement()
        {
            var r = "Rental Record for " + Name + "\n";
            r += "------------------------------\n";

            var userRentalStatement = new UserRentalStatement();
            r += userRentalStatement.GetStatement(_rentals);

            return r;
        }
    }
}