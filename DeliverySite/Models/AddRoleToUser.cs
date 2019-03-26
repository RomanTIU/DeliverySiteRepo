using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeliverySite.Models
{
    public class AddRoleToUser
    {
        public AddRoleToUser() { }

        public AddRoleToUser(ApplicationUserRole role)
        {
            UserId = role.UserId;

            RoleId = role.RoleId;
        }

        public string UserId { get; set; }

        public string RoleId { get; set; }
    }
}
