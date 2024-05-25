using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Authentication;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;

namespace TransportManagmentImplementation.DTOS.Vehicle.Action
{

    public record DataChangeDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string TableName { get; set; }
        [Required]
        public Guid VehicleId { get; set; }     
        public string? Reason { get; set; }
        public string CreatedById { get; set; } = null!;
        [Required]       
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DataChangeStatus Status { get; set; }
        [StringLength(ValidationClasses.UserId)]
        public string? ApprovedById { get; set; }     
        public DateTime? ApprovedDate { get; set; }
        public string? Comments { get; set; }
        public IEnumerable<DataChangeDetailDto> DataChangeDetails { get; set; } = null!;



    }
    public record DataChangeDetailDto 
    {
        public Guid Id { get; set; }
        [Required]
        public Guid DataChangeId { get; set; }
        [Required]
        public TableColumnName ColumnName { get; set; }
        [Required]
        public string OldValue { get; set; }
        [Required]
        public string NewValue { get; set; }       

    }
    //public record DataChangeGetDto : DataChangePostDto
    //{

    //    public string AISNo { get; set; } = null!;
    //    public string VehicleRegistrationNo { get; set; } = null!;
    //    public string GivenZone { get; set; } = null!;
    //    public IEnumerable<DataChangeDetailGetDto> dataChangePostDetailDtos { get; set; }



    //}
    //public record DataChangeDetailGetDto: DataChangePostDetailDto
    //{

    //    public string AISNo { get; set; } = null!;
    //    public string VehicleRegistrationNo { get; set; } = null!;
    //    public string GivenZone { get; set; } = null!;

    //}


}
