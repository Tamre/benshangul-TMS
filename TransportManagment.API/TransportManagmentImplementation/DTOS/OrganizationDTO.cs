using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;
using TransportManagmentImplementation.DTOS.Common;
using TransportManagmentInfrustructure.Data;

namespace TransportManagmentImplementation.DTOS
{
    public class OrganizationDTO
    {
       
            [Required]
            public Guid Id { get; set; }
            [Required]
            [StringLength(ValidationClasses.MaxNameLength)]
            public string Name { get; set; } = null!;
            [Required]
            [StringLength(ValidationClasses.TaxIdentificationNumberLength)]
            public string Tin { get; set; } = null!;
            [Required]
            [StringLength(ValidationClasses.MaxNameLength)]
            public string LocalName { get; set; } = null!;
            [Required]
            public int ZoneId { get; set; }
           // public virtual ZoneListDTO Zone { get; set; } = null!;
            public int? WoredaId { get; set; }
          //  public virtual WoredaDTO Woreda { get; set; } = null!;
           // [StringLength(ValidationClasses.MaxAddressLength)]
            public string? Town { get; set; }
           // [StringLength(ValidationClasses.MaxAddressLength)]
            public string? SubCity { get; set; }
          //  [StringLength(ValidationClasses.MaxAddressLength)]
            public string? Kebele { get; set; }
            [Required]
          //  [StringLength(ValidationClasses.AddressNumberLength)]
            public string HouseNumber { get; set; } = null!;
            [Required]
            [StringLength(ValidationClasses.PhoneNumber)]
            public string PhoneNumber { get; set; } = null!;
            [StringLength(ValidationClasses.PhoneNumber)]
            public string? SecondaryPhoneNumber { get; set; }
            [Required]
            public TypeOfOrganization TypeOfOrganization { get; set; }
            public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
            [Required]
            [StringLength(ValidationClasses.UserId)]
            public string? CreatedById { get; set; } = null!;
            public DateTime? ModifiedDate { get; set; } = null!;
           [StringLength(ValidationClasses.UserId)]
           public string? ModifiedById { get; set; } = null!;
        
      
}
}
