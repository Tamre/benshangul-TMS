using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Authentication;
using TransportManagmentInfrustructure.Model.Vehicle.Configuration;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;

namespace TransportManagmentInfrustructure.Model.Vehicle.Action
{
    public class VehicleDocument: ActionIdModel
    {
        public Guid VehicleId { get; set; }
        public virtual VehicleList Vehicle { get; set; } = null!;
        public int DocumentTypeId { get; set; }
        public virtual DocumentType DocumentType { get; set; } = null!;
        [StringLength(ValidationClasses.MaxSettingRemarkLength)]
        public string DocumentPath { get; set; } = null!;

        public ForVehicleDocument ForVehicleDocument { get; set; }


    }
}
