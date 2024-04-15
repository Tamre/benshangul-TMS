using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Model.Authentication;

namespace TransportManagmentInfrustructure.Model.Common
{
    public class CompanyProfile : SettingIdModel
    {
        [StringLength(20)]
        public string Name { get; set; } = null!;
        [StringLength(20)]
        public string LocalName { get; set; } = null!;
        [StringLength(100)]
        public string Logo { get; set; } = null!;
        [StringLength(20)]
        public string Email { get; set; } = null!;
        [StringLength(50)]
        public string Address { get; set; } = null!;
        [StringLength(50)]
        public string Description { get; set; } = null!;
    }
}
