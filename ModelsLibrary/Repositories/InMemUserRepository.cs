using Microsoft.Data.SqlClient;
using ModelsLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskKevin.ModelsLibrary.Data.Model;

namespace TaskKevin.ModelsLibrary.Repositories
{
    public class InMemUserRepository : UserInterface
    {
        private List<User> userList = new List<User>();
        public IEnumerable<User> GetItems()
        {
            var context = new AppDbContext();
            userList = context.userTable.ToList();
            return userList;

        }
        public MyModel GetItem(string username)
        {
            var context = new AppDbContext();
            User user = context.userTable
                .Join(context.rolesTable, u => u.RoleId, r => r.RoleId, (u, r) => new { User = u, Role = r })
                .Where(ur => ur.User.username.Equals(username))
                .Select(ur => new User
                {
                    id = ur.User.id,
                    name = ur.User.name,
                    surname = ur.User.surname,
                    username = ur.User.username,
                    password = ur.User.password,
                    RoleId = ur.User.RoleId,
                    role = ur.Role
                })
                .FirstOrDefault();
            MyModel us = new MyModel();
            us.username = user.username;
            us.password = user.password;
            us.roleName = user.role.RoleName;
            return us;
        }
        public bool UserExists(string username)
        {
            var context = new AppDbContext();
            bool exists = context.userTable.Any(u => u.username == username);
            return exists;
        }
    }
}
