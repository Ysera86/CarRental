using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDAL : IBrandDAL
    {
        List<Brand> _brands;
        public InMemoryBrandDAL()
        {
            _brands = new List<Brand>
            {
                new Brand{ BrandId=1, BrandName="Audi"},
                new Brand{ BrandId=2, BrandName="Peugeot"},
                new Brand{ BrandId = 3, BrandName="Lamborghini"}
            };
        }
        public void Add(Brand brand)
        {
            Brand brandToDelete = _brands.SingleOrDefault(b => b.BrandId == brand.BrandId);
            if (brandToDelete != null)
            {
                _brands.Add(brandToDelete); 
            }
        }

        public void Delete(Brand brand)
        {
            _brands.Remove(brand);
        }

        public List<Brand> GetAll()
        {
            return _brands;
        }

        public Brand GetById(int Id)
        {
            return _brands.SingleOrDefault(x => x.BrandId == Id);
        }

        public void Update(Brand brand)
        {
            Brand brandToUpdate = _brands.SingleOrDefault(x => x.BrandId == brand.BrandId);
            if (brandToUpdate != null)
            {
                brandToUpdate.BrandName = brand.BrandName;
            }
        }
    }
}
