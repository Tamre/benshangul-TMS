using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TransportManagmentInfrustructure.Enums.CommonEnum;

namespace TransportManagmentImplementation.DTOS.Common
{
    public record CommonCodePostDto
    {
        public int ZoneId { get; set; }

        public string CommonCodeType { get; set; }

        [StringLength(5)]
        public string Name { get; set; } = null!;
        public int Pad { get; set; }
        public int CurrentNumber { get; set; }

        public string CreatedById { get; set; }

    }

    public record CommonCodeGetDto:CommonCodePostDto
    {

        public int Id { get; set; }

        public string ZoneName { get; set; }

        public bool IsActive { get; set; }
    }
}
