using ModelsLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskKevin.ModelsLibrary.Data.Model;

namespace ModelsLibrary.Repositories
{
    class IProjectRepo : IProject
    {
        public Projects GetItem(string project)
        {
            var context = new AppDbContext();
            Projects projectData = context.projectsTable.FirstOrDefault(t =>t.projectName.Equals(project));
            return projectData;
        }

        public IEnumerable<Projects> GetItems()
        {
            var context = new AppDbContext();
            List<Projects> projectList = context.projectsTable.ToList();
            return projectList;
        }

        public bool UserExists(string project)
        {
            var context = new AppDbContext();
            bool exists = context.projectsTable.Any(u => u.projectName.Equals(project));
            return exists;
        }
        public void InsertProjects(Projects project)
        {
            var context = new AppDbContext();
            context.projectsTable.Add(project);
        }
        public void DeleteProject(Projects project)
        {
            var context = new AppDbContext();
            context.projectsTable.Remove(project);
        }
    }
}
