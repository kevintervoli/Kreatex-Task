using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskKevin.ModelsLibrary.Data.Model;

namespace ModelsLibrary.Data.ViewModel
{
   public  class RolesViewModel
    {
        [Key]
        public int RoleId { get; set; }
        [Required]
        [StringLength(50)]
        public string RoleName { get; set; }
        public User userLink { get; set; }
    }
}
