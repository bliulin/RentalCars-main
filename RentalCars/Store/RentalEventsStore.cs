using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RentalCars.Store
{
    class RentalEventsStore
    {
        private List<Rental> _events = new List<Rental>();
        private CustomerStore _customerStore = new CustomerStore(); //TODO: DI

        public IEnumerable<Rental> Events
        {
            get
            {
                return _events.AsEnumerable();
            }
        }

        public void AddRentalEvent(Rental rentalEvent)
        {
            _events.Add(rentalEvent);
            _customerStore.AddCustomerFromRentalEvent(rentalEvent);
        }
    }
}
