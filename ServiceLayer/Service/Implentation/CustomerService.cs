using DomainLayer.Model;
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
            try
            {
                _db.AddCustomer(customer);
                return "Successfully add";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string DeleteCustomerRepo(int id)
        {
            try
            {
                var data = _db.FindById(id);
                if (data == null)
                {
                    return "Not found record";
                }
                else
                {
                    _db.DeleteCustomer(data);
                    return "Successfully remove";
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

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
            var CustomerValue = _db.FindById(customer.CustomerID);
            if (CustomerValue == null)
            {
                return "No record Found";
            }
            else
            {
                if (customer.CustomerName != null)
                    CustomerValue.CustomerName = customer.CustomerName;
                if (customer.Address != null)
                    CustomerValue.Address = customer.Address;
                if (CustomerValue.Phone != null)
                    CustomerValue.Phone = customer.Phone;
                _db.UpdateCustomer(CustomerValue);
                return "Successfully Update";
            }
        }
    }
}
