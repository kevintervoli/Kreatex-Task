using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskKevin.ModelsLibrary.Data.Model
{
    public class Task
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(256)]
        public int taskName { get; set; }
        [Required]
        [StringLength(512)]
        public int taskProperties { get; set; }
        [Required]
        public bool completed { get; set; }
        public ICollection<User> UserLink {get;set;}
    }
}
