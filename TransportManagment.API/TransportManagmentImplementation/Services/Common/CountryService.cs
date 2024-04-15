using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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
    public class CountryService : ICountryService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CountryService(ApplicationDbContext dbContext, IMapper mapper)
        {

            _dbContext = dbContext;
            _mapper = mapper;

        }

        public async Task<ResponseMessage> Add(CountryPostDto countryPost)
        {
            try
            {
                var country = new Country
                {
                    Name = countryPost.Name,
                    LocalName = countryPost.LocalName,
                    NationalityName = countryPost.NationalityName,
                    LocalNationalityName = countryPost.LocalNationalityName,
                    CreatedById = countryPost.CreatedById,
                    CountryCode = countryPost.CountryCode,
                    CreatedDate = DateTime.Now,

                };
                await _dbContext.Countries.AddAsync(country);
                await _dbContext.SaveChangesAsync();

                return new ResponseMessage
                {
                    Success = true,
                    Message = "Country Added Successfully !!!"
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

        public async Task<List<CountryGetDto>> GetAll()
        {


            var countries = await _dbContext.Countries.AsNoTracking().ToListAsync();
           
            var countryDtos = _mapper.Map<List<CountryGetDto>>(countries);

            return countryDtos;




        }

        public async Task<ResponseMessage> Update(CountryGetDto countryGet)
        {
           try
            {
                
                var country = await _dbContext.Countries.FindAsync(countryGet.Id);
                
                if(country != null)
                {
                    // Update the properties of the country entity
                    country.Name = countryGet.Name;
                    country.LocalName = countryGet.LocalName;
                    country.CountryCode = countryGet.CountryCode;
                    country.NationalityName = countryGet.NationalityName;
                    country.LocalNationalityName = countryGet.LocalNationalityName;

                    // Save the changes to the database
                    await _dbContext.SaveChangesAsync();

                    return new ResponseMessage
                    {
                        Success = true,
                        Message = "Country Updated Successfully !!!"
                    };
                }
                else
                {
                    return new ResponseMessage
                    {
                        Success = false,
                        Message = "Country Not Found !!!"
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
