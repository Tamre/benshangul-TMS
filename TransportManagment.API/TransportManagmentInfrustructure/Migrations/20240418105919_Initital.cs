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
                    LocalName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
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
                    LocalName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
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
                    LocalName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
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
                    LocalName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
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
                    LocalName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
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
                name: "PlateTypes",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LocalName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    RegionList = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
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
                name: "SalvageValues",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LocalName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
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
                    LocalName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
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
                name: "ServiceYearSettings",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromYear = table.Column<int>(type: "int", nullable: false),
                    ToYear = table.Column<int>(type: "int", nullable: false),
                    YearValue = table.Column<double>(type: "float", nullable: false),
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
                    LocalName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
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
                    LocalName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
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
                name: "VehicleBodyTypes",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LocalName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
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
                name: "AISORCStockTypes",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "BanBodies",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "CommonCodes",
                schema: "Common");

            migrationBuilder.DropTable(
                name: "CompanyProfiles",
                schema: "Common");

            migrationBuilder.DropTable(
                name: "DepreciationCosts",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "DeviceLists",
                schema: "Common");

            migrationBuilder.DropTable(
                name: "DocumentTypes",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "FactoryPoints",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "InitialPrices",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "ManufacturingCountries",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "PasswordChangeRequests",
                schema: "UserMgt");

            migrationBuilder.DropTable(
                name: "PasswordHistories",
                schema: "UserMgt");

            migrationBuilder.DropTable(
                name: "PlateTypes",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "UserMgt");

            migrationBuilder.DropTable(
                name: "SalvageValues",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "ServiceTypes",
                schema: "VRMS");

            migrationBuilder.DropTable(
                name: "ServiceYearSettings",
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
                name: "Woredas",
                schema: "Common");

            migrationBuilder.DropTable(
                name: "RoleCategories",
                schema: "UserMgt");

            migrationBuilder.DropTable(
                name: "VehicleTypes",
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
