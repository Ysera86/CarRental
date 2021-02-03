using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ReCapProject
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDAL());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

           
        }
    }
}
