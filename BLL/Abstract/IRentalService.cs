﻿using Core.Utilities.Results;
using Entities.Concrete;
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
        bool CheckCarIsAvailable(int carId);
    }
}