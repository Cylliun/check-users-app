using check_users.Data;
using check_users.Models;
using Microsoft.EntityFrameworkCore;

namespace check_users.Repositories
{
    public class PunchClockRepository : IPunchClockRepository
    {
        private readonly AppDbContext _context;

        public PunchClockRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PunchClock?> GetByUserIdAsync(int userId)
        {
            return await _context.clocks.FirstOrDefaultAsync(c => c.IdUser == userId);
        }

        public async Task<PunchClock?> GetTodayPunchAsync(int userId)
        {
            return await _context.clocks.FirstOrDefaultAsync(c =>
                c.IdUser == userId &&
                c.CheckInTime.Date == DateTime.Today);
        }

        public async Task CreateAsync(PunchClock punchClock)
        {
            await _context.clocks.AddAsync(punchClock);
        }

        public void Update(PunchClock punchClock)
        {
            _context.clocks.Update(punchClock);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}