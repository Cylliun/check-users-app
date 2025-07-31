using check_users.Models;

namespace check_users
{
    public interface IPunchClockRepository
    {
        Task<PunchClock?> CreateAsync(PunchClock punchClock);
        Task<PunchClock?> GetByUserIdAsync(int userId);
        Task<PunchClock?> GetTodayPunchAsync(int userId);
        void Update(PunchClock punchClock);
        Task SaveChangesAsync();
    }
}
