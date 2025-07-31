using check_users.Dtos;
using check_users.Models;
using check_users.Services.PunchCLock;

namespace check_users.Services.PunchClock
{
    public class PunchClockServices : IPunchClockServices
    {
        private readonly IPunchClockRepository _repository;

        public PunchClockServices(IPunchClockRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseModel<PunchClock>> CreateAsync(PunchClockDto punchClockDto)
        {
            var entity = new PunchClock
            {
                IdUser = punchClockDto.IdUser,
                CheckInTime = punchClockDto.CheckInTime,
                CheckOutTime = punchClockDto.CheckOutTime,
            };

            var response = new ResponseModel<PunchClock>();

            try
            {
                await _repository.CreateAsync(entity);
                await _repository.SaveChangesAsync();

                response.Status = true;
                response.Message = "Check-in realizado com sucesso";
                response.Dados = entity;
                
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = $"Erro ao realizar check-in: {ex.Message}";
                
            }
            return response;
        }

        public async Task<ResponseModel<PunchClock>> GetByUserIdAsync(int userId)
        {
            var response = new ResponseModel<PunchClock>();

            if (userId <= 0)
            {
                response.Status = false;
                response.Message = "ID de usuário inválido.";
                return response;
            }

            try
            {
                var user = await _repository.GetByUserIdAsync(userId);

                if (user == null)
                {
                    response.Status = false;
                    response.Message = "Usuário não encontrado.";
                    return response;
                }

                response.Status = true;
                response.Message = "Usuário encontrado com sucesso.";
                response.Dados = user;
                
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = $"Erro ao buscar usuário: {ex.Message}";
                
            }
            return response;
        }

        public async Task<ResponseModel<PunchClock>> GetTodayPunchAsync(int userId)
        {
            var response = new ResponseModel<PunchClock>();

            try
            {
                var todayPunch = await _repository.GetTodayPunchAsync(userId);

                if (todayPunch == null)
                {
                    response.Status = false;
                    response.Message = "Nenhum registro de check-in encontrado para hoje.";
                    return response;
                }

                response.Status = true;
                response.Message = "Registro de hoje encontrado com sucesso.";
                response.Dados = todayPunch;
                
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = $"Erro ao buscar check-in de hoje: {ex.Message}";
                
            }
            return response;
        }

        public async Task<ResponseModel<PunchClock>> UpdateCheckOutAsync(int userId, DateTime checkOutTime)
        {
            var response = new ResponseModel<PunchClock>();

            try
            {
                var clock = await _repository.GetTodayPunchAsync(userId);

                if (clock == null)
                {
                    response.Status = false;
                    response.Message = "Check-in de hoje não encontrado para este usuário.";
                    return response;
                }

                clock.CheckOutTime = checkOutTime;

                _repository.Update(clock);
                await _repository.SaveChangesAsync();

                response.Status = true;
                response.Message = "Check-out realizado com sucesso.";
                response.Dados = clock;
                
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = $"Erro ao atualizar check-out: {ex.Message}";
                
            }
            return response;
        }
    }
}
