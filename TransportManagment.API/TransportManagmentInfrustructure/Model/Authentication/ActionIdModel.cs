using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TransportManagmentInfrustructure.Enums.CommonEnum;

namespace TransportManagmentInfrustructure.Model.Authentication
{
    public class ActionIdModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        [StringLength(450)]
        public string CreatedById { get; set; } = null!;
        public virtual ApplicationUser ApplicationUser { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
