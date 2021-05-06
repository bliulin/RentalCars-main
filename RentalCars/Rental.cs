namespace RentalCars
{
    public class Rental
    {
        public Rental(Customer customer, RentalLocation location, Car car, int daysRented)
        {
            Customer = customer;
            Car = car;
            DaysRented = daysRented;
            Location = location;
        }

        public Customer Customer { get; }
        public Car Car { get; }
        public int DaysRented { get; }
        public RentalLocation Location { get; }
    }
}