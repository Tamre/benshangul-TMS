using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportManagmentInfrustructure.Migrations
{
    /// <inheritdoc />
    public partial class Initital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "VRMS");

            migrationBuilder.EnsureSchema(
                name: "Common");

            migrationBuilder.EnsureSchema(
                name: "UserMgt");

            migrationBuilder.CreateTable(
                name: "RoleCategories",
                schema: "UserMgt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleModule = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "UserMgt",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmharicName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Module = table.Column<int>(type: "int", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    UserTypeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPasswordChanged = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "UserMgt",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleCategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_RoleCategories_RoleCategoryId",
                        column: x => x.RoleCategoryId,
                        principalSchema: "UserMgt",
                        principalTable: "RoleCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AISORCStockTypes",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LocalName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
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
                    LocalName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
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
                name: "CompanyProfiles",
                schema: "Common",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LocalName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyProfiles_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "Common",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LocalName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    NationalityName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LocalNationalityName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DepreciationCosts",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LocalName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepreciationCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepreciationCosts_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DeviceLists",
                schema: "Common",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PCNAme = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MACAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ApproverId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ApprovedFor = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceLists_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DeviceLists_Users_ApproverId",
                        column: x => x.ApproverId,
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
                name: "InitialPrices",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LocalName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InitialPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InitialPrices_Users_ApplicationUserId",
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
                    LocalName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    ListOfCountries = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
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
                name: "PasswordChangeRequests",
                schema: "UserMgt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequesterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordChangeStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordChangeRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PasswordChangeRequests_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PasswordHistories",
                schema: "UserMgt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PasswordHistories_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SalvageValues",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LocalName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalvageValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalvageValues_Users_ApplicationUserId",
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
                    LocalName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ServiceModule = table.Column<int>(type: "int", nullable: false),
                    ListOfPlates = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    ListOfAIS = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
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
                name: "ValuationReason",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsValuationPayment = table.Column<bool>(type: "bit", nullable: false),
                    IsOwnershipPayment = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValuationReason", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValuationReason_Users_ApplicationUserId",
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
                    LocalName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
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
                name: "Regions",
                schema: "Common",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LocalName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    LocalCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regions_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Common",
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Regions_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FactoryPoints",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarkId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactoryPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FactoryPoints_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FactoryPoints_vehicleLookups_MarkId",
                        column: x => x.MarkId,
                        principalSchema: "VRMS",
                        principalTable: "vehicleLookups",
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
                    LocalName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    RegionList = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    MinorId = table.Column<int>(type: "int", nullable: true),
                    MajorId = table.Column<int>(type: "int", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_PlateTypes_vehicleLookups_MajorId",
                        column: x => x.MajorId,
                        principalSchema: "VRMS",
                        principalTable: "vehicleLookups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlateTypes_vehicleLookups_MinorId",
                        column: x => x.MinorId,
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
                    LocalName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
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
                name: "Zones",
                schema: "Common",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LocalName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    LocalCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Seffix = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LocalSuffix = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IsCity = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zones_Regions_RegionId",
                        column: x => x.RegionId,
                        principalSchema: "Common",
                        principalTable: "Regions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Zones_Users_ApplicationUserId",
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
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_ServiceYearSettings_VehicleTypes_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalSchema: "VRMS",
                        principalTable: "VehicleTypes",
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
                    LocalName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "AisStocks",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AISNo = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    StockTypeId = table.Column<int>(type: "int", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    ToZoneId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AisStocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AisStocks_AISORCStockTypes_StockTypeId",
                        column: x => x.StockTypeId,
                        principalSchema: "VRMS",
                        principalTable: "AISORCStockTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AisStocks_Regions_RegionId",
                        column: x => x.RegionId,
                        principalSchema: "Common",
                        principalTable: "Regions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AisStocks_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AisStocks_Zones_ToZoneId",
                        column: x => x.ToZoneId,
                        principalSchema: "Common",
                        principalTable: "Zones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CommonCodes",
                schema: "Common",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZoneId = table.Column<int>(type: "int", nullable: false),
                    CommonCodeType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Pad = table.Column<int>(type: "int", nullable: false),
                    CurrentNumber = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommonCodes_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CommonCodes_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalSchema: "Common",
                        principalTable: "Zones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ORCStocks",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ORCNo = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    StockTypeId = table.Column<int>(type: "int", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    ToZoneId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORCStocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ORCStocks_AISORCStockTypes_StockTypeId",
                        column: x => x.StockTypeId,
                        principalSchema: "VRMS",
                        principalTable: "AISORCStockTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ORCStocks_Regions_RegionId",
                        column: x => x.RegionId,
                        principalSchema: "Common",
                        principalTable: "Regions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ORCStocks_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ORCStocks_Zones_ToZoneId",
                        column: x => x.ToZoneId,
                        principalSchema: "Common",
                        principalTable: "Zones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlateStocks",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlateTypeId = table.Column<int>(type: "int", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    PlateNo = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    FrontPlateSizeId = table.Column<int>(type: "int", nullable: false),
                    BackPlateSizeId = table.Column<int>(type: "int", nullable: true),
                    PlateDigit = table.Column<int>(type: "int", nullable: false),
                    ToZoneId = table.Column<int>(type: "int", nullable: true),
                    GivenStatus = table.Column<int>(type: "int", nullable: false),
                    IssuanceType = table.Column<int>(type: "int", nullable: false),
                    IsBackLog = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlateStocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlateStocks_PlateTypes_PlateTypeId",
                        column: x => x.PlateTypeId,
                        principalSchema: "VRMS",
                        principalTable: "PlateTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlateStocks_Regions_RegionId",
                        column: x => x.RegionId,
                        principalSchema: "Common",
                        principalTable: "Regions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlateStocks_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlateStocks_Zones_ToZoneId",
                        column: x => x.ToZoneId,
                        principalSchema: "Common",
                        principalTable: "Zones",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlateStocks_vehicleLookups_BackPlateSizeId",
                        column: x => x.BackPlateSizeId,
                        principalSchema: "VRMS",
                        principalTable: "vehicleLookups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlateStocks_vehicleLookups_FrontPlateSizeId",
                        column: x => x.FrontPlateSizeId,
                        principalSchema: "VRMS",
                        principalTable: "vehicleLookups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VehicleLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegistrationType = table.Column<int>(type: "int", nullable: false),
                    RegistrationNo = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    ApprovalStatus = table.Column<int>(type: "int", nullable: false),
                    TaxStatus = table.Column<int>(type: "int", nullable: false),
                    IsVehicleComplete = table.Column<bool>(type: "bit", nullable: false),
                    ApprovedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    OfficeCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DeclarationNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DeclarationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BillOfLoading = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RemovalNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvoicePrice = table.Column<double>(type: "float", nullable: true),
                    ChassisNo = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    EngineNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    AssembledCountryId = table.Column<int>(type: "int", nullable: false),
                    ChassisMadeId = table.Column<int>(type: "int", nullable: false),
                    ManufacturingYear = table.Column<int>(type: "int", nullable: false),
                    HorsePower = table.Column<int>(type: "int", nullable: false),
                    HorsePowerMeasure = table.Column<int>(type: "int", nullable: false),
                    NoCylinder = table.Column<int>(type: "int", nullable: false),
                    EngineCapacity = table.Column<double>(type: "float", nullable: false),
                    LastActionTaken = table.Column<int>(type: "int", nullable: false),
                    TypeOfVehicle = table.Column<int>(type: "int", nullable: false),
                    VehicleCurrentStatus = table.Column<int>(type: "int", nullable: false),
                    TransferStatus = table.Column<int>(type: "int", nullable: false),
                    ServiceZoneId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleLists_Countries_AssembledCountryId",
                        column: x => x.AssembledCountryId,
                        principalSchema: "Common",
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VehicleLists_Countries_ChassisMadeId",
                        column: x => x.ChassisMadeId,
                        principalSchema: "Common",
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VehicleLists_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VehicleLists_Users_ApprovedById",
                        column: x => x.ApprovedById,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VehicleLists_VehicleModels_ModelId",
                        column: x => x.ModelId,
                        principalSchema: "VRMS",
                        principalTable: "VehicleModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VehicleLists_Zones_ServiceZoneId",
                        column: x => x.ServiceZoneId,
                        principalSchema: "Common",
                        principalTable: "Zones",
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
                name: "Woredas",
                schema: "Common",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZoneId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LocalName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    LocalCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RowStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Woredas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Woredas_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Woredas_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalSchema: "Common",
                        principalTable: "Zones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AisLists",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsPrinted = table.Column<bool>(type: "bit", nullable: false),
                    PrintedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AISYear = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    RegionCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    GivenZoneId = table.Column<int>(type: "int", nullable: false),
                    IssueReason = table.Column<int>(type: "int", nullable: false),
                    PreviousReason = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AisLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AisLists_AisStocks_StockId",
                        column: x => x.StockId,
                        principalSchema: "VRMS",
                        principalTable: "AisStocks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AisLists_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AisLists_VehicleLists_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "VehicleLists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AisLists_Zones_GivenZoneId",
                        column: x => x.GivenZoneId,
                        principalSchema: "Common",
                        principalTable: "Zones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ORCLists",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsPrinted = table.Column<bool>(type: "bit", nullable: false),
                    PrintedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GivenZoneId = table.Column<int>(type: "int", nullable: false),
                    IssueReason = table.Column<int>(type: "int", nullable: false),
                    PreviousReason = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORCLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ORCLists_ORCStocks_StockId",
                        column: x => x.StockId,
                        principalSchema: "VRMS",
                        principalTable: "ORCStocks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ORCLists_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ORCLists_VehicleLists_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "VehicleLists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ORCLists_Zones_GivenZoneId",
                        column: x => x.GivenZoneId,
                        principalSchema: "Common",
                        principalTable: "Zones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TemporaryVehicleDeactivations",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LetterNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LetterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    IsActivated = table.Column<bool>(type: "bit", nullable: false),
                    ActivatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActivatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemporaryVehicleDeactivations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemporaryVehicleDeactivations_Users_ActivatedById",
                        column: x => x.ActivatedById,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TemporaryVehicleDeactivations_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TemporaryVehicleDeactivations_VehicleLists_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "VehicleLists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ValuationLists",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepreciationCostId = table.Column<int>(type: "int", nullable: false),
                    DepreciationCostValue = table.Column<double>(type: "float", nullable: false),
                    FactoryPointId = table.Column<int>(type: "int", nullable: false),
                    FactoryPointValue = table.Column<double>(type: "float", nullable: false),
                    InitialPriceId = table.Column<int>(type: "int", nullable: false),
                    InitialPriceValue = table.Column<double>(type: "float", nullable: false),
                    SalvageValueID = table.Column<int>(type: "int", nullable: false),
                    SalvageValuePrice = table.Column<double>(type: "float", nullable: false),
                    ServiceYearId = table.Column<int>(type: "int", nullable: false),
                    ServiceYearValue = table.Column<double>(type: "float", nullable: false),
                    VehicleTypeValue = table.Column<double>(type: "float", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    ValuationReasonId = table.Column<int>(type: "int", nullable: false),
                    SellersAgreement = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValuationLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValuationLists_DepreciationCosts_DepreciationCostId",
                        column: x => x.DepreciationCostId,
                        principalSchema: "VRMS",
                        principalTable: "DepreciationCosts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ValuationLists_FactoryPoints_FactoryPointId",
                        column: x => x.FactoryPointId,
                        principalSchema: "VRMS",
                        principalTable: "FactoryPoints",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ValuationLists_InitialPrices_InitialPriceId",
                        column: x => x.InitialPriceId,
                        principalSchema: "VRMS",
                        principalTable: "InitialPrices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ValuationLists_SalvageValues_SalvageValueID",
                        column: x => x.SalvageValueID,
                        principalSchema: "VRMS",
                        principalTable: "SalvageValues",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ValuationLists_ServiceYearSettings_ServiceYearId",
                        column: x => x.ServiceYearId,
                        principalSchema: "VRMS",
                        principalTable: "ServiceYearSettings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ValuationLists_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ValuationLists_ValuationReason_ValuationReasonId",
                        column: x => x.ValuationReasonId,
                        principalTable: "ValuationReason",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ValuationLists_VehicleLists_VehicleListId",
                        column: x => x.VehicleListId,
                        principalTable: "VehicleLists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VehicleBans",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BanCaseId = table.Column<int>(type: "int", nullable: false),
                    BanBodyId = table.Column<int>(type: "int", nullable: false),
                    MoneyAmmount = table.Column<double>(type: "float", nullable: true),
                    BanDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BanLetterNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsLifted = table.Column<bool>(type: "bit", nullable: false),
                    LiftedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    LetterLiftDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LetterLiftNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Enclosure = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleBans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleBans_BanBodies_BanBodyId",
                        column: x => x.BanBodyId,
                        principalSchema: "VRMS",
                        principalTable: "BanBodies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VehicleBans_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VehicleBans_Users_LiftedById",
                        column: x => x.LiftedById,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VehicleBans_VehicleLists_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "VehicleLists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VehicleBans_vehicleLookups_BanCaseId",
                        column: x => x.BanCaseId,
                        principalSchema: "VRMS",
                        principalTable: "vehicleLookups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VehiclePlates",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlateStockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GivenZoneId = table.Column<int>(type: "int", nullable: false),
                    ServiceModule = table.Column<int>(type: "int", nullable: false),
                    PreviousModule = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclePlates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehiclePlates_PlateStocks_PlateStockId",
                        column: x => x.PlateStockId,
                        principalSchema: "VRMS",
                        principalTable: "PlateStocks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VehiclePlates_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VehiclePlates_VehicleLists_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "VehicleLists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VehiclePlates_Zones_GivenZoneId",
                        column: x => x.GivenZoneId,
                        principalSchema: "Common",
                        principalTable: "Zones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VehicleReplacements",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReplacementType = table.Column<int>(type: "int", nullable: false),
                    ReplacementReason = table.Column<int>(type: "int", nullable: false),
                    LetterNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PoliceStation = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    LetterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleReplacements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleReplacements_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VehicleReplacements_VehicleLists_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "VehicleLists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VehicleTransfers",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromZoneId = table.Column<int>(type: "int", nullable: false),
                    ToZoneId = table.Column<int>(type: "int", nullable: false),
                    TransferedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LetterNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    TransferNumber = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    TransferStatus = table.Column<int>(type: "int", nullable: false),
                    PreviousPlate = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    IsVehicleRejected = table.Column<bool>(type: "bit", nullable: false),
                    ChangePlate = table.Column<bool>(type: "bit", nullable: false),
                    ChangeOwner = table.Column<bool>(type: "bit", nullable: false),
                    ChangeServiceType = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTransfers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleTransfers_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VehicleTransfers_VehicleLists_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "VehicleLists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VehicleTransfers_Zones_FromZoneId",
                        column: x => x.FromZoneId,
                        principalSchema: "Common",
                        principalTable: "Zones",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VehicleTransfers_Zones_ToZoneId",
                        column: x => x.ToZoneId,
                        principalSchema: "Common",
                        principalTable: "Zones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrganizationList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZoneId = table.Column<int>(type: "int", nullable: false),
                    WoredaId = table.Column<int>(type: "int", nullable: true),
                    Town = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kebele = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseNumnber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondaryPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeOfOrganization = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationList_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrganizationList_Woredas_WoredaId",
                        column: x => x.WoredaId,
                        principalSchema: "Common",
                        principalTable: "Woredas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrganizationList_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalSchema: "Common",
                        principalTable: "Zones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OwnerLists",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerNumber = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    AmharicFirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AmharicMiddleName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AmharicLastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    ZoneId = table.Column<int>(type: "int", nullable: false),
                    WoredaId = table.Column<int>(type: "int", nullable: true),
                    Town = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    HouseNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    SecocdaryPhoneNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    IdNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PoBox = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OwnerLists_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OwnerLists_Woredas_WoredaId",
                        column: x => x.WoredaId,
                        principalSchema: "Common",
                        principalTable: "Woredas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OwnerLists_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalSchema: "Common",
                        principalTable: "Zones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TrainingCenterList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainingCenterNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmharicName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceZoneId = table.Column<int>(type: "int", nullable: false),
                    ZoneId = table.Column<int>(type: "int", nullable: false),
                    WoredaId = table.Column<int>(type: "int", nullable: false),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondaryPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longtiude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingCenterList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingCenterList_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrainingCenterList_Woredas_WoredaId",
                        column: x => x.WoredaId,
                        principalSchema: "Common",
                        principalTable: "Woredas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrainingCenterList_Zones_ServiceZoneId",
                        column: x => x.ServiceZoneId,
                        principalSchema: "Common",
                        principalTable: "Zones",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrainingCenterList_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalSchema: "Common",
                        principalTable: "Zones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceChanges",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehilceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GivingZoneId = table.Column<int>(type: "int", nullable: false),
                    ServiceChangeType = table.Column<int>(type: "int", nullable: false),
                    LetterNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    IsORCChanges = table.Column<bool>(type: "bit", nullable: false),
                    ISAISChanges = table.Column<bool>(type: "bit", nullable: false),
                    IsPlateChanges = table.Column<bool>(type: "bit", nullable: false),
                    PreviousEngineNo = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    EngineNo = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceChanges_OrganizationList_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "OrganizationList",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceChanges_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceChanges_VehicleLists_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "VehicleLists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceChanges_Zones_GivingZoneId",
                        column: x => x.GivingZoneId,
                        principalSchema: "Common",
                        principalTable: "Zones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ValuationDetails",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValuationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RepresentativeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RepresentativeAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnershipType = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValuationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValuationDetails_OwnerLists_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "VRMS",
                        principalTable: "OwnerLists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ValuationDetails_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ValuationDetails_ValuationLists_ValuationId",
                        column: x => x.ValuationId,
                        principalSchema: "VRMS",
                        principalTable: "ValuationLists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VehicleOwners",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TrainingCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OwnerState = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleOwners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleOwners_OwnerLists_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "VRMS",
                        principalTable: "OwnerLists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VehicleOwners_TrainingCenterList_TrainingCenterId",
                        column: x => x.TrainingCenterId,
                        principalTable: "TrainingCenterList",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VehicleOwners_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VehicleOwners_VehicleLists_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "VehicleLists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FieldInspections",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GivenZoneId = table.Column<int>(type: "int", nullable: false),
                    ServiceChangeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Width = table.Column<double>(type: "float", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Length = table.Column<double>(type: "float", nullable: false),
                    FrontTyreSize = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RearTyreSize = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NoOfRearAxel = table.Column<int>(type: "int", nullable: false),
                    NoOfFrontAxel = table.Column<int>(type: "int", nullable: false),
                    AxelDriveType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NumberOfTyre = table.Column<int>(type: "int", nullable: false),
                    FrontAxelMAxLoad = table.Column<double>(type: "float", nullable: false),
                    RearAxelMaxLoad = table.Column<double>(type: "float", nullable: false),
                    GrossWeight = table.Column<double>(type: "float", nullable: false),
                    TareWeight = table.Column<double>(type: "float", nullable: false),
                    FrontPlateSizeId = table.Column<int>(type: "int", nullable: false),
                    BackPlateSizeId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldInspections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldInspections_ServiceChanges_ServiceChangeId",
                        column: x => x.ServiceChangeId,
                        principalSchema: "VRMS",
                        principalTable: "ServiceChanges",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FieldInspections_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FieldInspections_VehicleLists_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "VehicleLists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FieldInspections_Zones_GivenZoneId",
                        column: x => x.GivenZoneId,
                        principalSchema: "Common",
                        principalTable: "Zones",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FieldInspections_vehicleLookups_BackPlateSizeId",
                        column: x => x.BackPlateSizeId,
                        principalSchema: "VRMS",
                        principalTable: "vehicleLookups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FieldInspections_vehicleLookups_FrontPlateSizeId",
                        column: x => x.FrontPlateSizeId,
                        principalSchema: "VRMS",
                        principalTable: "vehicleLookups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TechnicalInspections",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FieldInspectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleBodyTypeId = table.Column<int>(type: "int", nullable: false),
                    ServiceTypeId = table.Column<int>(type: "int", nullable: false),
                    LoadMesurementId = table.Column<int>(type: "int", nullable: true),
                    NoOfPeople = table.Column<int>(type: "int", nullable: false),
                    LoadValue = table.Column<double>(type: "float", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    HydroCarbon = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CarbonMonoOxide = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IsEngineReadable = table.Column<bool>(type: "bit", nullable: false),
                    PermissionLetterNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PermissionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalInspections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechnicalInspections_FieldInspections_FieldInspectionId",
                        column: x => x.FieldInspectionId,
                        principalSchema: "VRMS",
                        principalTable: "FieldInspections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TechnicalInspections_ServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalSchema: "VRMS",
                        principalTable: "ServiceTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TechnicalInspections_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TechnicalInspections_VehicleBodyTypes_VehicleBodyTypeId",
                        column: x => x.VehicleBodyTypeId,
                        principalSchema: "VRMS",
                        principalTable: "VehicleBodyTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TechnicalInspections_vehicleLookups_ColorId",
                        column: x => x.ColorId,
                        principalSchema: "VRMS",
                        principalTable: "vehicleLookups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TechnicalInspections_vehicleLookups_LoadMesurementId",
                        column: x => x.LoadMesurementId,
                        principalSchema: "VRMS",
                        principalTable: "vehicleLookups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AisLists_ApplicationUserId",
                schema: "VRMS",
                table: "AisLists",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AisLists_GivenZoneId",
                schema: "VRMS",
                table: "AisLists",
                column: "GivenZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_AisLists_StockId",
                schema: "VRMS",
                table: "AisLists",
                column: "StockId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AisLists_VehicleId",
                schema: "VRMS",
                table: "AisLists",
                column: "VehicleId");

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
                name: "IX_AisStocks_AISNo_StockTypeId",
                schema: "VRMS",
                table: "AisStocks",
                columns: new[] { "AISNo", "StockTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AisStocks_ApplicationUserId",
                schema: "VRMS",
                table: "AisStocks",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AisStocks_RegionId",
                schema: "VRMS",
                table: "AisStocks",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_AisStocks_StockTypeId",
                schema: "VRMS",
                table: "AisStocks",
                column: "StockTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AisStocks_ToZoneId",
                schema: "VRMS",
                table: "AisStocks",
                column: "ToZoneId");

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
                name: "IX_CommonCodes_ApplicationUserId",
                schema: "Common",
                table: "CommonCodes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CommonCodes_CommonCodeType",
                schema: "Common",
                table: "CommonCodes",
                column: "CommonCodeType",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommonCodes_ZoneId",
                schema: "Common",
                table: "CommonCodes",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyProfiles_ApplicationUserId",
                schema: "Common",
                table: "CompanyProfiles",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_ApplicationUserId",
                schema: "Common",
                table: "Countries",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Name",
                schema: "Common",
                table: "Countries",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DepreciationCosts_ApplicationUserId",
                schema: "VRMS",
                table: "DepreciationCosts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DepreciationCosts_Name",
                schema: "VRMS",
                table: "DepreciationCosts",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceLists_ApplicationUserId",
                schema: "Common",
                table: "DeviceLists",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceLists_ApproverId",
                schema: "Common",
                table: "DeviceLists",
                column: "ApproverId");

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
                name: "IX_FactoryPoints_ApplicationUserId",
                schema: "VRMS",
                table: "FactoryPoints",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FactoryPoints_MarkId",
                schema: "VRMS",
                table: "FactoryPoints",
                column: "MarkId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldInspections_ApplicationUserId",
                schema: "VRMS",
                table: "FieldInspections",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldInspections_BackPlateSizeId",
                schema: "VRMS",
                table: "FieldInspections",
                column: "BackPlateSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldInspections_FrontPlateSizeId",
                schema: "VRMS",
                table: "FieldInspections",
                column: "FrontPlateSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldInspections_GivenZoneId",
                schema: "VRMS",
                table: "FieldInspections",
                column: "GivenZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldInspections_ServiceChangeId",
                schema: "VRMS",
                table: "FieldInspections",
                column: "ServiceChangeId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldInspections_VehicleId",
                schema: "VRMS",
                table: "FieldInspections",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialPrices_ApplicationUserId",
                schema: "VRMS",
                table: "InitialPrices",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InitialPrices_Name",
                schema: "VRMS",
                table: "InitialPrices",
                column: "Name",
                unique: true);

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
                name: "IX_ORCLists_ApplicationUserId",
                schema: "VRMS",
                table: "ORCLists",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ORCLists_GivenZoneId",
                schema: "VRMS",
                table: "ORCLists",
                column: "GivenZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_ORCLists_StockId",
                schema: "VRMS",
                table: "ORCLists",
                column: "StockId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ORCLists_VehicleId",
                schema: "VRMS",
                table: "ORCLists",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_ORCStocks_ApplicationUserId",
                schema: "VRMS",
                table: "ORCStocks",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ORCStocks_ORCNo_StockTypeId",
                schema: "VRMS",
                table: "ORCStocks",
                columns: new[] { "ORCNo", "StockTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ORCStocks_RegionId",
                schema: "VRMS",
                table: "ORCStocks",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_ORCStocks_StockTypeId",
                schema: "VRMS",
                table: "ORCStocks",
                column: "StockTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ORCStocks_ToZoneId",
                schema: "VRMS",
                table: "ORCStocks",
                column: "ToZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationList_ApplicationUserId",
                table: "OrganizationList",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationList_WoredaId",
                table: "OrganizationList",
                column: "WoredaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationList_ZoneId",
                table: "OrganizationList",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerLists_ApplicationUserId",
                schema: "VRMS",
                table: "OwnerLists",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerLists_IdNumber",
                schema: "VRMS",
                table: "OwnerLists",
                column: "IdNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OwnerLists_PhoneNumber",
                schema: "VRMS",
                table: "OwnerLists",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OwnerLists_WoredaId",
                schema: "VRMS",
                table: "OwnerLists",
                column: "WoredaId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerLists_ZoneId",
                schema: "VRMS",
                table: "OwnerLists",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordChangeRequests_ApplicationUserId",
                schema: "UserMgt",
                table: "PasswordChangeRequests",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordHistories_UserId",
                schema: "UserMgt",
                table: "PasswordHistories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlateStocks_ApplicationUserId",
                schema: "VRMS",
                table: "PlateStocks",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlateStocks_BackPlateSizeId",
                schema: "VRMS",
                table: "PlateStocks",
                column: "BackPlateSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_PlateStocks_FrontPlateSizeId",
                schema: "VRMS",
                table: "PlateStocks",
                column: "FrontPlateSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_PlateStocks_PlateNo_IssuanceType",
                schema: "VRMS",
                table: "PlateStocks",
                columns: new[] { "PlateNo", "IssuanceType" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlateStocks_PlateTypeId",
                schema: "VRMS",
                table: "PlateStocks",
                column: "PlateTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PlateStocks_RegionId",
                schema: "VRMS",
                table: "PlateStocks",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_PlateStocks_ToZoneId",
                schema: "VRMS",
                table: "PlateStocks",
                column: "ToZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_PlateTypes_ApplicationUserId",
                schema: "VRMS",
                table: "PlateTypes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlateTypes_MajorId",
                schema: "VRMS",
                table: "PlateTypes",
                column: "MajorId");

            migrationBuilder.CreateIndex(
                name: "IX_PlateTypes_MinorId",
                schema: "VRMS",
                table: "PlateTypes",
                column: "MinorId");

            migrationBuilder.CreateIndex(
                name: "IX_PlateTypes_Name",
                schema: "VRMS",
                table: "PlateTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Regions_ApplicationUserId",
                schema: "Common",
                table: "Regions",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_CountryId",
                schema: "Common",
                table: "Regions",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_Name",
                schema: "Common",
                table: "Regions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_RoleCategoryId",
                schema: "UserMgt",
                table: "Roles",
                column: "RoleCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SalvageValues_ApplicationUserId",
                schema: "VRMS",
                table: "SalvageValues",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SalvageValues_Name",
                schema: "VRMS",
                table: "SalvageValues",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceChanges_ApplicationUserId",
                schema: "VRMS",
                table: "ServiceChanges",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceChanges_GivingZoneId",
                schema: "VRMS",
                table: "ServiceChanges",
                column: "GivingZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceChanges_OrganizationId",
                schema: "VRMS",
                table: "ServiceChanges",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceChanges_VehicleId",
                schema: "VRMS",
                table: "ServiceChanges",
                column: "VehicleId");

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
                name: "IX_ServiceYearSettings_VehicleTypeId",
                schema: "VRMS",
                table: "ServiceYearSettings",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalInspections_ApplicationUserId",
                schema: "VRMS",
                table: "TechnicalInspections",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalInspections_ColorId",
                schema: "VRMS",
                table: "TechnicalInspections",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalInspections_FieldInspectionId",
                schema: "VRMS",
                table: "TechnicalInspections",
                column: "FieldInspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalInspections_LoadMesurementId",
                schema: "VRMS",
                table: "TechnicalInspections",
                column: "LoadMesurementId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalInspections_ServiceTypeId",
                schema: "VRMS",
                table: "TechnicalInspections",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalInspections_VehicleBodyTypeId",
                schema: "VRMS",
                table: "TechnicalInspections",
                column: "VehicleBodyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TemporaryVehicleDeactivations_ActivatedById",
                schema: "VRMS",
                table: "TemporaryVehicleDeactivations",
                column: "ActivatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TemporaryVehicleDeactivations_ApplicationUserId",
                schema: "VRMS",
                table: "TemporaryVehicleDeactivations",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TemporaryVehicleDeactivations_VehicleId",
                schema: "VRMS",
                table: "TemporaryVehicleDeactivations",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingCenterList_ApplicationUserId",
                table: "TrainingCenterList",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingCenterList_ServiceZoneId",
                table: "TrainingCenterList",
                column: "ServiceZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingCenterList_WoredaId",
                table: "TrainingCenterList",
                column: "WoredaId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingCenterList_ZoneId",
                table: "TrainingCenterList",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_ValuationDetails_ApplicationUserId",
                schema: "VRMS",
                table: "ValuationDetails",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ValuationDetails_OwnerId",
                schema: "VRMS",
                table: "ValuationDetails",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ValuationDetails_ValuationId",
                schema: "VRMS",
                table: "ValuationDetails",
                column: "ValuationId");

            migrationBuilder.CreateIndex(
                name: "IX_ValuationLists_ApplicationUserId",
                schema: "VRMS",
                table: "ValuationLists",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ValuationLists_DepreciationCostId",
                schema: "VRMS",
                table: "ValuationLists",
                column: "DepreciationCostId");

            migrationBuilder.CreateIndex(
                name: "IX_ValuationLists_FactoryPointId",
                schema: "VRMS",
                table: "ValuationLists",
                column: "FactoryPointId");

            migrationBuilder.CreateIndex(
                name: "IX_ValuationLists_InitialPriceId",
                schema: "VRMS",
                table: "ValuationLists",
                column: "InitialPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_ValuationLists_SalvageValueID",
                schema: "VRMS",
                table: "ValuationLists",
                column: "SalvageValueID");

            migrationBuilder.CreateIndex(
                name: "IX_ValuationLists_ServiceYearId",
                schema: "VRMS",
                table: "ValuationLists",
                column: "ServiceYearId");

            migrationBuilder.CreateIndex(
                name: "IX_ValuationLists_ValuationReasonId",
                schema: "VRMS",
                table: "ValuationLists",
                column: "ValuationReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_ValuationLists_VehicleListId",
                schema: "VRMS",
                table: "ValuationLists",
                column: "VehicleListId");

            migrationBuilder.CreateIndex(
                name: "IX_ValuationReason_ApplicationUserId",
                table: "ValuationReason",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleBans_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleBans",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleBans_BanBodyId",
                schema: "VRMS",
                table: "VehicleBans",
                column: "BanBodyId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleBans_BanCaseId",
                schema: "VRMS",
                table: "VehicleBans",
                column: "BanCaseId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleBans_LiftedById",
                schema: "VRMS",
                table: "VehicleBans",
                column: "LiftedById");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleBans_VehicleId",
                schema: "VRMS",
                table: "VehicleBans",
                column: "VehicleId");

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
                name: "IX_VehicleLists_ApplicationUserId",
                table: "VehicleLists",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleLists_ApprovedById",
                table: "VehicleLists",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleLists_AssembledCountryId",
                table: "VehicleLists",
                column: "AssembledCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleLists_ChassisMadeId",
                table: "VehicleLists",
                column: "ChassisMadeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleLists_ChassisNo",
                table: "VehicleLists",
                column: "ChassisNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleLists_EngineNumber",
                table: "VehicleLists",
                column: "EngineNumber",
                unique: true,
                filter: "[EngineNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleLists_ModelId",
                table: "VehicleLists",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleLists_ServiceZoneId",
                table: "VehicleLists",
                column: "ServiceZoneId");

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
                name: "IX_VehicleOwners_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleOwners",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleOwners_OwnerId",
                schema: "VRMS",
                table: "VehicleOwners",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleOwners_TrainingCenterId",
                schema: "VRMS",
                table: "VehicleOwners",
                column: "TrainingCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleOwners_VehicleId",
                schema: "VRMS",
                table: "VehicleOwners",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePlates_ApplicationUserId",
                schema: "VRMS",
                table: "VehiclePlates",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePlates_GivenZoneId",
                schema: "VRMS",
                table: "VehiclePlates",
                column: "GivenZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePlates_PlateStockId",
                schema: "VRMS",
                table: "VehiclePlates",
                column: "PlateStockId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePlates_VehicleId",
                schema: "VRMS",
                table: "VehiclePlates",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleReplacements_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleReplacements",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleReplacements_VehicleId",
                schema: "VRMS",
                table: "VehicleReplacements",
                column: "VehicleId");

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
                name: "IX_VehicleTransfers_ApplicationUserId",
                schema: "VRMS",
                table: "VehicleTransfers",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTransfers_FromZoneId",
                schema: "VRMS",
                table: "VehicleTransfers",
                column: "FromZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTransfers_ToZoneId",
                schema: "VRMS",
                table: "VehicleTransfers",
                column: "ToZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTransfers_VehicleId",
                schema: "VRMS",
                table: "VehicleTransfers",
                column: "VehicleId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Woredas_ApplicationUserId",
                schema: "Common",
                table: "Woredas",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Woredas_Name",
                schema: "Common",
                table: "Woredas",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Woredas_ZoneId",
                schema: "Common",
                table: "Woredas",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Zones_ApplicationUserId",
                schema: "Common",
                table: "Zones",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Zones_Name",
                schema: "Common",
                table: "Zones",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zones_RegionId",
                schema: "Common",
                table: "Zones",
                column: "RegionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AisLists",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "CommonCodes",
                schema: "Common");

            migrationBuilder.DropTable(
                name: "CompanyProfiles",
                schema: "Common");

            migrationBuilder.DropTable(
                name: "DeviceLists",
                schema: "Common");

            migrationBuilder.DropTable(
                name: "DocumentTypes",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "ManufacturingCountries",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "ORCLists",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "PasswordChangeRequests",
                schema: "UserMgt");

            migrationBuilder.DropTable(
                name: "PasswordHistories",
                schema: "UserMgt");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "UserMgt");

            migrationBuilder.DropTable(
                name: "TechnicalInspections",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "TemporaryVehicleDeactivations",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "ValuationDetails",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "VehicleBans",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "VehicleOwners",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "VehiclePlates",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "VehicleReplacements",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "VehicleSerialSettings",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "VehicleSettings",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "VehicleTransfers",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "AisStocks",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "ORCStocks",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "RoleCategories",
                schema: "UserMgt");

            migrationBuilder.DropTable(
                name: "FieldInspections",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "ServiceTypes",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "VehicleBodyTypes",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "ValuationLists",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "BanBodies",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "OwnerLists",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "TrainingCenterList");

            migrationBuilder.DropTable(
                name: "PlateStocks",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "AISORCStockTypes",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "ServiceChanges",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "DepreciationCosts",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "FactoryPoints",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "InitialPrices",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "SalvageValues",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "ServiceYearSettings",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "ValuationReason");

            migrationBuilder.DropTable(
                name: "PlateTypes",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "OrganizationList");

            migrationBuilder.DropTable(
                name: "VehicleLists");

            migrationBuilder.DropTable(
                name: "VehicleTypes",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "Woredas",
                schema: "Common");

            migrationBuilder.DropTable(
                name: "VehicleModels",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "Zones",
                schema: "Common");

            migrationBuilder.DropTable(
                name: "vehicleLookups",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "Regions",
                schema: "Common");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "Common");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "UserMgt");
        }
    }
}
