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
            try
            {
                _db.AddProduct(product);
                return "Successfully add";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string DeleteProductRepo(int id)
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
                    _db.DeleteProduct(data);
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
            var ProductValue = _db.FindById(product.Id);
            if (ProductValue == null)
            {
                return "No record Found";
            }
            else
            {              
                _db.UpdateProduct(ProductValue);
                return "Successfully Update";
            }
        }
    }
}
