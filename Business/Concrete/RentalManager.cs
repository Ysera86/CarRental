using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDAL _rentalDAL;

        public RentalManager(IRentalDAL rentalDAL)
        {
            _rentalDAL = rentalDAL;
        }

        public IResult DeleteRentalInfo(Rental rental)
        {
            _rentalDAL.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IResult IsCarAvailable(Rental rental)
        {
            var rented = _rentalDAL.Get(r => r.CarId == rental.CarId && r.ReturnDate == null);
            if (rented != null)
            {
                return new ErrorResult(Messages.CarNotReturned);
            }
            return new SuccessResult(Messages.CarAvailable);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult RentACar(Rental rental)
        {
            if (IsCarAvailable(rental).Success)
            {
                //ValidationTool.Validate(new RentalValidator(), rental);

                _rentalDAL.Add(rental);
                return new SuccessResult(Messages.CarRented);
            }
            return new ErrorResult(Messages.CarNotReturned);
        }

        public IResult ReturnACar(Rental rental)
        {
            if (!IsCarAvailable(rental).Success)
            {
                _rentalDAL.Update(rental);
                return new SuccessResult(Messages.CarReturned);
            }
            return new ErrorResult(Messages.CarNotReturned);
        }

        public IDataResult<List<RentalDetailDTO>> ListAllRentalInfo()
        {
            return new SuccessDataResult<List<RentalDetailDTO>>(_rentalDAL.GetRentalDetails());
        }

        public IDataResult<List<RentalDetailDTO>> ListRentalInfoOfACar(int carId)
        {
            return new SuccessDataResult<List<RentalDetailDTO>>(_rentalDAL.GetRentalDetailsOfCar(r => r.CarId == carId));
        }


    }
}
