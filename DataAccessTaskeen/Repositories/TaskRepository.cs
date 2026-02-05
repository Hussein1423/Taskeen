using DataAccessTaskeen.Base;
using Domain.Mappers.Tasks;
using Domain.DTOs.Task;
using Domain.Entities;
using Domain.Helpers;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Repositories.ITask;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessTaskeen.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        public async Task<int?> CreateAsync(TaskEntity task)
        {
            try
            {
                using SqlConnection conn = SqlConnectionFactory.CreateConnection();
                using SqlCommand cmd = new SqlCommand("SP_CreateTask", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Title", task.Title);
                cmd.Parameters.AddWithValue("@Description", (object)task.Description ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Status", task.Status);
                cmd.Parameters.AddWithValue("@DueDate", task.DueDate);
                cmd.Parameters.AddWithValue("@CreatedAt", task.CreatedAt);
                cmd.Parameters.AddWithValue("@AssignedToUserId", task.AssignedToUserId);
                cmd.Parameters.AddWithValue("@CreatedByUserId", task.CreatedByUserId);
                cmd.Parameters.AddWithValue("@ExpectedDueDate", (object)task.ExpectedDueDate);

                await conn.OpenAsync();
                object result = await cmd.ExecuteScalarAsync();

                return result != null ? Convert.ToInt32(result) : null;
            }
            catch (Exception ex)
            {
                // سجل الخطأ بطريقة مناسبة، مثلاً في ملف لوج أو Event Viewer
                Helper.logErrors($"{ex.Message} | {ex.StackTrace} | {ex.InnerException}");
                return null; // إعادة null عند فشل العملية
            }
        }


        public async Task<bool> UpdateAsync(TaskEntity task)
        {
            try
            {
                using SqlConnection conn = SqlConnectionFactory.CreateConnection();
                using SqlCommand cmd = new SqlCommand("SP_UpdateTask", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                // تمرير كل الحقول، أي حقل فارغ أو null سيصبح DBNull.Value
                cmd.Parameters.AddWithValue("@TaskId", task.TaskId);
                cmd.Parameters.AddWithValue("@Title", string.IsNullOrWhiteSpace(task.Title) ? DBNull.Value : (object)task.Title);
                cmd.Parameters.AddWithValue("@Description", string.IsNullOrWhiteSpace(task.Description) ? DBNull.Value : (object)task.Description);
                cmd.Parameters.AddWithValue("@Status", string.IsNullOrWhiteSpace(task.Status) ? DBNull.Value : (object)task.Status);
                cmd.Parameters.AddWithValue("@DueDate", task.DueDate == default ? DBNull.Value : (object)task.DueDate);
                cmd.Parameters.AddWithValue("@CreatedAt", task.CreatedAt == default ? DBNull.Value : (object)task.CreatedAt);
                cmd.Parameters.AddWithValue("@AssignedToUserId", task.AssignedToUserId == 0 ? DBNull.Value : (object)task.AssignedToUserId);
                cmd.Parameters.AddWithValue("@CreatedByUserId", task.CreatedByUserId == 0 ? DBNull.Value : (object)task.CreatedByUserId);
                cmd.Parameters.AddWithValue("@ExpectedDueDate", task.ExpectedDueDate ?? (object)DBNull.Value);

                await conn.OpenAsync();
                int affectedRows = await cmd.ExecuteNonQueryAsync();
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                Helper.logErrors($"{ex.Message} | {ex.StackTrace} | {ex.InnerException}");
                return false;
            }
        }


        public async Task<bool> DeleteAsync(int taskId)
        {
            try
            {
                using SqlConnection conn = SqlConnectionFactory.CreateConnection();
                using SqlCommand cmd = new SqlCommand("SP_SoftDeleteTask", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@TaskId", taskId);

                await conn.OpenAsync();
                int affectedRows = await cmd.ExecuteNonQueryAsync();

                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                // تسجيل الخطأ بطريقة مناسبة
                Helper.logErrors($"{ex.Message} | {ex.StackTrace} | {ex.InnerException}");
                return false;
            }
        }

        public async Task<TaskEntity?> GetByIdAsync(int id)
        {
            try
            {
                using SqlConnection conn = SqlConnectionFactory.CreateConnection();
                using SqlCommand cmd = new SqlCommand("SP_GetTaskById", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@TaskId", id);

                await conn.OpenAsync();
                using SqlDataReader reader = await cmd.ExecuteReaderAsync();

                return await reader.ReadAsync() ? TaskMapper.Map(reader) : null;
            }
            catch (Exception ex)
            {
                Helper.logErrors($"{ex.Message} | {ex.StackTrace} | {ex.InnerException}");
                return null; // فشل الاستعلام
            }
        }


        public async Task<List<TaskEntity>> GetAllAsync()
        {
            try
            {
                List<TaskEntity> tasks = new List<TaskEntity>();

                using SqlConnection conn = SqlConnectionFactory.CreateConnection();
                using SqlCommand cmd = new SqlCommand("SP_GetAllTasks", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                await conn.OpenAsync();
                using SqlDataReader reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    tasks.Add(TaskMapper.Map(reader));
                }

                return tasks;
            }
            catch (Exception ex)
            {
                Helper.logErrors($"{ex.Message} | {ex.StackTrace} | {ex.InnerException}");
                return null; // فشل الاستعلام
            }
        }

        public async Task<List<TaskEntity>?> GetPagedAsync(int pageNumber, int pageSize = 30)
        {
            try
            {
                List<TaskEntity> tasks = new List<TaskEntity>();

                using SqlConnection conn = SqlConnectionFactory.CreateConnection();
                using SqlCommand cmd = new SqlCommand("SP_GetTasksPaged", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@PageNumber", pageNumber);
                cmd.Parameters.AddWithValue("@PageSize", pageSize);

                await conn.OpenAsync();
                using SqlDataReader reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    tasks.Add(TaskMapper.Map(reader));
                }

                return tasks;
            }
            catch (Exception ex)
            {
                Helper.logErrors($"{ex.Message} | {ex.StackTrace} | {ex.InnerException}");
                return null; // فشل الاستعلام
            }
        }


    }
}
