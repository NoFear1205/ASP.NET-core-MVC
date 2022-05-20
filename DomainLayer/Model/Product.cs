using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string? Image { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Provider { get; set; }
        public int CategoryID { get; set; }
        public Category? Category { get; set; }  
        
    }
}
