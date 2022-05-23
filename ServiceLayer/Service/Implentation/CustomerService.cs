﻿using DomainLayer.Model;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using ServiceLayer.Service.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.Implentation
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _db;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _db = customerRepository;
        }
        /// <summary>
        /// Add Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string AddCustomerRepo(Customer customer)
        {
                return _db.AddCustomer(customer);
        }

        public string DeleteCustomerRepo(int id)
        {

            var data = _db.FindById(id);
            return _db.DeleteCustomer(data);
        }
        /// <summary>
        /// Get All Customer record
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IList<Customer> GetAll(int page, int pageSize, string searchValue)
        {
            if(page <= 0)
            {
                page = 1;
            }
            if(pageSize <= 0)
            {
                pageSize = 10;
            }
            if(searchValue == null)
            {
                searchValue = "";
            }
            return _db.ListOfCustomers(page, pageSize, searchValue);
        }
        public int Count(string searchValue)
        {
            var data = _db.Count(searchValue);
            return data;
        }
        /// <summary>
        /// Get single record Customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Customer GetSingleRepo(int id)
        {
            //return _db.Customers.Where(c=>c.CustomerID==id).FirstOrDefault();
            return _db.FindById(id);
        }

        public string UpdateCustomerRepo(Customer customer)
        {
            return _db.UpdateCustomer(customer);
        }
    }
}
