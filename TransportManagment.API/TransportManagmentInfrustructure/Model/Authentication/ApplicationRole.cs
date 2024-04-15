using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TransportManagmentInfrustructure.Enums.CommonEnum;

namespace TransportManagmentInfrustructure.Model.Authentication
{

    public class RoleCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public RoleModule RoleModule { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Date { get; set; }
    }
    public class ApplicationRole: IdentityRole
    {
        public int RoleCategoryId { get; set; }
        public virtual RoleCategory RoleCategory { get; set; } = null!;
    }

}
