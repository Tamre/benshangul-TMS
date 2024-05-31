using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagmentImplementation.DTOS.Organaizations
{
    public class OrganizationCompoundDto
    {
        public Guid Id { get; set; }
        public Guid OrganizationId { get; set; }
        public string CompoundType { get; set; }
        public string CompoundSize { get; set; }
        public string Remark { get; set; }
        public string ServiceZoneId { get; set; }
        public string? ModifiedById { get; set; } = null!;
        public DateTime? ModifiedDate { get; set; } = null!;
       
    }
}
