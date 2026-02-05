using Domain.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappers.Notifications
{
    public static class NotificationMapper
    {
        public static Notification Map(SqlDataReader reader)
        {
            return new Notification
            {
                NotificationId = Convert.ToInt32(reader["NotificationId"]),
                UserId = Convert.ToInt32(reader["UserId"]),
                Message = reader["Message"].ToString() ?? "",
                IsRead = Convert.ToBoolean(reader["IsRead"]),
                CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                IsDeleted = Convert.ToBoolean(reader["IsDeleted"]),
                DeletedAt = reader["DeletedAt"] == DBNull.Value ? null : Convert.ToDateTime(reader["DeletedAt"])
            };
        }
    }

}
