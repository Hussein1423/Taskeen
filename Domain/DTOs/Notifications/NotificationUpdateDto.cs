using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Notifications
{
    public class NotificationUpdateDto
    {
        public int NotificationId { get; set; }
        public string? Message { get; set; }
        public bool? IsRead { get; set; }
    }
}
