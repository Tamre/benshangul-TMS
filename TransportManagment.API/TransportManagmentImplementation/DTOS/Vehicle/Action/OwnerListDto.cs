using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TransportManagmentInfrustructure.Enums.CommonEnum;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Common;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;
using TransportManagmentInfrustructure.Model.TrainingCenter;
using TransportManagmentInfrustructure.Model.Vehicle.Action;

namespace TransportManagmentImplementation.DTOS.Vehicle.Action
{
    public record OwnerListPostDto
    {

        [Required, StringLength(30)]
        public string FirstName { get; set; } = null!;
        [StringLength(ValidationClasses.MaxNameLength)]
        public string? MiddleName { get; set; } = null!;
        [ StringLength(ValidationClasses.MaxNameLength)]
        public string? LastName { get; set; } = null!;
        [Required, StringLength(30)]
        public string AmharicFirstName { get; set; } = null!;
        [ StringLength(ValidationClasses.MaxLocalNameLength)]
        public string? AmharicMiddleName { get; set; } = null!;
        [ StringLength(ValidationClasses.MaxLocalNameLength)]
        public string? AmharicLastName { get; set; } = null!;
      
        public Gender Gender { get; set; }
        [Required]
        public int ZoneId { get; set; }

        public int? WoredaId { get; set; }
       
        [StringLength(ValidationClasses.MaxNameLength)]
        public string? Town { get; set; }
        [StringLength(ValidationClasses.MaxNameLength)]
        public string? HouseNo { get; set; }
        [Required, StringLength(ValidationClasses.PhoneNumber)]
        public string PhoneNumber { get; set; } = null!;
        [StringLength(ValidationClasses.PhoneNumber)]
        public string? SecondaryPhoneNumber { get; set; }
        [StringLength(ValidationClasses.MaxNameLength)]
        public string? IdNumber { get; set; } = null!;
        [StringLength(ValidationClasses.MaxNameLength)]
        public string? PoBox { get; set; }
        public OrganizationType OrganizationType { get; set; }
        public OwnerGroup OwnerGroup { get; set; }

        public string CreatedById { get; set; } = null!;
        public int ServiceZoneId { get; set; }

    }

    public record OwnerListGetDto : OwnerListPostDto
    {
        public Guid Id { get; set; }
        public string? OwnerNumber { get; set; } = null!;
        public string? FullName { get; set; }
        public string? AmharicName { get; set; }
        public string? Woreda { get; set; }
        public string? Zone { get; set; }
        public string OwnerGroup { get; set; }= null!;
    }
    public record VehicleOwnerListGetDto 
    {

        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public string OwnerNumber { get; set; }= null!;
        public Guid VechicleId { get; set; }
        public string? VehicleRegistrationNo { get; set; }
        public string? FullName { get; set; }
        public string? AmharicName { get; set; }
        public string? Woreda { get; set; }
        public string? Zone { get; set; }
        public string? TrainingCenter { get; set; }
        public string? OwnerState { get; set; }

        public string Gender { get; set; } = null!;

        public string IdNumber { get; set; }

        public string Town { get; set; }

        public string HouseNo { get; set; }

        public string PhoneNumber { get; set; }

        public string SecondaryPhoneNumber { get; set; }

        public string PoBox { get; set; }

    }

    public record VehicleOwnerDto
    {
        public Guid VehicleId { get; set; }
        public Guid? OwnerId { get; set; }
        public Guid? TrainingCenterId { get; set; }
        public OwnerState OwnerState { get; set; }

        public string CreatedById { get; set; } = null!;

      

    }

    public record OwnerListDropdownDto
    {
        public Guid Id { get; set; }
        public string OwnerName { get; set; } = null!;
        public string OwnerNumber { get; set; } = null!;

        public string OwnerGroup { get; set; } = null!;
    }

  
}
