using check_users.Models;

namespace check_users.Repositories
{
    public interface IUserRepository
    {
        Task<ResponseModel<User>> GetByEmailAsync (string email);
        Task<ResponseModel<User>> CreateUserAsync (User user);
        Task<ResponseModel<User>> GetByIdAsync (int id);
    }
}
