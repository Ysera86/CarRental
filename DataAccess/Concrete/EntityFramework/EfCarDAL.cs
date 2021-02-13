using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDAL : EfEntityRepositoryBase<Car, RentACarContext>, ICarDAL
    {
        public List<CarDetailDTO> GetCarDetails()
        {
            using (RentACarContext context= new RentACarContext())
            {
                var result = from cr in context.Cars
                             join b in context.Brands on cr.BrandId equals b.BrandId
                             join cl in context.Colors on cr.ColorId equals cl.Id
                             select new CarDetailDTO
                             {
                                 CarName = cr.Name,
                                 BrandName = b.BrandName,
                                 ColorName = cl.Name,
                                 DailyPrice = cr.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
