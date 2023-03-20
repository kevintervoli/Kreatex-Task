using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using TaskKevin.ModelsLibrary.Data.Model;
using TaskKevin.ModelsLibrary.Repositories;

namespace TaskKevin.Controllers
{
    [Route("api/[controller]")]
    [Consumes("application/json")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserRepo _repository;
        public UserController(UserRepo repository)
        {
            _repository = repository;
        }
        [HttpGet("admin")]
        [Authorize(Roles= "admin")]
        public IActionResult AdminEndPoint()
        {
            var currentUSer = GetCurrentUser();
            return Ok($"Hi there {currentUSer.username}");
        }
        [HttpGet("Employee")]
        [Authorize(Roles = "Employee")]
        public IActionResult SellerEndPoint()
        {
            var currentUSer = GetCurrentUser();
            return Ok($"Hi there employee {currentUSer.username}");
        }

        [HttpGet("AdminsAndEmployee")]
        [Authorize(Roles = "Administrator,Employee")]
        public IActionResult AdminsAndSellerEndPoint()
        {
            var currentUSer = GetCurrentUser();
            return Ok($"Hi there employee/admin {currentUSer.username}");
        }
        [HttpGet("Public")]
        public IActionResult Public()
        {
            return Ok("Hi your are on public property");
        }
        [HttpGet("AllUsers")]
        public IEnumerable<User> GetUsers()
        {
            var users = _repository.GetItems();
            return users;
        }
        public UserViewModel GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if(identity != null)
            {
                var userClaims = identity.Claims;
                return new UserViewModel
                {
                    username = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    password = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    roleName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value
                };
            }
            return null;
        }

    }
}
