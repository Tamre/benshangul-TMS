using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TransportManagmentInfrustructure.Enums.CommonEnum;
using TransportManagmentInfrustructure.Model.Authentication;

namespace TransportManagmentImplementation.DTOS.Common
{
    public record DeviceListPostDto
    {
        [StringLength(20)]
        public string PCNAme { get; set; } = null!;

        [StringLength(20)]
        public string IpAddress { get; set; } = null!;

        [StringLength(100)]
        public string MACAddress { get; set; } = null!;

        [StringLength(450)]
        public string? ApproverId { get; set; }

        public string? ApprovedFor { get; set; }
        public string CreatedById { get; set; } = null!;
    }

    public record DeviceListGetDto : DeviceListPostDto
    {

        public int Id { get; set; }

        public string? ApproverUser { get; set; }

        public string ? RequesterUser { get; set; }

        public bool IsActive { get; set; }
    }
}
