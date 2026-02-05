using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CommentTask
    {
        public int CommentId { get; set; }
        public int TaskId { get; set; }
        public string CommentText { get; set; } = string.Empty;
        public int CommentedByUserId { get; set; }
        public DateTime CommentDate { get; set; }
    }

}
