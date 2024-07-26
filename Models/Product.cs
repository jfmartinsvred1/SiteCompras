using System.ComponentModel.DataAnnotations;

namespace SiteCompras.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; } = 0;

    }
}
