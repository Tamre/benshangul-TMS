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
using TransportManagmentInfrustructure.Model.Vehicle.Configuration;

namespace TransportManagmentInfrustructure.Data
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser, ApplicationRole, string>
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
        public DbSet<BaseEstimation> BaseEstimations { get; set; }
        public DbSet<BgPoint> BgPoints { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<HkPoint> HkPoints { get; set; }
        public DbSet<ManufacturePoint> ManufacturePoints { get; set; }
        public DbSet<ManufacturingCountry> ManufacturingCountries { get; set; }
        public DbSet<PlateType> PlateTypes { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<ServiceYearSetting> ServiceYearSettings { get; set; }
        public DbSet<Spoint> Spoints { get; set; }
        public DbSet<VehicleBodyType> VehicleBodyTypes { get; set; }
        public DbSet<VehicleLookups> vehicleLookups { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<VehicleSerialSetting> VehicleSerialSettings { get; set; }
        public DbSet<VehicleSettings> VehicleSettings { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }

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
            modelBuilder.Entity<BaseEstimation>(entity =>
            {
                entity.HasIndex(t => t.Name).IsUnique();
            });
            modelBuilder.Entity<BgPoint>(entity =>
            {
                entity.HasIndex(t => t.Name).IsUnique();
            });
            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.HasIndex(t => t.FileName).IsUnique();
            });
            modelBuilder.Entity<HkPoint>(entity =>
            {
                entity.HasIndex(t => t.Name).IsUnique();
            });
            modelBuilder.Entity<HkPoint>(entity =>
            {
                entity.HasIndex(t => t.Name).IsUnique();
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
            modelBuilder.Entity<Spoint>(entity =>
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



            modelBuilder.Entity<AISORCStockType>().ToTable("AISORCStockTypes", schema: "VRMS");
            modelBuilder.Entity<BanBody>().ToTable("BanBodies", schema: "VRMS");
            modelBuilder.Entity<BaseEstimation>().ToTable("BaseEstimations", schema: "VRMS");
            modelBuilder.Entity<BgPoint>().ToTable("BgPoints", schema: "VRMS");
            modelBuilder.Entity<DocumentType>().ToTable("DocumentTypes", schema: "VRMS");
            modelBuilder.Entity<HkPoint>().ToTable("HkPoints", schema: "VRMS");
            modelBuilder.Entity<ManufacturePoint>().ToTable("ManufacturePoints", schema: "VRMS");
            modelBuilder.Entity<ManufacturingCountry>().ToTable("ManufacturingCountries", schema: "VRMS");
            modelBuilder.Entity<PlateType>().ToTable("PlateTypes", schema: "VRMS");
            modelBuilder.Entity<ServiceType>().ToTable("ServiceTypes", schema: "VRMS");
            modelBuilder.Entity<ServiceYearSetting>().ToTable("ServiceYearSettings", schema: "VRMS");
            modelBuilder.Entity<Spoint>().ToTable("Spoints", schema: "VRMS");
            modelBuilder.Entity<VehicleBodyType>().ToTable("VehicleBodyTypes", schema: "VRMS");
            modelBuilder.Entity<VehicleLookups>().ToTable("vehicleLookups", schema: "VRMS");
            modelBuilder.Entity<VehicleModel>().ToTable("VehicleModels", schema: "VRMS");
            modelBuilder.Entity<VehicleSerialSetting>().ToTable("VehicleSerialSettings", schema: "VRMS");
            modelBuilder.Entity<VehicleSettings>().ToTable("VehicleSettings", schema: "VRMS");
            modelBuilder.Entity<VehicleType>().ToTable("VehicleTypes", schema: "VRMS");
        }
    }
}
