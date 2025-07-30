using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskeenLogicLayer.Events
{
    public static class TaskEvents
    {
        public static event EventHandler<TaskCreatedEventArgs> TaskCreated;
        public static event EventHandler<TaskChangedEventArgs> TaskDeleted;
        public static event EventHandler<TaskChangedEventArgs> TaskUpdated;
        public static event EventHandler<ExpectedDueDateExceededEventArgs> ExpectedDueDateExceeded;

        public static void OnTaskCreated(TaskCreatedEventArgs e)
            => TaskCreated?.Invoke(null, e);

        public static void OnTaskDeleted(TaskChangedEventArgs e)
            => TaskDeleted?.Invoke(null, e);

        public static void OnTaskUpdated(TaskChangedEventArgs e)
            => TaskUpdated?.Invoke(null, e);

        public static void OnExpectedDueDateExceeded(ExpectedDueDateExceededEventArgs e)
            => ExpectedDueDateExceeded?.Invoke(null, e);
    }


}
