using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Authentication;
using TransportManagmentInfrustructure.Model.Common;
using TransportManagmentInfrustructure.Model.Vehicle.Configuration;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;

namespace TransportManagmentInfrustructure.Model.Vehicle.Action
{
    public class PlateStock: ActionIdModel
    {
        public PlateStock()
        {
            Plates = new HashSet<VehiclePlate>();
        }

        [Required]
        public int PlateTypeId { get; set; }
        public virtual PlateType PlateType { get; set; } = null!;
        [Required]
        public int RegionId { get; set; }
        public virtual Common.Region Region { get; set; } = null!;

        [Required, StringLength(ValidationClasses.SerialNumberLength)]
        public string PlateNo { get; set; } = null!;
        [Required]
        public int FrontPlateSizeId { get; set; }
        public virtual VehicleLookups FrontPlateSize { get; set; } = null!;
        public int? BackPlateSizeId { get; set; }
        public virtual VehicleLookups BackPlateSize { get; set; } = null!;
        public PlateDigit PlateDigit { get; set; } 
        public int? ToZoneId { get; set; }
        public virtual ZoneList ToZone { get; set; } = null!;
        public GivenStatus GivenStatus { get; set; }
        public IssuanceType IssuanceType { get; set; }
        public bool IsBackLog { get; set; }
        public VehiclePlate VehiclePlate { get; set; } = null!;

        [InverseProperty(nameof(VehiclePlate.PlateStock))]
        public ICollection<VehiclePlate> Plates { get; set; }

    }
}
