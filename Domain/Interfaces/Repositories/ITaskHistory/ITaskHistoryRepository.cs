using Domain.DTOs.HistoryTask;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Interfaces.Repositories.ITaskHistory
{
    public interface ITaskHistoryRepository: ITaskHistoryQueryRepository, ITaskHistoryCommandRepository
    {
       
    }

}
