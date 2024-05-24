using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Vehicle.Action;
using TransportManagmentInfrustructure.Model.Vehicle.Configuration;

namespace TransportManagmentImplementation.DTOS.Vehicle.Action
{
    public record ValuationDto
    {
        [Required]
        public Guid VehicleId { get; set; }

        [Required]
        public int DepreciationCostId { get; set; }
        [Required]
        public double DepreciationCostValue { get; set; }
        [Required]
        public int FactoryPointId { get; set; }
        [Required]
        public double FactoryPointValue { get; set; }
        [Required]
        public int InitialPriceId { get; set; }
        [Required]
        public double InitialPriceValue { get; set; }
        [Required]
        public int SalvageValueID { get; set; }
        [Required]
        public double SalvageValuePrice { get; set; }
        [Required]
        public int ServiceYearId { get; set; }
        [Required]
        public double ServiceYearValue { get; set; }
        [Required]
        public double VehicleTypeValue { get; set; }

        [StringLength(ValidationClasses.MaxSettingRemarkLength)]
        public string? Remark { get; set; } = null!;
        [Required]
        public int ValuationReasonId { get; set; }
        [Required]
        public double SellersAgreement { get; set; }
    }
}
