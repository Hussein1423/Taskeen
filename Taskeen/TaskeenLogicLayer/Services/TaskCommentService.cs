using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskeenDataAccessLayer.Models;
using TaskeenDataAccessLayer.Repositories;
namespace TaskeenLogicLayer.Services
{
    public class TaskCommentService
    {
        public async Task<int?> CreateAsync(CommentTask taskComment)
        {
            return await TaskCommentRepository.Instance.CreateAsync(taskComment);
        }
        public async Task<bool> UpdateAsync(CommentTask taskComment)
        {
            return await TaskCommentRepository.Instance.UpdateAsync(taskComment);
        }
        public async Task<bool> DeleteAsync(int taskCommentId)
        {
            return await TaskCommentRepository.Instance.DeleteAsync(taskCommentId);
        }
        public async Task<CommentTask> GetAsync(int taskCommentId)
        {
            return await TaskCommentRepository.Instance.GetByIdAsync(taskCommentId);
        }
        public async Task<List<CommentTask>> GetAllAsync()
        {
            return await TaskCommentRepository.Instance.GetAllAsync();
        }
    }
}
