using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Implentation
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext applicationDbContext;
        public CustomerRepository(ApplicationDbContext dbContext)
        {
            applicationDbContext = dbContext;
        }
        public string AddCustomer(Customer customer)
        {
            try
            {
                applicationDbContext.Customers.Add(customer);
                applicationDbContext.SaveChanges();
                return "Successfull Add Customer";
            }catch (Exception ex)
            {
                return ex.Message;
            }
            
            
        }

        public int Count(string searchValue)
        {
            return applicationDbContext.Customers.Where(c=>c.CustomerName.Contains(searchValue)).Count();
        }

        public string DeleteCustomer(Customer customer)
        {
            try
            {
                applicationDbContext.Customers.Remove(customer);
                applicationDbContext.SaveChanges(true);
                return "Successfully delete record";
            }   
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Customer FindById(int id)
        {
            return applicationDbContext.Customers.Find(id);
        }

        public IList<Customer> ListOfCustomers(int page, int pageSize, string searchValue)
        {
            var data= applicationDbContext.Customers.Where((c)=>c.CustomerName.Contains(searchValue)).ToList();
            return data.Skip((page-1)*pageSize).Take(pageSize).ToList();
        }

        public string UpdateCustomer(Customer customer)
        {
            try
            {
                applicationDbContext.Customers.Update(customer);
                return "Successfully Update Customer";
            }catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
