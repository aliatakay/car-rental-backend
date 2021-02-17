using DAL.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars = new List<Car>
        {
            new Car 
            {   CarId = 1, 
                BrandId = 1, 
                ColorId = 1, 
                CarName = "Car Name 1", 
                ModelYear = 2010, 
                DailyPrice = 200,
                Description = "Car Description 1"
            },
            new Car
            {   CarId = 2,
                BrandId = 2,
                ColorId = 2,
                CarName = "Car Name 2",
                ModelYear = 2012,
                DailyPrice = 400,
                Description = "Car Description 2"
            },
            new Car
            {   CarId = 3,
                BrandId = 3,
                ColorId = 3,
                CarName = "Car Name 3",
                ModelYear = 2014,
                DailyPrice = 600,
                Description = "Car Description 3"
            }
        };

        public void Add(Car entity)
        {
            _cars.Add(entity);
        }

        public void Delete(Car entity)
        {
            _cars.Remove(_cars.SingleOrDefault(c => c.CarId == entity.CarId));
        }

        public Car Get(Expression<Func<Car, bool>> expr)
        {
            return _cars.SingleOrDefault(expr.Compile());
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> expr = null)
        {
            return (expr == null)
                ? _cars
                : _cars.Where(expr.Compile()).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car entity)
        {
            Car car = _cars.SingleOrDefault(c => c.CarId == entity.CarId);

            car.BrandId = entity.BrandId;
            car.ColorId = entity.ColorId;
            car.CarName = entity.CarName;
            car.DailyPrice = entity.DailyPrice;
            car.ModelYear = entity.ModelYear;
            car.Description = entity.Description;
        }
    }
}
