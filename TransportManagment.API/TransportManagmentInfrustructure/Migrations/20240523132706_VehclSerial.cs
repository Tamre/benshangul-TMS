using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportManagmentInfrustructure.Migrations
{
    /// <inheritdoc />
    public partial class VehclSerial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VehicleSerialSettings_VehicleSerialType",
                schema: "VRMS",
                table: "VehicleSerialSettings");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "VRMS",
                table: "OwnerLists",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleSerialSettings_VehicleSerialType_ZoneId",
                schema: "VRMS",
                table: "VehicleSerialSettings",
                columns: new[] { "VehicleSerialType", "ZoneId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VehicleSerialSettings_VehicleSerialType_ZoneId",
                schema: "VRMS",
                table: "VehicleSerialSettings");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "VRMS",
                table: "OwnerLists",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleSerialSettings_VehicleSerialType",
                schema: "VRMS",
                table: "VehicleSerialSettings",
                column: "VehicleSerialType",
                unique: true);
        }
    }
}
