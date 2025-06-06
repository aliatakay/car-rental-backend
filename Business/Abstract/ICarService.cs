﻿using CarRental.Data.Contracts.DTOs;
using CarRental.Data.Contracts.Entities;
using Core.Utilities.Results;
using System.Collections.Generic;

namespace CarRental.Business.Abstract
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
        IDataResult<List<CarDetailDto>> GetAllAsDto();
        IDataResult<List<CarDetailDto>> GetAllByModelYearGreaterThan(int modelYear);
        IDataResult<List<CarDetailDto>> GetAllByModelYearLessThan(int modelYear);
        IDataResult<List<CarDetailDto>> GetAllByModelYearBetween(int minModelYear, int maxModelYear);
        IDataResult<List<Car>> GetAllByDailyPriceMoreExpensiveThan(decimal dailyPrice);
        IDataResult<List<Car>> GetAllByDailyPriceCheaperThan(decimal dailyPrice);
        IDataResult<List<Car>> GetAllByDailyPriceBetween(decimal minDailyPrice, decimal maxDailyPrice);
    }
}