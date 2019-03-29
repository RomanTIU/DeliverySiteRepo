using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeliverySite.Models
{
    public class AssignRolesToUser
    {
        [Required(ErrorMessage = " Select Role Name")]
        public string RoleName { get; set; }

        [Required(ErrorMessage = "Select UserName")]
        public string UserId { get; set; }

        public List<SelectListItem> Userlist { get; set; }

        public List<SelectListItem> RolesList { get; set; }
    }
}