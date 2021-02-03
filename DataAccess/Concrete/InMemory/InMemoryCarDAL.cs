﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDAL : ICarDAL
    {
        List<Car> _cars;

        public InMemoryCarDAL()
        {
            _cars = new List<Car>
            {
                 new Car(){ Id = 1, BrandId= 1, ColorId = 1, DailyPrice = 100, Description = "Desc 1", ModelYear = 2019},
                 new Car(){ Id = 2, BrandId= 1, ColorId = 1, DailyPrice = 150, Description = "Desc 2", ModelYear = 2020},
                 new Car(){ Id = 3, BrandId= 2, ColorId = 1, DailyPrice = 200, Description = "Desc 3", ModelYear = 2015},
                 new Car(){ Id = 4, BrandId= 2, ColorId = 2, DailyPrice = 220, Description = "Desc 3", ModelYear = 2020},
                 new Car(){ Id = 5, BrandId= 3, ColorId = 2, DailyPrice = 500, Description = "Desc 4", ModelYear = 2020},
                 new Car(){ Id = 6, BrandId= 3, ColorId = 3, DailyPrice = 600, Description = "Desc 5", ModelYear = 2021},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete  = _cars.SingleOrDefault(x => x.Id == car.Id);
            if (carToDelete != null)
            {
                _cars.Remove(carToDelete);
            }
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAllByBrand(int brandId)
        {
            return _cars.Where(x => x.BrandId == brandId).ToList();
        }

        public Car GetById(int Id)
        {
            return _cars.SingleOrDefault(x => x.Id == Id);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(x => x.Id == car.Id);
            if (carToUpdate != null)
            {
                carToUpdate.BrandId = car.BrandId;
                carToUpdate.ColorId = car.ColorId;
                carToUpdate.DailyPrice = car.DailyPrice;
                carToUpdate.Description = car.Description;
                carToUpdate.ModelYear = car.ModelYear;
            }
        }
    }
}