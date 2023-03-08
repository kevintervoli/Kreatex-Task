using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TaskKevin.ModelsLibrary.Data.Model;
using TaskKevin.ModelsLibrary.Repositories;

namespace TaskKevin.Controllers
{
    public class UserDataController : ControllerBase
    {
        private readonly IUserRepo repository;
        public UserDataController(IUserRepo _repository)
        {
            repository = _repository;
        }
        [HttpPost("User/add")]
        public IActionResult addUser([FromBody] User user)
        {
            if (!repository.UserExists(user.username))
            {
                repository.InsertUser(user);
                return Ok("User added to database");
            }
            return Forbid("User already exists");
        }
        [HttpDelete("User/delete")]
        public IActionResult deleteUser(User user)
        {
            if (repository.UserExists(user.username))
            {
                return NotFound("User does not exist in the database");
            }
            repository.DeleteUser(user);
            return Ok("User deleted");
        }
        [HttpGet("User/GetUsers")]
        public IEnumerable<User> GetUsers()
        {
            var users = repository.GetItems();
            return users;
        }
        [HttpGet("User/Specific")]
        public IEnumerable<User> getUser(string username)
        {
            return (IEnumerable<User>)repository.GetItem(username);
        }

    }
}
