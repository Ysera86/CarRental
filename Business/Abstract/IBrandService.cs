using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        List<Brand> GetAll();
        Brand GetById(int id);
        string Insert(Brand Brand);
        string Update(Brand Brand);
        string Delete(Brand Brand);
    }
}
