using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportManagmentInfrustructure.Migrations
{
    /// <inheritdoc />
    public partial class forvehicledocuemnttype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SecocdaryPhoneNumber",
                schema: "VRMS",
                table: "OwnerLists",
                newName: "SecondaryPhoneNumber");

            migrationBuilder.AddColumn<Guid>(
                name: "PlateStockId1",
                schema: "VRMS",
                table: "VehiclePlates",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AISYear",
                schema: "VRMS",
                table: "AisLists",
                type: "int",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.CreateTable(
                name: "VehicleDocuments",
                schema: "VRMS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentTypeId = table.Column<int>(type: "int", nullable: false),
                    DocumentPath = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    ForVehicleDocument = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleDocuments_DocumentTypes_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalSchema: "VRMS",
                        principalTable: "DocumentTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VehicleDocuments_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "UserMgt",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VehicleDocuments_VehicleLists_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "VehicleLists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePlates_PlateStockId1",
                schema: "VRMS",
                table: "VehiclePlates",
                column: "PlateStockId1");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDocuments_CreatedById",
                schema: "VRMS",
                table: "VehicleDocuments",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDocuments_DocumentTypeId_VehicleId",
                schema: "VRMS",
                table: "VehicleDocuments",
                columns: new[] { "DocumentTypeId", "VehicleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDocuments_VehicleId",
                schema: "VRMS",
                table: "VehicleDocuments",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehiclePlates_PlateStocks_PlateStockId1",
                schema: "VRMS",
                table: "VehiclePlates",
                column: "PlateStockId1",
                principalSchema: "VRMS",
                principalTable: "PlateStocks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehiclePlates_PlateStocks_PlateStockId1",
                schema: "VRMS",
                table: "VehiclePlates");

            migrationBuilder.DropTable(
                name: "VehicleDocuments",
                schema: "VRMS");

            migrationBuilder.DropIndex(
                name: "IX_VehiclePlates_PlateStockId1",
                schema: "VRMS",
                table: "VehiclePlates");

            migrationBuilder.DropColumn(
                name: "PlateStockId1",
                schema: "VRMS",
                table: "VehiclePlates");

            migrationBuilder.RenameColumn(
                name: "SecondaryPhoneNumber",
                schema: "VRMS",
                table: "OwnerLists",
                newName: "SecocdaryPhoneNumber");

            migrationBuilder.AlterColumn<string>(
                name: "AISYear",
                schema: "VRMS",
                table: "AisLists",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 5);
        }
    }
}
