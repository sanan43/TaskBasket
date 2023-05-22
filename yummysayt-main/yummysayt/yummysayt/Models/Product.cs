using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace yummysayt.Models
{
    public class Product
    {
        
        public int Id { get; set; }
        public string ProductImage { get; set; }
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }
        public string Ingredient { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

    }
}
