using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using CarRental.Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using CarRental.Data.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace CarRental.Business.Concrete
{
    public class CityService : ICityService
    {
        ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        [ValidationAspect(typeof(CityValidator))]
        public IResult Add(City city)
        {
            //ValidationTool.Validate(new CityValidator(), city);

            _cityRepository.Add(city);
            return new SuccessDataResult<City>(Messages.DataAdded);
        }

        public IResult Delete(City city)
        {
            _cityRepository.Delete(city);
            return new SuccessDataResult<City>(Messages.DataDeleted);
        }

        public IDataResult<List<City>> GetAll()
        {
            return new SuccessDataResult<List<City>>(_cityRepository.GetAll(), Messages.DataListed);
        }

        public IDataResult<City> GetById(int id)
        {
            return new SuccessDataResult<City>(_cityRepository.Get(c => c.Id == id), Messages.DataListed);
        }

        public IDataResult<City> GetByName(string name)
        {
            return new SuccessDataResult<City>(_cityRepository.Get(c => c.Name == name), Messages.DataListed);
        }

        public IResult Update(City city)
        {
            _cityRepository.Update(city);
            return new SuccessDataResult<City>(Messages.DataAdded);
        }
    }
}