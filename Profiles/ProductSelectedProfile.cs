using AutoMapper;
using SiteCompras.Dtos;
using SiteCompras.Models;

namespace SiteCompras.Profiles
{
    public class ProductSelectedProfile:Profile
    {
        public ProductSelectedProfile()
        {
            CreateMap<CreateProductSelectedDto, ProductSelected>();
        }
    }
}
