using Business.Abstract;
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

        public string Delete(Brand brand)
        {
            _brandDAL.Delete(brand);
            return "brand deleted";
        }

        public List<Brand> GetAll()
        {
            return _brandDAL.GetAll();
        }

        public Brand GetById(int id)
        {
            return _brandDAL.Get(b => b.BrandId == id);
        }

        public string Insert(Brand brand)
        {
            _brandDAL.Add(brand);
            return "brand added";
        }

        public string Update(Brand brand)
        {
            _brandDAL.Update(brand);
            return "brand deleted";
        }
    }
}
