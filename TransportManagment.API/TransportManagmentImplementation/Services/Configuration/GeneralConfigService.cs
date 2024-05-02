
using AutoMapper;
using IntegratedImplementation.Interfaces.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Configuration;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Vehicle.Configuration;
using static TransportManagmentInfrustructure.Enums.CommonEnum;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;

namespace TransportManagmentImplementation.Services.Configuration
{
    public class GeneralConfigService :IGeneralConfigService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        
        public GeneralConfigService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<string> GenerateCode(GeneralCodeDto GeneralCodeType)
        {
            //var curentCode = await _dbContext.GeneralCodes.FirstOrDefaultAsync(x => x.GeneralCodeType == GeneralCodeType);
            //if (curentCode != null)
            //{
            //    var generatedCode = $"{curentCode.InitialName}/{curentCode.CurrentNumber.ToString().PadLeft(curentCode.Pad, '0')}/{DateTime.Now.Year}";

            //    curentCode.CurrentNumber += 1;
            //    await _dbContext.SaveChangesAsync();
            //    return generatedCode;
            //}
            return "";
        }

        public async Task<string> GenerateVehicleNumber(VehicleSerialType vehicleSerialType, int zoneId, string userId)
        {
            var curentCode = await _dbContext.VehicleSerialSettings.Include(x => x.Zone).FirstOrDefaultAsync(x => x.VehicleSerialType == vehicleSerialType);
            if (curentCode != null)
            {
                var generatedCode = $"{curentCode.Zone.Code}-{curentCode.Name}{curentCode.Value.ToString().PadLeft(curentCode.Pad, '0')}";

                curentCode.Value += 1;
                await _dbContext.SaveChangesAsync();
                return generatedCode;
            }
            else
            {
                var currentZone = await _dbContext.Zones.FindAsync(zoneId);
                if (currentZone == null)
                {
                    return "";
                }

                VehicleSerialSetting vehicleSerial = new VehicleSerialSetting()
                {
                    CreatedById = userId,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    Name = vehicleSerialType == VehicleSerialType.TRANSFERNO ? "TN" : "RN",
                    VehicleSerialType = vehicleSerialType,
                    Pad = 5,
                    Value = 1,
                    ZoneId = zoneId,
                };
                await _dbContext.VehicleSerialSettings.AddAsync(vehicleSerial);
                await _dbContext.SaveChangesAsync();

                var generatedCode = $"{currentZone.Code}-{vehicleSerial.Name}{vehicleSerial.Value.ToString().PadLeft(vehicleSerial.Pad, '0')}";

                return generatedCode;

            }

            return "";
        }

        public async Task<string> GetFiles(string path)
        {
            byte[] imageArray = await File.ReadAllBytesAsync(path);
            string imageRepresentation = Convert.ToBase64String(imageArray);
            return imageRepresentation.ToString();
        }

        public async Task<string> UploadFiles(IFormFile formFile, string Name, string FolderName)
        {
            var path = Path.Combine("wwwroot", FolderName);
            string pathToSave = Path.Combine(Directory.GetCurrentDirectory(), path);

            if (!Directory.Exists(pathToSave))
                Directory.CreateDirectory(pathToSave);

            if (formFile != null && formFile.Length > 0)
            {
                try
                {
                    string fileExtension = Path.GetExtension(formFile.FileName);
                    string fileName = $"{Name}{fileExtension}";
                    string filePath = Path.Combine(pathToSave, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }

                    var newPath = Path.Combine(path, fileName);
                    return newPath;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }

            return "";
        }


        //public async Task<List<GeneralCodeDto>> GetGeneralCodes()
        //{
        //    var generalCodeList = await _dbContext.GeneralCodes.AsNoTracking()
        //                          .ProjectTo<GeneralCodeDto>(_mapper.ConfigurationProvider)
        //                          .ToListAsync();
        //    return generalCodeList;
        //}

        public  string GeneratePassword()
        {
            int length = 8;
            string Letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&*()_-+=<>?0123456789";
            RandomNumberGenerator Rng = RandomNumberGenerator.Create();
           
            var data = new byte[length];
            Rng.GetBytes(data);

            var password = new char[length];
            for (int i = 0; i < length; i++)
            {
                int index = data[i] % Letters.Length;
                password[i] = Letters[index];
            }

            return new string(password);
        }
    }
}
