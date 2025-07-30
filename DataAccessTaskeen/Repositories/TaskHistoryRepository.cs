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
    public class TaskHistoryRepository : IMutableRepository<TaskHistory>
    {
        public static readonly TaskHistoryRepository Instance = new TaskHistoryRepository();
        public async Task<int?> CreateAsync(TaskHistory history)
        {
            using (SqlConnection conn = SqlConnectionFactory.CreateConnection())
            {
                string sql = @"
            INSERT INTO TaskHistory (TaskId, OldStatus, NewStatus, ChangedByUserId, ChangedAt)
            VALUES (@TaskId, @OldStatus, @NewStatus, @ChangedByUserId, @ChangedAt);
            SELECT SCOPE_IDENTITY();";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TaskId", history.TaskId);
                    cmd.Parameters.AddWithValue("@OldStatus", history.OldStatus);
                    cmd.Parameters.AddWithValue("@NewStatus", history.NewStatus);
                    cmd.Parameters.AddWithValue("@ChangedByUserId", history.ChangedByUserId);
                    cmd.Parameters.AddWithValue("@ChangedAt", history.ChangedAt);

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

        public async Task<bool> UpdateAsync(TaskHistory history)
        {
            using (SqlConnection conn = SqlConnectionFactory.CreateConnection())
            {
                string sql = @"
            UPDATE TaskHistory SET
                TaskId = @TaskId,
                OldStatus = @OldStatus,
                NewStatus = @NewStatus,
                ChangedByUserId = @ChangedByUserId,
                ChangedAt = @ChangedAt
            WHERE HistoryId = @HistoryId";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TaskId", history.TaskId);
                    cmd.Parameters.AddWithValue("@OldStatus", history.OldStatus);
                    cmd.Parameters.AddWithValue("@NewStatus", history.NewStatus);
                    cmd.Parameters.AddWithValue("@ChangedByUserId", history.ChangedByUserId);
                    cmd.Parameters.AddWithValue("@ChangedAt", history.ChangedAt);
                    cmd.Parameters.AddWithValue("@HistoryId", history.HistoryId);

                    await conn.OpenAsync();
                    int affectedRows = await cmd.ExecuteNonQueryAsync();
                    return affectedRows > 0;
                }
            }
        }

        public async Task<bool> DeleteAsync(int historyId)
        {
            using (SqlConnection conn = SqlConnectionFactory.CreateConnection())
            {
                string sql = "DELETE FROM TaskHistory WHERE HistoryId = @HistoryId";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@HistoryId", historyId);

                    await conn.OpenAsync();
                    int affectedRows = await cmd.ExecuteNonQueryAsync();
                    return affectedRows > 0;
                }
            }
        }

        public async Task<TaskHistory> GetByIdAsync(int historyId)
        {
            using (SqlConnection conn = SqlConnectionFactory.CreateConnection())
            {
                string sql = "SELECT * FROM TaskHistory WHERE HistoryId = @HistoryId";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@HistoryId", historyId);

                    await conn.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return MapReaderToTaskHistory(reader);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public async Task<List<TaskHistory>> GetAllAsync()
        {
            List<TaskHistory> histories = new List<TaskHistory>();

            using (SqlConnection conn = SqlConnectionFactory.CreateConnection())
            {
                string sql = "SELECT * FROM TaskHistory";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    await conn.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            histories.Add(MapReaderToTaskHistory(reader));
                        }
                    }
                }
            }

            return histories;
        }


        private TaskHistory MapReaderToTaskHistory(SqlDataReader reader)
        {
            return new TaskHistory
            {
                HistoryId = Convert.ToInt32(reader["HistoryId"]),
                TaskId = Convert.ToInt32(reader["TaskId"]),
                OldStatus = reader["OldStatus"].ToString(),
                NewStatus = reader["NewStatus"].ToString(),
                ChangedByUserId = Convert.ToInt32(reader["ChangedByUserId"]),
                ChangedAt = Convert.ToDateTime(reader["ChangedAt"])
            };
        }
    }
}
