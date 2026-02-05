using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.HistoryTask
{
    public class CreateTaskHistoryDTO
    {
        public int TaskId { get; set; }
        public string OldStatus { get; set; } = string.Empty;
        public string NewStatus { get; set; } = string.Empty;
        public int ChangedByUserId { get; set; }
    }

}
