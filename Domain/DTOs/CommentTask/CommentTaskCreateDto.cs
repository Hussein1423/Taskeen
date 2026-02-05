using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.CommentTask
{
    public class CommentTaskCreateDto
    {
        public int TaskId { get; set; }
        public string CommentText { get; set; } = string.Empty;
        public int CommentedByUserId { get; set; }
    }

}
