using DomainLayer.Model;
using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.Models;
using ServiceLayer.Service.Contact;
using System.Web;

namespace OnionArchitecture.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _product;
        public ProductController(IProductService product)
        {
            _product = product;
        }
        public IActionResult Index(int page, string searchValue)
        {
            if (searchValue == null)
                searchValue = "";
            int pageSize = 2;
            if (page <= 0)
                page = 1;
            IList<Product> list = _product.GetAll(page, pageSize, searchValue);
            ProductPaginationPageModel model = new ProductPaginationPageModel()
            {
                PageSize = pageSize,
                Page = page,
                searchValue = searchValue,
                rowCount = _product.Count(searchValue),
                Data = list
            };
            return View(model);
        }
        /*[Route("create")]*/
        public IActionResult Create()
        {
            return View();
        }
        /*[Route("save")]*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveAsync(Product model, IFormFile ImageString)
        {
            if(ImageString != null)
            {
                var fileTime = DateTime.UtcNow.ToString("yyMMddHHmmss");
                var fileName = fileTime + Path.GetFileName(ImageString.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "images", fileName);

                model.Image = $"/images/{fileName}";
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageString.CopyToAsync(fileStream);
                }
            }
            else
            {
                ModelState.AddModelError("Image", "không được để trống ảnh");
            }
            if(model.CategoryID == 0)
            {
                ModelState.AddModelError("Category", "Vui lòng chọn loại hàng");
            }
            if (ModelState.IsValid)
            {
                _product.AddProductRepo(model);
                return RedirectToAction("Index");
            }
            return View("Create", model);
/*            return Json(model);*/
        }
        /*[Route("update")]*/
        public IActionResult Update(int id)
        {
            var CustomerValue = _product.GetSingleRepo(id);
            return View(CustomerValue);
        }
        /*[Route("edit")]*/
        [HttpPost]
        public async Task<IActionResult> EditAsync(Product model,IFormFile? ImageString)
        {
            if (ImageString != null)
            {
                var fileTime = DateTime.UtcNow.ToString("yyMMddHHmmss");
                var fileName = fileTime + Path.GetFileName(ImageString.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "images", fileName);

                model.Image = $"/images/{fileName}";
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageString.CopyToAsync(fileStream);
                }
            }

            if (ModelState.IsValid)
            {
                _product.UpdateProductRepo(model);
                return RedirectToAction("Index");
            }
            return View("Update",model);
        }
        /*[Route("delete")]*/
        public IActionResult Delete(int id)
        {
            _product.DeleteProductRepo(id);
            return RedirectToAction("Index");
        }

    }
}
