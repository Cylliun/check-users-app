using check_users.Models;

namespace check_users.Repositories
{
    public interface IPunchClockRepository
    {
        Task<ResponseModel<PunchClock>> CreateAsync(PunchClock punchClock);
        Task<ResponseModel<PunchClock>> GetByUserIdAsync (int userId);
        Task<ResponseModel<PunchClock>> UpdateCheckOutAsync(DateTime? checkOutTime);
        Task<ResponseModel<PunchClock>> GetTodayPunchAsync(DateTime checkInTime);
    }
}
