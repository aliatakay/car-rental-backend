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
            // CarGetAll();

            // CarDelete();

            // AddDatabaseColors();

            // ShowColors();

            // AddDatabaseBrands();

            // ShowBrands();

            // AddDatabaseCars();

            // ShowCars();

            ShowCarDetails();
        }

        private static void ShowCarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("Araç: " + car.CarName);
                Console.WriteLine("Marka: " + car.BrandName);
                Console.WriteLine("Renk: " + car.ColorName);
                Console.WriteLine("Fiyat: " + car.DailyPrice.ToString("0.00##") + " TL");
                Console.WriteLine("-------------------");
            }
        }

        private static void ShowColors()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void ShowBrands()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void ShowCars()
        {
            CarManager carManager = new CarManager(new EfCarDal());


            foreach (var car in carManager.GetAll().Data)
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

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarName);
            }
        }

        private static void CarGetAll()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarName);
            }
        }
    }
}
