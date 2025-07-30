using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskeenDataAccessLayer.Models;
using TaskeenDataAccessLayer.Repositories;
using TaskeenLogicLayer.DTOs;
using TaskeenLogicLayer.Helpers;

namespace TaskeenLogicLayer.Services
{
    public class AuthenticationService
    {
        public async Task<AuthResultDto> Login(string username, string password)
        {
            User user = await UserRepository.Instance.AuthenticateAsync(username, PasswordHasher.HashPassword(password));

            if (user == null)
                return new AuthResultDto(false, "User not found or invalid password");

            CurrentUserSession.SetUser(user.UserId,user.Username,user.Email,user.Role);

            return new AuthResultDto(true, "Login successful");
        }

        public void Logout()
        {
            CurrentUserSession.Clear();
        }
    }
}
