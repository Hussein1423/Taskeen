using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories.ICommentTask
{
    public interface ICommentTaskCommandRepository
    {
        Task<int?> CreateAsync(CommentTask commentTask);
        Task<bool> UpdateAsync(CommentTask commentTask);
        Task<bool> DeleteAsync(int commentTaskId);
    }
}
