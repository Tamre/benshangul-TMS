using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.DTOS.Common;
using TransportManagmentImplementation.Helper;
using TransportManagmentImplementation.Interfaces.Common;
using TransportManagmentInfrustructure.Data;
using TransportManagmentInfrustructure.Model.Common;

namespace TransportManagmentImplementation.Services.Common
{
    public class ZoneService : IZoneService
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILoggerManagerService _logger;

        public ZoneService(ApplicationDbContext dbContext, IMapper mapper, ILoggerManagerService logger)
        {

            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }




        public async Task<ResponseMessage> Add(ZonePostDto ZonePost)
        {
            try
            {
                var zone = new ZoneList
                {
                    Name = ZonePost.Name,
                    LocalName = ZonePost.LocalName,
                    Code = ZonePost.Code,
                    LocalCode = ZonePost.LocalCode,
                    RegionId = ZonePost.RegionId,
                    Seffix = ZonePost.Seffix,
                    LocalSuffix = ZonePost.LocalSuffix,
                    IsCity = ZonePost.IsCity,
                    CreatedById = ZonePost.CreatedById,
                    CreatedDate = DateTime.Now,
                    IsActive = true

                };
                await _dbContext.Zones.AddAsync(zone);
                await _dbContext.SaveChangesAsync();

                _logger.LogCreate("COMMON", ZonePost.CreatedById, $"Zone Added Successfully on {DateTime.Now}");



                return new ResponseMessage
                {
                    Success = true,
                    Message = "Zone Added Successfully !!!"
                };


            }
            catch (Exception ex)
            {
                _logger.LogExcption("COMMON", ZonePost.CreatedById, ex.Message);
                return new ResponseMessage
                {
                    Success = false,
                    Message = ex.Message
                };
            }


        }

        public async Task<List<ZoneGetDto>> GetAll(RequestParameter requestParameter)
        {


            var Zones = await _dbContext.Zones.Include(x => x.Region).AsNoTracking().OrderBy(e => e.Id)
 .Skip((requestParameter.PageNumber - 1) * requestParameter.PageSize)
 .Take(requestParameter.PageSize)
 .ToListAsync();

            var ZoneDtos = _mapper.Map<List<ZoneGetDto>>(Zones);

            return ZoneDtos;




        }

        public async Task<ResponseMessage> Update(ZoneGetDto ZoneGet)
        {
            try
            {

                var Zone = await _dbContext.Zones.FindAsync(ZoneGet.Id);

                if (Zone != null)
                {
                    // Update the properties of the Zone entity
                    Zone.Name = ZoneGet.Name;
                    Zone.LocalName = ZoneGet.LocalName;
                    Zone.Code = ZoneGet.Code;
                    Zone.LocalCode = ZoneGet.LocalCode;

                    Zone.RegionId = ZoneGet.RegionId;
                    Zone.Seffix = ZoneGet.Seffix;
                    Zone.LocalSuffix = ZoneGet.LocalSuffix;
                    Zone.IsCity = ZoneGet.IsCity;

                    Zone.IsActive = ZoneGet.IsActive;

                    // Save the changes to the database
                    await _dbContext.SaveChangesAsync();
                    _logger.LogUpdate("COMMON", ZoneGet.CreatedById, $"Zone Updated Successfully on {DateTime.Now}");


                    return new ResponseMessage
                    {
                        Success = true,
                        Message = "Zone Updated Successfully !!!"
                    };
                }
                else
                {
                    return new ResponseMessage
                    {
                        Success = false,
                        Message = "Zone Not Found !!!"
                    };
                }

            }
            catch (Exception ex)
            {
                _logger.LogExcption("COMMON", ZoneGet.CreatedById, ex.Message);
                return new ResponseMessage
                {
                    Success = false,
                    Message = ex.Message
                };

            }
        }

    }
}
