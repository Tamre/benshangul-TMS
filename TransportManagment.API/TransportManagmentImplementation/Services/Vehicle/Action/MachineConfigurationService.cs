using AutoMapper;
using IntegratedImplementation.Interfaces.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Vehicle.Action;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Common;
using TransportManagmentImplementation.Interfaces.Vehicle.Action;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.MachineConfigeration;
using TransportManagmentInfrustructure.Model.Vehicle.Action;

namespace TransportManagmentImplementation.Services.Vehicle.Action
{
    public class MachineConfigurationService : IMachineConfigurations
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        private readonly ILoggerManagerService _logger;
        private readonly IGeneralConfigService _generalConfigService;

        public MachineConfigurationService(ApplicationDbContext dbContext, ILoggerManagerService logger, IGeneralConfigService generalConfigService, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger;
            _generalConfigService = generalConfigService;
            _mapper = mapper;
        }

        public async Task<ResponseMessage> Add(MachineConfigurationDTO data)
        {

            try
            {



                var MachineConfiguration = new MachineConfiguration
                {
                    Id = Guid.NewGuid(),
                    ApiEndpoint = data.ApiEndpoint,
                    Name = data.Name,
                    model = data.model






                };

                await _dbContext.MachineConfigurations.AddAsync(MachineConfiguration);

                await _dbContext.SaveChangesAsync();

                return new ResponseMessage
                {
                    Success = true,
                    Message = $"Replacement Request Created succussfuly"
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



        public async Task<List<MachineConfigurationDTO>> GetMachinData()
        {

            var machinConfig = _dbContext.MachineConfigurations.ToList();
            var MachinDto = _mapper.Map<List<MachineConfigurationDTO>>(machinConfig);
            return MachinDto;
        }

    }

    }
