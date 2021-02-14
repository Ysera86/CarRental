using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDAL _colorDAL;

        public ColorManager(IColorDAL colorDAL)
        {
            _colorDAL = colorDAL;
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDAL.GetAll());
        }

        public IResult Insert(Color color)
        {
            if (color.Name.Length > 2)
            {
                _colorDAL.Add(color);
                return new SuccessResult(Messages.ColorAdded);
            }
            else
            {
                return new ErrorResult(Messages.ColorNotAdded);
            }
        }

        public IResult Update(Color color)
        {
            _colorDAL.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }
        public IResult Delete(Color color)
        {
            _colorDAL.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

      
    }
}
