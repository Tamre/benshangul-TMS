using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TransportManagmentInfrustructure.Enums.CommonEnum;

namespace TransportManagmentInfrustructure.Model.Authentication
{
    public class PasswordChangeRequest: SettingIdModel
    {
        public string RequesterName { get; set; } = null!;
        public string UserCode { get; set; } = null!;
        public string Zone { get; set; } = null!;
        public string MobileNo { get; set; } = null!;
        public PasswordChangeStatus PasswordChangeStatus { get; set; }
    }
}
