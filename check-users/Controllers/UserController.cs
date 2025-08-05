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

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody]UserDto userDto)
        {
            var response = await _userServices.CreateUserAsync(userDto);
            if (!response.Status)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("email")]
        public async Task<IActionResult> Email([FromQuery] string email)
        {
            var response = await _userServices.GetByEmailAsync(email);
            if (!response.Status)
            {
                return BadRequest(response);
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
