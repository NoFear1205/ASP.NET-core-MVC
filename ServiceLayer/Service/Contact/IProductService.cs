using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.Contact
{
    public interface IProductService
    {
        //GetAll record
        IList<Product> GetAll(int page, int pageSize, string searchValue = "");
        //Get Single record
        Product GetSingleRepo(int id);
        //Add record
        string AddProductRepo(Product product);
        //Update or edit record
        string UpdateProductRepo(Product product);
        //Delete or remove
        string DeleteProductRepo(int id);
        int Count(string searchValue);
    }
}
