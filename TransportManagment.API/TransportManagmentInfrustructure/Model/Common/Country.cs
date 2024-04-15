using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Model.Authentication;
using static TransportManagmentInfrustructure.Enums.CommonEnum;

namespace TransportManagmentInfrustructure.Model.Common
{
    public class Country : SettingIdModel
    {
        [StringLength(10)]
        public string Name { get; set; } = null!;
        [StringLength(15)]
        public string LocalName { get; set; } = null!;
        [StringLength(5)]
        public string CountryCode { get; set; } = null!;
        [StringLength(10)]
        public string NationalityName { get; set; } = null!;
        [StringLength(15)]
        public string LocalNationalityName { get; set; } = null!;

    }
}
