using DomainLayer.Model;
using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.Models;
using ServiceLayer.Service.Contact;

namespace OnionArchitecture.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _cate;
        public CategoryController(ICategoryService category)
        {
            _cate = category;
        }
        public IActionResult Index(int page, string searchValue)
        {
            if (searchValue == null)
                searchValue = "";
            int pageSize = 2;
            if (page <= 0)
                page = 1;
            IList<Category> list = _cate.GetAll(page, pageSize, searchValue);
            CategoryPaginationPageModel model = new CategoryPaginationPageModel()
            {
                Page = page,
                PageSize = pageSize,
                searchValue = searchValue,
                rowCount = _cate.Count(searchValue),
                Data = list
            };
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Category model)
        {
            if (ModelState.IsValid)
            {
                _cate.AddCategory(model);
                return RedirectToAction("Index");
            }
            return View("Create", model);
        }

        public IActionResult Update(int id)
        {
            var CustomerValue = _cate.GetById(id);
            return View(CustomerValue);
        }
        [HttpPost]
        public IActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                _cate.UpdateCategory(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var model = _cate.GetById(id);
            _cate.DeleteCategory(model);
            return RedirectToAction("Index");
        }
    }
}
