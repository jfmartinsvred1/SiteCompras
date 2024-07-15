using Microsoft.AspNetCore.Mvc;
using SiteCompras.Dtos;

namespace SiteCompras.Interfaces
{
    public interface IUserDao
    {
        Task Create(CreateUserDto userDto, string role);
        Task CreateRole(string name);
    }
}
