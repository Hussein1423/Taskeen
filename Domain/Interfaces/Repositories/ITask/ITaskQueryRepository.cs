using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories.ITask
{
    public interface ITaskQueryRepository
    {
        Task<TaskEntity?> GetByIdAsync(int id);
        Task<List<TaskEntity>> GetAllAsync();
        Task<List<TaskEntity>> GetPagedAsync(int pageNumber, int pageSize);
    }
}
