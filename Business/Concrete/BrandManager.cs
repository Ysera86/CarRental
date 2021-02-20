using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDAL _brandDAL;

        public BrandManager(IBrandDAL brandDAL)
        {
            _brandDAL = brandDAL;
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Insert(Brand brand)
        {
            //ValidationTool.Validate(new BrandValidator(), brand);

            _brandDAL.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Update(Brand brand)
        {
            _brandDAL.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }


        public IResult Delete(Brand brand)
        {
            _brandDAL.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        IDataResult<List<Brand>> IBrandService.GetAll()
        {
            var brands = _brandDAL.GetAll();
            if (brands != null && brands.Count > 0)
            {
                return new SuccessDataResult<List<Brand>>(brands, Messages.BrandsListed);
            }
            return new ErrorDataResult<List<Brand>>(Messages.BrandNotFoundToList);
        }

        IDataResult<Brand> IBrandService.GetById(int id)
        {
            var brand = _brandDAL.Get(b => b.Id == id);
            if (brand != null)
            {
                return new SuccessDataResult<Brand>(brand, Messages.BrandListed);
            }
            else
            {
                return new ErrorDataResult<Brand>(Messages.BrandNotFoundToList);
            }
        }




    }
}
