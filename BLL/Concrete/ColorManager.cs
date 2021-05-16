using BLL.Abstract;
using BLL.Constants;
using BLL.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Results;
using DAL.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            //ValidationTool.Validate(new ColorValidator(), color);
            
            _colorDal.Add(color);
            return new SuccessDataResult<Color>(Messages.DataAdded);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessDataResult<Color>(Messages.DataDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.DataListed);
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == id), Messages.DataListed);
        }

        public IDataResult<Color> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessDataResult<Color>(Messages.DataAdded);
        }
    }
}
