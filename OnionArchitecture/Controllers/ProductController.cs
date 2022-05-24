using AutoMapper;
using DomainLayer.Model;
using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.Models;
using OnionArchitecture.Models.Mapper;
using ServiceLayer.Service.Contact;
using System.Web;

namespace OnionArchitecture.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _product;
        private readonly IMapper _mapper;
        public ProductController(IProductService product, IMapper mapper)
        {
            _product = product;
            _mapper = mapper;
        }
        public IActionResult Index(int page, string searchValue)
        {
            if (searchValue == null)
                searchValue = "";
            int pageSize = 2;
            if (page <= 0)
                page = 1;
            IList<Product> list = _product.GetAll(page, pageSize, searchValue);
            List<ProductDTO> dto = new List<ProductDTO>();
            foreach(var item in list)
            {
                dto.Add(_mapper.Map<ProductDTO>(item));
            }
            ProductPaginationPageModel model = new ProductPaginationPageModel()
            {
                PageSize = pageSize,
                Page = page,
                searchValue = searchValue,
                rowCount = _product.Count(searchValue),
                Data = dto
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
        public async Task<IActionResult> SaveAsync(ProductDTO result, IFormFile ImageString)
        {
            var model = _mapper.Map<Product>(result);
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
            if (CustomerValue == null)
                return RedirectToAction("Index");
            return View(CustomerValue);
        }
        /*[Route("edit")]*/
        [HttpPost]
        public async Task<IActionResult> EditAsync(ProductDTO result,IFormFile? ImageString)
        {
            var model = _mapper.Map<Product>(result);    
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
