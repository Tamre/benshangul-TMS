using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static TransportManagmentInfrustructure.Enums.CommonEnum;

namespace TransportManagmentInfrustructure.Model.Authentication
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = null!;
        public string AmharicName { get; set; } = null!;
        public string UserCode { get; set; } = null!;
        public RoleModule Module { get; set; }
        public UserType UserType { get; set; }
        public string UserTypeId { get; set; } = null!;
        public bool IsPasswordChanged { get; set; }
        public bool IsActive { get; set; }
    }
}
