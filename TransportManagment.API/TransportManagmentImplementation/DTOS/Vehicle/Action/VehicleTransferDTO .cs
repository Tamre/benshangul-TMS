using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;

namespace TransportManagmentImplementation.DTOS.Vehicle.Action
{
    public class VehicleTransferDTO
    {
        public Guid VehicleId { get; set; }
        public int FromZoneId { get; set; }
        public int ToZoneId { get; set; }
        public DateTime TransferedDate { get; set; }
        public string LetterNo { get; set; } = null!;
        public string? Description { get; set; }
        public string TransferNumber { get; set; } = null!;
        public TransferStatus TransferStatus { get; set; }
        public string? PreviousPlate { get; set; }
        public bool IsVehicleRejected { get; set; }
        public bool ChangePlate { get; set; }
        public bool ChangeOwner { get; set; }
        public bool ChangeServiceType { get; set; }
        public string CretedById { get; set; }

    }
}
