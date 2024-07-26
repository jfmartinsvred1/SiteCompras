using System.ComponentModel.DataAnnotations;

namespace SiteCompras.Dtos
{
    public class CreateProductDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
