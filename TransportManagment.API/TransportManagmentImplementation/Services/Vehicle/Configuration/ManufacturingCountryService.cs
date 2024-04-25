using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentAPI.Controllers.Vehicle.Configuration;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Vehicle.Configuration;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Vehicle.Configuration;

namespace TransportManagmentImplementation.Services.Vehicle.Configuration
{
    // Service
    public class ManufacturingCountryService : IManufacturingCountryService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ManufacturingCountryService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ResponseMessage> Add(ManufacturingCountryPostDto manufacturingCountryPost)
        {
            try
            {
                var manufacturingCountry = new ManufacturingCountry
                {
                    Name = manufacturingCountryPost.Name,
                    LocalName = manufacturingCountryPost.LocalName,
                    Value = manufacturingCountryPost.Value,
                    ListOfCountries = manufacturingCountryPost.ListOfCountries,
                    CreatedById = manufacturingCountryPost.CreatedById,
                    CreatedDate = DateTime.Now,
                    IsActive = true 
                };

                await _dbContext.ManufacturingCountries.AddAsync(manufacturingCountry);
                await _dbContext.SaveChangesAsync();

                return new ResponseMessage
                {
                    Success = true,
                    Message = "Manufacturing Country Added Successfully !!!"
                };
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

        public async Task<List<ManufacturingCountryGetDto>> GetAll()
        {
            var manufacturingCountries = await _dbContext.ManufacturingCountries.AsNoTracking().ToListAsync();
            var manufacturingCountryDtos = _mapper.Map<List<ManufacturingCountryGetDto>>(manufacturingCountries);
            return manufacturingCountryDtos;
        }

        public async Task<ResponseMessage> Update(ManufacturingCountryGetDto manufacturingCountryGet)
        {
            try
            {
                var manufacturingCountry = await _dbContext.ManufacturingCountries.FindAsync(manufacturingCountryGet.Id);
                if (manufacturingCountry != null)
                {
                    manufacturingCountry.Name = manufacturingCountryGet.Name;
                    manufacturingCountry.LocalName = manufacturingCountryGet.LocalName;
                    manufacturingCountry.Value = manufacturingCountryGet.Value;
                    manufacturingCountry.ListOfCountries = manufacturingCountryGet.ListOfCountries;
                    manufacturingCountry.IsActive = manufacturingCountryGet.IsActive;

                    await _dbContext.SaveChangesAsync();

                    return new ResponseMessage
                    {
                        Success = true,
                        Message = "Manufacturing Country Updated Successfully !!!"
                    };
                }
                else
                {
                    return new ResponseMessage
                    {
                        Success = false,
                        Message = "Manufacturing Country Not Found !!!"
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
