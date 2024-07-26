using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SiteCompras.Dtos;
using SiteCompras.Interfaces;
using SiteCompras.Models;
using SiteCompras.Services;

namespace SiteCompras.Data.Dao
{
    public class UserDao : IUserDao
    {
        private IMapper _mapper;
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private TokenService _tokenService;
        private RoleManager<IdentityRole> _roleManager;


        public UserDao(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, TokenService tokenService, RoleManager<IdentityRole> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _roleManager = roleManager;
        }

        public async Task Create(CreateUserDto userDto, string role)
        {
            var user = _mapper.Map<User>(userDto);
            IdentityResult result = await _userManager.CreateAsync(user, userDto.Password);
            if (!await _roleManager.RoleExistsAsync(role)) 
            {
                await CreateRoleAsync(role);
            }
            await AddInToRole(user, role);
            if (!result.Succeeded)
            {
                throw new Exception("Error Create");
            }
        }


        public async Task<string> Login(LoginUserDto userDto)
        {
            var resultado = await _signInManager.PasswordSignInAsync(userDto.Username, userDto.Password, false, false);

            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Usuario nao autenticado");
            }
            var user = _mapper.Map<User>(userDto);
            var roles = await ReturnRolesUser(user);
            //var roles2 = await _userManager.GetRolesAsync(user);
            //Esse metodo nao ta funcionando
            var token = _tokenService.GenerateToken(user, roles);
            return token;
        }
        public async Task CreateRoleAsync(string roleName)
        {
            await _roleManager.CreateAsync(new IdentityRole(roleName));
        }

        public async Task AddInToRole(User user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task<List<string>> ReturnRolesUser(User user)
        {
            var usersAdmin = await _userManager.GetUsersInRoleAsync("Admin");
            var usersCliente = await _userManager.GetUsersInRoleAsync("Client");
            var usersManager = await _userManager.GetUsersInRoleAsync("Manager");

            var list = new List<string>();
            foreach (var userAdmin in usersAdmin)
            {
                if (userAdmin.UserName == user.UserName)
                {
                    list.Add("Admin");
                }
            }
            foreach (var userManager in usersManager)
            {
                if (userManager.UserName == user.UserName)
                {
                    list.Add("Manager");
                }
            }
            foreach (var userCliente in usersCliente)
            {
                if (userCliente == user)
                {
                    list.Add("Client");
                }
            }
            return list;
        }
    }
}
