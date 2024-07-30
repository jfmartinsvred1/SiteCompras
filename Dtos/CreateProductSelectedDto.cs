using SiteCompras.Models;

namespace SiteCompras.Dtos
{
    public class CreateProductSelectedDto
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
    }
}
