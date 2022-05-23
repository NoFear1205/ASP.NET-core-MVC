using DomainLayer.Model;
using RepositoryLayer;
using ServiceLayer.Service.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.Implentation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _db;
        public ProductService(IProductRepository productRepository)
        {
            _db = productRepository;
        }
        /// <summary>
        /// Add Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string AddProductRepo(Product product)
        {
                return _db.AddProduct(product);
        }

        public string DeleteProductRepo(int id)
        {

                var data = _db.FindById(id);
                return _db.DeleteProduct(data);

        }
        /// <summary>
        /// Get All Customer record
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IList<Product> GetAll(int page, int pageSize, string searchValue)
        {
            if (page <= 0)
            {
                page = 1;
            }
            if (pageSize <= 0)
            {
                pageSize = 10;
            }
            if (searchValue == null)
            {
                searchValue = "";
            }
            return _db.ListOfProduct(page, pageSize, searchValue);
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
        public Product GetSingleRepo(int id)
        {
            //return _db.Customers.Where(c=>c.CustomerID==id).FirstOrDefault();
            return _db.FindById(id);
        }

        public string UpdateProductRepo(Product product)
        {
                return _db.UpdateProduct(product);
        }
    }
}
