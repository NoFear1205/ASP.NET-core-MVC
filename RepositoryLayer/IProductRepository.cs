using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public interface IProductRepository
    {
        public IList<Product> ListOfProduct(int page, int pageSize, string searchValue);
        public Product FindById(int id);
        public int Count(string searchValue);
        public string AddProduct(Product customer);
        public string UpdateProduct(Product customer);
        public string DeleteProduct(Product customer);
    }
}
