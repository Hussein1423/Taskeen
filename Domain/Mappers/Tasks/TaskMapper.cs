using Domain.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappers.Tasks
{
    public static class TaskMapper
    {
        public static TaskEntity Map(SqlDataReader reader)
        {
            return new TaskEntity
            {
                TaskId = Convert.ToInt32(reader["TaskId"]),
                Title = reader["Title"].ToString() ?? "",
                Description = reader["Description"] == DBNull.Value ? null : reader["Description"].ToString(),
                Status = reader["Status"].ToString() ?? "",
                DueDate = Convert.ToDateTime(reader["DueDate"]),
                CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                AssignedToUserId = Convert.ToInt32(reader["AssignedToUserId"]),
                CreatedByUserId = Convert.ToInt32(reader["CreatedByUserId"]),
                ExpectedDueDate = Convert.ToDateTime(reader["ExpectedDueDate"])
            };
        }
    }
}
