using SiteCompras.Dtos;
using SiteCompras.Models;

namespace SiteCompras.Interfaces
{
    public interface IProductDao
    {
        Task Create(CreateProductDto productDto);
        Task AddOrRemoveInStock(int amount, int productId);
        Task<List<Product>> GetAll();
        Task AddProductInCart(CreateProductSelectedDto dto);
    }
}
