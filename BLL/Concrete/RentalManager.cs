using BLL.Abstract;
using BLL.Constants;
using BLL.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DAL.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            //ValidationTool.Validate(new RentalValidator(), rental);

            IResult result = BusinessRules.Run(CheckIfCarIsAvailable(rental.CarId));

            if (result != null)
            {
                return result;
            }

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.DataAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.DataDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.DataListed);

        }

        public IDataResult<List<Rental>> GetAllByCarId(int carId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetAllByCustomerId(int customerId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetAllByRentDate(DateTime rentDate)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetAllByRentYear(int rentYear)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetAllByRentYearBetween(int minYear, int maxYear)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetAllByRentYearGreaterThan(int rentYear)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetAllByRentYearLessThan(int rentYear)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetAllByReturnDate(DateTime returnDate)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetAllByReturnYear(int returnYear)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetAllByReturnYearBetween(int minYear, int maxYear)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetAllByReturnYearGreaterThan(int returnYear)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetAllByReturnYearLessThan(int returnYear)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetAllNotReturnedYet()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id), Messages.DataListed);
        }

        public IDataResult<List<RentalDetailDto>> GetAllAsDto()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetAllAsDto(), Messages.DataListed);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.DataUpdated);
        }

        private IResult CheckIfCarIsAvailable(int carId)
        {
            var rentals = _rentalDal.GetAll(r => r.CarId == carId);

            if(rentals.Count > 0)
            {
                var rental = rentals[rentals.Count - 1].ReturnDate;

                if (rental != null)
                {
                    if (DateTime.Compare(rental.Value, DateTime.Now) > 0)
                    {
                        return new ErrorResult(Messages.CannotBeRented);
                    }
                }
            }

            return new SuccessResult();
        }

    }
}
