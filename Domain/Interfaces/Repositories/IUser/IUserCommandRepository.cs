using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories.IUser
{
    public interface IUserCommandRepository
    {
        Task<int?> CreateAsync(User user, string salt);
        Task<bool> UpdateAsync(User user, string? salt);
        Task<bool> DeleteAsync(int id);
    }

}
