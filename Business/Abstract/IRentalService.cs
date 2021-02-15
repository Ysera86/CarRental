using Core.Utilities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<RentalDetailDTO>> ListAllRentalInfo();
        IDataResult<List<RentalDetailDTO>> ListRentalInfoOfCar(Car car);
        IResult RentACar(Rental rental);
        IResult ReturnACar(Rental rental);
        IResult IsCarAvailable(Rental rental);
        IResult DeleteRentalInfo(Rental rental);
    }
}
