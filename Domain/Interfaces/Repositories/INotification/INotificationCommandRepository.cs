using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories.INotification
{
    public interface INotificationCommandRepository
    {
        Task<int?> CreateAsync(Notification notification);
        Task<bool> UpdateAsync(Notification notification);
        Task<bool> DeleteAsync(int notificationId);
    }
}
