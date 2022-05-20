using DomainLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Implentation
{
    public class ProductRepository:IProductRepository
    {
        private readonly ApplicationDbContext applicationDbContext;
        public ProductRepository(ApplicationDbContext dbContext)
        {
            applicationDbContext = dbContext;
        }
        public string AddProduct(Product product)
        {
            try
            {
                applicationDbContext.Products.Add(product);
                applicationDbContext.SaveChanges();
                return "Successfull Add Customer";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }


        }

        public int Count(string searchValue)
        {
            return applicationDbContext.Products.Where(c => c.Name.Contains(searchValue)).Count();
        }

        public string DeleteProduct(Product product)
        {
            try
            {
                applicationDbContext.Products.Remove(product);
                applicationDbContext.SaveChanges(true);
                return "Successfully delete record";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Product FindById(int id)
        {
            return applicationDbContext.Products.Where(x=>x.Id==id).FirstOrDefault();
        }

        public IList<Product> ListOfProduct(int page, int pageSize, string searchValue)
        {
            var data = applicationDbContext.Products.Include(c=>c.Category).Where((c) => c.Name.Contains(searchValue)).ToList();
            return data.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public string UpdateProduct(Product product)
        {
            try
            {
                applicationDbContext.Products.Update(product);
                applicationDbContext.SaveChanges();
                return "Successfully Update Customer";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
