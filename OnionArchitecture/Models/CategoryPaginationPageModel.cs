using DomainLayer.Model;

namespace OnionArchitecture.Models
{
    public class CategoryPaginationPageModel:PaginationPageModel
    {
        public IList<Category> Data { get; set; }
    }
}
