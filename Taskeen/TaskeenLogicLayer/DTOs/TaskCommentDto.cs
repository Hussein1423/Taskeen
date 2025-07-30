using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskeenLogicLayer.DTOs
{
    public class TaskCommentDto
    {
        public int CommentId { get; set; }

        public string TaskName { get; set; } = "";

        public string CreatedByUser { get; set; }
        public string CommentText { get; set; } = "";
        public DateTime CommentDate { get; set; }
    }
}
