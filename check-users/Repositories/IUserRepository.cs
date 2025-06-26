using check_users.Models;

namespace check_users.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync (string email);
        Task<User> CreateUserAsync (User user);
        Task<User> GetByIdAsync (int id);
    }
}
