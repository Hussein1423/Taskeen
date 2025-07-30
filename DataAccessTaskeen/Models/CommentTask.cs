using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskeenDataAccessLayer.Models
{
    public class CommentTask
    {
        public int CommentId { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }  // العلاقة مع المهمة
        public string CommentText { get; set; } = "";
        public int CommentedByUserId { get; set; }
        public User CommentedByUser { get; set; }  // العلاقة مع المستخدم
        public DateTime CommentDate { get; set; }
    }
}
