using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SiteCompras.Dtos;
using SiteCompras.Interfaces;
using SiteCompras.Models;

namespace SiteCompras.Data.Dao
{
    public class ProductDao : IProductDao
    {
        private AppDbContext _appDbContext;
        private IMapper _mapper;

        public ProductDao(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task AddOrRemoveInStock(int amount, int productId)
        {
            var product = await _appDbContext.Products.FirstOrDefaultAsync(x => x.ProductId == productId);
            if (product == null)
            {
                throw new Exception("Produto não existem, ou id errado");
            }
            if((product.Amount+amount)<0) 
            {
                throw new Exception("Remocao maior que itens em estoque");
            }
            product.Amount += amount;
            _appDbContext.Products.Update(product);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Create(CreateProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _appDbContext.Products.AddAsync(product);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAll()
        {
            var products = await _appDbContext.Products.ToListAsync();
            return products;
        }

    }
}
