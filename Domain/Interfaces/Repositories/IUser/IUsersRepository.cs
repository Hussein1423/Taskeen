using Domain.DTOs.User;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories.IUser
{
    public interface  IUserRepository : IUserQueryRepository, IUserCommandRepository
    {
    
    }

}
