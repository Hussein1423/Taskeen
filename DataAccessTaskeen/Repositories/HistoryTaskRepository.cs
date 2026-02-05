using DataAccessTaskeen.Base;
using Domain.Mappers.HistoryTask;
using Domain.DTOs.HistoryTask;
using Domain.Entities;
using Domain.Helpers;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Repositories.ITask;
using Domain.Interfaces.Repositories.ITaskHistory;
using Domain.Interfaces.Repositories.IUser;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessTaskeen.Repositories
{
    public class HistoryTaskRepository : ITaskHistoryRepository
    {
        public async Task<int?> CreateAsync(TaskHistory dto)
        {
            try
            {
                using SqlConnection conn = SqlConnectionFactory.CreateConnection();
                using SqlCommand cmd = new SqlCommand("SP_TaskHistory_Create", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@TaskId", dto.TaskId);
                cmd.Parameters.AddWithValue("@OldStatus", dto.OldStatus);
                cmd.Parameters.AddWithValue("@NewStatus", dto.NewStatus);
                cmd.Parameters.AddWithValue("@ChangedByUserId", dto.ChangedByUserId);

                await conn.OpenAsync();
                object? result = await cmd.ExecuteScalarAsync();

                return int.TryParse(result?.ToString(), out int id) ? id : null;
            }
            catch (Exception ex)
            {
                Helper.logErrors($"{ex.Message} | {ex.StackTrace} | {ex.InnerException}");
                return null;
            }
        }

        public async Task<bool> UpdateAsync(TaskHistory dto)
        {
            try
            {
                using SqlConnection conn = SqlConnectionFactory.CreateConnection();
                using SqlCommand cmd = new SqlCommand("SP_TaskHistory_Update", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@HistoryId", dto.HistoryId);
                cmd.Parameters.AddWithValue("@OldStatus", (object?)dto.OldStatus ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NewStatus", (object?)dto.NewStatus ?? DBNull.Value);

                await conn.OpenAsync();

                return await cmd.ExecuteNonQueryAsync() > 0;
            }
            catch (Exception ex)
            {
                Helper.logErrors($"{ex.Message} | {ex.StackTrace} | {ex.InnerException}");
                return false;
            }
        }



        public async Task<bool> DeleteAsync(int historyId)
        {
            try
            {
                using SqlConnection conn = SqlConnectionFactory.CreateConnection();
                using SqlCommand cmd = new SqlCommand("SP_TaskHistory_Delete", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@HistoryId", historyId);

                await conn.OpenAsync();
                return await cmd.ExecuteNonQueryAsync() > 0;
            }
            catch (Exception ex)
            {
                Helper.logErrors($"{ex.Message} | {ex.StackTrace} | {ex.InnerException}");
                return false;
            }
        }


        public async Task<TaskHistory?> GetByIdAsync(int id)
        {
            try
            {
                using SqlConnection conn = SqlConnectionFactory.CreateConnection();
                using SqlCommand cmd = new SqlCommand("SP_TaskHistory_GetById", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@HistoryId", id);

                await conn.OpenAsync();
                using SqlDataReader r = await cmd.ExecuteReaderAsync();

                return await r.ReadAsync() ? TaskHistoryMapper.Map(r) : null;
            }
            catch (Exception ex)
            {
                Helper.logErrors($"{ex.Message} | {ex.StackTrace} | {ex.InnerException}");
                return null;
            }
        }


        public async Task<List<TaskHistory>> GetAllAsync()
        {
            List<TaskHistory> list = new();

            try
            {
                using SqlConnection conn = SqlConnectionFactory.CreateConnection();
                using SqlCommand cmd = new SqlCommand("SP_TaskHistory_GetAll", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                await conn.OpenAsync();
                using SqlDataReader r = await cmd.ExecuteReaderAsync();

                while (await r.ReadAsync())
                    list.Add(TaskHistoryMapper.Map(r));

                return list;
            }
            catch (Exception ex)
            {
                Helper.logErrors($"{ex.Message} | {ex.StackTrace} | {ex.InnerException}");
                return null;
            }
        }

        public async Task<List<TaskHistory>?> GetPagedAsync(int taskId, int pageNumber, int pageSize = 30)
        {
            try
            {
                List<TaskHistory> historyList = new List<TaskHistory>();

                using SqlConnection conn = SqlConnectionFactory.CreateConnection();
                using SqlCommand cmd = new SqlCommand("SP_GetTaskHistoryPaged", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@TaskId", taskId);
                cmd.Parameters.AddWithValue("@PageNumber", pageNumber);
                cmd.Parameters.AddWithValue("@PageSize", pageSize);

                await conn.OpenAsync();
                using SqlDataReader reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    historyList.Add(TaskHistoryMapper.Map(reader));
                }

                return historyList;
            }
            catch (Exception ex)
            {
                Helper.logErrors($"{ex.Message} | {ex.StackTrace} | {ex.InnerException}");
                return null; // فشل الاستعلام
            }
        }





    }
}
