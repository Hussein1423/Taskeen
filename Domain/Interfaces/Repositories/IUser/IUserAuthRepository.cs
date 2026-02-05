using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories.IUser
{
    public interface IUserAuthRepository
    {
        Task<string?> GetSaltByUsernameOrEmailAsync(string input);
        Task<User?> GetUserByCredentialsAsync(string input, string passwordHash);
    }

}
