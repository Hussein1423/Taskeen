using Domain.DTOs.User;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappers.Users
{
    public static class UserDtoMapper
    {
        public static User ToEntity(UserCommandDTO dto)
        {
            return new User
            {
                UserId = dto.UserId,
                FirstName = dto.FirstName,
                SecondName = dto.SecondName,
                LastName = dto.LastName,
                Username = dto.Username,
                PasswordHash = dto.PasswordHash,
                Email = dto.Email,
                Role = dto.Role,
            };
        }
        public static UserReadDTO ToDto(User user)
        {
            if (user == null) return null!;
            return new UserReadDTO
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                LastName = user.LastName,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role,
            };
        }
    }

}
