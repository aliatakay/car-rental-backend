using BLL.Concrete;
using DAL.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.Helpers
{
    public static class RentalHelper
    {
        public static void Print()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var result = rentalManager.GetAll();

            foreach (var rental in result.Data)
            {
                Console.WriteLine("Id: " + rental.Id);
                Console.WriteLine("Car Id: " + rental.CarId);
                Console.WriteLine("Customer Id: " + rental.CustomerId);
                Console.WriteLine("Rent Date: " + rental.RentDate.ToString("dd/MM/yyyy"));

                Console.WriteLine($"Id: {rental.Id}");
                Console.WriteLine($"Car Id: {rental.CarId}");
                Console.WriteLine($"Customer Id: {rental.CustomerId}");
                Console.WriteLine($"Rent Date: {rental.RentDate:dd/MM/yyyy}");
                Console.WriteLine($"Return Date: {rental.ReturnDate.Value:dd/MM/yyyy}");
            }
        }
    }
}
