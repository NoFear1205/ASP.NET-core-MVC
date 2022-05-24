using System.ComponentModel.DataAnnotations;

namespace OnionArchitecture.Models.Mapper
{
    public class ProductDTO
    {
        [Key]
        public int Id { get; set; }
        public string? Image { get; set; }
        [Required(ErrorMessage ="Tên sản phẩm không được để trống")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Tên nhà cung cấp không được để trống")]
        public string? Provider { get; set; }
        public string? CategoryName { get; set; }
        public int CategoryID { get; set; }
    }
}
