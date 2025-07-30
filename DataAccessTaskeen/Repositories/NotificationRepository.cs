using TaskeenDataAccessLayer.Base;
using TaskeenDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskeenDataAccessLayer.Repositories
{
    public class NotificationRepository : IMutableRepository<Notification>
    {
        public static readonly NotificationRepository Instance = new NotificationRepository();
        public async Task<int?> CreateAsync(Notification notification)
        {
            using (SqlConnection conn = SqlConnectionFactory.CreateConnection())
            {
                string sql = @"
            INSERT INTO Notifications (UserId, Message, IsRead, CreatedAt)
            VALUES (@UserId, @Message, @IsRead, @CreatedAt);
            SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", notification.UserId);
                    cmd.Parameters.AddWithValue("@Message", notification.Message);
                    cmd.Parameters.AddWithValue("@IsRead", notification.IsRead);
                    cmd.Parameters.AddWithValue("@CreatedAt", notification.CreatedAt);

                    await conn.OpenAsync();
                    object result = await cmd.ExecuteScalarAsync();

                    if (result != null && int.TryParse(result.ToString(), out int value))
                    {
                        return value;
                    }

                    return null;
                }
            }
        }


        public async Task<bool> UpdateAsync(Notification notification)
        {
            using (SqlConnection conn = SqlConnectionFactory.CreateConnection())
            {
                string sql = @"
            UPDATE Notifications SET
                UserId = @UserId,
                Message = @Message,
                IsRead = @IsRead,
                CreatedAt = @CreatedAt
            WHERE NotificationId = @NotificationId";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", notification.UserId);
                    cmd.Parameters.AddWithValue("@Message", notification.Message);
                    cmd.Parameters.AddWithValue("@IsRead", notification.IsRead);
                    cmd.Parameters.AddWithValue("@CreatedAt", notification.CreatedAt);
                    cmd.Parameters.AddWithValue("@NotificationId", notification.NotificationId);

                    await conn.OpenAsync();
                    int affectedRows = await cmd.ExecuteNonQueryAsync();
                    return affectedRows > 0;
                }
            }
        }


        public async Task<bool> DeleteAsync(int notificationId)
        {
            using (SqlConnection conn = SqlConnectionFactory.CreateConnection())
            {
                string sql = "DELETE FROM Notifications WHERE NotificationId = @NotificationId";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@NotificationId", notificationId);

                    await conn.OpenAsync();
                    int affectedRows = await cmd.ExecuteNonQueryAsync();
                    return affectedRows > 0;
                }
            }
        }


        public async Task<Notification> GetByIdAsync(int notificationId)
        {
            using (SqlConnection conn = SqlConnectionFactory.CreateConnection())
            {
                string sql = "SELECT * FROM Notifications WHERE NotificationId = @NotificationId";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@NotificationId", notificationId);

                    await conn.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return MapReaderToNotification(reader);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }


        public async Task<List<Notification>> GetAllAsync()
        {
            List<Notification> notifications = new List<Notification>();

            using (SqlConnection conn = SqlConnectionFactory.CreateConnection())
            {
                string sql = "SELECT * FROM Notifications";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    await conn.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            notifications.Add(MapReaderToNotification(reader));
                        }
                    }
                }
            }

            return notifications;
        }


        private Notification MapReaderToNotification(SqlDataReader reader)
        {
            return new Notification
            {
                NotificationId = Convert.ToInt32(reader["NotificationId"]),
                UserId = Convert.ToInt32(reader["UserId"]),
                Message = reader["Message"].ToString(),
                IsRead = Convert.ToBoolean(reader["IsRead"]),
                CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
            };
        }
    }
}
