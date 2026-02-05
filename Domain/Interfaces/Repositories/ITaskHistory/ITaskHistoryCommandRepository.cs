using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories.ITaskHistory
{
    public interface ITaskHistoryCommandRepository
    {
        Task<int?> CreateAsync(TaskHistory taskH);
        Task<bool> UpdateAsync(TaskHistory taskH);
        Task<bool> DeleteAsync(int taskId);
    }
}
