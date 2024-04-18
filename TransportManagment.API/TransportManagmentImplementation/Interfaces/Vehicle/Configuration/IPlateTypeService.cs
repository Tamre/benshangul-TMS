using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Vehicle.Configuration;
using TransportManagmentImplementation.Helper;

namespace TransportManagmentImplementation.Interfaces.Vehicle.Configuration
{
    public interface IPlateTypeService
    {
        Task<ResponseMessage> Add(PlateTypePostDto plateTypePost);
        Task<ResponseMessage> Update(PlateTypeGetDto plateTypeGet);
        Task<List<PlateTypeGetDto>> GetAll();
    }
}
