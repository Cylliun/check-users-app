﻿using check_users.Dtos;
using check_users.Models;

namespace check_users
{
    public interface IUserServices
    {
        Task<ResponseModel<User>> CreateUserAsync(UserDto userDto);
        Task<ResponseModel<User>> GetByEmailAsync(UserDto userDto);
        Task<ResponseModel<User>> GetByIdAsync(string id);
    }
}
