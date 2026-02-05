using Domain.DTOs.User;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.IUser
{
    public interface IUserService
    {
        Task<int?> CreateAsync(UserCommandDTO dto);
        Task<bool> UpdateAsync(UserCommandDTO dto);
        Task<bool> DeleteAsync(int userId);
        Task<UserReadDTO?> GetAsync(int userId);
        Task<List<UserReadDTO>> GetAllAsync();
    }
}
