using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagmentImplementation.DTOS.Common
{
    public record WoredaPostDto
    {
        public int ZoneId { get; set; }      

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

    public record WoredaGetDto : WoredaPostDto
    {
        public int Id { get; set; }

        public string ZoneName { get; set;}

        public bool IsActive { get; set; }
    }
}
