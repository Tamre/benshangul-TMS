using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Helper;

namespace TransportManagmentImplementation.Interfaces.Vehicle.Action
{
    public interface IInpsectionService
    {

        public Task<InspectionDto> GetInspectionByVehicleId(Guid vehicleId);
        public Task<ResponseMessage> CreateFieldInspection(FieldInspectionPostDto inspection);
        public Task<ResponseMessage> CreateTechnicalInspection(TechnicalInspectionPostDto inspection);
        public Task<ResponseMessage> UpdateFieldInspection(FieldInspectionGetDto inspection);
        public Task<ResponseMessage> UpdateTechnicalInspection(TechnicalInspectionGetDto inspection);

    }
}
