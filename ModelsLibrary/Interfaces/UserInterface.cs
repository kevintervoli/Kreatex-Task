using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskKevin.ModelsLibrary.Data.Model;

namespace ModelsLibrary.Interfaces
{
    interface UserInterface
    {
        IEnumerable<User> GetItems();
        MyModel GetItem(string username);
        bool UserExists(string username);

    }
}
