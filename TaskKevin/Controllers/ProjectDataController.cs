using Microsoft.AspNetCore.Mvc;
using ModelsLibrary.Repositories;
using System.Threading.Tasks;
using TaskKevin.ModelsLibrary.Data.Model;
using System.Collections.Generic;


namespace TaskKevin.Controllers
{
    public class ProjectDataController : ControllerBase
    {
        private readonly ProjectRepo repository;
        public ProjectDataController(ProjectRepo _repository)
        {
            repository = _repository;
        }
        [HttpPost("Projects/add")]
        public IActionResult addProject([FromBody] Projects project)
        {
            if (!repository.ProjectExists(project.projectName))
            {
                repository.InsertProjects(project);
                return Ok("Project added to database");
            }
            return Forbid("Project already exists");
        }
        [HttpDelete("Projects/delete")]
        public IActionResult delteProjects(Projects project)
        {
            if (!repository.ProjectExists(project.projectName))
            {
                return NotFound("Project does not exist in the database");
            }
            repository.DeleteProject(project);
            return Ok("Project deleted");
        }
        [HttpGet("Projects/GetTasks")]
        public IEnumerable<Projects> getProjects()
        {
            var tasks = repository.GetItems();
            return tasks;
        }
        [HttpGet("Projects/Specific")]
        public IEnumerable<Projects> getTask(string taskName)
        {
            return (IEnumerable<Projects>)repository.GetItem(taskName);
        }
    }
}
