
using Implementation.Interfaces.Authentication;
using Implementation.Services.Authentication;
using IntegratedImplementation.Interfaces.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentImplementation.Interfaces.Common;
using TransportManagmentImplementation.Interfaces.Configuration;
using TransportManagmentImplementation.Interfaces.Vehicle.Configuration;
using TransportManagmentImplementation.Services.Common;
using TransportManagmentImplementation.Services.Configuration;
using TransportManagmentImplementation.Services.Vehicle.Configuration;

namespace TransportManagmentImplementation.Datas
{
    public static class ServiceExtenstions
    {
        public static IServiceCollection AddCoreBusiness(this IServiceCollection services)
        {
           
            #region User Service
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            #endregion

            #region Configuration
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IGeneralConfigService, GeneralConfigService>();
            #endregion

            #region Common
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IRegionService, RegionService>();
            services.AddScoped<IWoredaService, WoredaService>();
            services.AddScoped<IZoneService, ZoneService>();
            services.AddScoped<ICompanyProfileService, CompanyProfileService>();
            services.AddScoped<ICommonCodeService, CommonCodeService>();
            services.AddScoped<IDeviceListService, DeviceListService>();

            #endregion

            #region Vehicle

            services.AddScoped<IAISORCStockTypeService, AISORCStockTypeService>();
            services.AddScoped<IBanBodyService, BanBodyService>();
            services.AddScoped<IDocumentTypeService, DocumentTypeService>();
            services.AddScoped<IPlateTypeService, PlateTypeService>();
            services.AddScoped<IDepreciationCostService, DepreciationCostService>();
            services.AddScoped<IFactoryPointService, FactoryPointService>();
            services.AddScoped<IInitialPriceService, InitialPriceService>();
            services.AddScoped<IManufacturingCountryService, ManufacturingCountryService>();
            services.AddScoped<ISalvageValueService, SalvageValueService>();
            services.AddScoped<IServiceTypeService, ServiceTypeService>();
            services.AddScoped<IServiceYearSettingService, ServiceYearSettingService>();
            services.AddScoped<IVehicleBodyTypeService, VehicleBodyTypeService>();
            services.AddScoped<IVehicleLookupsService, VehicleLookupsService>();
            services.AddScoped<IVehicleModelService, VehicleModelService>();
            services.AddScoped<IVehicleSerialSettingService, VehicleSerialSettingService>();
            services.AddScoped<IVehicleSettingsService, VehicleSettingsService>();
            services.AddScoped<IVehicleSettingsService, VehicleSettingsService>();
            services.AddScoped<IVehicleTypeService, VehicleTypeService>();




            #endregion


            return services;
        }
    }
}
