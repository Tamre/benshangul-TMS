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
    public class CommonCodes: SettingIdModel
    {
        public int ZoneId { get; set; }
        public virtual ZoneList Zone { get; set; } = null!;
        public CommonCodeType CommonCodeType { get; set; }
        [StringLength(5)]
        public string Name { get; set; } = null!;
        public int Pad { get; set; }
        public int CurrentNumber { get; set; }


    }
}
