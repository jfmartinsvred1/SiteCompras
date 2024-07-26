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
        [HttpPost("create/manager")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> CreateManager([FromBody] CreateUserDto userDto)
        {
            await _userDao.Create(userDto,"Manager");
            return Ok("Criado Com Sucesso");
        }
        [HttpPost("create/client")]
        public async Task<IActionResult> CreateCliente([FromBody] CreateUserDto userDto)
        {
            await _userDao.Create(userDto, "Client");
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
