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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _cate;

        public CategoryService(ICategoryRepository cate)
        {
            _cate = cate;
        }

        public bool AddCategory(Category category)
        {
            return _cate.Add(category);
        }

        public int Count(string searchValue)
        {
            return _cate.Count(searchValue);
        }

        public bool DeleteCategory(Category category)
        {
            return _cate.Delete(category);
        }

        public IList<Category> GetAll(int page, int pageSize, string searchValue)
        {
            return _cate.ListOfCategories(page, pageSize, searchValue);
        }

        public IList<Category> GetAll()
        {
            return _cate.GetAll();
        }

        public Category GetById(int id)
        {
           return _cate.FindById(id);
        }

        public bool UpdateCategory(Category category)
        {
            return _cate.Update(category);
        }
    }
}
