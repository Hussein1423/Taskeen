using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskeenDataAccessLayer.Models;
using TaskeenDataAccessLayer.Repositories;

namespace TaskeenLogicLayer.Services
{
    public class UserService
    {
        public async Task<int?> createAsync(User user)
        {
            return await UserRepository.Instance.CreateAsync(user);
        }
        public async Task<bool> updateAsync(User user)
        {
            return await UserRepository.Instance.UpdateAsync(user);
        }
        public async Task<bool> deleteAsync(int userId)
        {
            return await UserRepository.Instance.DeleteAsync(userId);
        }
        public async Task<User> getAsync(int userId)
        {
            return await UserRepository.Instance.GetByIdAsync(userId);
        }
        public async Task<List<User>> getAllAsync()
        {
            return await UserRepository.Instance.GetAllAsync();
        }
    }
}
