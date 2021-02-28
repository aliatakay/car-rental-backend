using BLL.Concrete;
using DAL.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI.Helpers
{
    public static class CarHelper
    {
        public static void Print()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetAll();

            foreach (var car in result.Data)
            {
                Console.WriteLine(car.CarName);
            }
        }
        public static void Add()
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

        public static void Delete()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Delete(new Car { CarId = 3 });

            var result = carManager.GetAll();

            foreach (var car in result.Data)
            {
                Console.WriteLine(car.CarName);
            }
        }

        public static void PrintDto()
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
    }
}
