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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessDataResult<Brand>(Messages.DataAdded);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessDataResult<Brand>(Messages.DataDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.DataListed);
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == id), Messages.DataListed);
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessDataResult<Brand>(Messages.DataUpdated);
        }
    }
}
