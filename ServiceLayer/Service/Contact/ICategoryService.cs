using DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.Contact
{
    public interface ICategoryService
    {
        IList<Category> GetAll(int page, int pageSize, string searchValue);
        IList<Category> GetAll();
        Category GetById(int id);
        bool   AddCategory(Category category);
        bool DeleteCategory(Category category);
        bool UpdateCategory(Category category);
        int Count(string searchValue);
        bool InUsed(int categoryID);
    }
}
