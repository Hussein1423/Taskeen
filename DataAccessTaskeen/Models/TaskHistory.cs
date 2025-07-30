using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskeenDataAccessLayer.Models
{
    public class TaskHistory
    {
        public int HistoryId { get; set; }

        public int TaskId { get; set; }
        public Task Task { get; set; }  // العلاقة مع المهمة

        public string OldStatus { get; set; } = "";
        public string NewStatus { get; set; } = "";

        public int ChangedByUserId { get; set; }
        public User ChangedByUser { get; set; }  // من قام بالتغيير

        public DateTime ChangedAt { get; set; }
    }
}
