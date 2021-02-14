using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDAL _carDAL;
        public CarManager(ICarDAL carDAL)
        {
            _carDAL = carDAL;
        }

        public IResult Insert(Car car)
        {
            if (car.Name.Length > 2 && car.DailyPrice > 0)
            {
                _carDAL.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }
            else
            {
                return new ErrorResult(Messages.CarNotAdded);
            }

        }

        public IResult Update(Car car)
        {
            _carDAL.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IResult Delete(Car car)
        {
            _carDAL.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDAL.GetAll());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDAL.GetAll(c => c.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDAL.GetAll(c => c.ColorId == colorId));
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDAL.Get(c => c.Id == id));
        }

        public IDataResult<List<CarDetailDTO>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDTO>>(_carDAL.GetCarDetails().ToList());
        }
    }
}
