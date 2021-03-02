using BLL.Abstract;
using BLL.Constants;
using BLL.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Results;
using DAL.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
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

        public IResult Add(Rental rental)
        {
            ValidationTool.Validate(new RentalValidator(), rental);

            if (CheckCarIsAvailable(rental.CarId))
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.DataAdded);
            }
            
            return new ErrorResult(Messages.DataRulesFailed);
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

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == id), Messages.DataListed);
        }

        public bool CheckCarIsAvailable(int carId)
        {
            var rentals = _rentalDal.GetAll(r => r.CarId == carId);

            return (rentals == null) || rentals[rentals.Count - 1].ReturnDate != null;
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.DataUpdated);
        }
    }
}
