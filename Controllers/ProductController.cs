using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiteCompras.Dtos;
using SiteCompras.Interfaces;
using SiteCompras.Models;

namespace SiteCompras.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private IProductDao _productDao;

        public ProductController(IProductDao productDao)
        {
            _productDao = productDao;
        }
        //Colocar authorize
        [HttpGet]
        [Authorize]
        public async Task<List<Product>> GetAll()
        {
            return await _productDao.GetAll();
        }
        [HttpPost("create")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Create(CreateProductDto productDto)
        {
            await _productDao.Create(productDto);

            return Ok("Produto Inserido Com Sucesso");

        }
        [HttpPost("updateAmount/{amount}/{productId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAmount(int amount,int productId)
        {
            await _productDao.AddOrRemoveInStock(amount,productId);

            return Ok("Quantidade Alterada Com Sucesso");

        }

    }
}
