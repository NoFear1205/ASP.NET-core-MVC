using DomainLayer.Model;

namespace OnionArchitecture.Models
{
    public class PaginationPageModel
    {
        public int PageSize { get; set; }
        public int rowCount { get; set; }
        public int Page { get; set; }
        public string searchValue { get; set; }
        public int PageCount
        {
            get
            {
                if (PageSize == 0)
                {
                    return 1;
                }

                int p = rowCount / PageSize;

                if (rowCount % PageSize > 0)
                {
                    p++;
                }
                return p;
            }
        }
       

    }
}
