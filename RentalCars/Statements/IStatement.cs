using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCars.Statements
{
    interface IStatement
    {
        string GetStatement(IEnumerable<Rental> rentalEvents);
    }
}
