using AutoMapper;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Vehicle.Action;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.MachineConfigeration;
using TransportManagmentInfrustructure.Model.Vehicle.Action;
using TransportManagmentAPI;
using Microsoft.Extensions.Options;

using Microsoft.Extensions.Configuration;

using System.Runtime.Intrinsics.X86;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;

namespace TransportManagmentImplementation.Services.Vehicle.Action
{
    public class BrakeService : IBrake
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _dbContext; 
        private readonly IMapper _mapper;            
      // private readonly IBackgroundJobClient _backgroundJobClient;
      // private readonly IRecurringJobManager _recurringJobManager;
        

        public BrakeService(  IHttpClientFactory httpClientFactory, IConfiguration configuration, ApplicationDbContext dbContext, IMapper mapper)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _dbContext = dbContext;
            _mapper = mapper;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;           
            //_backgroundJobClient = backgroundJobClient;
        }
        public void ScheduleGetDataFromJEVOL()
        {
            //_backgroundJobClient.Enqueue(() => GetDataFromMachineAsync());
        }
        public void ScheduleSaveDataToSql(IEnumerable<BrakeInspectionDTO> data)
        {
           // _backgroundJobClient.Enqueue(() => CreateBrake(data));
        }
        //private async Task GetDataFromJEVOLAsync()
        //{
        //    // Existing implementation

        //}
        public async Task<IEnumerable<BrakeInspectionDTO>> GetDataFromMachineAsync()
        {
            var config = _configuration.GetSection("Configuration").Get<MachineConfiguration>();
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(config.ApiEndpoint);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadFromJsonAsync<IEnumerable<BrakeInspectionDTO>>();

            return data;

        }

        public async Task<ResponseMessage> CreateBrake(IEnumerable<BrakeInspectionDTO> data)
        {

            try
            {

                

            var config = _configuration.GetSection("Configuration").Get<MachineConfiguration>();
            var BrakeData = data.Select(d => new BrakeIspection
            {
                Id = Guid.NewGuid(),
                BrakeEfficency = d.BrakeEfficency,
                CreatedById = d.CreatedById,
                  //CreatedDate = d.CreatedDate,
                FrontLeftBrakeForce = d.FrontLeftBrakeForce,
                FrontRightBrakeForce = d.FrontRightBrakeForce,
                FrontLeftFriction = d.FrontLeftFriction,
                FrontBrakeEfficency = d.FrontBrakeEfficency,
                FrontRightFriction = d.FrontRightFriction,
                FrontRightFrictionEfficency = d.FrontRightFrictionEfficency,
                FrontRightBrakeForceStatus = d.FrontRightBrakeForceStatus,
                FrontLeftFrictionEfficency=d.FrontLeftFrictionEfficency,
                FrontLeftFrictionStatus=d.FrontLeftFrictionStatus,
                HandBrakeEfficency=d.HandBrakeEfficency,
                InspectionId=d.InspectionId,
                PedalForce=d.PedalForce,
                RearBrakeEfficency=d.RearBrakeEfficency,
                RearLeftBrakeForce=d.RearLeftBrakeForce,
                RearLeftFriction = d.RearLeftFriction,
                RearLeftFrictionEfficency=d.RearLeftFrictionEfficency,


                 

            });
            await _dbContext.AddRangeAsync(BrakeData);
                return new ResponseMessage
                {
                    Success = true,
                    Message = $" Saved Successfuly "
                };

            }
            catch (Exception ex)
            {
                return new ResponseMessage
                {
                    Success = false,
                    Message = ex.Message,
                };
            }

        }

        public void EnqueueBackgroundJob()
        {
            //_backgroundJobClient.Enqueue(() => DoSomeWork());
        }

        public void ScheduleRecurringJob()
        {
            //_recurringJobManager.AddOrUpdate("my-recurring-job", () => DoSomePeriodicWork(), Cron.Daily());
        }

        private void DoSomeWork()
        {
            // Your background job logic
        }

        private void DoSomePeriodicWork()
        {
            // Your recurring job logic
        }
        

    }
}
