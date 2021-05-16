using BLL.Abstract;
using BLL.Constants;
using BLL.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
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
            throw new NotImplementedException();
        }

        public IDataResult<List<Car>> GetAllByColorId(int colorId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Car>> GetAllByDailyPriceBetween(decimal minDailyPrice, decimal maxDailyPrice)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Car>> GetAllByDailyPriceCheaperThan(decimal dailyPrice)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Car>> GetAllByDailyPriceMoreExpensiveThan(decimal dailyPrice)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Car>> GetAllByModelId(int modelId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Car>> GetAllByModelYearBetween(int minModelYear, int maxModelYear)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Car>> GetAllByModelYearGreaterThan(int modelYear)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Car>> GetAllByModelYearGreaterThanOrEqualTo(int modelYear)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Car>> GetAllByModelYearLessThan(int modelYear)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Car>> GetAllByModelYearLessThanOrEqualTo(int modelYear)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id), Messages.DataListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.DataListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.Id == id), Messages.DataListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.Id == id), Messages.DataListed);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.DataUpdated);
        }
    }
}
