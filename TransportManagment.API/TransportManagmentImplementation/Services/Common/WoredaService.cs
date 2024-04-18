using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class WoredaService : IWoredaService
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public WoredaService(ApplicationDbContext dbContext, IMapper mapper)
        {

            _dbContext = dbContext;
            _mapper = mapper;

        }


        public async Task<ResponseMessage> Add(WoredaPostDto WoredaPost)
        {
            try
            {
                var woreda = new Woreda
                {
                    Name = WoredaPost.Name,
                    LocalName = WoredaPost.LocalName,
                    Code = WoredaPost.Code,
                    LocalCode = WoredaPost.LocalCode,
                    ZoneId = WoredaPost.ZoneId,                  
                    CreatedById = WoredaPost.CreatedById,                    
                    CreatedDate = DateTime.Now,
                    IsActive = true

                };
                await _dbContext.Woredas.AddAsync(woreda);
                await _dbContext.SaveChangesAsync();

                return new ResponseMessage
                {
                    Success = true,
                    Message = "Woreda Added Successfully !!!"
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

        public async Task<List<WoredaGetDto>> GetAll()
        {


            var Woredas = await _dbContext.Woredas.Include(x => x.Zone).AsNoTracking().ToListAsync();

            var WoredaDtos = _mapper.Map<List<WoredaGetDto>>(Woredas);

            return WoredaDtos;




        }

        public async Task<ResponseMessage> Update(WoredaGetDto WoredaGet)
        {
            try
            {

                var Woreda = await _dbContext.Woredas.FindAsync(WoredaGet.Id);

                if (Woreda != null)
                {
                    // Update the properties of the Woreda entity
                    Woreda.Name = WoredaGet.Name;
                    Woreda.LocalName = WoredaGet.LocalName;
                    Woreda.Code = WoredaGet.Code;
                    Woreda.LocalCode = WoredaGet.LocalCode;
                    Woreda.ZoneId = WoredaGet.ZoneId;

                    Woreda.IsActive = WoredaGet.IsActive;

                    // Save the changes to the database
                    await _dbContext.SaveChangesAsync();

                    return new ResponseMessage
                    {
                        Success = true,
                        Message = "Woreda Updated Successfully !!!"
                    };
                }
                else
                {
                    return new ResponseMessage
                    {
                        Success = false,
                        Message = "Woreda Not Found !!!"
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
