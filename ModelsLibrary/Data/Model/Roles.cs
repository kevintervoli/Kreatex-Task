using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskKevin.ModelsLibrary.Data.Model
{
    public class Roles
    {
        [Key]
        public int RoleId { get; set; }
        [Required]
        [StringLength(50)]
        public string RoleName { get; set; }
        public User userLink { get; set; }
    }
}
