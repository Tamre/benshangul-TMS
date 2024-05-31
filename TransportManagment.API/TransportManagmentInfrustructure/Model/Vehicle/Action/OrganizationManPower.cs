using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Model.Authentication;
using static TransportManagmentInfrustructure.Enums.CommonEnum;

namespace TransportManagmentInfrustructure.Model.Vehicle.Action
{
    public class OrganizationManPower : ActionIdModel
    {
        [StringLength(40)]
        public string OrganizationId { get; set; }

        [StringLength(40)]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        [StringLength(220)]
        public string FullName { get; set; }
        public string FirstNameAm { get; set; }
        public string MiddleNameAm { get; set; }
        public string LastNameAm { get; set; }
        [StringLength(220)]
        public string AmharicFullName { get; set; }

        [StringLength(220)]
        public string Position { get; set; }

        [StringLength(25)]
        public string PhoneNo { get; set; }
        public bool IsActive { get; set; }
        public string Remark { get; set; }
        public Gender Gender { get; set; }
        public string ServiceZoneId { get; set; }
        public string EducationLevel { get; set; }
        public string Qualification { get; set; }
    }
}
