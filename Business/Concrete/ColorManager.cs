using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using CarRental.Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using System.Collections.Generic;
using CarRental.Data.Contracts.Repositories;
using CarRental.Data.Contracts.Entities;

namespace CarRental.Business.Concrete
{
    public class ColorService : IColorService
    {
        IColorRepository _colorRepository;

        public ColorService(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            //ValidationTool.Validate(new ColorValidator(), color);

            _colorRepository.Add(color);
            return new SuccessDataResult<Color>(Messages.DataAdded);
        }

        public IResult Delete(Color color)
        {
            _colorRepository.Delete(color);
            return new SuccessDataResult<Color>(Messages.DataDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorRepository.GetAll(), Messages.DataListed);
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorRepository.Get(c => c.Id == id), Messages.DataListed);
        }

        public IDataResult<Color> GetByName(string name)
        {
            return new SuccessDataResult<Color>(_colorRepository.Get(c => c.Name == name), Messages.DataListed);
        }

        public IResult Update(Color color)
        {
            _colorRepository.Update(color);
            return new SuccessDataResult<Color>(Messages.DataAdded);
        }
    }
}