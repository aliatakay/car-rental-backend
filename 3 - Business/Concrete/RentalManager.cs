using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using CarRental.Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using CarRental.Data.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace CarRental.Business.Concrete
{
    public class RentalService : IRentalService
    {
        IRentalRepository _rentalRepository;

        public RentalService(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
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

            _rentalRepository.Add(rental);
            return new SuccessResult(Messages.DataAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalRepository.Delete(rental);
            return new SuccessResult(Messages.DataDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalRepository.GetAll(), Messages.DataListed);

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
            return new SuccessDataResult<Rental>(_rentalRepository.Get(r => r.Id == id), Messages.DataListed);
        }

        public IDataResult<List<RentalDetailDto>> GetAllAsDto()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalRepository.GetAllAsDto(), Messages.DataListed);
        }

        public IResult Update(Rental rental)
        {
            _rentalRepository.Update(rental);
            return new SuccessResult(Messages.DataUpdated);
        }

        private IResult CheckIfCarIsAvailable(int carId)
        {
            var rentals = _rentalRepository.GetAll(r => r.CarId == carId);

            if (rentals.Count > 0)
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