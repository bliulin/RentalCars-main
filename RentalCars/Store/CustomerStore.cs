using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentalCars.Store
{
    class CustomerStore //TODO: extract interface
    {
        private List<Customer> _customers = new List<Customer>();

        public IEnumerable<Customer> Customers
        {
            get
            {
                return _customers.AsEnumerable();
            }
        }

        public void AddCustomerFromRentalEvent(Rental rentalEvent)
        {
            if (!_customers.Any(c => c.Name == rentalEvent.Customer.Name))
            {
                _customers.Add(rentalEvent.Customer);
            }
        }
    }
}
