using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Task
{
    public class UpdateTaskDTO
    {
        public int TaskId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? AssignedToUserId { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime? ExpectedDueDate { get; set; }
    }
}
