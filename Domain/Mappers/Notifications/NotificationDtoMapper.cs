using Domain.DTOs.Notifications;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappers.Notifications
{
    public static class NotificationDtoMapper
    {
        public static NotificationDto Map(SqlDataReader reader)
        {
            return new NotificationDto
            {
                NotificationId = Convert.ToInt32(reader["NotificationId"]),
                Username = reader["Username"].ToString() ?? "",
                Message = reader["Message"].ToString() ?? "",
                IsRead = Convert.ToBoolean(reader["IsRead"]),
                CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                IsDeleted = Convert.ToBoolean(reader["IsDeleted"]),
                DeletedAt = reader["DeletedAt"] == DBNull.Value ? null : Convert.ToDateTime(reader["DeletedAt"])
            };
        }
    }

}
