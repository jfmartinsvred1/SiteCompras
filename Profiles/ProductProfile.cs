using AutoMapper;
using SiteCompras.Dtos;
using SiteCompras.Models;

namespace SiteCompras.Profiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductDto, Product>();
        }
    }
}
