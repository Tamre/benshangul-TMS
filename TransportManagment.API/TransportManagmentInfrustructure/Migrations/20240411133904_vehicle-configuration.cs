using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportManagmentInfrustructure.Migrations
{
    /// <inheritdoc />
    public partial class vehicleconfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "VRMS");

            migrationBuilder.CreateTable(
                name: "AISORCStockTypes",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    AmharicName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AISORCStockTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AISORCStockTypes_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BanBodies",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    AmharicNAme = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BanBodyCategory = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BanBodies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BanBodies_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BaseEstimations",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    AmharicName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseEstimations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseEstimations_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BgPoints",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    AmharicName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Value = table.Column<double>(type: "float", maxLength: 10, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BgPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BgPoints_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DocumentTypes",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FileExtentions = table.Column<int>(type: "int", nullable: false),
                    IsPermanentRequired = table.Column<bool>(type: "bit", nullable: false),
                    IsTemporaryRequired = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentTypes_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HkPoints",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    AmharicName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HkPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HkPoints_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ManufacturingCountries",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    ListOfCountries = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturingCountries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManufacturingCountries_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlateTypes",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    AmharicName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    RegionList = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlateTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlateTypes_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceTypes",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    AmharicName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ServiceModule = table.Column<int>(type: "int", nullable: false),
                    ListOfPlates = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ListOfAIS = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceTypes_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Spoints",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    AmharicName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spoints_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "vehicleLookups",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleLookupType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    AmharicName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicleLookups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vehicleLookups_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VehicleSerialSettings",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleSerialType = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Pad = table.Column<int>(type: "int", nullable: false),
                    ZoneId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleSerialSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleSerialSettings_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VehicleSerialSettings_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalSchema: "Common",
                        principalTable: "Zones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VehicleSettings",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleSettingType = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleSettings_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceYearSettings",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromYear = table.Column<int>(type: "int", nullable: false),
                    ToYear = table.Column<int>(type: "int", nullable: false),
                    YearValue = table.Column<double>(type: "float", nullable: false),
                    ServiceYearCategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceYearSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceYearSettings_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceYearSettings_vehicleLookups_ServiceYearCategoryId",
                        column: x => x.ServiceYearCategoryId,
                        principalSchema: "VRMS",
                        principalTable: "vehicleLookups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VehicleModels",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    EngineCapacity = table.Column<double>(type: "float", nullable: false),
                    NoOfCylinder = table.Column<double>(type: "float", nullable: false),
                    HorsePowerMeasure = table.Column<int>(type: "int", nullable: false),
                    MarkId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleModels_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VehicleModels_vehicleLookups_MarkId",
                        column: x => x.MarkId,
                        principalSchema: "VRMS",
                        principalTable: "vehicleLookups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleCategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    AmharicName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleTypes_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VehicleTypes_vehicleLookups_VehicleCategoryId",
                        column: x => x.VehicleCategoryId,
                        principalSchema: "VRMS",
                        principalTable: "vehicleLookups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ManufacturePoints",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false),
                    MarkId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturePoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManufacturePoints_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ManufacturePoints_VehicleTypes_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalSchema: "VRMS",
                        principalTable: "VehicleTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ManufacturePoints_vehicleLookups_MarkId",
                        column: x => x.MarkId,
                        principalSchema: "VRMS",
                        principalTable: "vehicleLookups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VehicleBodyTypes",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    AmharicName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleBodyTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleBodyTypes_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VehicleBodyTypes_VehicleTypes_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalSchema: "VRMS",
                        principalTable: "VehicleTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AISORCStockTypes_ApplicationUserId",
                schema: "VRMS",
                table: "AISORCStockTypes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AISORCStockTypes_Code",
                schema: "VRMS",
                table: "AISORCStockTypes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AISORCStockTypes_Name",
                schema: "VRMS",
                table: "AISORCStockTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BanBodies_ApplicationUserId",
                schema: "VRMS",
                table: "BanBodies",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BanBodies_Name",
                schema: "VRMS",
                table: "BanBodies",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaseEstimations_ApplicationUserId",
                schema: "VRMS",
                table: "BaseEstimations",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEstimations_Name",
                schema: "VRMS",
                table: "BaseEstimations",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BgPoints_ApplicationUserId",
                schema: "VRMS",
                table: "BgPoints",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BgPoints_Name",
                schema: "VRMS",
                table: "BgPoints",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTypes_ApplicationUserId",
                schema: "VRMS",
                table: "DocumentTypes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTypes_FileName",
                schema: "VRMS",
                table: "DocumentTypes",
                column: "FileName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HkPoints_ApplicationUserId",
                schema: "VRMS",
                table: "HkPoints",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HkPoints_Name",
                schema: "VRMS",
                table: "HkPoints",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturePoints_ApplicationUserId",
                schema: "VRMS",
                table: "ManufacturePoints",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturePoints_MarkId",
                schema: "VRMS",
                table: "ManufacturePoints",
                column: "MarkId");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturePoints_VehicleTypeId",
                schema: "VRMS",
                table: "ManufacturePoints",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturingCountries_ApplicationUserId",
                schema: "VRMS",
                table: "ManufacturingCountries",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturingCountries_Name",
                schema: "VRMS",
                table: "ManufacturingCountries",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlateTypes_ApplicationUserId",
                schema: "VRMS",
                table: "PlateTypes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlateTypes_Name",
                schema: "VRMS",
                table: "PlateTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTypes_ApplicationUserId",
                schema: "VRMS",
                table: "ServiceTypes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTypes_Name",
                schema: "VRMS",
                table: "ServiceTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceYearSettings_ApplicationUserId",
                schema: "VRMS",
                table: "ServiceYearSettings",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceYearSettings_ServiceYearCategoryId",
                schema: "VRMS",
                table: "ServiceYearSettings",
                column: "ServiceYearCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Spoints_ApplicationUserId",
                schema: "VRMS",
                table: "Spoints",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Spoints_Name",
                schema: "VRMS",
                table: "Spoints",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleBodyTypes_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleBodyTypes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleBodyTypes_Name",
                schema: "VRMS",
                table: "VehicleBodyTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleBodyTypes_VehicleTypeId",
                schema: "VRMS",
                table: "VehicleBodyTypes",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_vehicleLookups_ApplicationUserId",
                schema: "VRMS",
                table: "vehicleLookups",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_vehicleLookups_Name",
                schema: "VRMS",
                table: "vehicleLookups",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModels_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleModels",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModels_MarkId",
                schema: "VRMS",
                table: "VehicleModels",
                column: "MarkId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModels_Name",
                schema: "VRMS",
                table: "VehicleModels",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleSerialSettings_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleSerialSettings",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleSerialSettings_VehicleSerialType",
                schema: "VRMS",
                table: "VehicleSerialSettings",
                column: "VehicleSerialType",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleSerialSettings_ZoneId",
                schema: "VRMS",
                table: "VehicleSerialSettings",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleSettings_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleSettings",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleSettings_VehicleSettingType",
                schema: "VRMS",
                table: "VehicleSettings",
                column: "VehicleSettingType",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTypes_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleTypes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTypes_Name",
                schema: "VRMS",
                table: "VehicleTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTypes_VehicleCategoryId",
                schema: "VRMS",
                table: "VehicleTypes",
                column: "VehicleCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AISORCStockTypes",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "BanBodies",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "BaseEstimations",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "BgPoints",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "DocumentTypes",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "HkPoints",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "ManufacturePoints",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "ManufacturingCountries",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "PlateTypes",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "ServiceTypes",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "ServiceYearSettings",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "Spoints",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "VehicleBodyTypes",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "VehicleModels",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "VehicleSerialSettings",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "VehicleSettings",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "VehicleTypes",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "vehicleLookups",
                schema: "VRMS");
        }
    }
}
