using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories.INotification
{
    public interface INotificationQueryRepository
    {
        Task<Notification?> GetByIdAsync(int notificationId);
        Task<List<Notification>> GetAllAsync();
        Task<List<Notification>> GetPagedAsync(int userId, int pageNumber, int pageSize = 30);
    }
}
