using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Model.Authentication;
using static TransportManagmentInfrustructure.Enums.CommonEnum;

namespace TransportManagmentInfrustructure.Model.Common
{
    public class DeviceList: SettingIdModel
    {
        [StringLength(10)]
        public string PCNAme { get; set; } = null!;

        [StringLength(10)]
        public string IpAddress { get; set; } = null!;

        [StringLength(100)]
        public string MACAddress { get; set; } = null!;

        [StringLength(450)]
        public string? ApproverId { get; set; }
        public virtual ApplicationUser Approver { get; set; } = null!;
        public ApprovedFor ApprovedFor { get; set; }
    }
}
