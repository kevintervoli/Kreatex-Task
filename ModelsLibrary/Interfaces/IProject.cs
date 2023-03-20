using ModelsLibrary.Data.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskKevin.ModelsLibrary.Data.Model;

namespace ModelsLibrary.Interfaces
{
    interface IProject
    {
        IEnumerable<Projects> GetItems();
        ProjectViewModel GetItem(string project);
        bool ProjectExists(string project);
        void InsertProjects(Projects project);
        public void DeleteProject(Projects project);
    }
}
