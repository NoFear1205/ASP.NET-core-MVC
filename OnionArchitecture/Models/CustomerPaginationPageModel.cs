using DomainLayer.Model;

namespace OnionArchitecture.Models
{
    public class CustomerPaginationPageModel : PaginationPageModel
    {
        public IList<Customer> Data { get; set; }
    }
}
