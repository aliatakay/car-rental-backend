using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Abstract
{
    public interface ICarService
    {
        IDataResult<Car> GetById(int id);
        IDataResult<List<Car>> GetAll();
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<Car>> GetAllByModelId(int modelId);
        IDataResult<List<Car>> GetAllByColorId(int colorId);
        IDataResult<List<Car>> GetAllAvailable();
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<Car>> GetAllByModelYearGreaterThanOrEqualTo(int modelYear);
        IDataResult<List<Car>> GetAllByModelYearGreaterThan(int modelYear);
        IDataResult<List<Car>> GetAllByModelYearLessThanOrEqualTo(int modelYear);
        IDataResult<List<Car>> GetAllByModelYearLessThan(int modelYear);
        IDataResult<List<Car>> GetAllByModelYearBetween(int minModelYear, int maxModelYear);
        IDataResult<List<Car>> GetAllByDailyPriceMoreExpensiveThan(decimal dailyPrice);
        IDataResult<List<Car>> GetAllByDailyPriceCheaperThan(decimal dailyPrice);
        IDataResult<List<Car>> GetAllByDailyPriceBetween(decimal minDailyPrice, decimal maxDailyPrice);

    }
}
