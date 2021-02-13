using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ReCapProject
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDAL());
            //GetAll(carManager);
            //Console.WriteLine("-------------------------------------------------");
            //GetCarsByBrandId(carManager);
            //Console.WriteLine("-------------------------------------------------");
            //GetCarsByColorId(carManager);
            //Console.WriteLine("-------------------------------------------------");
            //AddCar(carManager);
            //Console.WriteLine("-------------------------------------------------");
            Console.WriteLine(carManager.GetById(4).Name);
        }

        private static void AddCar(CarManager carManager)
        {
            Car newCar = new Car
            {
                BrandId = 2,
                ColorId = 3,
                DailyPrice = 95,
                Description = "deneme",
                ModelYear = 2019,
                Name = "test Car"
            };
            Console.WriteLine(carManager.AddCar(newCar));
        }

        private static void GetCarsByColorId(CarManager carManager)
        {
            foreach (var car in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine(car.Name);
            }
        }

        private static void GetCarsByBrandId(CarManager carManager)
        {
            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(car.Name);
            }
        }

        private static void GetAll(CarManager carManager)
        {
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Name);
            }
        }
    }
}
