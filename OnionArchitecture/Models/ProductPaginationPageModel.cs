using DomainLayer.Model;
using OnionArchitecture.Models.Mapper;

namespace OnionArchitecture.Models
{
    public class ProductPaginationPageModel : PaginationPageModel
    {
        public IList<ProductDTO>? Data { get; set; }
    }
}
