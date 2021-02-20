using BLL.Concrete;
using DAL.Concrete.EntityFramework;
using DAL.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // ShowRentals();
        }

        private static void ShowRentals()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var result = rentalManager.GetAll();

            foreach (var rental in result.Data)
            {
                Console.WriteLine(rental.CarId + " /" + rental.RentDate + "/" + rental.ReturnDate);
            }
        }
        private static void AddDatabaseRentals()
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
        private static void ShowCustomers()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            var result = customerManager.GetAll();

            foreach (var customer in result.Data)
            {
                Console.WriteLine(customer.CompanyName);
            }
        }
        private static void AddDatabaseCustomers()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            List<Customer> customers = new List<Customer>
            {
                new Customer { UserId = 6, CompanyName = "CompanyName 1"},
                new Customer { UserId = 7, CompanyName = "CompanyName 2"},
                new Customer { UserId = 8, CompanyName = "CompanyName 3"},
                new Customer { UserId = 9, CompanyName = "CompanyName 4"},
                new Customer { UserId = 10, CompanyName = "CompanyName 5"}
            };

            foreach (var customer in customers)
            {
                customerManager.Add(customer);
            }
        }
        private static void ShowUsers()
        {
            UserManager userManager = new UserManager(new EfUserDal());

            var result = userManager.GetAll();

            foreach (var user in result.Data)
            {
                Console.WriteLine(user.Email);
            }
        }
        private static void AddDatabaseUsers()
        {
            UserManager userManager = new UserManager(new EfUserDal());

            List<User> users = new List<User>
            {
                new User { FirstName = "Name 1", LastName = "LastName 1", Email = "mail1@mail.com", Password = "Password1"},
                new User { FirstName = "Name 2", LastName = "LastName 2", Email = "mail2@mail.com", Password = "Password2"},
                new User { FirstName = "Name 3", LastName = "LastName 3", Email = "mail3@mail.com", Password = "Password3"},
                new User { FirstName = "Name 4", LastName = "LastName 4", Email = "mail4@mail.com", Password = "Password4"},
                new User { FirstName = "Name 5", LastName = "LastName 5", Email = "mail5@mail.com", Password = "Password5"}
            };

            foreach (var user in users)
            {
                userManager.Add(user);
            }
        }
        private static void ShowCarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();

            foreach (var car in result.Data)
            {
                Console.WriteLine("Araç: " + car.CarName);
                Console.WriteLine("Marka: " + car.BrandName);
                Console.WriteLine("Renk: " + car.ColorName);
                Console.WriteLine("Fiyat: " + car.DailyPrice.ToString("0.00##") + " TL");
                Console.WriteLine("-------------------");
            }

            Console.WriteLine(result.Message);
        }

        private static void ShowColors()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            var result = colorManager.GetAll();

            foreach (var color in result.Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void ShowBrands()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            var result = brandManager.GetAll();

            foreach (var brand in result.Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void ShowCars()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetAll();

            foreach (var car in result.Data)
            {
                Console.WriteLine(car.CarName);
            }
        }

        private static void AddDatabaseColors()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            List<Color> colors = new List<Color>
            {
                new Color { ColorName = "Red"},
                new Color { ColorName = "Blue"},
                new Color { ColorName = "Black"},
                new Color { ColorName = "White"},
                new Color { ColorName = "Orange"},
                new Color { ColorName = "Dark Blue"}
            };

            foreach (var color in colors)
            {
                colorManager.Add(color);
            }
        }

        private static void AddDatabaseBrands()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            List<Brand> brands = new List<Brand>
            {
                new Brand { BrandName = "BMW"},
                new Brand { BrandName = "Audi"},
                new Brand { BrandName = "Ford"},
                new Brand { BrandName = "Fiat"},
                new Brand { BrandName = "Tesla"},
                new Brand { BrandName = "Mercedes"}
            };

            foreach (var brand in brands)
            {
                brandManager.Add(brand);
            }
        }

        private static void AddDatabaseCars()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            List<Car> cars = new List<Car>
            {
                new Car
                {   
                    BrandId = 1,
                    ColorId = 1,
                    CarName = "Car Name 1",
                    ModelYear = 2010,
                    DailyPrice = 200,
                    Description = "Car Description 1"
                },
                new Car
                {   
                    BrandId = 2,
                    ColorId = 2,
                    CarName = "Car Name 2",
                    ModelYear = 2012,
                    DailyPrice = 400,
                    Description = "Car Description 2"
                },
                new Car
                {   
                    BrandId = 3,
                    ColorId = 3,
                    CarName = "Car Name 3",
                    ModelYear = 2014,
                    DailyPrice = 600,
                    Description = "Car Description 3"
                }
            };

            foreach (var car in cars)
            {
                carManager.Add(car);
            }
        }

        private static void CarDelete()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            carManager.Delete(new Car { CarId = 3 });

            var result = carManager.GetAll();

            foreach (var car in result.Data)
            {
                Console.WriteLine(car.CarName);
            }
        }

        private static void CarGetAll()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            var result = carManager.GetAll();

            foreach (var car in result.Data)
            {
                Console.WriteLine(car.CarName);
            }
        }
    }
}
