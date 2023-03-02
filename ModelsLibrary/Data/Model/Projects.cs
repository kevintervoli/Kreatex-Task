using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskKevin.ModelsLibrary.Data.Model
{
    public class Projects
    {
        [Key]
        public int projectId { get; set; }
        [Required]
        [StringLength(256)]
        public string projectName { get; set; }
        [Required]
        [StringLength(512)]
        public string projectData { get; set; }
        [Required]
        public DateTime dateCreated { get; set; }
        // one to many relationship
        public ICollection<Task> Task { get; set; }
        //many to many relationship
        public ICollection<User> User { get; set; }

    }
}
