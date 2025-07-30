using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskeenDataAccessLayer.Models;
using TaskeenDataAccessLayer.Repositories;

namespace TaskeenLogicLayer.Services
{
    public class NotificationService
    {
        public  async Task<int?> CreateAsync(Notification notification)
        {
            return await NotificationRepository.Instance.CreateAsync(notification);
        }
        public async Task<bool> UpdateAsync(Notification notification)
        {
            return await NotificationRepository.Instance.UpdateAsync(notification);
        }
        public async Task<bool> DeleteAsync(int notificationId)
        {
            return await NotificationRepository.Instance.DeleteAsync(notificationId);
        }
        public async Task<Notification> GetAsync(int notificationId)
        {
            return await NotificationRepository.Instance.GetByIdAsync(notificationId);
        }
        public async Task<List<Notification>> GetAllAsync()
        {
            return await NotificationRepository.Instance.GetAllAsync();
        }
    }
}
