using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskKevin.ModelsLibrary.Data.Model;

namespace ModelsLibrary.Interfaces
{
    interface IUser
    {
        IEnumerable<User> GetItems();
        UserViewModel GetItem(string username);
        bool UserExists(string username);
        void InsertUser(User user);
        public void DeleteUser(User user);
    }
}
