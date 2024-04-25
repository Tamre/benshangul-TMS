using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Authentication;
using TransportManagmentInfrustructure.Model.Common;
using TransportManagmentInfrustructure.Model.Vehicle.Configuration;

namespace TransportManagmentInfrustructure.Model.Vehicle.Action
{
    public class FieldInspection: ActionIdModel
    {
        [Required]
        public Guid VehicleId { get;set; }
        public virtual VehicleList Vehicle { get; set; } = null!;
        [Required]
        public int GivenZoneId { get; set; }
        public virtual ZoneList GivenZone { get; set; } = null!;
        public Guid? ServiceChangeId { get; set; }
        public virtual ServiceChange ServiceChange { get; set; } = null!;
        public double Width { get; set; }
        public double Height { get; set; }
        public double Length { get; set; }
        [StringLength(ValidationClasses.MaxLocalNameLength)]
        public string FrontTyreSize { get; set; } = null!;
        [StringLength(ValidationClasses.MaxLocalNameLength)]
        public string RearTyreSize { get; set; } = null!;
        public int NoOfRearAxel { get; set; }
        public int NoOfFrontAxel { get; set; }
        [StringLength(ValidationClasses.MaxNameLength)]
        public string AxelDriveType { get; set; } = null!;
        public int NumberOfTyre { get; set; }
        public double FrontAxelMAxLoad { get; set; }
        public double RearAxelMaxLoad { get; set; }
        public double GrossWeight { get; set; }
        public double TareWeight { get; set; }
        public int FrontPlateSizeId { get; set; }
        public virtual VehicleLookups FrontPlateSize { get; set; } = null!;
        public int? BackPlateSizeId { get; set; }
        public virtual VehicleLookups BackPlateSize { get; set; } = null!;
    }
}
