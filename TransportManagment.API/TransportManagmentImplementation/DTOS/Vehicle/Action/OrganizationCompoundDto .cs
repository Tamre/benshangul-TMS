using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagmentImplementation.DTOS.Vehicle.Action
{
    public class OrganizationCompoundDto
    {

        public string OrganizationId { get; set; }
        public string CompoundType { get; set; }
        public string CompoundSize { get; set; }
        public string Remark { get; set; }
        public string ServiceZoneId { get; set; }
        public DateTime? ModifiedDate { get; set; } = null!;
    }
}
