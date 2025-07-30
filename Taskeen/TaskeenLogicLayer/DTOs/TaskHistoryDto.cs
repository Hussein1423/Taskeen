using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskeenLogicLayer.DTOs
{
    public class TaskHistoryDto
    {
        public string TaskName { get; set; } = "";  // اسم المهمة
        public string OldStatus { get; set; } = "";
        public string NewStatus { get; set; } = "";
        public string ChangedByUserName { get; set; } = "";  // اسم المستخدم الذي قام بالتغيير
        public DateTime ChangedAt { get; set; }
    }
}
