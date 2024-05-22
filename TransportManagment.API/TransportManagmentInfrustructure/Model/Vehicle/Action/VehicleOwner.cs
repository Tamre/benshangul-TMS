using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Model.Authentication;
using TransportManagmentInfrustructure.Model.TrainingCenter;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;

namespace TransportManagmentInfrustructure.Model.Vehicle.Action
{
    public class VehicleOwner: ActionIdModel
    {
        [Required]
        public Guid VehicleId { get; set; }
        public virtual VehicleList Vehicle { get; set; } = null!;
        public Guid? OwnerId { get; set; }
        public virtual OwnerList Owner { get; set; } = null!;
        public Guid? TrainingCenterId { get; set; }
        public virtual TrainingCenterList TrainingCenter { get; set; } = null!;
        public OwnerState OwnerState { get; set; }
        

    }
}
