using Business.Abstract;
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

        public Car GetById(int id)
        {
            return _carDAL.Get(c => c.Id == id);
        }

        public string Insert(Car car)
        {
            _carDAL.Add(car);
            return "Car added";
        }

        public string Update(Car car)
        {
            _carDAL.Update(car);
            return "Car updated";
        }

        public string Delete(Car car)
        {
            _carDAL.Delete(car);
            return "Car deleted";
        }

        public List<CarDetailDTO> GetCarDetails()
        {
            return _carDAL.GetCarDetails().ToList();
        }
    }
}
