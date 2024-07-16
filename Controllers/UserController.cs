using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiteCompras.Dtos;
using SiteCompras.Interfaces;

namespace SiteCompras.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController:ControllerBase
    {
        private IUserDao _userDao;

        public UserController(IUserDao userDao)
        {
            _userDao = userDao;
        }

        //Create
        [HttpPost("create/admin")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> CreateAdmin([FromBody] CreateUserDto userDto)
        {
            await _userDao.Create(userDto,"Admin");
            return Ok("Criado Com Sucesso");
        }
        [HttpPost("create/cliente")]
        public async Task<IActionResult> CreateCliente([FromBody] CreateUserDto userDto)
        {
            await _userDao.Create(userDto, "Cliente");
            return Ok("Criado Com Sucesso");
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserDto dto)
        {
            var token = await _userDao.Login(dto);
            return Ok(token);
        }
    }
}
