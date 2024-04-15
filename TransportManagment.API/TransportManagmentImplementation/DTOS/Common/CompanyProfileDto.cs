using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagmentImplementation.DTOS.Common
{
  
  
    public class CompanyProfileGetDto 
    {
        public int Id { get; set; }
        [StringLength(10)]
        public string Name { get; set; } = null!;
        [StringLength(15)]
        public string LocalName { get; set; } = null!;

        public IFormFile? LogoFile { get; set; }

        public string? Logo { get; set; }
        public string Email { get; set; } = null!;
        [StringLength(50)]
        public string Address { get; set; } = null!;
        [StringLength(50)]
        public string Description { get; set; } = null!;

        public string CreatedById { get; set; }
    }


}
