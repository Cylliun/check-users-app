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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByUser([FromQuery] int userId)
        {
            var response = await _clockRepository.GetByUserIdAsync(userId);
            if (!response.Status)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
