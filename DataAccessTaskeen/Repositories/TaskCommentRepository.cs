using TaskeenDataAccessLayer.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskeenDataAccessLayer.Models;

namespace TaskeenDataAccessLayer.Repositories
{
    public class TaskCommentRepository : IMutableRepository<CommentTask>
    {
        public static readonly TaskCommentRepository Instance = new TaskCommentRepository();
        public async Task<int?> CreateAsync(CommentTask comment)
        {
            using (SqlConnection conn = SqlConnectionFactory.CreateConnection())
            {
                string sql = @"
            INSERT INTO TaskComments (TaskId, CommentText, CommentedByUserId, CommentDate)
            VALUES (@TaskId, @CommentText, @CommentedByUserId, @CommentDate);
            SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TaskId", comment.TaskId);
                    cmd.Parameters.AddWithValue("@CommentText", comment.CommentText);
                    cmd.Parameters.AddWithValue("@CommentedByUserId", comment.CommentedByUserId);
                    cmd.Parameters.AddWithValue("@CommentDate", comment.CommentDate);

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


        public async Task<bool> UpdateAsync(CommentTask comment)
        {
            using (SqlConnection conn = SqlConnectionFactory.CreateConnection())
            {
                string sql = @"
            UPDATE TaskComments SET
                TaskId = @TaskId,
                CommentText = @CommentText,
                CommentedByUserId = @CommentedByUserId,
                CommentDate = @CommentDate
            WHERE CommentId = @CommentId";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TaskId", comment.TaskId);
                    cmd.Parameters.AddWithValue("@CommentText", comment.CommentText);
                    cmd.Parameters.AddWithValue("@CommentedByUserId", comment.CommentedByUserId);
                    cmd.Parameters.AddWithValue("@CommentDate", comment.CommentDate);
                    cmd.Parameters.AddWithValue("@CommentId", comment.CommentId);

                    await conn.OpenAsync();
                    int affectedRows = await cmd.ExecuteNonQueryAsync();
                    return affectedRows > 0;
                }
            }
        }


        public async Task<bool> DeleteAsync(int commentId)
        {
            using (SqlConnection conn = SqlConnectionFactory.CreateConnection())
            {
                string sql = "DELETE FROM TaskComments WHERE CommentId = @CommentId";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CommentId", commentId);

                    await conn.OpenAsync();
                    int affectedRows = await cmd.ExecuteNonQueryAsync();
                    return affectedRows > 0;
                }
            }
        }


        public async Task<CommentTask> GetByIdAsync(int commentId)
        {
            using (SqlConnection conn = SqlConnectionFactory.CreateConnection())
            {
                string sql = "SELECT * FROM TaskComments WHERE CommentId = @CommentId";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CommentId", commentId);

                    await conn.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return MapReaderToComment(reader);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public async Task<List<CommentTask>> GetAllAsync()
        {
            List<CommentTask> comments = new List<CommentTask>();

            using (SqlConnection conn = SqlConnectionFactory.CreateConnection())
            {
                string sql = "SELECT * FROM TaskComments";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    await conn.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            comments.Add(MapReaderToComment(reader));
                        }
                    }
                }
            }

            return comments;
        }


        private CommentTask MapReaderToComment(SqlDataReader reader)
        {
            return new CommentTask
            {
                CommentId = Convert.ToInt32(reader["CommentId"]),
                TaskId = Convert.ToInt32(reader["TaskId"]),
                CommentText = reader["CommentText"].ToString(),
                CommentedByUserId = Convert.ToInt32(reader["CommentedByUserId"]),
                CommentDate = Convert.ToDateTime(reader["CommentDate"])
            };
        }
    }
}
