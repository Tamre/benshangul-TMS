using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Model.Common;

namespace TransportManagmentImplementation.DTOS.Common
{
    public record RegionPostDto
    {

        public int CountryId { get; set; }     

        [StringLength(10)]
        public string Name { get; set; } = null!;
        [StringLength(15)]
        public string LocalName { get; set; } = null!;
        [StringLength(5)]
        public string Code { get; set; } = null!;
        [StringLength(5)]
        public string LocalCode { get; set; } = null!;

        public string CreatedById { get; set; }
    }

    public record RegionGetDto : RegionPostDto { 

        public int Id { get; set; }

        public string CountryName { get; set; }

        public bool IsActive { get; set; }
    }
}
