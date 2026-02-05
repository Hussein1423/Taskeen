using DataAccessTaskeen.Base;
using Domain.Mappers.Notifications;
using Domain.DTOs.Notifications;
using Domain.Entities;
using Domain.Helpers;
using Domain.Interfaces.Repositories.INotification;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessTaskeen.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        public async Task<int?> CreateAsync(Notification dto)
        {
            try
            {
                using SqlConnection conn = SqlConnectionFactory.CreateConnection();
                using SqlCommand cmd = new SqlCommand("SP_CreateNotification", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@UserId", dto.UserId);
                cmd.Parameters.AddWithValue("@Message", dto.Message);
                await conn.OpenAsync();
                object result = await cmd.ExecuteScalarAsync();
                return result != null ? Convert.ToInt32(result) : null;
            }
            catch (Exception ex)
            {
                Helper.logErrors($"{ex.Message} | {ex.StackTrace} | {ex.InnerException}");
                return null;
            }
        }

        public async Task<bool> UpdateAsync(Notification dto)
        {
            try
            {
                using SqlConnection conn = SqlConnectionFactory.CreateConnection();
                using SqlCommand cmd = new SqlCommand("SP_UpdateNotification", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@NotificationId", dto.NotificationId);
                cmd.Parameters.AddWithValue("@Message", (object?)dto.Message ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@IsRead", (object?)dto.IsRead ?? DBNull.Value);

                await conn.OpenAsync();
                return await cmd.ExecuteNonQueryAsync() > 0;
            }
            catch (Exception ex)
            {
                Helper.logErrors($"{ex.Message} | {ex.StackTrace} | {ex.InnerException}");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int notificationId)
        {
            try
            {
                using SqlConnection conn = SqlConnectionFactory.CreateConnection();
                using SqlCommand cmd = new SqlCommand("SP_DeleteNotification", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@NotificationId", notificationId);
                await conn.OpenAsync();
                return await cmd.ExecuteNonQueryAsync() > 0;
            }
            catch (Exception ex)
            {
                Helper.logErrors($"{ex.Message} | {ex.StackTrace} | {ex.InnerException}");
                return false;
            }
        }

        public async Task<Notification?> GetByIdAsync(int notificationId)
        {
            try
            {
                using SqlConnection conn = SqlConnectionFactory.CreateConnection();
                using SqlCommand cmd = new SqlCommand("SP_GetNotificationById", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@NotificationId", notificationId);
                await conn.OpenAsync();
                using SqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    return NotificationMapper.Map(reader);
                }

                return null;
            }
            catch (Exception ex)
            {
                Helper.logErrors($"{ex.Message} | {ex.StackTrace} | {ex.InnerException}");
                return null;
            }
        }

        public async Task<List<Notification>> GetAllAsync()
        {
            List<Notification> list = new();

            try
            {
                using SqlConnection conn = SqlConnectionFactory.CreateConnection();
                using SqlCommand cmd = new SqlCommand("SP_GetAllNotifications", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                await conn.OpenAsync();
                using SqlDataReader reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    list.Add(NotificationMapper.Map(reader));
                }
            }
            catch (Exception ex)
            {
                Helper.logErrors($"{ex.Message} | {ex.StackTrace} | {ex.InnerException}");
            }

            return list;
        }

        public async Task<List<Notification>> GetPagedAsync(int userId, int pageNumber, int pageSize = 30)
        {
            List<Notification> list = new();

            try
            {
                using SqlConnection conn = SqlConnectionFactory.CreateConnection();
                using SqlCommand cmd = new SqlCommand("SP_GetNotificationsPaged", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@PageNumber", pageNumber);
                cmd.Parameters.AddWithValue("@PageSize", pageSize);

                await conn.OpenAsync();
                using SqlDataReader reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                    list.Add(NotificationMapper.Map(reader));
            }
            catch (Exception ex)
            {
                Helper.logErrors($"{ex.Message} | {ex.StackTrace} | {ex.InnerException}");
            }

            return list;
        }

    }
}
