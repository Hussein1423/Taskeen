using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories.IUser
{
    public interface IUserQueryRepository
    {
        Task<User?> GetByIdAsync(int id);
        Task<List<User>?> GetAllAsync();
        Task<List<User>?> GetUsersPagedAsync(int pageNumber, int pageSize);
    }

}
