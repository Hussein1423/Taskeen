using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskeenDataAccessLayer.Models;



namespace TaskeenLogicLayer.Events
{
    public class TaskChangedEventArgs : EventArgs
    {
        public Task Task { get; set; }

        public TaskHistory TaskHistory { get; set; }

        public Notification Notification { get; set; }

        public TaskChangedEventArgs(Task task, TaskHistory taskHistory, Notification notification)
        {
            Task = task;
            TaskHistory = taskHistory;
            Notification = notification;
        }
    }

}
