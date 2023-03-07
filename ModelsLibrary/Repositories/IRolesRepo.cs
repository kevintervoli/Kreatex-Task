using ModelsLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskKevin.ModelsLibrary.Data.Model;

namespace ModelsLibrary.Repositories
{
    class IRolesRepo : IRoles
    {

        public IEnumerable<Roles> GetRoleData()
        {
            var context = new AppDbContext();
            List<Roles>  roles = context.rolesTable.ToList();
            return roles;
        }

        public bool TaskRoleExist(string role)
        {
            var context = new AppDbContext();
            bool exists = context.rolesTable.Any(u => u.RoleName.Equals(role));
            return exists;
        }
        public void InsertRole(Roles role)
        {
            var context = new AppDbContext();
            context.rolesTable.Add(role);
        }
        public void DeleteRole(Roles role)
        {
            var context = new AppDbContext();
            context.rolesTable.Remove(role);
        }
    }
}
