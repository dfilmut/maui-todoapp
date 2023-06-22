using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todoApp.Models
{
    class TaskRepository
    {

        public static List<Task> _tasks = new List<Task>()
        {
            new Task {TaskId = 1, Title ="Learn .NET MAUI", Description="Learn .NET MAUI and make todoApp", Status="In progress"},
        };

        public static List<Task> GetTasks() => _tasks;

        public static Task GetTaskById(int taskId)
        {
            var task = _tasks.FirstOrDefault(x => x.TaskId == taskId);
            if (task != null)
            {
                return new Task
                {
                    TaskId = task.TaskId,
                    Title = task.Title,
                    Description = task.Description,
                    Status = task.Status
                };
            }
            return null;
        }

        public static void UpdateTask(int taskId, Task task)
        {
            if (taskId != task.TaskId) return;

            var taskToUpdate = _tasks.FirstOrDefault(x => x.TaskId == taskId);
            if (taskToUpdate != null)
            {
                taskToUpdate.Title = task.Title;
                taskToUpdate.Description = task.Description;
                taskToUpdate.Status = task.Status;
            }
        }

        public static void AddTask(Task task)
        {
            var maxId = _tasks.Max(x => x.TaskId);
            task.TaskId = maxId + 1;
            _tasks.Add(task);
        }

        public static void DeleteTask(int taskId)
        {
            var task = _tasks.FirstOrDefault(x => x.TaskId == taskId);
            if (task != null)
            {
                _tasks.Remove(task);
            }
        }
    }
}
