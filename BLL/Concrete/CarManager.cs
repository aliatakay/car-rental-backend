using BLL.Abstract;
using BLL.Constants;
using BLL.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DAL.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            //ValidationTool.Validate(new CarValidator(), car);
            
            _carDal.Add(car);
            return new SuccessResult(Messages.DataAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.DataDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if(DateTime.Now.Hour == 5)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            else
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.DataListed);
            }
        }

        public IDataResult<List<Car>> GetAllAvailable()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.IsAvailable == true), Messages.DataListed);

        }

        public IDataResult<List<Car>> GetAllByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId), Messages.DataListed);
        }

        public IDataResult<List<Car>> GetAllByDailyPriceBetween(decimal minDailyPrice, decimal maxDailyPrice)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= minDailyPrice && c.DailyPrice <= maxDailyPrice), Messages.DataListed);

        }

        public IDataResult<List<Car>> GetAllByDailyPriceCheaperThan(decimal dailyPrice)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice <= dailyPrice), Messages.DataListed);
        }

        public IDataResult<List<Car>> GetAllByDailyPriceMoreExpensiveThan(decimal dailyPrice)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= dailyPrice), Messages.DataListed);

        }

        public IDataResult<List<Car>> GetAllByModelId(int modelId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ModelId <= modelId), Messages.DataListed);

        }

        public IDataResult<List<CarDetailDto>> GetAllByModelYearBetween(int minModelYear, int maxModelYear)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllAsDto(c => c.ModelYear >= minModelYear && c.ModelYear <= maxModelYear), Messages.DataListed);

        }

        public IDataResult<List<CarDetailDto>> GetAllByModelYearGreaterThan(int modelYear)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllAsDto(c => c.ModelYear > modelYear), Messages.DataListed);
        }


        public IDataResult<List<CarDetailDto>> GetAllByModelYearLessThan(int modelYear)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllAsDto(c => c.ModelYear < modelYear), Messages.DataListed);
        }


        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id), Messages.DataListed);
        }

        public IDataResult<List<CarDetailDto>> GetAllAsDto()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllAsDto(), Messages.DataListed);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.DataUpdated);
        }
    }
}
