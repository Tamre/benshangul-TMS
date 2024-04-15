

using AutoMapper;
using TransportManagmentImplementation.DTOS.Common;
using TransportManagmentImplementation.DTOS.Configuration;
using TransportManagmentImplementation.Interfaces.Common;
using TransportManagmentImplementation.Services.Common;
using TransportManagmentInfrustructure.Model.Common;

namespace TransportManagmentImplementation.Datas
{
    public class AutoMapperConfigurations : Profile
    {

        public AutoMapperConfigurations()
        {
            #region Configuration

            #endregion

            #region Common 

            CreateMap<Country, CountryGetDto>();
            CreateMap<Region, RegionGetDto>().ForMember(a => a.CountryName, e => e.MapFrom(mfg => mfg.Country.Name));
            CreateMap<ZoneList, ZoneGetDto>().ForMember(a => a.RegionName, e => e.MapFrom(mfg => mfg.Region.Name));
            CreateMap<Woreda, WoredaGetDto>().ForMember(a => a.ZoneName, e => e.MapFrom(mfg => mfg.Zone.Name));
            CreateMap<CompanyProfile, CompanyProfileGetDto>();
            CreateMap<CommonCodes, CommonCodeGetDto>()
                .ForMember(a => a.ZoneName, e => e.MapFrom(mfg => mfg.Zone.Name))
                .ForMember(a => a.CommonCodeType, e => e.MapFrom(mfg => mfg.CommonCodeType.ToString()))
                ;
            CreateMap<DeviceList, DeviceListGetDto>()
        .ForMember(a => a.ApprovedFor, e => e.MapFrom(mfg => mfg.ApprovedFor.ToString()))
        .ForMember(a => a.ApproverUser, e => e.MapFrom(mfg => mfg.Approver.FullName))
        ;
            #endregion
        }
    }
}
