using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskeenDataAccessLayer.Base;
using TaskeenDataAccessLayer.Models;
namespace TaskeenDataAccessLayer.Repositories
{
    public class TaskRepository : IMutableRepository<Models.Task>
    {
        public static readonly TaskRepository Instance = new TaskRepository();
        public async Task<int?> CreateAsync(Models.Task task)
        {
            using (SqlConnection conn = SqlConnectionFactory.CreateConnection())
            {
                string sql = @"
                INSERT INTO Tasks (Title, Description, Status, DueDate, CreatedAt, AssignedToUserId, CreatedByUserId, ExpectedDueDate)
                VALUES (@Title, @Description, @Status, @DueDate, @CreatedAt, @AssignedToUserId, @CreatedByUserId, @ExpectedDueDate);
                SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Title", task.Title);
                    cmd.Parameters.AddWithValue("@Description", (object)task.Description ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Status", task.Status);
                    cmd.Parameters.AddWithValue("@DueDate", task.DueDate);
                    cmd.Parameters.AddWithValue("@CreatedAt", task.CreatedAt);
                    cmd.Parameters.AddWithValue("@AssignedToUserId", task.AssignedToUserId);
                    cmd.Parameters.AddWithValue("@CreatedByUserId", task.CreatedByUserId);
                    cmd.Parameters.AddWithValue("@ExpectedDueDate", (object)task.ExpectedDueDate ?? DBNull.Value);

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

        public async Task<bool> UpdateAsync(Models.Task task)
        {
            using (SqlConnection conn = SqlConnectionFactory.CreateConnection())
            {
                string sql = @"
                UPDATE Tasks SET
                    Title = @Title,
                    Description = @Description,
                    Status = @Status,
                    DueDate = @DueDate,
                    CreatedAt = @CreatedAt,
                    AssignedToUserId = @AssignedToUserId,
                    CreatedByUserId = @CreatedByUserId,
                    ExpectedDueDate = @ExpectedDueDate
                WHERE TaskId = @TaskId";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Title", task.Title);
                    cmd.Parameters.AddWithValue("@Description", (object)task.Description ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Status", task.Status);
                    cmd.Parameters.AddWithValue("@DueDate", task.DueDate);
                    cmd.Parameters.AddWithValue("@CreatedAt", task.CreatedAt);
                    cmd.Parameters.AddWithValue("@AssignedToUserId", task.AssignedToUserId);
                    cmd.Parameters.AddWithValue("@CreatedByUserId", task.CreatedByUserId);
                    cmd.Parameters.AddWithValue("@ExpectedDueDate", (object)task.ExpectedDueDate ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TaskId", task.TaskId);

                    await conn.OpenAsync();
                    int affectedRows = await cmd.ExecuteNonQueryAsync();
                    return affectedRows > 0;
                }
            }
        }

        public async Task<bool> DeleteAsync(int taskId)
        {
            using (SqlConnection conn = SqlConnectionFactory.CreateConnection())
            {
                string sql = "DELETE FROM Tasks WHERE TaskId = @TaskId";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TaskId", taskId);

                    await conn.OpenAsync();
                    int affectedRows = await cmd.ExecuteNonQueryAsync();
                    return affectedRows > 0;
                }
            }
        }

        public async Task<Models.Task> GetByIdAsync(int taskId)
        {
            using (SqlConnection conn = SqlConnectionFactory.CreateConnection())
            {
                string sql = "SELECT * FROM Tasks WHERE TaskId = @TaskId";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TaskId", taskId);

                    await conn.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return MapReaderToTask(reader);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public async Task<List<Models.Task>> GetAllAsync()
        {
            List<Models.Task> tasks = new List<Models.Task>();

            using (SqlConnection conn = SqlConnectionFactory.CreateConnection())
            {
                string sql = "SELECT * FROM Tasks";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    await conn.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            tasks.Add(MapReaderToTask(reader));
                        }
                    }
                }
            }

            return tasks;
        }
        private Models.Task MapReaderToTask(SqlDataReader reader)
        {
            return new Models.Task
            {
                TaskId = Convert.ToInt32(reader["TaskId"]),
                Title = reader["Title"].ToString() ?? "",
                Description = reader["Description"] == DBNull.Value ? null : reader["Description"].ToString(),
                Status = reader["Status"].ToString() ?? "",
                DueDate = Convert.ToDateTime(reader["DueDate"]),
                CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                AssignedToUserId = Convert.ToInt32(reader["AssignedToUserId"]),
                CreatedByUserId = Convert.ToInt32(reader["CreatedByUserId"]),
                ExpectedDueDate = reader["ExpectedDueDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["ExpectedDueDate"])
            };
        }
    }
}
