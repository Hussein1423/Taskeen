using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskeenLogicLayer.DTOs
{
    public class TaskDto
    {
        public int TaskId { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; }
        public string Status { get; set; } = "";
        public DateTime DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ExpectedDueDate { get; set; }

        public string CreatedByUser { get; set; }

        public string AssignedToUser { get; set; }

    }
}
