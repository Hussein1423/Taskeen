using Domain.DTOs.User;
using Domain.Entities;
using Domain.Helpers;
using Domain.Interfaces.Repositories.IUser;
using Domain.Interfaces.Services.IUser;
using Domain.Mappers.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessTaskeen.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<int?> CreateAsync(UserCommandDTO dto)
        {
            User entity = UserDtoMapper.ToEntity(dto);
            return await _repository.CreateAsync(entity, dto.Salt!);
        }

        public async Task<bool> UpdateAsync(UserCommandDTO dto)
        {
            // أولًا نحول الـ DTO إلى Entity
            User entity = UserDtoMapper.ToEntity(dto);

            // تحقق إذا تم تمرير Password جديد
            if (!string.IsNullOrWhiteSpace(dto.PasswordHash))
            {
                // 1️⃣ إنشاء Salt جديد
                string newSalt = PasswordHasher.GenerateSalt();

                // 2️⃣ إنشاء Hash جديد
                entity.PasswordHash = PasswordHasher.HashPassword(dto.PasswordHash, newSalt);

                // 3️⃣ تحديث Salt في DTO / Entity حسب تصميمك
                dto.Salt = newSalt;
            }

            // إرسال الـ Entity + Salt للـ Repository
            return await _repository.UpdateAsync(entity, dto.Salt);
        }


        public async Task<bool> DeleteAsync(int userId)
        {
            return await _repository.DeleteAsync(userId);
        }

        public async Task<UserReadDTO?> GetAsync(int userId)
        {
            User? user = await _repository.GetByIdAsync(userId);
            return UserDtoMapper.ToDto(user);
        }

        public async Task<List<UserReadDTO>> GetAllAsync()
        {
            List<User>? users = await _repository.GetAllAsync();
            if (users == null) return new List<UserReadDTO>(); // تجنب null
            return users.Select(UserDtoMapper.ToDto).ToList();
        }
    }

}
