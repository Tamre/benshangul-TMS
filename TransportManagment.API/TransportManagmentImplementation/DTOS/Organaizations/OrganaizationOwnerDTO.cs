using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TransportManagmentInfrustructure.Enums.CommonEnum;
using TransportManagmentInfrustructure.Model.Common;
using System.ComponentModel.DataAnnotations;
using TransportManagmentInfrustructure.Data;

namespace TransportManagmentImplementation.DTOS.Organaizations
{
    public class OrganaizationOwnerDTO
    {
        public Guid Id { get; set; }
        public string OrganizationId { get; set; }
        public string SNO { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FirstNameAm { get; set; }
        public string MiddleNameAm { get; set; }
        public string LastNameAm { get; set; }
        public Gender Gender { get; set; }
        public string RegionId { get; set; }
        public virtual Region Region { get; set; }
        public string ZoneId { get; set; }

        public string WoredaId { get; set; }
        public virtual Woreda Woreda { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string ServiceZoneId { get; set; }

        public string Remark { get; set; }
        public string Town { get; set; }
        public string Kebele { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
        [Required]
        [StringLength(ValidationClasses.UserId)]
        public string? CreatedById { get; set; } = null!;
        public DateTime? ModifiedDate { get; set; } = null!;
        [StringLength(ValidationClasses.UserId)]
        public string? ModifiedById { get; set; } = null!;
    }
}
