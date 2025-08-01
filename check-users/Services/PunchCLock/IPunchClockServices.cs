using check_users.Dtos;
using check_users.Models;

namespace check_users.Services.PunchCLock
{
    public interface IPunchClockServices
    {
        Task<ResponseModel<PunchClock>> CreateAsync(PunchClockDto punchClockDto);
        Task<ResponseModel<PunchClock>> GetByUserIdAsync(int userId);
        Task<ResponseModel<PunchClock>> UpdateCheckOutAsync(PunchClockDto punchClockDto);
        Task<ResponseModel<PunchClock>> GetTodayPunchAsync(DateTime checkInTime);
    }
}
