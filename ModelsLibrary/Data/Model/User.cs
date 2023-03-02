using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskKevin.ModelsLibrary.Data.Model
{
    public class User
    {
        public int id { get; set; }
        [StringLength(256)]
        [Required]
        public string name { get; set; }
        [StringLength(256)]
        [Required]
        public string surname { get; set; }
        /*[Required]*/
        /*public int age { get; set; }*/
        [StringLength(256)]
        [Required]
        public string username { get; set; }
        [StringLength(256)]
        [Required]
        public string password { get; set; }
        [StringLength(256)]

        [ForeignKey("RoleId")]
        public int RoleId { get; set; }
        public Roles role { get; set; }

        public ICollection<Projects> ProjectLink { get; set; }
        public ICollection<Task> TaskLink { get; set; }

    }
}
