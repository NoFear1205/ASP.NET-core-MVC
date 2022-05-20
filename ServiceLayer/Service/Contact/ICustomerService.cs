using DomainLayer.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.Contact
{
    public interface ICustomerService
    {
        //GetAll record
        IList<Customer> GetAll(int page, int pageSize, string searchValue = "");
        //Get Single record
        Customer GetSingleRepo(int id);
        //Add record
        string AddCustomerRepo(Customer customer);
        //Update or edit record
        string UpdateCustomerRepo(Customer customer);
        //Delete or remove
        string DeleteCustomerRepo(int id);
        int Count(string searchValue);

    }
}
