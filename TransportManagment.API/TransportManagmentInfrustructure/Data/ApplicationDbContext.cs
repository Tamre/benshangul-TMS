using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagmentInfrustructure.Model.Authentication;
using TransportManagmentInfrustructure.Model.Common;
using TransportManagmentInfrustructure.Model.Vehicle.Action;
using TransportManagmentInfrustructure.Model.Vehicle.Configuration;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TransportManagmentInfrustructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<RoleCategory> RoleCategories { get; set; }
        public DbSet<PasswordHistory> PasswordHistories { get; set; }
        public DbSet<PasswordChangeRequest> PasswordChangeRequests { get; set; }

        #region Common

        public DbSet<CommonCodes> CommonCodes { get; set; }
        public DbSet<CompanyProfile> CompanyProfiles { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<DeviceList> DeviceLists { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<ZoneList> Zones { get; set; }
        public DbSet<Woreda> Woredas { get; set; }

        #endregion

        #region VehicleRegistration
        public DbSet<AISORCStockType> AISORCStockTypes { get; set; }
        public DbSet<BanBody> BanBodies { get; set; }
        public DbSet<InitialPrice> InitialPrices { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<FactoryPoint> FactoryPoints { get; set; }
        public DbSet<ManufacturingCountry> ManufacturingCountries { get; set; }
        public DbSet<PlateType> PlateTypes { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<ServiceYearSetting> ServiceYearSettings { get; set; }
        public DbSet<VehicleBodyType> VehicleBodyTypes { get; set; }
        public DbSet<VehicleLookups> VehicleLookups { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<VehicleSerialSetting> VehicleSerialSettings { get; set; }
        public DbSet<VehicleSettings> VehicleSettings { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<DepreciationCost> DepreciationCosts { get; set; }
        public DbSet<SalvageValue> SalvageValues { get; set; }
        public DbSet<ValuationReason> ValuationReasons { get; set; }

        public DbSet<VehicleList> VehicleLists { get; set; }
        public DbSet<VehicleOwner> VehicleOwners { get; set; }
        public DbSet<AIS> AisLists { get; set; }
        public DbSet<AisStock> AisStocks { get; set; }
        public DbSet<FieldInspection> FieldInspections { get; set; }
        public DbSet<TechnicalInspection> TechnicalInspections { get; set; }
        public DbSet<ORC> ORCLists { get; set; }
        public DbSet<ORCStock> ORCStocks { get; set; }
        public DbSet<OwnerList> OwnerLists { get; set; }
        public DbSet<PlateStock> PlateStocks { get; set; }
        public DbSet<VehiclePlate> VehiclePlates { get; set; }
        public DbSet<ServiceChange> ServiceChanges { get; set; }
        public DbSet<TemporaryVehicleDeactivation> TemporaryVehicleDeactivations { get; set; }
        public DbSet<Valuation> ValuationLists { get; set; }
        public DbSet<ValuationDetail> ValuationDetails { get; set; }
        public DbSet<VehicleBan> VehicleBans { get; set; }
        public DbSet<VehicleReplacement> VehicleReplacements { get; set; }
        public DbSet<VehicleTransfer> VehicleTransfers { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                 .SelectMany(t => t.GetForeignKeys())
                 .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.NoAction;

            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.HasKey(l => new { l.LoginProvider, l.ProviderKey });
            });
            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.HasKey(r => new { r.UserId, r.RoleId });
            });
            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });
            });

            modelBuilder.Entity<CommonCodes>(entity =>
            {
                entity.HasIndex(t => t.CommonCodeType).IsUnique();
            });
            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasIndex(t => t.Name).IsUnique();
            });
            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasIndex(t => t.Name).IsUnique();
            });
            modelBuilder.Entity<ZoneList>(entity =>
            {
                entity.HasIndex(t => t.Name).IsUnique();
            });
            modelBuilder.Entity<Woreda>(entity =>
            {
                entity.HasIndex(t => t.Name).IsUnique();
            });


            modelBuilder.Entity<AISORCStockType>(entity =>
            {
                entity.HasIndex(t => t.Name).IsUnique();
                entity.HasIndex(t => t.Code).IsUnique();
            });
            modelBuilder.Entity<BanBody>(entity =>
            {
                entity.HasIndex(t => t.Name).IsUnique();
            });
            modelBuilder.Entity<InitialPrice>(entity =>
            {
                entity.HasIndex(t => t.Name).IsUnique();
            });
          
            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.HasIndex(t => t.FileName).IsUnique();
            });
           
            modelBuilder.Entity<ManufacturingCountry>(entity =>
            {
                entity.HasIndex(t => t.Name).IsUnique();
            });
            modelBuilder.Entity<PlateType>(entity =>
            {
                entity.HasIndex(t => t.Name).IsUnique();
            });
            modelBuilder.Entity<ServiceType>(entity =>
            {
                entity.HasIndex(t => t.Name).IsUnique();
            });
         
            modelBuilder.Entity<VehicleBodyType>(entity =>
            {
                entity.HasIndex(t => t.Name).IsUnique();
            });
            modelBuilder.Entity<VehicleLookups>(entity =>
            {
                entity.HasIndex(t => t.Name).IsUnique();
            });
            modelBuilder.Entity<VehicleModel>(entity =>
            {
                entity.HasIndex(t => t.Name).IsUnique();
            });
            modelBuilder.Entity<VehicleSerialSetting>(entity =>
            {
                entity.HasIndex(t => t.VehicleSerialType).IsUnique();
            });
            modelBuilder.Entity<VehicleSettings>(entity =>
            {
                entity.HasIndex(t => t.VehicleSettingType).IsUnique();
            });
            modelBuilder.Entity<VehicleType>(entity =>
            {
                entity.HasIndex(t => t.Name).IsUnique();
            });
            modelBuilder.Entity<DepreciationCost>(entity =>
            {
                entity.HasIndex(t => t.Name).IsUnique();
            });
            modelBuilder.Entity<SalvageValue>(entity =>
            {
                entity.HasIndex(t => t.Name).IsUnique();
            });

            modelBuilder.Entity<AisStock>(entity =>
            {
                entity.HasIndex(t => new { t.AISNo, t.StockTypeId }).IsUnique();
            });

            modelBuilder.Entity<AisStock>()
            .HasOne(s => s.AIS)
            .WithOne(p => p.Stock)
           .HasForeignKey<AIS>(p => p.StockId);

            modelBuilder.Entity<ORCStock>(entity =>
            {
                entity.HasIndex(t => new { t.ORCNo, t.StockTypeId }).IsUnique();
            });

            modelBuilder.Entity<ORCStock>()
            .HasOne(s => s.ORC)
            .WithOne(p => p.Stock)
           .HasForeignKey<ORC>(p => p.StockId);

            modelBuilder.Entity<OwnerList>(entity =>
            {
                entity.HasIndex(t => t.PhoneNumber).IsUnique();
                entity.HasIndex(t => t.IdNumber).IsUnique();
            });

            modelBuilder.Entity<PlateStock>(entity =>
            {
                entity.HasIndex(t => new { t.PlateNo , t.IssuanceType}).IsUnique();
            });

            modelBuilder.Entity<PlateStock>()
           .HasOne(s => s.VehiclePlate)
           .WithOne(p => p.PlateStock)
           .HasForeignKey<VehiclePlate>(p => p.PlateStockId);

            modelBuilder.Entity<VehicleList>(entity =>
            {
                entity.HasIndex(t =>  t.ChassisNo).IsUnique();
                entity.HasIndex(t => t.EngineNumber).IsUnique();
            });
            

            #region commonNames
            modelBuilder.Entity<RoleCategory>().ToTable("RoleCategories", schema: "UserMgt");
            modelBuilder.Entity<ApplicationUser>().ToTable("Users", schema: "UserMgt");
            modelBuilder.Entity<ApplicationRole>().ToTable("Roles", schema: "UserMgt");
            modelBuilder.Entity<PasswordHistory>().ToTable("PasswordHistories", schema: "UserMgt");
            modelBuilder.Entity<PasswordChangeRequest>().ToTable("PasswordChangeRequests", schema: "UserMgt");
           

            modelBuilder.Entity<CommonCodes>().ToTable("CommonCodes", schema: "Common");
            modelBuilder.Entity<CompanyProfile>().ToTable("CompanyProfiles", schema: "Common");
            modelBuilder.Entity<Country>().ToTable("Countries", schema: "Common");
            modelBuilder.Entity<DeviceList>().ToTable("DeviceLists", schema: "Common");
            modelBuilder.Entity<Region>().ToTable("Regions", schema: "Common");
            modelBuilder.Entity<ZoneList>().ToTable("Zones", schema: "Common");
            modelBuilder.Entity<Woreda>().ToTable("Woredas", schema: "Common");
            #endregion

            #region Vehicle
            modelBuilder.Entity<AISORCStockType>().ToTable("AISORCStockTypes", schema: "VRMS");
            modelBuilder.Entity<BanBody>().ToTable("BanBodies", schema: "VRMS");
            modelBuilder.Entity<InitialPrice>().ToTable("InitialPrices", schema: "VRMS");
            modelBuilder.Entity<DocumentType>().ToTable("DocumentTypes", schema: "VRMS");
            modelBuilder.Entity<FactoryPoint>().ToTable("FactoryPoints", schema: "VRMS");
            modelBuilder.Entity<ManufacturingCountry>().ToTable("ManufacturingCountries", schema: "VRMS");
            modelBuilder.Entity<PlateType>().ToTable("PlateTypes", schema: "VRMS");
            modelBuilder.Entity<ServiceType>().ToTable("ServiceTypes", schema: "VRMS");
            modelBuilder.Entity<ServiceYearSetting>().ToTable("ServiceYearSettings", schema: "VRMS");
            modelBuilder.Entity<VehicleBodyType>().ToTable("VehicleBodyTypes", schema: "VRMS");
            modelBuilder.Entity<VehicleLookups>().ToTable("vehicleLookups", schema: "VRMS");
            modelBuilder.Entity<VehicleModel>().ToTable("VehicleModels", schema: "VRMS");
            modelBuilder.Entity<VehicleSerialSetting>().ToTable("VehicleSerialSettings", schema: "VRMS");
            modelBuilder.Entity<VehicleSettings>().ToTable("VehicleSettings", schema: "VRMS");
            modelBuilder.Entity<VehicleType>().ToTable("VehicleTypes", schema: "VRMS");
            modelBuilder.Entity<SalvageValue>().ToTable("SalvageValues", schema: "VRMS");
            modelBuilder.Entity<DepreciationCost>().ToTable("DepreciationCosts", schema: "VRMS");
            modelBuilder.Entity<AisStock>().ToTable("AisStocks", schema: "VRMS");
            modelBuilder.Entity<AIS>().ToTable("AisLists", schema: "VRMS");
            modelBuilder.Entity<FieldInspection>().ToTable("FieldInspections", schema: "VRMS");
            modelBuilder.Entity<ORCStock>().ToTable("ORCStocks", schema: "VRMS");
            modelBuilder.Entity<ORC>().ToTable("ORCLists", schema: "VRMS");
            modelBuilder.Entity<OwnerList>().ToTable("OwnerLists", schema: "VRMS");
            modelBuilder.Entity<PlateStock>().ToTable("PlateStocks", schema: "VRMS");
            modelBuilder.Entity <VehiclePlate>().ToTable("VehiclePlates", schema: "VRMS");
            modelBuilder.Entity <ServiceChange>().ToTable("ServiceChanges", schema: "VRMS");
            modelBuilder.Entity <TechnicalInspection>().ToTable("TechnicalInspections", schema: "VRMS");
            modelBuilder.Entity <TemporaryVehicleDeactivation>().ToTable("TemporaryVehicleDeactivations", schema: "VRMS");
            modelBuilder.Entity <Valuation>().ToTable("ValuationLists", schema: "VRMS");
            modelBuilder.Entity <ValuationDetail>().ToTable("ValuationDetails", schema: "VRMS");
            modelBuilder.Entity <VehicleBan>().ToTable("VehicleBans", schema: "VRMS");
            modelBuilder.Entity <VehicleOwner>().ToTable("VehicleOwners", schema: "VRMS");
            modelBuilder.Entity <VehicleReplacement>().ToTable("VehicleReplacements", schema: "VRMS");
            modelBuilder.Entity <VehicleTransfer>().ToTable("VehicleTransfers", schema: "VRMS");


            #endregion
        }

    }
}
