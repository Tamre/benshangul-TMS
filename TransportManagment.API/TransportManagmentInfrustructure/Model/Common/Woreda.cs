﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Model.Authentication;

namespace TransportManagmentInfrustructure.Model.Common
{
    public class Woreda : SettingIdModel
    {
        public int ZoneId { get; set; }
        public virtual ZoneList Zone { get; set; } = null!;

        [StringLength(10)]
        public string Name { get; set; } = null!;
        [StringLength(15)]
        public string LocalName { get; set; } = null!;
        [StringLength(5)]
        public string Code { get;set; } = null!;
        [StringLength(5)]
        public string LocalCode { get; set; } = null!;
    }
}
