using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskKevin.ModelsLibrary.Data.Model;

namespace ModelsLibrary.Interfaces
{
    interface IRoles
    {
        IEnumerable<Roles> GetRoleData();
        bool TaskRoleExist(string task);
        void InsertRole(Roles roles);
        public void DeleteRole(Roles role);
    }
}
