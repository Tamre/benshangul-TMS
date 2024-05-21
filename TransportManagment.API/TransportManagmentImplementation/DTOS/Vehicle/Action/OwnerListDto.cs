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
        [Required, StringLength(ValidationClasses.MaxNameLength)]
        public string FirstName { get; set; } = null!;
        [Required, StringLength(ValidationClasses.MaxNameLength)]
        public string MiddleName { get; set; } = null!;
        [Required, StringLength(ValidationClasses.MaxNameLength)]
        public string LastName { get; set; } = null!;
        [Required, StringLength(ValidationClasses.MaxLocalNameLength)]
        public string AmharicFirstName { get; set; } = null!;
        [Required, StringLength(ValidationClasses.MaxLocalNameLength)]
        public string AmharicMiddleName { get; set; } = null!;
        [Required, StringLength(ValidationClasses.MaxLocalNameLength)]
        public string AmharicLastName { get; set; } = null!;
        [Required]
        public string Gender { get; set; } = null!;
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
        public string IdNumber { get; set; } = null!;

        [StringLength(ValidationClasses.MaxNameLength)]
        public string? PoBox { get; set; }
        public string CreatedById { get; set; } = null!;
    }

    public record OwnerListGetDto : OwnerListPostDto
    {

        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public Guid VechicleId { get; set; }
        public string? VehicleRegistrationNo { get; set; }
        public string? FullName { get; set; }
        public string? AmharicName { get; set; }
        public string? Woreda { get; set; }
        public string? Zone { get; set; }
        public string? TrainingCenter { get; set; }
        public string? OwnerState { get; set; }

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
    }

  
}
