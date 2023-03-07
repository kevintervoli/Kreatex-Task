
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskKevin.ModelsLibrary.Data.Model;
using TaskKevin.ModelsLibrary.Repositories;

namespace TaskKevin.Controllers 
{
    public class LoginController : Controller
    {
        public string username;
        public string password;
        public string role;
        private IConfiguration _config;
        private readonly IUserRepo repository;
        public LoginController(IConfiguration config)
        {
            _config = config;
            repository = new IUserRepo();
        }
        [HttpPost("api/login")]
        public IActionResult Login([FromBody] UserViewModel mymodel)
        {
        
            if (repository.UserExists(mymodel.username))
            {
                mymodel = repository.GetItem(mymodel.username);

                var token = Generate(mymodel);
                return Ok(token);
            }
            return NotFound("User not found");
        }

        private string Generate(UserViewModel model)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier ,model.username),
                new Claim(ClaimTypes.NameIdentifier,model.password),
                new Claim(ClaimTypes.Role,model.roleName)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                                             _config["Jwt:Audience"],
                                             claims,
                                             expires: DateTime.Now.AddMinutes(15),
                                             signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
    }
