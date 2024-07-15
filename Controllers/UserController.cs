using Microsoft.AspNetCore.Mvc;
using SiteCompras.Dtos;
using SiteCompras.Interfaces;

namespace SiteCompras.Controllers
{
    [Route("[Controller]")]
    public class UserController:ControllerBase
    {
        private IUserDao _userDao;

        public UserController(IUserDao userDao)
        {
            _userDao = userDao;
        }

        //Create
        [HttpPost("/create/admin")]
        public async Task<IActionResult> CreateAdmin([FromBody] CreateUserDto userDto)
        {
            await _userDao.Create(userDto,"Admin");
            return Ok("Criado Com Sucesso");
        }
        [HttpPost("/create/cliente")]
        public async Task<IActionResult> CreateCliente([FromBody] CreateUserDto userDto)
        {
            await _userDao.Create(userDto, "Cliente");
            return Ok("Criado Com Sucesso");
        }

        [HttpPost("/create/role")]
        public async Task<IActionResult> CreateRole([FromBody] string role)
        {
            await _userDao.CreateRole(role);
            return Ok("Criada com sucesso");
        }
    }
}
