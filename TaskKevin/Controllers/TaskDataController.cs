using Microsoft.AspNetCore.Mvc;
using ModelsLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskKevin.ModelsLibrary.Data.Model;

namespace TaskKevin.Controllers
{
    public class TaskDataController : ControllerBase
    {
        private readonly TaskRepo repository;
        public TaskDataController(TaskRepo _repository)
        {
            repository = _repository;
        }
        [HttpPost("Task/add")]
        public IActionResult addTask([FromBody] Task task)
        {
            if (!repository.TaskExist(task.taskName.ToString()))
            {
                repository.InsertTask(task);
                return Ok("Task added to database");
            }
            return Forbid("Task already exists");
        }
        [HttpDelete("Task/delete")]
        public IActionResult delteProjects(Task task)
        {
            if (!repository.TaskExist(task.taskName.ToString()))
            {
                return NotFound("Task does not exist in the database");
            }
            repository.DeleteTask(task);
            return Ok("Project deleted");
        }
        [HttpGet("Task/GetTasks")]
        public IEnumerable<Task> getProjects()
        {
            var tasks = repository.GetTaskData();
            return tasks;
        }
        [HttpGet("Task/Specific")]
        public IEnumerable<Projects> getTask(string taskName)
        {
            return (IEnumerable<Projects>)repository.GetSpecificTask(taskName);
        }
    }
}
