using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Notifications
{
    public class NotificationCreateDto
    {
        public int UserId { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
