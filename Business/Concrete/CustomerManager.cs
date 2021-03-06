﻿using Business.Abstract;
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
    public class CustomerManager : ICustomerService
    {
        ICustomerDAL _customerDAL;

        public CustomerManager(ICustomerDAL customerDAL)
        {
            _customerDAL = customerDAL;
        }

        public IResult Delete(Customer customer)
        {
            _customerDAL.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDAL.GetAll());
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Insert(Customer customer)
        {
            //if (customer.UserId > 0)
            //{
            //    _customerDAL.Add(customer);
            //    return new SuccessResult(Messages.CustomerAdded);
            //}
            //return new ErrorResult(Messages.CustomerNotAddedUserId);

            //if (customer.UserId > 0)
            //{
            //    _customerDAL.Add(customer);
            //    return new SuccessResult(Messages.CustomerAdded);
            //}
            //return new ErrorResult(Messages.CustomerNotAddedUserId);

            //ValidationTool.Validate(new CustomerValidator(), customer);

            _customerDAL.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Update(Customer customer)
        {
            _customerDAL.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
