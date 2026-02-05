using DataAccessTaskeen.Base;
using Domain.Mappers.CommentTasks;
using Domain.DTOs.CommentTask;
using Domain.Entities;
using Domain.Helpers;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Repositories.ICommentTask;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessTaskeen.Repositories
{
    public class CommentTaskRepository : ICommentTaskRepository
    {
        public async Task<int?> CreateAsync(CommentTask dto)
        {
            try
            {
                using SqlConnection conn = SqlConnectionFactory.CreateConnection();
                using SqlCommand cmd = new SqlCommand("SP_CreateTaskComment", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@TaskId", dto.TaskId);
                cmd.Parameters.AddWithValue("@CommentText", dto.CommentText);
                cmd.Parameters.AddWithValue("@UserId", dto.CommentedByUserId);

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

        public async Task<bool> UpdateAsync(CommentTask dto)
        {
            try
            {
                using SqlConnection conn = SqlConnectionFactory.CreateConnection();

                using SqlCommand cmd = new SqlCommand("SP_UpdateTaskComment", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@CommentId", dto.CommentId);
                cmd.Parameters.AddWithValue("@CommentText", (object?)dto.CommentText ?? DBNull.Value);
                await conn.OpenAsync();
                return await cmd.ExecuteNonQueryAsync() > 0;
            }
            catch (Exception ex)
            {
                Helper.logErrors($"{ex.Message} | {ex.StackTrace} | {ex.InnerException}");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int commentId)
        {
            try
            {
                using SqlConnection conn = SqlConnectionFactory.CreateConnection();
                using SqlCommand cmd = new SqlCommand("SP_DeleteTaskComment", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@CommentId", commentId);

                await conn.OpenAsync();
                return await cmd.ExecuteNonQueryAsync() > 0;
            }
            catch (Exception ex)
            {
                Helper.logErrors($"{ex.Message} | {ex.StackTrace} | {ex.InnerException}");
                return false;
            }
        }


        public async Task<CommentTask?> GetByIdAsync(int commentId)
        {
            try
            {
                using SqlConnection conn = SqlConnectionFactory.CreateConnection();
                using SqlCommand cmd = new SqlCommand("SP_GetTaskCommentById", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@CommentId", commentId);

                await conn.OpenAsync();
                using SqlDataReader reader = await cmd.ExecuteReaderAsync();

                return await reader.ReadAsync()
                    ? CommentTaskMapper.Map(reader)
                    : null;
            }
            catch (Exception ex)
            {
                Helper.logErrors($"{ex.Message} | {ex.StackTrace} | {ex.InnerException}");
                return null;
            }
        }


        public async Task<List<CommentTask>> GetAllAsync()
        {
            List<CommentTask> list = new();

            try
            {
                using SqlConnection conn = SqlConnectionFactory.CreateConnection();
                using SqlCommand cmd = new SqlCommand("SP_GetAllTaskComments", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                await conn.OpenAsync();
                using SqlDataReader reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    list.Add(CommentTaskMapper.Map(reader));
                }
            }
            catch (Exception ex)
            {
                Helper.logErrors($"{ex.Message} | {ex.StackTrace} | {ex.InnerException}");
                return null;
            }

            return list;
        }


        public async Task<List<CommentTask>> GetPagedAsync(int taskId, int pageNumber, int pageSize = 20)
        {
            List<CommentTask> comments = new();

            try
            {
                using SqlConnection conn = SqlConnectionFactory.CreateConnection();
                using SqlCommand cmd = new SqlCommand("SP_GetTaskCommentsByTaskIdPaged", conn)
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
                    comments.Add(CommentTaskMapper.Map(reader));
                }
            }
            catch (Exception ex)
            {
                Helper.logErrors($"{ex.Message} | {ex.StackTrace} | {ex.InnerException}");
                return null;
            }

            return comments;
        }


    }

}
