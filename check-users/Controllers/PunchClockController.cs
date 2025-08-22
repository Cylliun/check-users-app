using check_users.Dtos;
using check_users.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace check_users.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PunchClockController : Controller
    {
        private readonly IPunchClockServices _clockRepository;
        public PunchClockController(IPunchClockServices clockRepository)
        {   
            _clockRepository = clockRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateClock([FromBody] PunchClockDto punchClockDto)
        {
            var response = await _clockRepository.CreateAsync(punchClockDto);
            if (!response.Status)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("/user/{id}")]
        public async Task<IActionResult> GetByUserId([FromRoute] int userId)
        {
            var response = await _clockRepository.GetByUserIdAsync(userId);
            if (!response.Status)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("today")]
        public async Task<IActionResult> GetTodayPunchClock([FromQuery] int userId)
        {
            var response = await _clockRepository.GetTodayPunchAsync(userId);
            if (!response.Status)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}

