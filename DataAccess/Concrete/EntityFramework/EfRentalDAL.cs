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
    public class EfRentalDAL : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDAL
    {
        public List<RentalDetailDTO> GetRentalDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rentals
                             join cr in context.Cars
                                 on r.CarId equals cr.Id
                             join cstm in context.Customers
                                 on r.CustomerId equals cstm.Id
                             select new RentalDetailDTO
                             {
                                 CarId= cr.Id,
                                 CarName = cr.Name,
                                 CustomerName = cstm.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate

                             };

                return result.ToList();
            }
        }

        public List<RentalDetailDTO> GetRentalDetailsOfCar(Expression<Func<RentalDetailDTO, bool>> filter)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = GetRentalDetails().Where(filter.Compile());
                return result.ToList();
            }
        }
    }
}
