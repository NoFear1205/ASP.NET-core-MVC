using DomainLayer.Model;

namespace OnionArchitecture.Models
{
    public class ProductPaginationPageModel : PaginationPageModel
    {
        public IList<Product>? Data { get; set; }
    }
}
