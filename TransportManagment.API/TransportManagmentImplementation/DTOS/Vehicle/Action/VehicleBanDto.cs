using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Authentication;
using TransportManagmentInfrustructure.Model.Vehicle.Action;
using TransportManagmentInfrustructure.Model.Vehicle.Configuration;

namespace TransportManagmentImplementation.DTOS.Vehicle.Action
{
    public record VehicleBanPostDto
    {

        [Required]
        public Guid VehicleId { get; set; }

        [Required]
        public int BanCaseId { get; set; }

        [Required]
        public int BanBodyId { get; set; }
 
        public double? MoneyAmmount { get; set; }
        public DateTime BanDate { get; set; }

        [Required, StringLength(ValidationClasses.LetterLength)]
        public string BanLetterNo { get; set; } = null!;
  

        [StringLength(ValidationClasses.MaxSettingRemarkLength)]
        public string? Enclosure { get; set; }


        public string CreatedById { get; set; } = null!;
    }

    public record VehicleBanGetDto : VehicleBanPostDto
    {

        public string VehicleRegistrationNo { get; set; } = null!;

        public string VehicleChesisNo { get; set; } = null!;

        public string BanCase { get; set; } = null!;

        public string BanBody { get; set; } = null!;

        public Guid Id { get; set; }
    }

    public record VehicleLiftBanDto
    {

        [Required]
        public Guid BanId { get; set; }
        [Required]
        public Guid VehicleId { get; set; }
      
        public string? LiftedById { get; set; } = null!;    
        public DateTime? LetterLiftDate { get; set; }

        [StringLength(ValidationClasses.LetterLength)]
        public string? LetterLiftNo { get; set; }
    }

}
