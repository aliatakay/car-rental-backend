﻿using BLL.Abstract;
using BLL.Constants;
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

        public IResult Add(Color color)
        {
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
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == id), Messages.DataListed);
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessDataResult<Color>(Messages.DataAdded);
        }
    }
}