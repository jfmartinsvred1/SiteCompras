using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SiteCompras.Dtos;
using SiteCompras.Interfaces;
using SiteCompras.Models;

namespace SiteCompras.Data.Dao
{
    public class UserDao : IUserDao
    {
        private IMapper _mapper;
        private UserManager<User> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public UserDao(IMapper mapper, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Create(CreateUserDto userDto, string role)
        {
            var user = _mapper.Map<User>(userDto);
            IdentityResult result = await _userManager.CreateAsync(user, userDto.Password);
            await _userManager.AddToRoleAsync(user, role);
            if (!result.Succeeded)
            {
                throw new Exception("Error Create");
            }
        }

        public async Task CreateRole(string name)
        {
            var result = await _roleManager.CreateAsync(new IdentityRole(name));

            if(!result.Succeeded) 
            {
                throw new Exception("Error Create");
            }

        }
    }
}
