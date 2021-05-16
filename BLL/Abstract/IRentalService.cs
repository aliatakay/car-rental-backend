using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Abstract
{
    public interface IRentalService
    {
        IDataResult<Rental> GetById(int id);
        IDataResult<List<Rental>> GetAll();
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
        IDataResult<List<Rental>> GetAllByCarId(int carId);
        IDataResult<List<Rental>> GetAllByCustomerId(int customerId);
        IDataResult<List<Rental>> GetAllByRentDate(DateTime rentDate);
        IDataResult<List<Rental>> GetAllByRentDateGreaterThanOrEqualTo(DateTime rentDate);
        IDataResult<List<Rental>> GetAllByRentDateGreaterThan(DateTime rentDate);
        IDataResult<List<Rental>> GetAllByRentDateBetween(DateTime minYear, DateTime maxYear);
        IDataResult<List<Rental>> GetAllByRentDateLessThanOrEqualTo(DateTime rentDate);
        IDataResult<List<Rental>> GetAllByRentDateLessThan(DateTime rentDate);
        IDataResult<List<Rental>> GetAllByRentYear(int rentYear);
        IDataResult<List<Rental>> GetAllByRentYearGreaterThanOrEqualTo(int rentYear);
        IDataResult<List<Rental>> GetAllByRentYearGreaterThan(int rentYear);
        IDataResult<List<Rental>> GetAllByRentYearBetween(int minYear, int maxYear);
        IDataResult<List<Rental>> GetAllByRentYearLessThanOrEqualTo(int rentYear);
        IDataResult<List<Rental>> GetAllByRentYearLessThan(int rentYear);
        IDataResult<List<Rental>> GetAllByReturnDate(DateTime returnDate);
        IDataResult<List<Rental>> GetAllByReturnDateGreaterThanOrEqualTo(DateTime returnDate);
        IDataResult<List<Rental>> GetAllByReturnDateGreaterThan(DateTime returnDate);
        IDataResult<List<Rental>> GetAllByReturnDateBetween(DateTime minYear, DateTime maxYear);
        IDataResult<List<Rental>> GetAllByReturnDateLessThanOrEqualTo(DateTime returnDate);
        IDataResult<List<Rental>> GetAllByReturnDateLessThan(DateTime returnDate);
        IDataResult<List<Rental>> GetAllByReturnYear(int returnYear);
        IDataResult<List<Rental>> GetAllByReturnYearGreaterThanOrEqualTo(int returnYear);
        IDataResult<List<Rental>> GetAllByReturnYearGreaterThan(int returnYear);
        IDataResult<List<Rental>> GetAllByReturnYearBetween(int minYear, int maxYear);
        IDataResult<List<Rental>> GetAllByReturnYearLessThanOrEqualTo(int returnYear);
        IDataResult<List<Rental>> GetAllByReturnYearLessThan(int returnYear);
        IDataResult<List<Rental>> GetAllNotReturnedYet();
    }
}
