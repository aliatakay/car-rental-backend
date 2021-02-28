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
                Console.WriteLine("Rental Id: " + rental.RentalId);
                Console.WriteLine("Car Id: " + rental.CarId);
                Console.WriteLine("Customer Id: " + rental.CustomerId);
                Console.WriteLine("Rent Date: " + rental.RentDate.ToString("dd/MM/yyyy"));

                if (rental.ReturnDate != null)
                {
                    Console.WriteLine("Return Date: " + rental.ReturnDate.Value.ToString("dd/MM/yyyy"));
                }

                else
                {
                    Console.WriteLine("Return Date: Not Returned Yet");
                }

                Console.WriteLine("-------------------");
            }
        }
        public static void Add()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            List<Rental> rentals = new List<Rental>
            {
                new Rental { CarId = 1, CustomerId = 3, RentDate = new DateTime(2021,01,01), ReturnDate = new DateTime(2021,01,03)},
                new Rental { CarId = 2, CustomerId = 4, RentDate = new DateTime(2021,01,02), ReturnDate = new DateTime(2021,01,07)},
                new Rental { CarId = 3, CustomerId = 5, RentDate = new DateTime(2021,01,05), ReturnDate = new DateTime(2021,01,11)}
            };

            foreach (var rental in rentals)
            {
                rentalManager.Add(rental);
            }
        }
    }
}
