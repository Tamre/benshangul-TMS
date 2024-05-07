using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Model.Authentication;
using TransportManagmentInfrustructure.Model.Common;
using TransportManagmentInfrustructure.Model.Vehicle.Configuration;
using static TransportManagmentInfrustructure.Enums.CommonEnum;

namespace TransportManagmentInfrustructure.Model.Vehicle.Action
{
    public class VehiclePlate: ActionIdModel
    {
      
        [Required]
        public Guid VehicleId { get; set; }
        public virtual VehicleList Vehicle { get; set; } = null!;

        [Required]
        public Guid PlateStockId { get; set; }
        public virtual PlateStock PlateStock { get; set; } = null!;
        [Required]
        public int GivenZoneId { get; set; }
        public virtual ZoneList GivenZone { get; set; } = null!;
        public ServiceModule ServiceModule { get; set; } 
        public ServiceModule PreviousModule { get; set; }

       
    }
}
