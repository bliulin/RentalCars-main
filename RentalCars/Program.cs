using RentalCars.Statements;
using RentalCars.Store;
using System;
using System.Linq;

namespace RentalCars
{
    class Program
    {
        static void Main(string[] args)
        {            
            var rentalStore = new RentalEventsStore();

            var customer1 = new Customer("Ion Popescu");
            var customer2 = new Customer("Mihai Chirica");
            var customer3 = new Customer("Gigi Becali");

            rentalStore.AddRentalEvent(new Rental(customer1, RentalLocation.Iasi, new Car(PriceCode.Regular, "Ford Focus"), 2));
            rentalStore.AddRentalEvent(new Rental(customer3, RentalLocation.Iasi, new Car(PriceCode.Regular, "Renault Clio"), 3));
            rentalStore.AddRentalEvent(new Rental(customer1, RentalLocation.Iasi, new Car(PriceCode.Premium, "BMW 330i"), 1));
            rentalStore.AddRentalEvent(new Rental(customer3, RentalLocation.Iasi, new Car(PriceCode.Premium, "Volvo XC90"), 3));
            rentalStore.AddRentalEvent(new Rental(customer2, RentalLocation.Iasi, new Car(PriceCode.Mini, "Toyota Aygo"), 2));
            rentalStore.AddRentalEvent(new Rental(customer1, RentalLocation.Iasi, new Car(PriceCode.Mini, "Hyundai i10"), 4));
            rentalStore.AddRentalEvent(new Rental(customer3, RentalLocation.Iasi, new Car(PriceCode.Premium, "Volvo XC90"), 2));
            rentalStore.AddRentalEvent(new Rental(customer3, RentalLocation.Iasi, new Car(PriceCode.Premium, "Mercedes E320"), 1));

            var rentalManager = new RentalManager();
            var ops = rentalManager.ProcessRentalEvents(rentalStore.Events);

            RentalStatementGenerator rentalStatement = new RentalStatementGenerator("Rental Company LLC");
            Console.WriteLine(rentalStatement.GetStatement(ops.ToList()));

            var categoryStatement = new CategoryStatement();
            Console.WriteLine(categoryStatement.GetStatement(ops.ToList()));

            Console.ReadKey();

        }
    }
}
