using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImageListed);
        }


        public IDataResult<List<CarImage>> GetById(int id)
        {
            IResult result = BusinessRules.Run(GetDefaultIfImageIsEmpty(id));

            if (result.Success)
            {
                return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.Id == id), Messages.CarImageListed);
            }

            return new ErrorDataResult<List<CarImage>>(result.Message);

        }


        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(
                CheckIfCarImageContLimit(carImage.CarId)
            );

            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            string filepath = _carImageDal.Get(p => p.Id == carImage.Id).ImagePath;

            carImage.ImagePath = FileHelper.Update(filepath, file);
            carImage.Date = DateTime.Now;

            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        public IResult Delete(CarImage carImage)
        {
            string filepath = _carImageDal.Get(p => p.Id == carImage.Id).ImagePath;

            bool isDeleted = FileHelper.Delete(filepath);

            if (isDeleted)
            {
                _carImageDal.Delete(carImage);
                return new SuccessResult(Messages.CarImageDeleted);
            }
            else
            {
                return new ErrorResult(Messages.CarImageCantDelete);
            }
        }

        private IResult CheckIfCarImageContLimit(int carid)
        {
            var carImagecount = _carImageDal.GetAll(i => i.CarId == carid).Count;

            if (carImagecount >= 5)
            {
                return new ErrorResult(Messages.CarImageCaountLimitFull);
            }

            return new SuccessResult();
        }

        private IResult GetDefaultIfImageIsEmpty(int carid)
        {
            bool exists = _carImageDal.GetAll(i => i.CarId == carid).Any();

            if (!exists)
            {
                try
                {
                    List<CarImage> carimage = new List<CarImage>();

                    string filePath = Directory.GetCurrentDirectory();
                    filePath = Path.Combine(filePath, "Upload", "Files");

                    filePath = Path.Combine(filePath, "default.jpg");

                    carimage.Add(new CarImage { CarId = carid, ImagePath = filePath, Date = DateTime.Now });

                    return new SuccessDataResult<List<CarImage>>(carimage);
                }
                catch (Exception exception)
                {
                    return new ErrorResult(exception.Message); ;
                }

            }

            return new SuccessResult();
        }

    }
}