using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Model.Authentication;
using TransportManagmentInfrustructure.Model.Common;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;

namespace TransportManagmentInfrustructure.Model.Organizations
{
    public class OrganizationList: ActionIdModel
    {
        public string Name { get; set; } = null!;
        public string LocalName { get; set; } = null!;
        public int ZoneId { get; set; }
        public virtual ZoneList Zone { get; set; } = null!;
        public int? WoredaId { get; set; }
        public virtual Woreda Woreda { get; set; } = null!;
        public string? Town { get; set; }
        public string? SubCity { get; set; } 
        public string? Kebele { get; set; } 
        public string HouseNumnber { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? SecondaryPhoneNumber { get; set; }
        public TypeOfOrganization TypeOfOrganization { get; set; }
    }
}
