﻿using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public interface ICustomerRepository
    {
        public IList<Customer> ListOfCustomers(int page, int pageSize, string searchValue);
        public Customer FindById(int id);
        public int Count(string searchValue);
        public string AddCustomer(Customer customer);
        public string UpdateCustomer(Customer customer);
        public string DeleteCustomer(Customer customer);
    }
}
