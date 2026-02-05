using Domain.DTOs.CommentTask;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories.ICommentTask
{
    public interface ICommentTaskRepository : ICommentTaskQueryRepository, ICommentTaskCommandRepository
    {
       
    }

}
