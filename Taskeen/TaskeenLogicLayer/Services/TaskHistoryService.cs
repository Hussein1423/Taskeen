using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskeenDataAccessLayer.Models;
using TaskeenDataAccessLayer.Repositories;
namespace TaskeenLogicLayer.Services
{
    public class TaskHistoryService
    {
        public async Task<int?> CreateAsync(TaskHistory taskHistory)
        {
            return await TaskHistoryRepository.Instance.CreateAsync(taskHistory);
        }
        public async Task<bool> UpdateAsync(TaskHistory taskHistory)
        {
            return await TaskHistoryRepository.Instance.UpdateAsync(taskHistory);
        }
        public async Task<bool> DeleteAsync(int taskHistoryId)
        {
            return await TaskHistoryRepository.Instance.DeleteAsync(taskHistoryId);
        }
        public async Task<TaskHistory> GetAsync(int taskHistoryId)
        {
            return await TaskHistoryRepository.Instance.GetByIdAsync(taskHistoryId);
        }
        public async Task<List<TaskHistory>> GetAllAsync()
        {
            return await TaskHistoryRepository.Instance.GetAllAsync();
        }
    }
}
