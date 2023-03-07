using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskKevin.ModelsLibrary.Data.Model;

namespace ModelsLibrary.Interfaces
{
    interface IProject
    {
        IEnumerable<Projects> GetItems();
        Projects GetItem(string project);
        bool UserExists(string project);

    }
}
