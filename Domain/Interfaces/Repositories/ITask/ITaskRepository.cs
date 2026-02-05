using Domain.DTOs.Task;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories.ITask
{
    public interface ITaskRepository : ITaskQueryRepository, ITaskCommandRepository
    {
        
    }
}
