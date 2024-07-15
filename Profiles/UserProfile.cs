using AutoMapper;
using SiteCompras.Dtos;
using SiteCompras.Models;

namespace SiteCompras.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>();
        }
    }
}
