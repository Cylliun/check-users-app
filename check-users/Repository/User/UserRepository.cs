using check_users.Data;
using check_users.Models;
using Microsoft.EntityFrameworkCore;

namespace check_users.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository( AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<User>> CreateUserAsync(User user)
        {
            ResponseModel<User> response = new ResponseModel<User>();

            try
            {

                _context.users.Add(user);
                await _context.SaveChangesAsync();

                response.Dados = user;
                response.Message = "Usuário criado com sucesso";
                response.Status = true;
            } 
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                
            }
            return response;
        }

        public async Task<ResponseModel<User>> GetByEmailAsync(string email)
        {
            var response = new ResponseModel<User>();
            try
            {
                var user = await _context.users.FirstOrDefaultAsync(u => u.Email == email);
                response.Dados = user;
                response.Status = user != null;
                response.Message = user != null ? "Usuário encontrado." : "Usuário não encontrado.";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ResponseModel<User>> GetByIdAsync(int id)
        {
            var response = new ResponseModel<User>();
            try
            {
                var user = await _context.users.FindAsync(id);
                response.Dados = user;
                response.Status = user != null;
                response.Message = user != null ? "Usuário encontrado." : "Usuário não encontrado.";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
