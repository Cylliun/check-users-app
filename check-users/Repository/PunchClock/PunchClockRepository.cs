using check_users.Data;
using check_users.Models;
using Microsoft.EntityFrameworkCore;

namespace check_users
{
    public class PunchClockRepository : IPunchClockRepository
    {
        private readonly AppDbContext _context;
        public PunchClockRepository( AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<PunchClock>> CreateAsync(PunchClock punchClock)
        {
            ResponseModel<PunchClock> response = new ResponseModel<PunchClock>();

            try
            {

                _context.clocks.Add(punchClock);
                await _context.SaveChangesAsync();

                response.Dados = punchClock;
                response.Message = "Acessado com sucesso";
                response.Status = true;

            }
            catch (Exception ex) 
            {
                response.Message = ex.Message;
                response.Status = false;
            }

            return response;

        }

        public async Task<ResponseModel<PunchClock>> GetByUserIdAsync(int userId)
        {
            ResponseModel<PunchClock> response = new ResponseModel<PunchClock>();

            try
            {
               var user = await _context.clocks.FindAsync(userId);

                response.Dados = user;
                response.Message = "usuário encontrado com sucesso";
                response.Status = true;

            }
            catch (Exception ex) 
            {
                response.Message = ex.Message;
                response.Status = false;
            }

            return response;

        }

        public async Task<ResponseModel<PunchClock>> GetTodayPunchAsync(DateTime checkInTime)
        {
            ResponseModel<PunchClock> response = new ResponseModel<PunchClock>();

            try
            {

                var checkIn = await _context.clocks.SingleOrDefaultAsync(c => c.CheckInTime.Date == checkInTime);

                response.Dados = checkIn;
                response.Message = "Verificação de Check-in realizada com sucesso";
                response.Status = true;
               

            } catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
            }

            return response;
        }

        public async Task<ResponseModel<PunchClock>> UpdateCheckOutAsync(PunchClock punchClock)
        {
            ResponseModel<PunchClock> response = new ResponseModel<PunchClock>();

            try
            {

                _context.clocks.Update(punchClock);
                await _context.SaveChangesAsync();
                
                response.Dados = punchClock;
                response.Message = "Checkout realizado com sucesso";
                response.Status = true;

            } catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
              
            }
            return response;
        }
    }
}
