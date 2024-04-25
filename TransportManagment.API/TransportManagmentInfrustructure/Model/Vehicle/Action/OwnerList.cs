using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Authentication;
using TransportManagmentInfrustructure.Model.Common;
using static TransportManagmentInfrustructure.Enums.CommonEnum;

namespace TransportManagmentInfrustructure.Model.Vehicle.Action
{
    public class OwnerList : ActionIdModel
    {
        [Required, StringLength(ValidationClasses.SerialNumberLength)]
        public string OwnerNumber { get; set; } = null!;

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
        public Gender Gender { get; set; }
        [Required]
        public int ZoneId { get; set; }
        public virtual ZoneList Zone { get; set; } = null!;
        public int? WoredaId { get; set; }
        public virtual Woreda Woreda { get; set; } = null!;
        [StringLength(ValidationClasses.MaxNameLength)]
        public string? Town { get; set; }
        [StringLength(ValidationClasses.MaxNameLength)]
        public string? HouseNo { get; set; }
        [Required,StringLength(ValidationClasses.PhoneNumber)]
        public string PhoneNumber { get; set; } = null!;
        [StringLength(ValidationClasses.PhoneNumber)]
        public string? SecocdaryPhoneNumber { get; set; }
        [StringLength(ValidationClasses.MaxNameLength)]
        public string IdNumber { get; set; } = null!;
        [StringLength(ValidationClasses.MaxNameLength)]
        public string? PoBox { get; set; } 
    }
}
