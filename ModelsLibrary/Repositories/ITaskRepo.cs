using ModelsLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskKevin.ModelsLibrary.Data.Model;

namespace ModelsLibrary.Repositories
{
    class ITaskRepo : ITask
    {
        private List<Task> taskList = new List<Task>();
        public IEnumerable<Task> GetSpecificTask(string tname)
        {
            var context = new AppDbContext();
            var task = context.taskTable.FirstOrDefault(t => t.taskName.Equals(tname));
            return (IEnumerable<Task>)task;
        }

        public IEnumerable<Task> GetTaskData()
        {
            var context = new AppDbContext();
            taskList = context.taskTable.ToList();
            return taskList;
        }

        public bool TaskExist(string task)
        {
            var context = new AppDbContext();
            bool exists = context.taskTable.Any(u => u.taskName.Equals(task));
            return exists;
        }
    }
}
