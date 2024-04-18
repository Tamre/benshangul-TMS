using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportManagmentImplementation.DTOS.Vehicle.Configuration
{
    // DTOs
    public record DocumentTypePostDto
    {
        [StringLength(10)]
        [Required]
        public string FileName { get; set; } = null!;

        [Required]
        public string FileExtentions { get; set; } = null!;

        public bool IsPermanentRequired { get; set; }
        public bool IsTemporaryRequired { get; set; }

        public string CreatedById { get; set; } = null!;
    }

    public record DocumentTypeGetDto : DocumentTypePostDto
    {
        public int Id { get; set; }
    }

}
