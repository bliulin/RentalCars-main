namespace RentalCars
{
    class Car
    {
        public Car(PriceCode priceCode, string model)
        {
            PriceCode = priceCode;
            Model = model;
        }

        public PriceCode PriceCode { get; }
        public string Model { get; }
    }
}