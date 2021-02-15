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
            //CarManager carManager = new CarManager(new EfCarDAL());
            //GetAll(carManager);
            //Console.WriteLine("-------------------------------------------------");
            //GetCarsByBrandId(carManager);
            //Console.WriteLine("-------------------------------------------------");
            //GetCarsByColorId(carManager);
            //Console.WriteLine("-------------------------------------------------");
            //AddCar(carManager);
            //Console.WriteLine("-------------------------------------------------");
            //Console.WriteLine(carManager.GetById(4).Data.Name);

            UserManager userManager = new UserManager(new EfUserDAL());
            //Console.WriteLine(userManager.Insert(new User { FirstName = "Kullanıcı1", LastName = "Soyad1", Email = "kullanici1@test.com", Password = "test" }).Message);
            //foreach (var user in userManager.GetAll().Data)
            //{
            //    Console.WriteLine("{0} - {1}", user.FirstName, user.LastName);
            //}

            CustomerManager customerManager = new CustomerManager(new EfCustomerDAL());
            //Console.WriteLine(customerManager.Insert(new Customer { UserId = 1, CompanyName = "Test Company" }).Message);
            //foreach (var customer in customerManager.GetAll().Data)
            //{
            //    Console.WriteLine("{0}", customer.CompanyName);
            //}

            RentalManager rentalManager = new RentalManager(new EfRentalDAL());
            //Rental rental = new Rental { CarId = 1, CustomerId = 1, RentDate = DateTime.Now };
            //RentACar(rentalManager, rental);
            //ReturnACar(rentalManager, rental);

            //Rental rental2 = new Rental { CarId = 1, CustomerId = 1, RentDate = DateTime.Now };
            //Console.WriteLine(RentACar(rentalManager, rental2));
            //Console.WriteLine(RentACar(rentalManager, rental2));

            Rental rental3 = new Rental { CarId = 3, CustomerId = 1, RentDate = DateTime.Now };
            Console.WriteLine(RentACar(rentalManager, rental3));
            Console.WriteLine(ReturnACar(rentalManager, rental3));

            foreach (var rentalDetail in rentalManager.ListAllRentalInfo().Data)
            {
                Console.WriteLine("{0} - {1} - {2} - {3}", rentalDetail.CarName, rentalDetail.CustomerName, rentalDetail.RentDate, rentalDetail.ReturnDate);
            }
        }


        private static string RentACar(RentalManager rentalManager, Rental rental)
        {
            var message = "";
            if (rental.ReturnDate != null)
            {
                message += "RentDate cant be selected, will be set to null. ";
            }
            if (!string.IsNullOrEmpty(message))
            {
                Console.WriteLine(message);
            }
            rental.RentDate = DateTime.Now;
            rental.ReturnDate = null;
            var mesaj = rentalManager.RentACar(rental).Message;
            return mesaj;
        }
        private static string ReturnACar(RentalManager rentalManager, Rental rental)
        {
            if (rental.ReturnDate != null)
            {
                Console.WriteLine("ReturnDate cant be selected, will be set to now");
            }
            rental.ReturnDate = DateTime.Now;
            return rentalManager.ReturnACar(rental).Message;
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
            Console.WriteLine(carManager.Insert(newCar));
        }

        private static void GetCarsByColorId(CarManager carManager)
        {
            foreach (var car in carManager.GetCarsByColorId(1).Data)
            {
                Console.WriteLine(car.Name);
            }
        }

        private static void GetCarsByBrandId(CarManager carManager)
        {
            foreach (var car in carManager.GetCarsByBrandId(1).Data)
            {
                Console.WriteLine(car.Name);
            }
        }

        private static void GetAll(CarManager carManager)
        {
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Name);
            }
        }
    }
}
