using DomainLayer.Model;
using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.Models;
using ServiceLayer.Service.Contact;

namespace OnionArchitecture.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customer;
        public CustomerController(ICustomerService customer)
        {
            _customer = customer;
        }
        public IActionResult Index(int page, string searchValue)
        {
            if (searchValue == null)
                searchValue = "";
            int pageSize = 2;
            if(page <= 0)
                page = 1;
            IList<Customer> list = _customer.GetAll(page, pageSize, searchValue);
            CustomerPaginationPageModel model = new CustomerPaginationPageModel()
            {
                Page = page,
                PageSize = pageSize,
                searchValue = searchValue,
                rowCount = _customer.Count(searchValue),
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
        public IActionResult Save(Customer model)
        {
            if (ModelState.IsValid)
                {
                    _customer.AddCustomerRepo(model);
                    return RedirectToAction("Index");
                } 
            return View("Create",model);
        }
        
        public IActionResult Update(int id)
        {
            var CustomerValue = _customer.GetSingleRepo(id);
            return View(CustomerValue);
        }
        [HttpPost]
        public IActionResult Edit(Customer model)
        {
            if(ModelState.IsValid)
            {
                _customer.UpdateCustomerRepo(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        
        public IActionResult Delete(int id)
        {
            _customer.DeleteCustomerRepo(id);
            return RedirectToAction("Index");
        }
    }
}
