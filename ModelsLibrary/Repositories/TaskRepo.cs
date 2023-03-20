using AutoMapper;
using ModelsLibrary.Data.ViewModel;
using ModelsLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskKevin.ModelsLibrary.Data.Model;

namespace ModelsLibrary.Repositories
{
    public class TaskRepo : ITask
    {
        private List<Task> taskList = new List<Task>();
        private readonly IMapper _mapper;
        public TaskRepo(IMapper mapper)
        {
            _mapper = mapper;
        }
        public TaskViewModel GetSpecificTask(string tname)
        {
            var context = new AppDbContext();
            Task task = context.taskTable.FirstOrDefault(t => t.taskName.Equals(tname));
            TaskViewModel taskvm = _mapper.Map<TaskViewModel>(task);
            return taskvm;
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
        public void InsertTask(Task task)
        {
            var context = new AppDbContext();
            context.taskTable.Add(task);
        }
        public void DeleteTask(Task task)
        {
            var context = new AppDbContext();
            context.taskTable.Remove(task);
        }

    }
}
