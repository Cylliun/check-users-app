using check_users.Dtos;
using check_users.Models;
using check_users.Repository;
namespace check_users
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices( IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResponseModel<User>> CreateUserAsync(UserDto userDto)
        {
            
            var existingUser = await _userRepository.GetByEmailAsync(userDto.Email);
            if (existingUser.Dados != null)
            {
                return new ResponseModel<User>
                {
                    Status = false,
                    Message = "Usuário existente com este email."
                };
            }

            var newUser = new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Password = HashPassword(userDto.Password)
            };

            return await _userRepository.CreateUserAsync(newUser);
        }

        public async Task<ResponseModel<User>> GetByEmailAsync(UserDto userDto)
        {

            if (userDto.Email == null)
            {
                return new ResponseModel<User>
                {
                    Status = false,
                    Message = "Nenhum usuário foi encontrado"
                };
            }
   
            return await _userRepository.GetByEmailAsync(userDto.Email);
        }

        public async Task<ResponseModel<User>> GetByIdAsync(string id)
        {
            if (!int.TryParse(id, out int parsedId))
            {
                return new ResponseModel<User>
                {
                    Status = false,
                    Message = "ID inválido"
                };
            }

            return await _userRepository.GetByIdAsync(parsedId);
        }

        private string HashPassword(string password)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}
