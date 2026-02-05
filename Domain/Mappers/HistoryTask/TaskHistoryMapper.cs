using Domain.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappers.HistoryTask
{
    public static class TaskHistoryMapper
    {
        public static TaskHistory Map(SqlDataReader r) => new TaskHistory
        {
            HistoryId = Convert.ToInt32(r["HistoryId"]),
            TaskId = Convert.ToInt32(r["TaskId"]),
            OldStatus = r["OldStatus"].ToString()!,
            NewStatus = r["NewStatus"].ToString()!,
            ChangedByUserId = Convert.ToInt32(r["ChangedByUserId"]),
            ChangedAt = Convert.ToDateTime(r["ChangedAt"])
        };
    }

}
