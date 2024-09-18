using BLL.Abstract;
using BLL.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DAL.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

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
            IResult result = BusinessRules.Run(CheckIfNumberOfImagesExceeded(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.DataAdded);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.DataListed);
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            var carImages = _carImageDal.GetAll(c => c.CarId == carId);

            return new SuccessDataResult<List<CarImage>>(carImages);
        }

        private IResult CheckIfNumberOfImagesExceeded(int carId)
        {
            var carImages = GetImagesByCarId(carId);

            if (carImages.Success)
            {
                if (carImages.Data.Count >= 5)
                {
                    return new ErrorResult(Messages.DataRulesFailed);
                }
            }

            return new SuccessResult();
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id), Messages.DataListed);
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.DataDeleted);
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId), Messages.DataListed);
        }
    }
}