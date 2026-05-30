using NecroClock.Application.DTOs.Models;
using NecroClock.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NecroClock.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> RegisterAsync(UserDTO userDTO);
        Task<UserModel> AuthenticateAsync(UserDTO userDTO);
        void Logout(long userID);
    }
}
