using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace BLL.Abstract
{
    public interface IRentalService
    {
        IDataResult<Rental> GetById(int id);
        IDataResult<List<Rental>> GetAll();
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IDataResult<List<RentalDetailDto>> GetAllAsDto();
        IDataResult<List<Rental>> GetAllByCarId(int carId);
        IDataResult<List<Rental>> GetAllByCustomerId(int customerId);
        IDataResult<List<Rental>> GetAllByRentDate(DateTime rentDate);
        IDataResult<List<Rental>> GetAllByRentYear(int rentYear);
        IDataResult<List<Rental>> GetAllByRentYearGreaterThan(int rentYear);
        IDataResult<List<Rental>> GetAllByRentYearBetween(int minYear, int maxYear);
        IDataResult<List<Rental>> GetAllByRentYearLessThan(int rentYear);
        IDataResult<List<Rental>> GetAllByReturnDate(DateTime returnDate);
        IDataResult<List<Rental>> GetAllByReturnYear(int returnYear);
        IDataResult<List<Rental>> GetAllByReturnYearGreaterThan(int returnYear);
        IDataResult<List<Rental>> GetAllByReturnYearBetween(int minYear, int maxYear);
        IDataResult<List<Rental>> GetAllByReturnYearLessThan(int returnYear);
        IDataResult<List<Rental>> GetAllNotReturnedYet();
    }
}