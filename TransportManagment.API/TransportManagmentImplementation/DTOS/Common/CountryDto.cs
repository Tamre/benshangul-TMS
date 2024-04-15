using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagmentImplementation.DTOS.Common
{
    public record CountryPostDto
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
        public string CreatedById { get; set; } = null!;
    }

    public record CountryGetDto: CountryPostDto
    {

        public int Id { get; set; }
    }
}
