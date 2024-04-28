using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Vehicle.Configuration;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Vehicle.Configuration;
using TransportManagmentInfrustructure.Data;
using static TransportManagmentInfrustructure.Enums.VehicleEnum;
using TransportManagmentInfrustructure.Model.Vehicle.Configuration;
using Microsoft.EntityFrameworkCore;
using TransportManagmentImplementation.DTOS.Common;
using TransportManagmentImplementation.Interfaces.Common;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Serilog;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;
using Serilog.Context;
using System.Reflection;


namespace TransportManagmentImplementation.Services.Vehicle.Configuration
{
    public class BanBodyService : IBanBodyService
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<BanBodyService> _logger;




        public BanBodyService(ApplicationDbContext dbContext, IMapper mapper, ILogger<BanBodyService> logger)
        {

            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;


        }
        public async Task<ResponseMessage> Add(BanBodyPostDto BanBodyPost)
        {
            try
            {
                var banBody = new BanBody
                {
                    Name = BanBodyPost.Name,
                    LocalName = BanBodyPost.LocalName,
                    BanBodyCategory = Enum.Parse<BanBodyCategory>(BanBodyPost.BanBodyCategory),
                    CreatedById = BanBodyPost.CreatedById,
                    CreatedDate = DateTime.Now,
                    IsActive = true

                };
                await _dbContext.BanBodies.AddAsync(banBody);
                await _dbContext.SaveChangesAsync();

                //_loggerManager.LogInfo($"Band Body Added Successfully By {banBody.CreatedById} on {banBody.CreatedDate}");

                return new ResponseMessage
                {
                    Success = true,
                    Message = "Band Body Added Successfully !!!"
                };

            }
            catch (Exception ex)
            {

                //_loggerManager.LogError($"An error occurred: {ex.Message}\nStack trace: {ex.StackTrace}");

                return new ResponseMessage
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<List<BanBodyGetDto>> GetAll(RequestParameter requestParameter)
        {




            var banBodies = await _dbContext.BanBodies.AsNoTracking()
 .OrderBy(e => e.Id)
 .Skip((requestParameter.PageNumber - 1) * requestParameter.PageSize)
 .Take(requestParameter.PageSize)
 .ToListAsync();





            var banBodyDtos = _mapper.Map<List<BanBodyGetDto>>(banBodies);

            return banBodyDtos;
        }

        public async Task<ResponseMessage> Update(BanBodyGetDto BanBodyGet)
        {
            try
            {

                var banBody = await _dbContext.BanBodies.FindAsync(BanBodyGet.Id);

                if (banBody != null)
                {
                    banBody.Name = BanBodyGet.Name;
                    banBody.LocalName = BanBodyGet.LocalName;
                    banBody.BanBodyCategory = Enum.Parse<BanBodyCategory>(BanBodyGet.BanBodyCategory);
                    banBody.IsActive = BanBodyGet.IsActive;

                    // Save the changes to the database
                    await _dbContext.SaveChangesAsync();

                    var changedOn = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss");

                    // Enrich the log context with the relevant properties
                    LogContext.PushProperty("ChangedOn", changedOn);
                    LogContext.PushProperty("Module", "VRMS");
                    LogContext.PushProperty("UserId", BanBodyGet.CreatedById);

                    // Log the information
                    _logger.LogInformation("Ban Body Updated Successfully !!!");

                    return new ResponseMessage
                    {
                        Success = true,
                        Message = "Ban Body Updated Successfully !!!"
                    };
                }
                else
                {

                    return new ResponseMessage
                    {
                        Success = false,
                        Message = "Ban Body Not Found !!!"
                    };
                }

            }
            catch (Exception ex)
            {
                return new ResponseMessage
                {
                    Success = false,
                    Message = ex.Message
                };

            }
        }
    }
}
