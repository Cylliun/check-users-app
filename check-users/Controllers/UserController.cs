using check_users.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace check_users.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            var response = await _userServices.CreateUserAsync(userDto);
            if (!response.Status)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);
        }

        [HttpGet("email")]
        public async Task<IActionResult> Email(UserDto userDto)
        {
            var response = await _userServices.GetByEmailAsync(userDto);
            if (!response.Status)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Id(string Id)
        {
            var response = await _userServices.GetByIdAsync(Id);
            if (!response.Status)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);
        }

    }
}
