using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportManagmentInfrustructure.Migrations
{
    /// <inheritdoc />
    public partial class applicationUsertocreatedby : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AisLists_Users_ApplicationUserId",
                schema: "VRMS",
                table: "AisLists");

            migrationBuilder.DropForeignKey(
                name: "FK_AISORCStockTypes_Users_ApplicationUserId",
                schema: "VRMS",
                table: "AISORCStockTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_AisStocks_Users_ApplicationUserId",
                schema: "VRMS",
                table: "AisStocks");

            migrationBuilder.DropForeignKey(
                name: "FK_BanBodies_Users_ApplicationUserId",
                schema: "VRMS",
                table: "BanBodies");

            migrationBuilder.DropForeignKey(
                name: "FK_CommonCodes_Users_ApplicationUserId",
                schema: "Common",
                table: "CommonCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyProfiles_Users_ApplicationUserId",
                schema: "Common",
                table: "CompanyProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Users_ApplicationUserId",
                schema: "Common",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_DepreciationCosts_Users_ApplicationUserId",
                schema: "VRMS",
                table: "DepreciationCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_DeviceLists_Users_ApplicationUserId",
                schema: "Common",
                table: "DeviceLists");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentTypes_Users_ApplicationUserId",
                schema: "VRMS",
                table: "DocumentTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_FactoryPoints_Users_ApplicationUserId",
                schema: "VRMS",
                table: "FactoryPoints");

            migrationBuilder.DropForeignKey(
                name: "FK_FieldInspections_Users_ApplicationUserId",
                schema: "VRMS",
                table: "FieldInspections");

            migrationBuilder.DropForeignKey(
                name: "FK_InitialPrices_Users_ApplicationUserId",
                schema: "VRMS",
                table: "InitialPrices");

            migrationBuilder.DropForeignKey(
                name: "FK_ManufacturingCountries_Users_ApplicationUserId",
                schema: "VRMS",
                table: "ManufacturingCountries");

            migrationBuilder.DropForeignKey(
                name: "FK_ORCLists_Users_ApplicationUserId",
                schema: "VRMS",
                table: "ORCLists");

            migrationBuilder.DropForeignKey(
                name: "FK_ORCStocks_Users_ApplicationUserId",
                schema: "VRMS",
                table: "ORCStocks");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationList_Users_ApplicationUserId",
                table: "OrganizationList");

            migrationBuilder.DropForeignKey(
                name: "FK_OwnerLists_Users_ApplicationUserId",
                schema: "VRMS",
                table: "OwnerLists");

            migrationBuilder.DropForeignKey(
                name: "FK_PasswordChangeRequests_Users_ApplicationUserId",
                schema: "UserMgt",
                table: "PasswordChangeRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_PlateStocks_Users_ApplicationUserId",
                schema: "VRMS",
                table: "PlateStocks");

            migrationBuilder.DropForeignKey(
                name: "FK_PlateTypes_Users_ApplicationUserId",
                schema: "VRMS",
                table: "PlateTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Regions_Users_ApplicationUserId",
                schema: "Common",
                table: "Regions");

            migrationBuilder.DropForeignKey(
                name: "FK_SalvageValues_Users_ApplicationUserId",
                schema: "VRMS",
                table: "SalvageValues");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceChanges_Users_ApplicationUserId",
                schema: "VRMS",
                table: "ServiceChanges");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTypes_Users_ApplicationUserId",
                schema: "VRMS",
                table: "ServiceTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceYearSettings_Users_ApplicationUserId",
                schema: "VRMS",
                table: "ServiceYearSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_TechnicalInspections_Users_ApplicationUserId",
                schema: "VRMS",
                table: "TechnicalInspections");

            migrationBuilder.DropForeignKey(
                name: "FK_TemporaryVehicleDeactivations_Users_ApplicationUserId",
                schema: "VRMS",
                table: "TemporaryVehicleDeactivations");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingCenterList_Users_ApplicationUserId",
                table: "TrainingCenterList");

            migrationBuilder.DropForeignKey(
                name: "FK_ValuationDetails_Users_ApplicationUserId",
                schema: "VRMS",
                table: "ValuationDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ValuationLists_Users_ApplicationUserId",
                schema: "VRMS",
                table: "ValuationLists");

            migrationBuilder.DropForeignKey(
                name: "FK_ValuationReason_Users_ApplicationUserId",
                table: "ValuationReason");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleBans_Users_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleBans");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleBodyTypes_Users_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleBodyTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleLists_Users_ApplicationUserId",
                table: "VehicleLists");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicleLookups_Users_ApplicationUserId",
                schema: "VRMS",
                table: "vehicleLookups");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleModels_Users_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleModels");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleOwners_Users_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_VehiclePlates_Users_ApplicationUserId",
                schema: "VRMS",
                table: "VehiclePlates");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleReplacements_Users_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleReplacements");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleSerialSettings_Users_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleSerialSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleSettings_Users_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleTransfers_Users_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleTransfers");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleTypes_Users_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Woredas_Users_ApplicationUserId",
                schema: "Common",
                table: "Woredas");

            migrationBuilder.DropForeignKey(
                name: "FK_Zones_Users_ApplicationUserId",
                schema: "Common",
                table: "Zones");

            migrationBuilder.DropIndex(
                name: "IX_Zones_ApplicationUserId",
                schema: "Common",
                table: "Zones");

            migrationBuilder.DropIndex(
                name: "IX_Woredas_ApplicationUserId",
                schema: "Common",
                table: "Woredas");

            migrationBuilder.DropIndex(
                name: "IX_VehicleTypes_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleTypes");

            migrationBuilder.DropIndex(
                name: "IX_VehicleTransfers_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleTransfers");

            migrationBuilder.DropIndex(
                name: "IX_VehicleSettings_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleSettings");

            migrationBuilder.DropIndex(
                name: "IX_VehicleSerialSettings_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleSerialSettings");

            migrationBuilder.DropIndex(
                name: "IX_VehicleReplacements_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleReplacements");

            migrationBuilder.DropIndex(
                name: "IX_VehiclePlates_ApplicationUserId",
                schema: "VRMS",
                table: "VehiclePlates");

            migrationBuilder.DropIndex(
                name: "IX_VehicleOwners_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleOwners");

            migrationBuilder.DropIndex(
                name: "IX_VehicleModels_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleModels");

            migrationBuilder.DropIndex(
                name: "IX_vehicleLookups_ApplicationUserId",
                schema: "VRMS",
                table: "vehicleLookups");

            migrationBuilder.DropIndex(
                name: "IX_VehicleLists_ApplicationUserId",
                table: "VehicleLists");

            migrationBuilder.DropIndex(
                name: "IX_VehicleBodyTypes_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleBodyTypes");

            migrationBuilder.DropIndex(
                name: "IX_VehicleBans_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleBans");

            migrationBuilder.DropIndex(
                name: "IX_ValuationReason_ApplicationUserId",
                table: "ValuationReason");

            migrationBuilder.DropIndex(
                name: "IX_ValuationLists_ApplicationUserId",
                schema: "VRMS",
                table: "ValuationLists");

            migrationBuilder.DropIndex(
                name: "IX_ValuationDetails_ApplicationUserId",
                schema: "VRMS",
                table: "ValuationDetails");

            migrationBuilder.DropIndex(
                name: "IX_TrainingCenterList_ApplicationUserId",
                table: "TrainingCenterList");

            migrationBuilder.DropIndex(
                name: "IX_TemporaryVehicleDeactivations_ApplicationUserId",
                schema: "VRMS",
                table: "TemporaryVehicleDeactivations");

            migrationBuilder.DropIndex(
                name: "IX_TechnicalInspections_ApplicationUserId",
                schema: "VRMS",
                table: "TechnicalInspections");

            migrationBuilder.DropIndex(
                name: "IX_ServiceYearSettings_ApplicationUserId",
                schema: "VRMS",
                table: "ServiceYearSettings");

            migrationBuilder.DropIndex(
                name: "IX_ServiceTypes_ApplicationUserId",
                schema: "VRMS",
                table: "ServiceTypes");

            migrationBuilder.DropIndex(
                name: "IX_ServiceChanges_ApplicationUserId",
                schema: "VRMS",
                table: "ServiceChanges");

            migrationBuilder.DropIndex(
                name: "IX_SalvageValues_ApplicationUserId",
                schema: "VRMS",
                table: "SalvageValues");

            migrationBuilder.DropIndex(
                name: "IX_Regions_ApplicationUserId",
                schema: "Common",
                table: "Regions");

            migrationBuilder.DropIndex(
                name: "IX_PlateTypes_ApplicationUserId",
                schema: "VRMS",
                table: "PlateTypes");

            migrationBuilder.DropIndex(
                name: "IX_PlateStocks_ApplicationUserId",
                schema: "VRMS",
                table: "PlateStocks");

            migrationBuilder.DropIndex(
                name: "IX_PasswordChangeRequests_ApplicationUserId",
                schema: "UserMgt",
                table: "PasswordChangeRequests");

            migrationBuilder.DropIndex(
                name: "IX_OwnerLists_ApplicationUserId",
                schema: "VRMS",
                table: "OwnerLists");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationList_ApplicationUserId",
                table: "OrganizationList");

            migrationBuilder.DropIndex(
                name: "IX_ORCStocks_ApplicationUserId",
                schema: "VRMS",
                table: "ORCStocks");

            migrationBuilder.DropIndex(
                name: "IX_ORCLists_ApplicationUserId",
                schema: "VRMS",
                table: "ORCLists");

            migrationBuilder.DropIndex(
                name: "IX_ManufacturingCountries_ApplicationUserId",
                schema: "VRMS",
                table: "ManufacturingCountries");

            migrationBuilder.DropIndex(
                name: "IX_InitialPrices_ApplicationUserId",
                schema: "VRMS",
                table: "InitialPrices");

            migrationBuilder.DropIndex(
                name: "IX_FieldInspections_ApplicationUserId",
                schema: "VRMS",
                table: "FieldInspections");

            migrationBuilder.DropIndex(
                name: "IX_FactoryPoints_ApplicationUserId",
                schema: "VRMS",
                table: "FactoryPoints");

            migrationBuilder.DropIndex(
                name: "IX_DocumentTypes_ApplicationUserId",
                schema: "VRMS",
                table: "DocumentTypes");

            migrationBuilder.DropIndex(
                name: "IX_DeviceLists_ApplicationUserId",
                schema: "Common",
                table: "DeviceLists");

            migrationBuilder.DropIndex(
                name: "IX_DepreciationCosts_ApplicationUserId",
                schema: "VRMS",
                table: "DepreciationCosts");

            migrationBuilder.DropIndex(
                name: "IX_Countries_ApplicationUserId",
                schema: "Common",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_CompanyProfiles_ApplicationUserId",
                schema: "Common",
                table: "CompanyProfiles");

            migrationBuilder.DropIndex(
                name: "IX_CommonCodes_ApplicationUserId",
                schema: "Common",
                table: "CommonCodes");

            migrationBuilder.DropIndex(
                name: "IX_BanBodies_ApplicationUserId",
                schema: "VRMS",
                table: "BanBodies");

            migrationBuilder.DropIndex(
                name: "IX_AisStocks_ApplicationUserId",
                schema: "VRMS",
                table: "AisStocks");

            migrationBuilder.DropIndex(
                name: "IX_AISORCStockTypes_ApplicationUserId",
                schema: "VRMS",
                table: "AISORCStockTypes");

            migrationBuilder.DropIndex(
                name: "IX_AisLists_ApplicationUserId",
                schema: "VRMS",
                table: "AisLists");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "Common",
                table: "Zones");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "Common",
                table: "Woredas");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "VehicleTypes");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "VehicleTransfers");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "VehicleSettings");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "VehicleSerialSettings");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "VehicleReplacements");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "VehiclePlates");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "VehicleOwners");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "VehicleModels");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "vehicleLookups");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "VehicleLists");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "VehicleBodyTypes");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "VehicleBans");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "ValuationReason");

            migrationBuilder.DropColumn(
                name: "RowStatus",
                table: "ValuationReason");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "ValuationLists");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "ValuationDetails");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "TrainingCenterList");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "TemporaryVehicleDeactivations");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "TechnicalInspections");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "ServiceYearSettings");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "ServiceTypes");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "ServiceChanges");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "SalvageValues");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "Common",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "PlateTypes");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "PlateStocks");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "UserMgt",
                table: "PasswordChangeRequests");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "OwnerLists");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "OrganizationList");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "ORCStocks");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "ORCLists");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "ManufacturingCountries");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "InitialPrices");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "FieldInspections");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "FactoryPoints");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "DocumentTypes");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "Common",
                table: "DeviceLists");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "DepreciationCosts");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "Common",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "Common",
                table: "CompanyProfiles");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "Common",
                table: "CommonCodes");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "BanBodies");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "AisStocks");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "AISORCStockTypes");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "AisLists");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ValuationReason",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Zones_CreatedById",
                schema: "Common",
                table: "Zones",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Woredas_CreatedById",
                schema: "Common",
                table: "Woredas",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTypes_CreatedById",
                schema: "VRMS",
                table: "VehicleTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTransfers_CreatedById",
                schema: "VRMS",
                table: "VehicleTransfers",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleSettings_CreatedById",
                schema: "VRMS",
                table: "VehicleSettings",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleSerialSettings_CreatedById",
                schema: "VRMS",
                table: "VehicleSerialSettings",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleReplacements_CreatedById",
                schema: "VRMS",
                table: "VehicleReplacements",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePlates_CreatedById",
                schema: "VRMS",
                table: "VehiclePlates",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleOwners_CreatedById",
                schema: "VRMS",
                table: "VehicleOwners",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModels_CreatedById",
                schema: "VRMS",
                table: "VehicleModels",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_vehicleLookups_CreatedById",
                schema: "VRMS",
                table: "vehicleLookups",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleLists_CreatedById",
                table: "VehicleLists",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleBodyTypes_CreatedById",
                schema: "VRMS",
                table: "VehicleBodyTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleBans_CreatedById",
                schema: "VRMS",
                table: "VehicleBans",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ValuationReason_CreatedById",
                table: "ValuationReason",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ValuationLists_CreatedById",
                schema: "VRMS",
                table: "ValuationLists",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ValuationDetails_CreatedById",
                schema: "VRMS",
                table: "ValuationDetails",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingCenterList_CreatedById",
                table: "TrainingCenterList",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TemporaryVehicleDeactivations_CreatedById",
                schema: "VRMS",
                table: "TemporaryVehicleDeactivations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalInspections_CreatedById",
                schema: "VRMS",
                table: "TechnicalInspections",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceYearSettings_CreatedById",
                schema: "VRMS",
                table: "ServiceYearSettings",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTypes_CreatedById",
                schema: "VRMS",
                table: "ServiceTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceChanges_CreatedById",
                schema: "VRMS",
                table: "ServiceChanges",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_SalvageValues_CreatedById",
                schema: "VRMS",
                table: "SalvageValues",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_CreatedById",
                schema: "Common",
                table: "Regions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PlateTypes_CreatedById",
                schema: "VRMS",
                table: "PlateTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PlateStocks_CreatedById",
                schema: "VRMS",
                table: "PlateStocks",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordChangeRequests_CreatedById",
                schema: "UserMgt",
                table: "PasswordChangeRequests",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerLists_CreatedById",
                schema: "VRMS",
                table: "OwnerLists",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationList_CreatedById",
                table: "OrganizationList",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ORCStocks_CreatedById",
                schema: "VRMS",
                table: "ORCStocks",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ORCLists_CreatedById",
                schema: "VRMS",
                table: "ORCLists",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturingCountries_CreatedById",
                schema: "VRMS",
                table: "ManufacturingCountries",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_InitialPrices_CreatedById",
                schema: "VRMS",
                table: "InitialPrices",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_FieldInspections_CreatedById",
                schema: "VRMS",
                table: "FieldInspections",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryPoints_CreatedById",
                schema: "VRMS",
                table: "FactoryPoints",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTypes_CreatedById",
                schema: "VRMS",
                table: "DocumentTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceLists_CreatedById",
                schema: "Common",
                table: "DeviceLists",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DepreciationCosts_CreatedById",
                schema: "VRMS",
                table: "DepreciationCosts",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CreatedById",
                schema: "Common",
                table: "Countries",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyProfiles_CreatedById",
                schema: "Common",
                table: "CompanyProfiles",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CommonCodes_CreatedById",
                schema: "Common",
                table: "CommonCodes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_BanBodies_CreatedById",
                schema: "VRMS",
                table: "BanBodies",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AisStocks_CreatedById",
                schema: "VRMS",
                table: "AisStocks",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AISORCStockTypes_CreatedById",
                schema: "VRMS",
                table: "AISORCStockTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AisLists_CreatedById",
                schema: "VRMS",
                table: "AisLists",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_AisLists_Users_CreatedById",
                schema: "VRMS",
                table: "AisLists",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AISORCStockTypes_Users_CreatedById",
                schema: "VRMS",
                table: "AISORCStockTypes",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AisStocks_Users_CreatedById",
                schema: "VRMS",
                table: "AisStocks",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BanBodies_Users_CreatedById",
                schema: "VRMS",
                table: "BanBodies",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommonCodes_Users_CreatedById",
                schema: "Common",
                table: "CommonCodes",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyProfiles_Users_CreatedById",
                schema: "Common",
                table: "CompanyProfiles",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Users_CreatedById",
                schema: "Common",
                table: "Countries",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DepreciationCosts_Users_CreatedById",
                schema: "VRMS",
                table: "DepreciationCosts",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceLists_Users_CreatedById",
                schema: "Common",
                table: "DeviceLists",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentTypes_Users_CreatedById",
                schema: "VRMS",
                table: "DocumentTypes",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FactoryPoints_Users_CreatedById",
                schema: "VRMS",
                table: "FactoryPoints",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FieldInspections_Users_CreatedById",
                schema: "VRMS",
                table: "FieldInspections",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InitialPrices_Users_CreatedById",
                schema: "VRMS",
                table: "InitialPrices",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ManufacturingCountries_Users_CreatedById",
                schema: "VRMS",
                table: "ManufacturingCountries",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ORCLists_Users_CreatedById",
                schema: "VRMS",
                table: "ORCLists",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ORCStocks_Users_CreatedById",
                schema: "VRMS",
                table: "ORCStocks",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationList_Users_CreatedById",
                table: "OrganizationList",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OwnerLists_Users_CreatedById",
                schema: "VRMS",
                table: "OwnerLists",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PasswordChangeRequests_Users_CreatedById",
                schema: "UserMgt",
                table: "PasswordChangeRequests",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlateStocks_Users_CreatedById",
                schema: "VRMS",
                table: "PlateStocks",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlateTypes_Users_CreatedById",
                schema: "VRMS",
                table: "PlateTypes",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Regions_Users_CreatedById",
                schema: "Common",
                table: "Regions",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalvageValues_Users_CreatedById",
                schema: "VRMS",
                table: "SalvageValues",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceChanges_Users_CreatedById",
                schema: "VRMS",
                table: "ServiceChanges",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTypes_Users_CreatedById",
                schema: "VRMS",
                table: "ServiceTypes",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceYearSettings_Users_CreatedById",
                schema: "VRMS",
                table: "ServiceYearSettings",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TechnicalInspections_Users_CreatedById",
                schema: "VRMS",
                table: "TechnicalInspections",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TemporaryVehicleDeactivations_Users_CreatedById",
                schema: "VRMS",
                table: "TemporaryVehicleDeactivations",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingCenterList_Users_CreatedById",
                table: "TrainingCenterList",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ValuationDetails_Users_CreatedById",
                schema: "VRMS",
                table: "ValuationDetails",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ValuationLists_Users_CreatedById",
                schema: "VRMS",
                table: "ValuationLists",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ValuationReason_Users_CreatedById",
                table: "ValuationReason",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleBans_Users_CreatedById",
                schema: "VRMS",
                table: "VehicleBans",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleBodyTypes_Users_CreatedById",
                schema: "VRMS",
                table: "VehicleBodyTypes",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleLists_Users_CreatedById",
                table: "VehicleLists",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_vehicleLookups_Users_CreatedById",
                schema: "VRMS",
                table: "vehicleLookups",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleModels_Users_CreatedById",
                schema: "VRMS",
                table: "VehicleModels",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleOwners_Users_CreatedById",
                schema: "VRMS",
                table: "VehicleOwners",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VehiclePlates_Users_CreatedById",
                schema: "VRMS",
                table: "VehiclePlates",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleReplacements_Users_CreatedById",
                schema: "VRMS",
                table: "VehicleReplacements",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleSerialSettings_Users_CreatedById",
                schema: "VRMS",
                table: "VehicleSerialSettings",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleSettings_Users_CreatedById",
                schema: "VRMS",
                table: "VehicleSettings",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleTransfers_Users_CreatedById",
                schema: "VRMS",
                table: "VehicleTransfers",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleTypes_Users_CreatedById",
                schema: "VRMS",
                table: "VehicleTypes",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Woredas_Users_CreatedById",
                schema: "Common",
                table: "Woredas",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Zones_Users_CreatedById",
                schema: "Common",
                table: "Zones",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AisLists_Users_CreatedById",
                schema: "VRMS",
                table: "AisLists");

            migrationBuilder.DropForeignKey(
                name: "FK_AISORCStockTypes_Users_CreatedById",
                schema: "VRMS",
                table: "AISORCStockTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_AisStocks_Users_CreatedById",
                schema: "VRMS",
                table: "AisStocks");

            migrationBuilder.DropForeignKey(
                name: "FK_BanBodies_Users_CreatedById",
                schema: "VRMS",
                table: "BanBodies");

            migrationBuilder.DropForeignKey(
                name: "FK_CommonCodes_Users_CreatedById",
                schema: "Common",
                table: "CommonCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyProfiles_Users_CreatedById",
                schema: "Common",
                table: "CompanyProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Users_CreatedById",
                schema: "Common",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_DepreciationCosts_Users_CreatedById",
                schema: "VRMS",
                table: "DepreciationCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_DeviceLists_Users_CreatedById",
                schema: "Common",
                table: "DeviceLists");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentTypes_Users_CreatedById",
                schema: "VRMS",
                table: "DocumentTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_FactoryPoints_Users_CreatedById",
                schema: "VRMS",
                table: "FactoryPoints");

            migrationBuilder.DropForeignKey(
                name: "FK_FieldInspections_Users_CreatedById",
                schema: "VRMS",
                table: "FieldInspections");

            migrationBuilder.DropForeignKey(
                name: "FK_InitialPrices_Users_CreatedById",
                schema: "VRMS",
                table: "InitialPrices");

            migrationBuilder.DropForeignKey(
                name: "FK_ManufacturingCountries_Users_CreatedById",
                schema: "VRMS",
                table: "ManufacturingCountries");

            migrationBuilder.DropForeignKey(
                name: "FK_ORCLists_Users_CreatedById",
                schema: "VRMS",
                table: "ORCLists");

            migrationBuilder.DropForeignKey(
                name: "FK_ORCStocks_Users_CreatedById",
                schema: "VRMS",
                table: "ORCStocks");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationList_Users_CreatedById",
                table: "OrganizationList");

            migrationBuilder.DropForeignKey(
                name: "FK_OwnerLists_Users_CreatedById",
                schema: "VRMS",
                table: "OwnerLists");

            migrationBuilder.DropForeignKey(
                name: "FK_PasswordChangeRequests_Users_CreatedById",
                schema: "UserMgt",
                table: "PasswordChangeRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_PlateStocks_Users_CreatedById",
                schema: "VRMS",
                table: "PlateStocks");

            migrationBuilder.DropForeignKey(
                name: "FK_PlateTypes_Users_CreatedById",
                schema: "VRMS",
                table: "PlateTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Regions_Users_CreatedById",
                schema: "Common",
                table: "Regions");

            migrationBuilder.DropForeignKey(
                name: "FK_SalvageValues_Users_CreatedById",
                schema: "VRMS",
                table: "SalvageValues");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceChanges_Users_CreatedById",
                schema: "VRMS",
                table: "ServiceChanges");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTypes_Users_CreatedById",
                schema: "VRMS",
                table: "ServiceTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceYearSettings_Users_CreatedById",
                schema: "VRMS",
                table: "ServiceYearSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_TechnicalInspections_Users_CreatedById",
                schema: "VRMS",
                table: "TechnicalInspections");

            migrationBuilder.DropForeignKey(
                name: "FK_TemporaryVehicleDeactivations_Users_CreatedById",
                schema: "VRMS",
                table: "TemporaryVehicleDeactivations");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingCenterList_Users_CreatedById",
                table: "TrainingCenterList");

            migrationBuilder.DropForeignKey(
                name: "FK_ValuationDetails_Users_CreatedById",
                schema: "VRMS",
                table: "ValuationDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ValuationLists_Users_CreatedById",
                schema: "VRMS",
                table: "ValuationLists");

            migrationBuilder.DropForeignKey(
                name: "FK_ValuationReason_Users_CreatedById",
                table: "ValuationReason");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleBans_Users_CreatedById",
                schema: "VRMS",
                table: "VehicleBans");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleBodyTypes_Users_CreatedById",
                schema: "VRMS",
                table: "VehicleBodyTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleLists_Users_CreatedById",
                table: "VehicleLists");

            migrationBuilder.DropForeignKey(
                name: "FK_vehicleLookups_Users_CreatedById",
                schema: "VRMS",
                table: "vehicleLookups");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleModels_Users_CreatedById",
                schema: "VRMS",
                table: "VehicleModels");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleOwners_Users_CreatedById",
                schema: "VRMS",
                table: "VehicleOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_VehiclePlates_Users_CreatedById",
                schema: "VRMS",
                table: "VehiclePlates");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleReplacements_Users_CreatedById",
                schema: "VRMS",
                table: "VehicleReplacements");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleSerialSettings_Users_CreatedById",
                schema: "VRMS",
                table: "VehicleSerialSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleSettings_Users_CreatedById",
                schema: "VRMS",
                table: "VehicleSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleTransfers_Users_CreatedById",
                schema: "VRMS",
                table: "VehicleTransfers");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleTypes_Users_CreatedById",
                schema: "VRMS",
                table: "VehicleTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Woredas_Users_CreatedById",
                schema: "Common",
                table: "Woredas");

            migrationBuilder.DropForeignKey(
                name: "FK_Zones_Users_CreatedById",
                schema: "Common",
                table: "Zones");

            migrationBuilder.DropIndex(
                name: "IX_Zones_CreatedById",
                schema: "Common",
                table: "Zones");

            migrationBuilder.DropIndex(
                name: "IX_Woredas_CreatedById",
                schema: "Common",
                table: "Woredas");

            migrationBuilder.DropIndex(
                name: "IX_VehicleTypes_CreatedById",
                schema: "VRMS",
                table: "VehicleTypes");

            migrationBuilder.DropIndex(
                name: "IX_VehicleTransfers_CreatedById",
                schema: "VRMS",
                table: "VehicleTransfers");

            migrationBuilder.DropIndex(
                name: "IX_VehicleSettings_CreatedById",
                schema: "VRMS",
                table: "VehicleSettings");

            migrationBuilder.DropIndex(
                name: "IX_VehicleSerialSettings_CreatedById",
                schema: "VRMS",
                table: "VehicleSerialSettings");

            migrationBuilder.DropIndex(
                name: "IX_VehicleReplacements_CreatedById",
                schema: "VRMS",
                table: "VehicleReplacements");

            migrationBuilder.DropIndex(
                name: "IX_VehiclePlates_CreatedById",
                schema: "VRMS",
                table: "VehiclePlates");

            migrationBuilder.DropIndex(
                name: "IX_VehicleOwners_CreatedById",
                schema: "VRMS",
                table: "VehicleOwners");

            migrationBuilder.DropIndex(
                name: "IX_VehicleModels_CreatedById",
                schema: "VRMS",
                table: "VehicleModels");

            migrationBuilder.DropIndex(
                name: "IX_vehicleLookups_CreatedById",
                schema: "VRMS",
                table: "vehicleLookups");

            migrationBuilder.DropIndex(
                name: "IX_VehicleLists_CreatedById",
                table: "VehicleLists");

            migrationBuilder.DropIndex(
                name: "IX_VehicleBodyTypes_CreatedById",
                schema: "VRMS",
                table: "VehicleBodyTypes");

            migrationBuilder.DropIndex(
                name: "IX_VehicleBans_CreatedById",
                schema: "VRMS",
                table: "VehicleBans");

            migrationBuilder.DropIndex(
                name: "IX_ValuationReason_CreatedById",
                table: "ValuationReason");

            migrationBuilder.DropIndex(
                name: "IX_ValuationLists_CreatedById",
                schema: "VRMS",
                table: "ValuationLists");

            migrationBuilder.DropIndex(
                name: "IX_ValuationDetails_CreatedById",
                schema: "VRMS",
                table: "ValuationDetails");

            migrationBuilder.DropIndex(
                name: "IX_TrainingCenterList_CreatedById",
                table: "TrainingCenterList");

            migrationBuilder.DropIndex(
                name: "IX_TemporaryVehicleDeactivations_CreatedById",
                schema: "VRMS",
                table: "TemporaryVehicleDeactivations");

            migrationBuilder.DropIndex(
                name: "IX_TechnicalInspections_CreatedById",
                schema: "VRMS",
                table: "TechnicalInspections");

            migrationBuilder.DropIndex(
                name: "IX_ServiceYearSettings_CreatedById",
                schema: "VRMS",
                table: "ServiceYearSettings");

            migrationBuilder.DropIndex(
                name: "IX_ServiceTypes_CreatedById",
                schema: "VRMS",
                table: "ServiceTypes");

            migrationBuilder.DropIndex(
                name: "IX_ServiceChanges_CreatedById",
                schema: "VRMS",
                table: "ServiceChanges");

            migrationBuilder.DropIndex(
                name: "IX_SalvageValues_CreatedById",
                schema: "VRMS",
                table: "SalvageValues");

            migrationBuilder.DropIndex(
                name: "IX_Regions_CreatedById",
                schema: "Common",
                table: "Regions");

            migrationBuilder.DropIndex(
                name: "IX_PlateTypes_CreatedById",
                schema: "VRMS",
                table: "PlateTypes");

            migrationBuilder.DropIndex(
                name: "IX_PlateStocks_CreatedById",
                schema: "VRMS",
                table: "PlateStocks");

            migrationBuilder.DropIndex(
                name: "IX_PasswordChangeRequests_CreatedById",
                schema: "UserMgt",
                table: "PasswordChangeRequests");

            migrationBuilder.DropIndex(
                name: "IX_OwnerLists_CreatedById",
                schema: "VRMS",
                table: "OwnerLists");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationList_CreatedById",
                table: "OrganizationList");

            migrationBuilder.DropIndex(
                name: "IX_ORCStocks_CreatedById",
                schema: "VRMS",
                table: "ORCStocks");

            migrationBuilder.DropIndex(
                name: "IX_ORCLists_CreatedById",
                schema: "VRMS",
                table: "ORCLists");

            migrationBuilder.DropIndex(
                name: "IX_ManufacturingCountries_CreatedById",
                schema: "VRMS",
                table: "ManufacturingCountries");

            migrationBuilder.DropIndex(
                name: "IX_InitialPrices_CreatedById",
                schema: "VRMS",
                table: "InitialPrices");

            migrationBuilder.DropIndex(
                name: "IX_FieldInspections_CreatedById",
                schema: "VRMS",
                table: "FieldInspections");

            migrationBuilder.DropIndex(
                name: "IX_FactoryPoints_CreatedById",
                schema: "VRMS",
                table: "FactoryPoints");

            migrationBuilder.DropIndex(
                name: "IX_DocumentTypes_CreatedById",
                schema: "VRMS",
                table: "DocumentTypes");

            migrationBuilder.DropIndex(
                name: "IX_DeviceLists_CreatedById",
                schema: "Common",
                table: "DeviceLists");

            migrationBuilder.DropIndex(
                name: "IX_DepreciationCosts_CreatedById",
                schema: "VRMS",
                table: "DepreciationCosts");

            migrationBuilder.DropIndex(
                name: "IX_Countries_CreatedById",
                schema: "Common",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_CompanyProfiles_CreatedById",
                schema: "Common",
                table: "CompanyProfiles");

            migrationBuilder.DropIndex(
                name: "IX_CommonCodes_CreatedById",
                schema: "Common",
                table: "CommonCodes");

            migrationBuilder.DropIndex(
                name: "IX_BanBodies_CreatedById",
                schema: "VRMS",
                table: "BanBodies");

            migrationBuilder.DropIndex(
                name: "IX_AisStocks_CreatedById",
                schema: "VRMS",
                table: "AisStocks");

            migrationBuilder.DropIndex(
                name: "IX_AISORCStockTypes_CreatedById",
                schema: "VRMS",
                table: "AISORCStockTypes");

            migrationBuilder.DropIndex(
                name: "IX_AisLists_CreatedById",
                schema: "VRMS",
                table: "AisLists");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ValuationReason");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "Common",
                table: "Zones",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "Common",
                table: "Woredas",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "VehicleTypes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "VehicleTransfers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "VehicleSettings",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "VehicleSerialSettings",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "VehicleReplacements",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "VehiclePlates",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "VehicleOwners",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "VehicleModels",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "vehicleLookups",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "VehicleLists",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "VehicleBodyTypes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "VehicleBans",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "ValuationReason",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RowStatus",
                table: "ValuationReason",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "ValuationLists",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "ValuationDetails",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "TrainingCenterList",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "TemporaryVehicleDeactivations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "TechnicalInspections",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "ServiceYearSettings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "ServiceTypes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "ServiceChanges",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "SalvageValues",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "Common",
                table: "Regions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "PlateTypes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "PlateStocks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "UserMgt",
                table: "PasswordChangeRequests",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "OwnerLists",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "OrganizationList",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "ORCStocks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "ORCLists",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "ManufacturingCountries",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "InitialPrices",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "FieldInspections",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "FactoryPoints",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "DocumentTypes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "Common",
                table: "DeviceLists",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "DepreciationCosts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "Common",
                table: "Countries",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "Common",
                table: "CompanyProfiles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "Common",
                table: "CommonCodes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "BanBodies",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "AisStocks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "AISORCStockTypes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "VRMS",
                table: "AisLists",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zones_ApplicationUserId",
                schema: "Common",
                table: "Zones",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Woredas_ApplicationUserId",
                schema: "Common",
                table: "Woredas",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTypes_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleTypes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTransfers_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleTransfers",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleSettings_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleSettings",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleSerialSettings_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleSerialSettings",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleReplacements_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleReplacements",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePlates_ApplicationUserId",
                schema: "VRMS",
                table: "VehiclePlates",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleOwners_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleOwners",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModels_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleModels",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_vehicleLookups_ApplicationUserId",
                schema: "VRMS",
                table: "vehicleLookups",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleLists_ApplicationUserId",
                table: "VehicleLists",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleBodyTypes_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleBodyTypes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleBans_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleBans",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ValuationReason_ApplicationUserId",
                table: "ValuationReason",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ValuationLists_ApplicationUserId",
                schema: "VRMS",
                table: "ValuationLists",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ValuationDetails_ApplicationUserId",
                schema: "VRMS",
                table: "ValuationDetails",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingCenterList_ApplicationUserId",
                table: "TrainingCenterList",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TemporaryVehicleDeactivations_ApplicationUserId",
                schema: "VRMS",
                table: "TemporaryVehicleDeactivations",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalInspections_ApplicationUserId",
                schema: "VRMS",
                table: "TechnicalInspections",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceYearSettings_ApplicationUserId",
                schema: "VRMS",
                table: "ServiceYearSettings",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTypes_ApplicationUserId",
                schema: "VRMS",
                table: "ServiceTypes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceChanges_ApplicationUserId",
                schema: "VRMS",
                table: "ServiceChanges",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SalvageValues_ApplicationUserId",
                schema: "VRMS",
                table: "SalvageValues",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_ApplicationUserId",
                schema: "Common",
                table: "Regions",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlateTypes_ApplicationUserId",
                schema: "VRMS",
                table: "PlateTypes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlateStocks_ApplicationUserId",
                schema: "VRMS",
                table: "PlateStocks",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordChangeRequests_ApplicationUserId",
                schema: "UserMgt",
                table: "PasswordChangeRequests",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerLists_ApplicationUserId",
                schema: "VRMS",
                table: "OwnerLists",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationList_ApplicationUserId",
                table: "OrganizationList",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ORCStocks_ApplicationUserId",
                schema: "VRMS",
                table: "ORCStocks",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ORCLists_ApplicationUserId",
                schema: "VRMS",
                table: "ORCLists",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturingCountries_ApplicationUserId",
                schema: "VRMS",
                table: "ManufacturingCountries",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialPrices_ApplicationUserId",
                schema: "VRMS",
                table: "InitialPrices",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldInspections_ApplicationUserId",
                schema: "VRMS",
                table: "FieldInspections",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryPoints_ApplicationUserId",
                schema: "VRMS",
                table: "FactoryPoints",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTypes_ApplicationUserId",
                schema: "VRMS",
                table: "DocumentTypes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceLists_ApplicationUserId",
                schema: "Common",
                table: "DeviceLists",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DepreciationCosts_ApplicationUserId",
                schema: "VRMS",
                table: "DepreciationCosts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_ApplicationUserId",
                schema: "Common",
                table: "Countries",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyProfiles_ApplicationUserId",
                schema: "Common",
                table: "CompanyProfiles",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CommonCodes_ApplicationUserId",
                schema: "Common",
                table: "CommonCodes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BanBodies_ApplicationUserId",
                schema: "VRMS",
                table: "BanBodies",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AisStocks_ApplicationUserId",
                schema: "VRMS",
                table: "AisStocks",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AISORCStockTypes_ApplicationUserId",
                schema: "VRMS",
                table: "AISORCStockTypes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AisLists_ApplicationUserId",
                schema: "VRMS",
                table: "AisLists",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AisLists_Users_ApplicationUserId",
                schema: "VRMS",
                table: "AisLists",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AISORCStockTypes_Users_ApplicationUserId",
                schema: "VRMS",
                table: "AISORCStockTypes",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AisStocks_Users_ApplicationUserId",
                schema: "VRMS",
                table: "AisStocks",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BanBodies_Users_ApplicationUserId",
                schema: "VRMS",
                table: "BanBodies",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommonCodes_Users_ApplicationUserId",
                schema: "Common",
                table: "CommonCodes",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyProfiles_Users_ApplicationUserId",
                schema: "Common",
                table: "CompanyProfiles",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Users_ApplicationUserId",
                schema: "Common",
                table: "Countries",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DepreciationCosts_Users_ApplicationUserId",
                schema: "VRMS",
                table: "DepreciationCosts",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DeviceLists_Users_ApplicationUserId",
                schema: "Common",
                table: "DeviceLists",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentTypes_Users_ApplicationUserId",
                schema: "VRMS",
                table: "DocumentTypes",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FactoryPoints_Users_ApplicationUserId",
                schema: "VRMS",
                table: "FactoryPoints",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FieldInspections_Users_ApplicationUserId",
                schema: "VRMS",
                table: "FieldInspections",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InitialPrices_Users_ApplicationUserId",
                schema: "VRMS",
                table: "InitialPrices",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ManufacturingCountries_Users_ApplicationUserId",
                schema: "VRMS",
                table: "ManufacturingCountries",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ORCLists_Users_ApplicationUserId",
                schema: "VRMS",
                table: "ORCLists",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ORCStocks_Users_ApplicationUserId",
                schema: "VRMS",
                table: "ORCStocks",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationList_Users_ApplicationUserId",
                table: "OrganizationList",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OwnerLists_Users_ApplicationUserId",
                schema: "VRMS",
                table: "OwnerLists",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PasswordChangeRequests_Users_ApplicationUserId",
                schema: "UserMgt",
                table: "PasswordChangeRequests",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlateStocks_Users_ApplicationUserId",
                schema: "VRMS",
                table: "PlateStocks",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlateTypes_Users_ApplicationUserId",
                schema: "VRMS",
                table: "PlateTypes",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Regions_Users_ApplicationUserId",
                schema: "Common",
                table: "Regions",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalvageValues_Users_ApplicationUserId",
                schema: "VRMS",
                table: "SalvageValues",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceChanges_Users_ApplicationUserId",
                schema: "VRMS",
                table: "ServiceChanges",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTypes_Users_ApplicationUserId",
                schema: "VRMS",
                table: "ServiceTypes",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceYearSettings_Users_ApplicationUserId",
                schema: "VRMS",
                table: "ServiceYearSettings",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TechnicalInspections_Users_ApplicationUserId",
                schema: "VRMS",
                table: "TechnicalInspections",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TemporaryVehicleDeactivations_Users_ApplicationUserId",
                schema: "VRMS",
                table: "TemporaryVehicleDeactivations",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingCenterList_Users_ApplicationUserId",
                table: "TrainingCenterList",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ValuationDetails_Users_ApplicationUserId",
                schema: "VRMS",
                table: "ValuationDetails",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ValuationLists_Users_ApplicationUserId",
                schema: "VRMS",
                table: "ValuationLists",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ValuationReason_Users_ApplicationUserId",
                table: "ValuationReason",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleBans_Users_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleBans",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleBodyTypes_Users_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleBodyTypes",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleLists_Users_ApplicationUserId",
                table: "VehicleLists",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_vehicleLookups_Users_ApplicationUserId",
                schema: "VRMS",
                table: "vehicleLookups",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleModels_Users_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleModels",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleOwners_Users_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleOwners",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VehiclePlates_Users_ApplicationUserId",
                schema: "VRMS",
                table: "VehiclePlates",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleReplacements_Users_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleReplacements",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleSerialSettings_Users_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleSerialSettings",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleSettings_Users_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleSettings",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleTransfers_Users_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleTransfers",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleTypes_Users_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleTypes",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Woredas_Users_ApplicationUserId",
                schema: "Common",
                table: "Woredas",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Zones_Users_ApplicationUserId",
                schema: "Common",
                table: "Zones",
                column: "ApplicationUserId",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
