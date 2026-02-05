using Domain.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappers.CommentTasks
{
    public static class CommentTaskMapper
    {
        public static CommentTask Map(SqlDataReader reader)
        {
            return new CommentTask
            {
                CommentId = Convert.ToInt32(reader["CommentId"]),
                TaskId = Convert.ToInt32(reader["TaskId"]),
                CommentText = reader["CommentText"].ToString()!,
                CommentedByUserId = Convert.ToInt32(reader["CommentedByUserId"]),
                CommentDate = Convert.ToDateTime(reader["CommentDate"])
            };
        }
    }

}
