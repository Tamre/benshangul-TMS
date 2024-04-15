using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagmentImplementation.DTOS.Common
{
    public record ZonePostDto
    {
        public int RegionId { get; set; }
     
        public string Name { get; set; } = null!;
        [StringLength(15)]
        public string LocalName { get; set; } = null!;
        [StringLength(5)]
        public string Code { get; set; } = null!;
        [StringLength(5)]
        public string LocalCode { get; set; } = null!;
        [StringLength(10)]
        public string Seffix { get; set; } = null!;
        [StringLength(10)]
        public string LocalSuffix { get; set; } = null!;
        public bool IsCity { get; set; }
        public string CreatedById { get; set; }

    }

    public record ZoneGetDto:ZonePostDto
    {

        public int Id { get; set; }

        public string RegionName { get; set; }
    
    }
}
