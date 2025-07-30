using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskeenDataAccessLayer.Models;

namespace TaskeenLogicLayer.Events
{
    public class ExpectedDueDateExceededEventArgs : EventArgs
    {
        public Task Task { get; set; }

        public Notification Notification { get; set; }

        public ExpectedDueDateExceededEventArgs(Task task, Notification notification)
        {
            Task = task;
            Notification = notification;
        }
    }

}
