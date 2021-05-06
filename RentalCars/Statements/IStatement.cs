using System;
using System.Collections.Generic;
using System.Text;

namespace RentalCars.Statements
{
    public interface IStatement
    {
        string GetStatement(IEnumerable<Rental> rentalEvents);
    }
}
