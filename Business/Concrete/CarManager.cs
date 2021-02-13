using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDAL _carDAL;
        public CarManager(ICarDAL carDAL)
        {
            _carDAL = carDAL;
        }
        public List<Car> GetAll()
        {
            return _carDAL.GetAll();
        }

        public string AddCar(Car car)
        {
            if (car.Name.Length > 2 && car.DailyPrice > 0)
            {
                _carDAL.Add(car);
                return "Car added";
            }
            else
            {
                return "Car couldn't be added";
            }
        }
        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDAL.GetAll(c => c.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDAL.GetAll(c => c.ColorId == colorId);
        }
    }
}
