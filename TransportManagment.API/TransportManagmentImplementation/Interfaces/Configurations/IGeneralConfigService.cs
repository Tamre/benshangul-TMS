using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Configuration;
using static TransportManagmentInfrustructure.Enums.CommonEnum;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;


namespace IntegratedImplementation.Interfaces.Configuration
{
    public interface IGeneralConfigService
    {
        Task<string> GenerateCode(GeneralCodeDto GeneralCodeType);
        Task<string> UploadFiles(IFormFile formFile, string Name, string FolderName);
        Task<string> GetFiles(string path);
        //Task<List<GeneralCodeDto>> GetGeneralCodes();
        public string GeneratePassword();
        Task<string> GenerateVehicleNumber(VehicleSerialType vehicleSerialType, int zoneId, string userId);
    }
}
