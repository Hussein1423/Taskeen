using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskeenDataAccessLayer.Models;
using TaskeenDataAccessLayer.Repositories;
using TaskeenLogicLayer.Events;
namespace TaskeenLogicLayer.Services
{
    public class TaskService
    {
        public async Task<int?> CreateAsync(TaskeenDataAccessLayer.Models.Task task)
        {
            int? taskId = await TaskRepository.Instance.CreateAsync(task);

            if (taskId != null)
            {
                Notification notification = new Notification
                {
                    UserId = task.AssignedToUserId,
                    Message = $"New task assigned: {task.Title}",
                    IsRead = false,
                    CreatedAt = DateTime.Now
                };
                TaskCreatedEventArgs taskCreated = new TaskCreatedEventArgs(task, notification);
                TaskEvents.OnTaskCreated(taskCreated);
            }

            return taskId;
        }


        public async Task<bool> UpdateAsync(TaskeenDataAccessLayer.Models.Task task)
        {
            // من الأفضل الحصول على المهمة الأصلية من قاعدة البيانات أولاً 
            // لتعرف الـ oldStatus قبل التحديث
            var existingTask = await TaskRepository.Instance.GetByIdAsync(task.TaskId);
            if (existingTask == null)
                return false; // المهمة غير موجودة

            string oldStatus = existingTask.Status;

            bool isUpdated = await TaskRepository.Instance.UpdateAsync(task);

            if (isUpdated)
            {
                Notification notification = new Notification
                {
                    UserId = task.AssignedToUserId,
                    Message = $"Task updated: {task.Title}",
                    IsRead = false,
                    CreatedAt = DateTime.Now
                };

                TaskHistory taskHistory = new TaskHistory
                {
                    TaskId = task.TaskId,
                    Task = task,
                    ChangedAt = DateTime.Now,
                    ChangedByUserId = task.CreatedByUserId,
                    ChangedByUser = task.CreatedByUser,
                    HistoryId = 0, // جديد، سيتحدد في DB
                    OldStatus = oldStatus, // القيمة القديمة
                    NewStatus = task.Status // القيمة الجديدة
                };

                TaskChangedEventArgs taskUpdated = new TaskChangedEventArgs(task, taskHistory, notification);
                TaskEvents.OnTaskUpdated(taskUpdated);
            }

            return isUpdated;
        }


        public async Task<bool> DeleteAsync(int taskId)
        {
            var task = await TaskRepository.Instance.GetByIdAsync(taskId);
            if (task == null)
                return false; // المهمة غير موجودة
            bool isDeleted = await TaskRepository.Instance.DeleteAsync(taskId);
            if (isDeleted)
            {
                Notification notification = new Notification
                {
                    UserId = task.AssignedToUserId,
                    Message = $"Task deleted: {task.Title}",
                    IsRead = false,
                    CreatedAt = DateTime.Now
                };
                TaskHistory taskHistory = new TaskHistory
                {
                    TaskId = task.TaskId,
                    Task = task,
                    ChangedAt = DateTime.Now,
                    ChangedByUserId = task.CreatedByUserId,
                    ChangedByUser = task.CreatedByUser,
                    HistoryId = 0, // جديد، سيتحدد في DB
                    OldStatus = task.Status, // القيمة القديمة
                    NewStatus = "Deleted" // القيمة الجديدة
                };
                TaskChangedEventArgs taskDeleted = new TaskChangedEventArgs(task, taskHistory, notification);
                TaskEvents.OnTaskDeleted(taskDeleted);
            }
            return isDeleted;
        }

        public async Task<TaskeenDataAccessLayer.Models.Task> GetByIdAsync(int taskId)
        {
            return await TaskRepository.Instance.GetByIdAsync(taskId);
        }
        public async Task<List<TaskeenDataAccessLayer.Models.Task>> GetAllAsync()
        {
            return await TaskRepository.Instance.GetAllAsync();

        }

        public static void CheckExpectedDueDate(TaskeenDataAccessLayer.Models.Task task)
        {
            if (task.ExpectedDueDate.HasValue && DateTime.Now > task.ExpectedDueDate.Value)
            {
                var notification = new Notification
                {
                    UserId = task.AssignedToUserId,
                    Message = $"Task '{task.Title}' has exceeded the expected due date!",
                    IsRead = false,
                    CreatedAt = DateTime.Now
                };

                ExpectedDueDateExceededEventArgs args = new ExpectedDueDateExceededEventArgs(task, notification);
                TaskEvents.OnExpectedDueDateExceeded(args);
            }
        }
    }
}
