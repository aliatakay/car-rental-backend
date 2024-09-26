using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using CarRental.Data.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace CarRental.Business.Concrete
{
    public class CarImageService : ICarImageService
    {
        ICarImageRepository _carImageRepository;

        public CarImageService(ICarImageRepository carImageRepository)
        {
            _carImageRepository = carImageRepository;
        }

        public IResult Add(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfNumberOfImagesExceeded(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            _carImageRepository.Add(carImage);
            return new SuccessResult(Messages.DataAdded);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageRepository.GetAll(), Messages.DataListed);
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            var carImages = _carImageRepository.GetAll(c => c.CarId == carId);

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
            return new SuccessDataResult<CarImage>(_carImageRepository.Get(c => c.Id == id), Messages.DataListed);
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageRepository.Delete(carImage);
            return new SuccessResult(Messages.DataDeleted);
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageRepository.GetAll(c => c.CarId == carId), Messages.DataListed);
        }
    }
}