using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskeenDataAccessLayer.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; }
        public string Status { get; set; } = "";
        public DateTime DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ExpectedDueDate { get; set; }

        public int AssignedToUserId { get; set; }
        public int CreatedByUserId { get; set; }

        public User AssignedToUser { get; set; }
        public User CreatedByUser { get; set; }
    }
}
