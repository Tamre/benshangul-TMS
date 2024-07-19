using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportManagmentInfrustructure.Migrations
{
    /// <inheritdoc />
    public partial class MachineConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationList_Users_CreatedById",
                table: "OrganizationList");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationList_Woredas_WoredaId",
                table: "OrganizationList");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationList_Zones_ZoneId",
                table: "OrganizationList");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceChanges_OrganizationList_OrganizationId",
                schema: "VRMS",
                table: "ServiceChanges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationList",
                table: "OrganizationList");

            migrationBuilder.RenameTable(
                name: "OrganizationList",
                newName: "GetOrganizationLists");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationList_ZoneId",
                table: "GetOrganizationLists",
                newName: "IX_GetOrganizationLists_ZoneId");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationList_WoredaId",
                table: "GetOrganizationLists",
                newName: "IX_GetOrganizationLists_WoredaId");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationList_CreatedById",
                table: "GetOrganizationLists",
                newName: "IX_GetOrganizationLists_CreatedById");

            migrationBuilder.AddColumn<string>(
                name: "ApprovedById",
                schema: "VRMS",
                table: "VehicleReplacements",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedDate",
                schema: "VRMS",
                table: "VehicleReplacements",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CretedById",
                schema: "VRMS",
                table: "VehicleReplacements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "VRMS",
                table: "VehicleReplacements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedById",
                table: "GetOrganizationLists",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "GetOrganizationLists",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tin",
                table: "GetOrganizationLists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GetOrganizationLists",
                table: "GetOrganizationLists",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MachineConfigurations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    model = table.Column<int>(type: "int", nullable: false),
                    ApiEndpoint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SqlConnectionString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduleIntervalMinutes = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceZoneId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineConfigurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MachineConfigurations_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "organizationCompounds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompoundType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompoundSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceZoneId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizationCompounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_organizationCompounds_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VehicleCancelations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    ClearanceLetterNo = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CleranceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsReverted = table.Column<bool>(type: "bit", nullable: false),
                    RevertedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleCancelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleCancelations_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VehicleCancelations_Users_RevertedById",
                        column: x => x.RevertedById,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VehicleCancelations_VehicleLists_VehicleId",
                        column: x => x.VehicleId,
                        principalSchema: "VRMS",
                        principalTable: "VehicleLists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleReplacements_ApprovedById",
                schema: "VRMS",
                table: "VehicleReplacements",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_MachineConfigurations_CreatedById",
                table: "MachineConfigurations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_organizationCompounds_CreatedById",
                table: "organizationCompounds",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleCancelations_CreatedById",
                table: "VehicleCancelations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleCancelations_RevertedById",
                table: "VehicleCancelations",
                column: "RevertedById");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleCancelations_VehicleId",
                table: "VehicleCancelations",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_GetOrganizationLists_Users_CreatedById",
                table: "GetOrganizationLists",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GetOrganizationLists_Woredas_WoredaId",
                table: "GetOrganizationLists",
                column: "WoredaId",
                principalSchema: "Common",
                principalTable: "Woredas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GetOrganizationLists_Zones_ZoneId",
                table: "GetOrganizationLists",
                column: "ZoneId",
                principalSchema: "Common",
                principalTable: "Zones",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceChanges_GetOrganizationLists_OrganizationId",
                schema: "VRMS",
                table: "ServiceChanges",
                column: "OrganizationId",
                principalTable: "GetOrganizationLists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleReplacements_Users_ApprovedById",
                schema: "VRMS",
                table: "VehicleReplacements",
                column: "ApprovedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GetOrganizationLists_Users_CreatedById",
                table: "GetOrganizationLists");

            migrationBuilder.DropForeignKey(
                name: "FK_GetOrganizationLists_Woredas_WoredaId",
                table: "GetOrganizationLists");

            migrationBuilder.DropForeignKey(
                name: "FK_GetOrganizationLists_Zones_ZoneId",
                table: "GetOrganizationLists");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceChanges_GetOrganizationLists_OrganizationId",
                schema: "VRMS",
                table: "ServiceChanges");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleReplacements_Users_ApprovedById",
                schema: "VRMS",
                table: "VehicleReplacements");

            migrationBuilder.DropTable(
                name: "MachineConfigurations");

            migrationBuilder.DropTable(
                name: "organizationCompounds");

            migrationBuilder.DropTable(
                name: "VehicleCancelations");

            migrationBuilder.DropIndex(
                name: "IX_VehicleReplacements_ApprovedById",
                schema: "VRMS",
                table: "VehicleReplacements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GetOrganizationLists",
                table: "GetOrganizationLists");

            migrationBuilder.DropColumn(
                name: "ApprovedById",
                schema: "VRMS",
                table: "VehicleReplacements");

            migrationBuilder.DropColumn(
                name: "ApprovedDate",
                schema: "VRMS",
                table: "VehicleReplacements");

            migrationBuilder.DropColumn(
                name: "CretedById",
                schema: "VRMS",
                table: "VehicleReplacements");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "VRMS",
                table: "VehicleReplacements");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "GetOrganizationLists");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "GetOrganizationLists");

            migrationBuilder.DropColumn(
                name: "Tin",
                table: "GetOrganizationLists");

            migrationBuilder.RenameTable(
                name: "GetOrganizationLists",
                newName: "OrganizationList");

            migrationBuilder.RenameIndex(
                name: "IX_GetOrganizationLists_ZoneId",
                table: "OrganizationList",
                newName: "IX_OrganizationList_ZoneId");

            migrationBuilder.RenameIndex(
                name: "IX_GetOrganizationLists_WoredaId",
                table: "OrganizationList",
                newName: "IX_OrganizationList_WoredaId");

            migrationBuilder.RenameIndex(
                name: "IX_GetOrganizationLists_CreatedById",
                table: "OrganizationList",
                newName: "IX_OrganizationList_CreatedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationList",
                table: "OrganizationList",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationList_Users_CreatedById",
                table: "OrganizationList",
                column: "CreatedById",
                principalSchema: "UserMgt",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationList_Woredas_WoredaId",
                table: "OrganizationList",
                column: "WoredaId",
                principalSchema: "Common",
                principalTable: "Woredas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationList_Zones_ZoneId",
                table: "OrganizationList",
                column: "ZoneId",
                principalSchema: "Common",
                principalTable: "Zones",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceChanges_OrganizationList_OrganizationId",
                schema: "VRMS",
                table: "ServiceChanges",
                column: "OrganizationId",
                principalTable: "OrganizationList",
                principalColumn: "Id");
        }
    }
}
