using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories.ITaskHistory
{
    public interface ITaskHistoryQueryRepository
    {
        Task<TaskHistory?> GetByIdAsync(int id);
        Task<List<TaskHistory>> GetAllAsync();
        Task<List<TaskHistory>> GetPagedAsync(int taskId, int pageNumber, int pageSize);
    }
}
