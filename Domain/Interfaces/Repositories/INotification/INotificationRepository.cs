using Domain.DTOs.Notifications;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories.INotification
{
    public interface INotificationRepository : INotificationQueryRepository, INotificationCommandRepository
    {
       
    }

}
