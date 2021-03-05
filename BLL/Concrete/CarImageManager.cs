using BLL.Abstract;
using BLL.Constants;
using Core.Utilities.Results;
using DAL.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage)
        {
            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.DataAdded);
        }
    }
}
