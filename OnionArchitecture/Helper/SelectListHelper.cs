using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceLayer.Service.Contact;

namespace OnionArchitecture.Helper
{
    public class SelectListHelper
    {
        private readonly ICategoryService _cate;

        public SelectListHelper(ICategoryService cate)
        {
            _cate = cate;
        }
        public List<SelectListItem> ListCategoriesItem()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem
            {
                Text = "---Chọn loại hàng---",
                Value = "0"
            });
            var data = _cate.GetAll();
            foreach(var item in data)
            {
                list.Add(new SelectListItem
                {
                    Value = item.CategoryID.ToString(),
                    Text = item.CategoryName
                });
            }
            return list;
        }
       
    }
}
