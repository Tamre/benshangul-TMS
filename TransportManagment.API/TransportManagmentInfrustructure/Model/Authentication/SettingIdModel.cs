using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TransportManagmentInfrustructure.Enums.CommonEnum;
using System.ComponentModel;

namespace TransportManagmentInfrustructure.Model.Authentication
{
    public class SettingIdModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        [StringLength(45)]
        public string CreatedById { get; set; } = null!;
        public virtual ApplicationUser CreatedBy { get; set; } = null!;

        [DefaultValue(true)]
        public bool IsActive { get; set; }
    }
}
