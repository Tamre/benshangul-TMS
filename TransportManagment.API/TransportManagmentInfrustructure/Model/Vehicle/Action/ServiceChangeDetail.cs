using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;
using TransportManagmentInfrustructure.Model.Authentication;

namespace TransportManagmentInfrustructure.Model.Vehicle.Action
{
    public class ServiceChangeDetail : ActionIdModel
    {
        [Required]
        public Guid ServiceChangeId { get; set; }
        [Required]
        public ServiceChangeType ServiceChangeType { get; set; }
        [Required]
        public string OldValue { get; set; } = null!;
        [Required]
        public string NewValue { get; set; } = null!;







    }
}
