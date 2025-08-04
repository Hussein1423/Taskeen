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
    public static class AuthenticationService
    {
        public static async Task<AuthResultDto> Login(string usernameOrEmail, string password)
        {
            User user = await UserRepository.Instance.AuthenticateAsync(usernameOrEmail, PasswordHasher.HashPassword(password));

            if (user == null)
                return new AuthResultDto(false, "User not found or invalid password");

            CurrentUserSession.SetUser(user.UserId,user.Username,user.Email,user.Role);

            return new AuthResultDto(true, "Login successful");
        }

        public static void Logout()
        {
            CurrentUserSession.Clear();
        }
    }
}
