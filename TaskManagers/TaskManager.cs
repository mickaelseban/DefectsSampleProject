using System.Collections.Generic;
using System.Linq;

namespace TaskManagers
{
    public class TaskManager
    {
        private readonly List<Task> _tasks;
        private int _nextId;

        public TaskManager()
        {
            _tasks = new List<Task>();
            _nextId = 1;
        }

        public Task AddTask(string title, string description, string category, int priority)
        {
            var task = new Task(_nextId++, title, description, category, false, priority);
            _tasks.Add(task);
            return task;
        }

        public bool RemoveTask(int id)
        {
            var task = _tasks.SingleOrDefault(t => t.Id == id);
            if (task == null)
            {
                return false;
            }

            _tasks.Remove(task);
            return true;
        }

        public Task GetTask(int id)
        {
            return _tasks.SingleOrDefault(t => t.Id == id);
        }

        public List<Task> GetAllTasks()
        {
            return _tasks;
        }

        public List<Task> GetTasksByCategory(string category)
        {
            return _tasks.Where(t => t.Category == category).ToList();
        }

        public List<Task> GetTasksByPriority(int priority)
        {
            // Bug! Fix: return _tasks.Where(t => t.Priority == priority).ToList();
            return _tasks.Where(t => t.Priority != priority).ToList();
        }

        public bool UpdateTask(int id, string title, string description, string category, int priority)
        {
            var task = GetTask(id);
            if (task == null)
            {
                return false;
            }

            task.Update(title, description, category, priority);
            return true;
        }
    }
}