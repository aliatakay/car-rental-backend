using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using CarRental.Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using CarRental.Data.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace CarRental.Business.Concrete
{
    public class CarService : ICarService
    {
        ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            //ValidationTool.Validate(new CarValidator(), car);

            _carRepository.Add(car);
            return new SuccessResult(Messages.DataAdded);
        }

        public IResult Delete(Car car)
        {
            _carRepository.Delete(car);
            return new SuccessResult(Messages.DataDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 5)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            else
            {
                return new SuccessDataResult<List<Car>>(_carRepository.GetAll(), Messages.DataListed);
            }
        }

        public IDataResult<List<Car>> GetAllAvailable()
        {
            return new SuccessDataResult<List<Car>>(_carRepository.GetAll(c => c.IsAvailable == true), Messages.DataListed);

        }

        public IDataResult<List<Car>> GetAllByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carRepository.GetAll(c => c.ColorId == colorId), Messages.DataListed);
        }

        public IDataResult<List<Car>> GetAllByDailyPriceBetween(decimal minDailyPrice, decimal maxDailyPrice)
        {
            return new SuccessDataResult<List<Car>>(_carRepository.GetAll(c => c.DailyPrice >= minDailyPrice && c.DailyPrice <= maxDailyPrice), Messages.DataListed);

        }

        public IDataResult<List<Car>> GetAllByDailyPriceCheaperThan(decimal dailyPrice)
        {
            return new SuccessDataResult<List<Car>>(_carRepository.GetAll(c => c.DailyPrice <= dailyPrice), Messages.DataListed);
        }

        public IDataResult<List<Car>> GetAllByDailyPriceMoreExpensiveThan(decimal dailyPrice)
        {
            return new SuccessDataResult<List<Car>>(_carRepository.GetAll(c => c.DailyPrice >= dailyPrice), Messages.DataListed);

        }

        public IDataResult<List<Car>> GetAllByModelId(int modelId)
        {
            return new SuccessDataResult<List<Car>>(_carRepository.GetAll(c => c.ModelId <= modelId), Messages.DataListed);

        }

        public IDataResult<List<CarDetailDto>> GetAllByModelYearBetween(int minModelYear, int maxModelYear)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carRepository.GetAllAsDto(c => c.ModelYear >= minModelYear && c.ModelYear <= maxModelYear), Messages.DataListed);

        }

        public IDataResult<List<CarDetailDto>> GetAllByModelYearGreaterThan(int modelYear)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carRepository.GetAllAsDto(c => c.ModelYear > modelYear), Messages.DataListed);
        }


        public IDataResult<List<CarDetailDto>> GetAllByModelYearLessThan(int modelYear)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carRepository.GetAllAsDto(c => c.ModelYear < modelYear), Messages.DataListed);
        }


        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carRepository.Get(c => c.Id == id), Messages.DataListed);
        }

        public IDataResult<List<CarDetailDto>> GetAllAsDto()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carRepository.GetAllAsDto(), Messages.DataListed);
        }

        public IResult Update(Car car)
        {
            _carRepository.Update(car);
            return new SuccessResult(Messages.DataUpdated);
        }
    }
}