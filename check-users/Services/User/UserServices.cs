using check_users.Models;
using check_users.Repository;
using check_users.Dtos;

namespace check_users.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResponseModel<User>> CreateUserAsync(UserDto userDto)
        {
            var response = new ResponseModel<User>();

            var existingUser = await _userRepository.GetByEmailAsync(userDto.Email);
            if (existingUser != null)
            {
                response.Status = false;
                response.Message = "Usuário existente com este email.";
                return response;
            }

            var newUser = new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Password = HashPassword(userDto.Password)
            };

            try
            {
                var createdUser = await _userRepository.CreateUserAsync(newUser);
                response.Status = true;
                response.Message = "Usuário criado com sucesso";
                response.Dados = createdUser;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ResponseModel<User>> GetByEmailAsync(UserDto userDto)
        {
            var response = new ResponseModel<User>();

            if (string.IsNullOrEmpty(userDto.Email))
            {
                response.Status = false;
                response.Message = "Email inválido.";
                return response;
            }

            try
            {
                var user = await _userRepository.GetByEmailAsync(userDto.Email);

                if (user == null)
                {
                    response.Status = false;
                    response.Message = "Usuário não encontrado.";
                    return response;
                }

                response.Status = true;
                response.Message = "Usuário encontrado.";
                response.Dados = user;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ResponseModel<User>> GetByIdAsync(string id)
        {
            var response = new ResponseModel<User>();

            if (!int.TryParse(id, out int parsedId))
            {
                response.Status = false;
                response.Message = "Id inválido";
                return response;
            }

            try
            {
                var user = await _userRepository.GetByIdAsync(parsedId);

                if (user == null)
                {
                    response.Status = false;
                    response.Message = "Usuário não encontrado.";
                    return response;
                }

                response.Status = true;
                response.Message = "Usuário encontrado.";
                response.Dados = user;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            ''
            return response;
        }

        private string HashPassword(string password)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}
