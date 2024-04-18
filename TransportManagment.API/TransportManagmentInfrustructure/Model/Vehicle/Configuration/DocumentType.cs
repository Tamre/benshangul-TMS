using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Authentication;
using static TransportManagmentInfrustructure.Enums.CommonEnum;

namespace TransportManagmentInfrustructure.Model.Vehicle.Configuration
{
    public class DocumentType: SettingIdModel
    {
        [StringLength(ValidationClasses.MaxNameLength)]
        [Required]
        public string FileName { get; set; } = null!;
        public FileExtentions FileExtentions { get; set; }
        public bool IsPermanentRequired { get; set; }
        public bool IsTemporaryRequired { get; set; }

    }
}
