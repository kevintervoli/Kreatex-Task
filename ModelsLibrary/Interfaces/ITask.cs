using ModelsLibrary.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskKevin.ModelsLibrary.Data.Model;

namespace ModelsLibrary.Interfaces
{
    interface ITask
    {
        IEnumerable<Task> GetTaskData();
        TaskViewModel GetSpecificTask(string taskName);
        bool TaskExist(string task);
        void InsertTask(Task task);
        public void DeleteTask(Task task);
    }
}
