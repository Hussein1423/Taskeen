using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories.ITask
{
    public interface ITaskCommandRepository
    {
        Task<int?> CreateAsync(TaskEntity task);
        Task<bool> UpdateAsync(TaskEntity task);
        Task<bool> DeleteAsync(int taskId);
    }
}
