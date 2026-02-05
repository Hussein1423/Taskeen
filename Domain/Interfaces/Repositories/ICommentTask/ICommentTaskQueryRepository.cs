using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories.ICommentTask
{
    public interface ICommentTaskQueryRepository
    {
        Task<CommentTask?> GetByIdAsync(int commentTaskId);
        Task<List<CommentTask>> GetAllAsync();
        Task<List<CommentTask>> GetPagedAsync(int taskId, int pageNumber, int pageSize = 30);
    }
}
