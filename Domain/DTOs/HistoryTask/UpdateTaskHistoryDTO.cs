using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.HistoryTask
{
    public class UpdateTaskHistoryDTO
    {
        public int HistoryId { get; set; }
        public string? OldStatus { get; set; }
        public string? NewStatus { get; set; }
    }

}
