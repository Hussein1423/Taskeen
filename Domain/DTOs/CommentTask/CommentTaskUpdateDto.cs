using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.CommentTask
{
    public class CommentTaskUpdateDto
    {
        public int CommentId { get; set; }
        public string? CommentText { get; set; }
    }

}
