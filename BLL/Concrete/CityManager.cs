using BLL.Abstract;
using BLL.Constants;
using BLL.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DAL.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Concrete
{
    public class CityManager : ICityService
    {
        ICityDal _cityDal;

        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }

        [ValidationAspect(typeof(CityValidator))]
        public IResult Add(City city)
        {
            //ValidationTool.Validate(new CityValidator(), city);

            _cityDal.Add(city);
            return new SuccessDataResult<City>(Messages.DataAdded);
        }

        public IResult Delete(City city)
        {
            _cityDal.Delete(city);
            return new SuccessDataResult<City>(Messages.DataDeleted);
        }

        public IDataResult<List<City>> GetAll()
        {
            return new SuccessDataResult<List<City>>(_cityDal.GetAll(), Messages.DataListed);
        }

        public IDataResult<City> GetById(int id)
        {
            return new SuccessDataResult<City>(_cityDal.Get(c => c.Id == id), Messages.DataListed);
        }

        public IDataResult<City> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IResult Update(City city)
        {
            _cityDal.Update(city);
            return new SuccessDataResult<City>(Messages.DataAdded);
        }
    }
}
